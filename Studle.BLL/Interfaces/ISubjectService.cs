using System.Collections.Generic;
using Studle.BLL.DTO;


namespace Studle.BLL.Interfaces
{
    public interface ISubjectService
    {
        void CreateSubject(SubjectDTO subjectDTO);
        void UpdateSubject(SubjectDTO subjectDTO);
        void DeleteSubject(SubjectDTO subjectDTO);
        SubjectDTO GetSubject(int? id);
        IEnumerable<SubjectDTO> GetSubjects();
        IEnumerable<SubjectDTO> GetSubjectsByUserId(int? userId);
    }
}
