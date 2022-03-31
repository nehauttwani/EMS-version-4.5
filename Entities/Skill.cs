namespace EMS.Entities
{
    public class Skill : EntityBase
    {

        private int skillid;
        public int SkillID
        {
            get
            {
                return skillid;
            }
            set
            {
                skillid = value;
                OnPropertyChanged("SkillID");
            }
        }
        private string skillname;
        public string SkillName
        {
            get
            {
                return skillname;
            }
            set
            {
                skillname = value;
                OnPropertyChanged("SkillName");
            }
        }
    }
}
