namespace Hackathon.Web.ApiControllers
{
    using System.Web.Http;
    using System.Net;
    using Core.Models;
     
    public class TaskController : ApiController
    {
        public IHttpActionResult Get(string id)
        {
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        public IHttpActionResult Post(BoardItem[] boardItems)
        {
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}