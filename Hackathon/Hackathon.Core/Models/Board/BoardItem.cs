namespace Hackathon.Core.Models.Board
{
    public class BoardItem
    {
        public int TaskID { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public Enums.BoardStatus Status { get; set; }
        public decimal Timebox { get; set; }
    }
}
