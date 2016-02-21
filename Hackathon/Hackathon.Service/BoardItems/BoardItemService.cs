namespace Hackathon.Service.BoardItems
{
    using System;
    using Core.Models.Board;
    using Repository.DataAccess;
    public interface IBoardItemService
    {
        void SaveBoardItems(BoardItem[] itemsToSave);
        void SaveBoardItem(BoardItem itemToSave);
    }

    public class BoardItemService : IBoardItemService
    {

        private BoardItemRepository BoardItemRepository { get; }

        public BoardItemService()
        {
            BoardItemRepository = new BoardItemRepository();
        }

        public void SaveBoardItem(BoardItem itemToSave)
        {
            BoardItemRepository.CreateBoardItems(new[] { itemToSave});
        }

        public void SaveBoardItems(BoardItem[] itemsToSave)
        {
            BoardItemRepository.CreateBoardItems(itemsToSave);
        }

    }
}
