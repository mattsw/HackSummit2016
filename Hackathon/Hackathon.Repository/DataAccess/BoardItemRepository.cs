namespace Hackathon.Repository.DataAccess
{
    using Core.Models.Board;
    using System.Data.SQLite;
    using System.IO;

    public interface IBoardItemRepository
    {
        void SaveBoardItems(BoardItem[] itemsToSave);
    }

    public class BoardItemRepository
    {

        public BoardItemRepository()
        {
            if (!File.Exists("BoardItems.sqlite"))
            {
                File.Create("BoardItems.sqlite");
                using (var connection = new SQLiteConnection("Data Source=BoardItems.sqlite;Version=3;"))
                {
                    var command = new SQLiteCommand("create table BoardItem " +
                        "(TaskID int identity(1,1) primary key, Description varchar(MAX) not null, Summary varchar(MAX)) " +
                        "CONSTRAINT pk_TaskId PRIMARY KEY (TaskID)"
                        , connection);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void SaveBoardItems(BoardItem[] itemsToSave)
        {
            using (var connection = new SQLiteConnection("Data Source=BoardItems.sqlite;Version=3;"))
            {
                foreach (var item in itemsToSave)
                {
                    var command = new SQLiteCommand("insert into BoardItem (Description, Summary) " +
                        $"values ({item.Description}, {item.Summary})"
                        , connection);
                    command.ExecuteNonQuery();
                }   
            }
        }
    }
}
