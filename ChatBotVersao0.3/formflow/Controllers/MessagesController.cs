using formflow.FormFlow;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace formflow
{
    //[BotAuthentication]
    public class MessagesController : ApiController
    {
        [ResponseType(typeof(void))]



        public virtual async Task<HttpResponseMessage> Post([FromBody] Activity activity)          //utilizar async habilita a utilizacao de await dentro do metodo | Task é
                                                                                                   //uma unidade de trabalho que devera ser executada, ao passar uma task em
                                                                                                   //um await, voce passa a executar esta tarefa em uma thread separada. | await é o gerenciador de thread que recebe como parametro uma task
        {
           
            if (activity != null && activity.GetActivityType() == ActivityTypes.Message)
            {
                await Conversation.SendAsync(activity, () => {
                    return Chain.From(() => FormDialog.FromForm(Enquiry.BuildEnquiryForm));         //O metodo Chain.From faz com que construa um dialogo que vai fazer copia de outro dialogo quando iniciado, por isso precisa de uma dialogo como parametro
                });                                                                                 //Cria uma mensagem de entrada na conversa 
                                                                                                    //Parametros: A mensagem a ser enviada, método que fabrica o dialogo
            }


            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        



    }
}