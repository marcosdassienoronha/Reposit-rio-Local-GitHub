using Microsoft.Bot.Builder.FormFlow;
using System;

namespace formflow.FormFlow
{
    [Serializable]
    public class Enquiry
    {
        [Prompt("Qual é o seu nome?")]
        public string Name { get; set; }
        [Prompt("Olá, sou um representante do Banco 1500, notamos que há algumas contas suas pendentes e gostariamos de negocia-las. A conta número 23323-90 é " +
            "pertencente a você? {||}")]
        public bool Fala1 { get; set; }
        [Prompt("Voce está de acordo com o combinado na negociação? {||}")]
        public bool Fala2 { get; set; }


        public Service ServiceRequired { get; set; }

        public enum Service
        {
            Consultancy, Support, ProjectDelivery, Unknown
        }

        public static IForm<Enquiry> BuildEnquiryForm()                                 //Cria um formulario adicionando alguns campos, retorna um IForm
        {
            return new FormBuilder<Enquiry>()                                           //aqui se define a ordem da apresentação das mensagens (Bot-to-User)
                .Field("Fala1")
                .Field("Name")
                .Build();
        }
    }
}