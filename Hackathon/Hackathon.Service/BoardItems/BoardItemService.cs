namespace Hackathon.Service.BoardItems
{
    using System;
    using Core.Models.Board;

    public interface IBoardItemService
    {
        void SaveBoardItems(BoardItem[] itemsToSave);
    }

    public class BoardItemService : IBoardItemService
    {

        public BoardItemService()
        {

        }

        public void SaveBoardItems(BoardItem[] itemsToSave)
        {
            throw new NotImplementedException();
        }

    }
}
