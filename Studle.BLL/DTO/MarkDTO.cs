using System;


namespace Studle.BLL.DTO
{
    public class MarkDTO
    {
        public float Point { get; set; }
        public DateTimeOffset Date { get; set; }
        public int Student_id { get; set; }
        public int Subject_id { get; set; }
    }
}
