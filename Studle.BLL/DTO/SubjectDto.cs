using Studle.DAL.Entities;

namespace Studle.BLL.Dto
{
    public class SubjectDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DurationSemesters { get; set; }

        public SubjectType Type { get; set; }
    }
}
