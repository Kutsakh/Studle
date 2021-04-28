using System.Collections.Generic;
using Studle.BLL.Dto;

namespace Studle.BLL.Interfaces
{
    public interface ISubjectService
    {
        void CreateSubject(SubjectDto subjectDto);

        void UpdateSubject(SubjectDto subjectDto);

        void DeleteSubject(SubjectDto subjectDto);

        SubjectDto GetSubject(int? id);

        IEnumerable<SubjectDto> GetSubjects();

        IEnumerable<SubjectDto> GetSubjectsByUserId(int? userId);
    }
}
