namespace Hackathon.Service.BoardItem
{
    using System;
    using Core.Models;

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
