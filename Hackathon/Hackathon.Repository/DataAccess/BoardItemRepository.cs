namespace Hackathon.Repository.DataAccess
{
    using Core.Models.Board;
    using System.Data.SQLite;

    public interface IBoardItemRepository
    {
        void SaveBoardItems(BoardItem[] itemsToSave);
    }

    public class BoardItemRepository
    {

        public void SaveBoardItems(BoardItem[] itemsToSave)
        {
            using (var connection = new SQLiteConnection())
            {

            }
        }
    }
}
