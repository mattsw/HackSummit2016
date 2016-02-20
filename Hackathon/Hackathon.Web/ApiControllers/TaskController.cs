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
            return Ok(new BoardState());
        }

        public IHttpActionResult Post(BoardItem[] boardItems)
        {
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}