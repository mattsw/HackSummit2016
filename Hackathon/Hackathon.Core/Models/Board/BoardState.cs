namespace Hackathon.Core.Models.Board
{
    using System.Collections.Generic;

    public class BoardState
    {

        public BoardState()
        {
            Open = new List<BoardItem>();
            Progress = new List<BoardItem>();
            Blocked = new List<BoardItem>();
            Done = new List<BoardItem>();
        }

        public List<BoardItem> Open { get; set; }
        public List<BoardItem> Progress { get; set; }
        public List<BoardItem> Blocked { get; set; }
        public List<BoardItem> Done { get; set; }
    }
}
