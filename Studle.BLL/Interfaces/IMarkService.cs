using System.Collections.Generic;
using Studle.BLL.DTO;


namespace Studle.BLL.Interfaces
{
    public interface IMarkService
    {
        void CreateMark(MarkDTO markDTO);
        void UpdateMark(MarkDTO markDTO);
        void DeleteMark(MarkDTO markDTO);
        MarkDTO GetMark(int? id);
        IEnumerable<MarkDTO> GetMarks();
        IEnumerable<MarkDTO> GetMarksByUserId(int? userId);
    }
}
