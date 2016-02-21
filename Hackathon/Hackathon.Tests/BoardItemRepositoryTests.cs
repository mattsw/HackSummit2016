using NUnit.Framework.Internal;

namespace Hackathon.Tests
{
    using Core.Models.Board;
    using Core.Models.Board.Enums;
    using NUnit.Framework;
    using Repository.DataAccess;
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.IO;

    [TestFixture]
    public class BoardItemRepositoryTests
    {
        [Test]
        public void Create_Database()
        {
            var sut = new BoardItemRepository();

            Assert.IsTrue(File.Exists("BoardItems.sqlite"));
        }

        [Test]
        public void Create_Table()
        {
            var sut = new BoardItemRepository();

            Assert.IsTrue(File.Exists("BoardItems.sqlite"));
            using (var connection = new SQLiteConnection("Data Source=BoardItems.sqlite;Version=3;"))
            {
                var command = new SQLiteCommand("select count(*) from BoardItem"
                    , connection);

                connection.Open();
                var result = (Int32)command.ExecuteScalar();
                connection.Close();

                Assert.IsNotNull(result);
            }
        }

        [TestFixture]
        public class CreateBoardItemsTests
        {
            [TestCase("testDesc", "testSummary", BoardStatus.Open, 1.0, 1)]
            public void Create_SingleOpenItem(string description, string summary, BoardStatus status, decimal timebox, int expected)
            {
                var sut = new BoardItemRepository();
                var boardItem = new BoardItem() { Description = description, Summary = summary, Status = status, Timebox = timebox };
                sut.CreateBoardItems(new BoardItem[1] { boardItem });

                using (var connection = new SQLiteConnection("Data Source=BoardItems.sqlite;Version=3;"))
                {
                    var command = new SQLiteCommand("select count(*) from BoardItem " +
                        $"where Description = {boardItem.Description} " +
                        $"and Summary = {boardItem.Summary} " +
                        $"and Status = {boardItem.Status} " +
                        $"and Timebox = {boardItem.Timebox}"
                        , connection);

                    connection.Open();
                    var result = (Int32)command.ExecuteScalar();
                    connection.Close();

                    Assert.AreEqual(expected, result);
                }

            }
        }
    }
}
