namespace Hackathon.Repository.DataAccess
{
    using Core.Models.Board;
    using Core.Models.Board.Enums;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.IO;

    public interface IBoardItemRepository
    {
        void CreateBoardItems(BoardItem[] itemsToCreate);
        void UpdateBoardItems(BoardItem[] itemsToUpdate);
        BoardItem[] SelectBoardItems();
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
                        "(TaskID int identity(1,1) primary key" +
                        ", Description varchar(MAX) not null" +
                        ", Summary varchar(MAX)" +
                        ", Status varchar(MAX)," +
                        ", Timebox decimal) " +
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
                    var command = new SQLiteCommand("insert into BoardItem (Description, Summary, Status, Timebox) " +
                        $"values ({item.Description}, {item.Summary}, {item.Status}, {item.Timebox} )"
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
                        $"set Description = {item.Description}, Summary = {item.Summary}, Status = {item.Status}, Timebox = {item.Timebox} " +
                        $"where TaskID = {item.TaskID}"
                        , connection);
                    command.ExecuteNonQuery();
                }
            }
        }

        public BoardItem[] SelectBoardItems()
        {
            using (var connection = new SQLiteConnection("Data Source=BoardItems.sqlite;Version=3;"))
            {
                var command = new SQLiteCommand("select * from BoardItem"
                    , connection);
                var reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    var boardItems = new List<BoardItem>();
                    while(reader.Read())
                    {
                        boardItems.Add(new BoardItem() { TaskID = int.Parse(reader["TaskID"].ToString())
                            , Description = reader["Description"].ToString()
                            , Summary = reader["Summary"].ToString()
                            , Status = (BoardStatus)System.Enum.Parse(typeof(BoardStatus), reader["Status"].ToString())
                            , Timebox = decimal.Parse(reader["Timebox"].ToString()) });
                    }

                    return boardItems.ToArray();
                }
            }
            return new BoardItem[0];
        }
    }
}
