namespace EMS.Entities
{
    public class Technology : EntityBase
    {
        private string technologyname;
        public string TechnologyName
        {
            get
            {
                return technologyname;
            }
            set
            {
                technologyname = value;
                OnPropertyChanged("TechnologyName");
            }
        }
        private int technologyid;
        public int TechnologyID
        {
            get
            {
                return technologyid;
            }
            set
            {
                technologyid = value;
                OnPropertyChanged("TechnologyID");
            }
        }
    }
}
