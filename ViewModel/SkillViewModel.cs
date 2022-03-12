using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EMS.Entities;

namespace EMS.ViewModel
{
    public class SkillViewModel: ViewModelBase
    {
        private Skill currentskill;
        public Skill CurrentSkill
        {
            get { return currentskill; }
            set { currentskill = value; OnPropertyChanged("CurrentSkill"); }
        }
        private Skill alterskill;
        public Skill AlterSkill
        {
            get { return alterskill; }
            set { alterskill = value; OnPropertyChanged("AlterSkill"); }
        }

        private ObservableCollection<Skill> skills;
        public ObservableCollection<Skill> Skills
        {
            get
            {
                return skills;
            }
            set
            {
                skills = value;
                OnPropertyChanged("Skills");
            }

        }

        public RelayCommand SkillOperations { get; set; }

        void Operations(object parameter)
        {
            if (parameter.ToString() == "SaveEditSkill")
            {

                SaveEditSkill();
                Skills = new ObservableCollection<Skill>();
                GetSkill();
                CurrentSkill = new Skill();



            }
            else if (parameter.ToString() == "EditSkill")
            {
                CurrentSkill.SkillID = AlterSkill.SkillID;
                CurrentSkill.SkillName = AlterSkill.SkillName;

                OnPropertyChanged("CurrentSkill");
            }
            else if (parameter.ToString() == "DeleteSkill")
            {
                MessageBoxResult d;
                d = MessageBox.Show("Do you want to delete this Skill?", "Warning", MessageBoxButton.YesNo);
                if (d == MessageBoxResult.Yes)
                {
                    DeleteSkill(AlterSkill);
                    Skills = new ObservableCollection<Skill>();
                    GetSkill();
                }
                CurrentSkill = new Skill();

            }

        }

        public void GetSkill()
        {
            //int rowcount = 0;
            string strConn = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(strConn);
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                // Settings.  
                sqlCommand.CommandText = "GetSkill";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandTimeout = 108; //// Setting timeeout for longer queries to 12 hours.  

                // Open.  
                sqlConnection.Open();

                // Result.  
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Skills.Add(new Skill() { SkillID = Convert.ToInt32(reader[0]), SkillName = Convert.ToString(reader[1]) });
                    }
                }

                // Close.  
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                // Close.  
                sqlConnection.Close();

                throw ex;
            }
        }


        public void SaveEditSkill()
        {
            try
            {

                int rowCount = 0;
                string strConn = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(strConn);
                SqlCommand sqlCommand = new SqlCommand();

                try
                {

                    // Settings.  
                    sqlCommand.CommandText = "SaveEditSkill";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = 180;
                    if (CurrentSkill.SkillName == "")
                    {
                        string message = "The required field cannot be empty!";
                        MessageBox.Show(message, "Warning", MessageBoxButton.OK);

                    }
                    else
                    {
                        SqlParameter skillName = new SqlParameter("@SkillName", SqlDbType.VarChar, 50)
                        {

                            Value = CurrentSkill.SkillName

                        };
                        SqlParameter skillId = new SqlParameter("@SkillID", SqlDbType.Int)
                        {
                            Value = CurrentSkill.SkillID
                        };
                        sqlCommand.Parameters.Add(skillName);
                        sqlCommand.Parameters.Add(skillId);

                   



                    // Open.  
                    sqlConnection.Open();

                    // Result.

                    rowCount = sqlCommand.ExecuteNonQuery();

                    // Close.  
                    sqlConnection.Close();
                }
                }
                catch (Exception ex)
                {
                    // Close.  
                    sqlConnection.Close();

                    throw ex;
                }

            }
            catch
            {
                string message = "The required field cannot be empty!";
                MessageBox.Show(message, "Warning", MessageBoxButton.OK);
            }
        }



        public void DeleteSkill(Skill obj)
        {
            try
            {

                int rowCount = 0;
                string strConn = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(strConn);
                SqlCommand sqlCommand = new SqlCommand();

                try
                {

                    // Settings.  
                    sqlCommand.CommandText = "RemoveSkill";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = 180;
                    SqlParameter skillName = new SqlParameter("@SkillName", SqlDbType.VarChar, 50)

                    {
                        Value = obj.SkillName
                    };

                    sqlCommand.Parameters.Add(skillName);



                    // Open.  
                    sqlConnection.Open();

                    // Result.

                    rowCount = sqlCommand.ExecuteNonQuery();

                    // Close.  
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    // Close.  
                    sqlConnection.Close();

                    throw ex;
                }

            }
            catch
            {
                string message = "The required field cannot be empty!";
                MessageBox.Show(message, "Warning", MessageBoxButton.OK);
            }
        }
        public SkillViewModel()
        {
            CurrentSkill = new Skill();
            AlterSkill = new Skill();
            Skills = new ObservableCollection<Skill>();
            SkillOperations = new RelayCommand(Operations);
            GetSkill();
        }
    }
}
