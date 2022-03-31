namespace EMS.Entities
{
    public class Designation : EntityBase
    {
        private int? designationid;
        public int? DesignationId
        {
            get
            {
                return designationid;
            }
            set
            {
                designationid = value;
                OnPropertyChanged("DesignationId");
            }
        }

        private string designationvalue;
        public string DesignationValue
        {
            get
            {
                return designationvalue;
            }
            set
            {
                designationvalue = value;
                OnPropertyChanged("DesignationValue");
            }
        }
    }
}
