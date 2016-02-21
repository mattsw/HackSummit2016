namespace Hackathon.Repository.DataAccess
{
    using Core.Models.Board;
    using System.Data.SQLite;
    using System.IO;

    public interface IBoardItemRepository
    {
        void CreateBoardItems(BoardItem[] itemsToCreate);
        void UpdateBoardItems(BoardItem[] itemsToUpdate);
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
                        "(TaskID int identity(1,1) primary key, Description varchar(MAX) not null, Summary varchar(MAX), Status varchar(MAX)) " +
                        "CONSTRAINT pk_TaskId PRIMARY KEY (TaskID)"
                        , connection);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateBoardItems(BoardItem[] itemsToCreate)
        {
            using (var connection = new SQLiteConnection("Data Source=BoardItems.sqlite;Version=3;"))
            {
                foreach (var item in itemsToCreate)
                {
                    var command = new SQLiteCommand("insert into BoardItem (Description, Summary, Status) " +
                        $"values ({item.Description}, {item.Summary}, {item.Status} )"
                        , connection);
                    command.ExecuteNonQuery();
                }   
            }
        }

        public void UpdateBoardItems(BoardItem[] itemsToUpdate)
        {
            using (var connection = new SQLiteConnection("Data Source=BoardItems.sqlite;Version=3;"))
            {
                foreach (var item in itemsToUpdate)
                {
                    var command = new SQLiteCommand("update BoardItem " +
                        $"set Description = {item.Description}, Summary = {item.Summary}, Status = {item.Status} " +
                        $"where TaskID = {item.TaskID}"
                        , connection);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
