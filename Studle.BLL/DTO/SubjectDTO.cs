using Studle.DAL.Entities;


namespace Studle.BLL.DTO
{
    public class SubjectDTO
    {
        public string Name { get; set; }
        public int Semester { get; set; }
        public string Faculty { get; set; }
        public float Hours { get; set; }
        public int Teacher_id { get; set; }
        public SubjectType Type { get; set; }
    }
}
