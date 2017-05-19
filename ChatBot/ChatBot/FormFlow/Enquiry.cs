using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.FormFlow;

namespace ChatBot.FormFlow
{
    [Serializable]

    public class Enquiry
    {
       
        [Prompt ("Qual seu nome?")]
        public string name { get; set; }

        [Prompt ("Qual a sua idade?")]
        public string age { get; set; }

        [Prompt("Voce aceita a negociação?")]
        public string negociacao { get; set; }

        public enum Service
        {
            Consultancy, Support, Other
        }

        public static IForm<Enquiry> BuildEnquiryForm()
        {
            return new FormBuilder<Enquiry>().AddRemainingFields().Build();
        }



    }


}