namespace Hackathon.Service.BoardItems
{
    using System;
    using Core.Models.Board;
    using Repository.DataAccess;
    public interface IBoardItemService
    {
        void SaveBoardItems(BoardItem[] itemsToSave);
    }

    public class BoardItemService : IBoardItemService
    {

        private BoardItemRepository BoardItemRepository { get; }

        public BoardItemService()
        {
            BoardItemRepository = new BoardItemRepository();
        }

        public void SaveBoardItems(BoardItem[] itemsToSave)
        {
            BoardItemRepository.SaveBoardItems(itemsToSave);
        }

    }
}
