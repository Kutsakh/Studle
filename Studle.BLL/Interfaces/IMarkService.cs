using System.Collections.Generic;
using Studle.BLL.Dto;

namespace Studle.BLL.Interfaces
{
    public interface IMarkService
    {
        void CreateMark(MarkDto markDto);

        void UpdateMark(MarkDto markDto);

        void DeleteMark(MarkDto markDto);

        MarkDto GetMark(int? id);

        IEnumerable<MarkDto> GetMarks();

        IEnumerable<MarkDto> GetMarksByUserId(int? userId);
    }
}
