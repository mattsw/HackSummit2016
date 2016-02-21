using System.Collections.Generic;
using System.Linq;
using Hackathon.Core.Models.Board.Enums;

namespace Hackathon.Service.BoardItems
{
    using Core.Models.Board;
    using Repository.DataAccess;

    public interface IBoardItemService
    {
        void SaveBoardItems(BoardState itemsToSave);
        void SaveBoardItem(BoardItem itemToSave);
        BoardState GetBoardItems();
    }

    public class BoardItemService : IBoardItemService
    {

        private BoardItemRepository BoardItemRepository { get; }

        public BoardItemService()
        {
            BoardItemRepository = new BoardItemRepository();
        }

        public BoardState GetBoardItems()
        {
            var items = BoardItemRepository.SelectBoardItems();
            return new BoardState
            {
                Open = items.Where(item => item.Status == BoardStatus.Open).ToList(),
                Progress = items.Where(item => item.Status == BoardStatus.Progress).ToList(),
                Blocked = items.Where(item => item.Status == BoardStatus.Blocked).ToList(),
                Done = items.Where(item => item.Status == BoardStatus.Done).ToList()
            };
        }

        public void SaveBoardItem(BoardItem itemToSave)
        {
            BoardItemRepository.CreateBoardItems(new[] { itemToSave});
        }

        public void SaveBoardItems(BoardState itemsToSave)
        {
            BoardItemRepository.UpdateBoardItems(itemsToSave.Done.Union(itemsToSave.Open).Union(itemsToSave.Blocked).Union(itemsToSave.Progress));
        }

    }
}
