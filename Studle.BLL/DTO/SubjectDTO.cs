using Studle.DAL.Entities;


namespace Studle.BLL.DTO
{
    public class SubjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DurationSemesters { get; set; }
        public SubjectType Type { get; set; }
    }
}
