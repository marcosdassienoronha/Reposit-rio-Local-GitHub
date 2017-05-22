
using ChatBot.Serialization;
using ChatBot.Services;
using formflow.FormFlow;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;
using System;
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
            string sim = string.Empty;
            string nao = string.Empty;
            var connector = new ConnectorClient(new Uri(activity.ServiceUrl));

            //Método Start
            //var resposta = await Start(activity);
            //var msg = activity.CreateReply(resposta, "pt-BR");
            //await connector.Conversations.SendToConversationAsync(msg);

            //Método Cases
          


             if (activity != null && activity.GetActivityType() == ActivityTypes.Message)
             {
                await Conversation.SendAsync(activity, () => {
                     return Chain.From(() => FormDialog.FromForm(Enquiry.BuildForm));         //O metodo Chain.From faz com que construa um dialogo que vai fazer copia de outro dialogo quando iniciado, por isso precisa de uma dialogo como parametro
                });

                if (activity.Text.Equals("sim"))
                {
                    sim = "sim";
                }
                if (activity.Text.Equals("nao"))
                {
                    nao = "nao";
                }
                 
           


                if (!string.IsNullOrEmpty(sim))
                {
                    var reply = activity.CreateReply($"Obrigado! Foi um prazer negociar com você. ");
                    await connector.Conversations.ReplyToActivityAsync(reply);
                }
                else if (!string.IsNullOrEmpty(nao))
                {
                    var reply = activity.CreateReply($"desconsidere entao");
                    await connector.Conversations.ReplyToActivityAsync(reply);
                }
                else
                {
                    var reply = activity.CreateReply($"n entendi");
                    await connector.Conversations.ReplyToActivityAsync(reply);
                }
            }


            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

       

       



    }
}