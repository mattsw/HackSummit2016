namespace Hackathon.Tests
{
    using Core.Models.Board;
    using NUnit.Framework;
    using Repository.DataAccess;

    [TestFixture]
    public class BoardItemRepositoryTests
    {
        [TestFixture]
        public class CreateBoardItemsTests
        {
            [TestCase]
            public void Create_SingleOpenItem()
            {
                var sut = new BoardItemRepository();
                var boardItem = new BoardItem() {  };
            }
        }
    }
}
