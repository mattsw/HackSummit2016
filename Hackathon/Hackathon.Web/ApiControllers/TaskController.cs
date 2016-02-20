namespace Hackathon.Web.ApiControllers
{
    using System.Web.Http;
    using System.Net;
    using Core.Models.Board;
     
    public class TaskController : ApiController
    {
        public IHttpActionResult Get(string id)
        {
            //TODO Fully implement this behavior
            return Ok(GenerateStubbedBoardItems(new BoardState()));
        }

        private BoardState GenerateStubbedBoardItems(BoardState boardState)
        {
            boardState.Done.Add(new BoardItem() { TaskID = 1, Description = "Some description for done", Summary = "Some description for Summary"});
            boardState.Blocked.Add(new BoardItem() { TaskID = 2, Description = "Some description for blocked", Summary = "Some description for Summary" });
            boardState.Open.Add(new BoardItem() { TaskID = 3, Description = "Some description for open", Summary = "Some description for Summary" });
            boardState.Progress.Add(new BoardItem() { TaskID = 4, Description = "Some description for progress", Summary = "Some description for Summary" });

            return boardState;
        }

        public IHttpActionResult Post(BoardItem[] boardItems)
        {
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}