using System.Net.Http;
using System.Web.Http;

namespace GuybrushAlexaSkill
{
   public class AlexaController : ApiController
   {
      [Route("alexa/guybrush-session")]
      [HttpPost]
      public HttpResponseMessage GuybrushSession()
      {
         var speechlet = new MySpeechlet();
         return speechlet.GetResponse(Request);
      }
   }
}