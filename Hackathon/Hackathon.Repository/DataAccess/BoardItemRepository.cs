using System;

namespace Hackathon.Repository.DataAccess
{
    using Core.Models.Board;
    using Core.Models.Board.Enums;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.IO;
    using System.Web;

    public interface IBoardItemRepository
    {
        void CreateBoardItems(BoardItem[] itemsToCreate);
        void UpdateBoardItems(BoardItem[] itemsToUpdate);
        BoardItem[] SelectBoardItems();
    }

    public class BoardItemRepository
    {

        private readonly string DatabaseFile =
            HttpContext.Current.Server.MapPath("~/App_Data/BoardItems.sqlite");

        public BoardItemRepository()
        {
            if (!File.Exists(HttpContext.Current.Server.MapPath("~/App_Data/BoardItems.sqlite")))
            {
                File.Create(HttpContext.Current.Server.MapPath("~/App_Data/BoardItems.sqlite"));
                DatabaseFile = HttpContext.Current.Server.MapPath("~/App_Data/BoardItems.sqlite");
                using (var connection = new SQLiteConnection("Data Source="+ DatabaseFile + ";Version=3;"))
                {
                    var command = new SQLiteCommand("create table BoardItem " +
                        "(TaskID integer primary key AUTOINCREMENT " +
                        ", Description varchar(255) not null" +
                        ", Summary varchar(255)" +
                        ", Status varchar(255)" +
                        ", Timebox float)"
                        , connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void CreateBoardItems(IEnumerable<BoardItem> itemsToCreate)
        {
            using (var connection = new SQLiteConnection("Data Source=" + DatabaseFile + ";Version=3;"))
            {
                
                foreach (var item in itemsToCreate)
                {
                    var command = new SQLiteCommand("insert into BoardItem (Description, Summary, Status, Timebox) " +
                        string.Format("values ('{0}', '{1}', '{2}', {3} )", item.Description, item.Summary, (int)item.Status, item.Timebox)
                        , connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                
            }
        }

        public void UpdateBoardItems(IEnumerable<BoardItem> itemsToUpdate)
        {
            using (var connection = new SQLiteConnection("Data Source=" + DatabaseFile + ";Version=3;"))
            {
                foreach (var item in itemsToUpdate)
                {
                    var command = new SQLiteCommand("update BoardItem " +
                        string.Format("set Description = '{0}', Summary = '{1}', Status = '{2}', Timebox = {3} ", item.Description, item.Summary, (int)item.Status, item.Timebox) +
                        string.Format("where TaskID = {0}", item.TaskID)
                        , connection);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public BoardItem[] SelectBoardItems()
        {
            using (var connection = new SQLiteConnection("Data Source=" + DatabaseFile + ";Version=3;"))
            {
                var command = new SQLiteCommand("select * from BoardItem"
                    , connection);
                connection.Open();
                var reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    var boardItems = new List<BoardItem>();
                    var i = 0;
                    while(reader.Read())
                    {
                        boardItems.Add(new BoardItem()
                        {
                            TaskID = int.Parse(reader["TaskID"].ToString())
                            , Description = reader["Description"].ToString()
                            , Summary = reader["Summary"].ToString()
                            , Status = (BoardStatus)Enum.Parse(typeof(BoardStatus), reader["Status"].ToString())
                            , Timebox =  decimal.Parse(reader["Timebox"].ToString())
                        });
                    }
                    connection.Close();
                    return boardItems.ToArray();
                }
                connection.Close();
            }
            return new BoardItem[0];
        }
        
    }
}
