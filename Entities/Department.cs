namespace EMS.Entities
{
    public class Department : EntityBase
    {
        private int? departmentid;
        public int? DepartmentId
        {
            get
            {
                return departmentid;
            }
            set
            {
                departmentid = value;
                OnPropertyChanged("DepartmentId");
            }
        }

        private string departmentvalue;
        public string DepartmentValue
        {
            get
            {
                return departmentvalue;
            }
            set
            {
                departmentvalue = value;
                OnPropertyChanged("DepartmentValue");
            }
        }
    }
}
