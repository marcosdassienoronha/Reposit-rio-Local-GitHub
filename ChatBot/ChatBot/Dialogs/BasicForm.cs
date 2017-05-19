using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatBot.Dialogs
{
    using System;
    using Microsoft.Bot.Builder.FormFlow;

    public enum YesOrNoOptions { Sim = 1, Não };

    // For more information about this template visit http://aka.ms/azurebots-csharp-form
    [Serializable]
    public class BasicForm
    {

        [Prompt("Essa resposta é valida?{||}")]
        public YesOrNoOptions Opt { get; set; }

        public static IForm<BasicForm> BuildForm()
        {
            var builder = new FormBuilder<BasicForm>();
            builder.Configuration.DefaultPrompt.ChoiceStyle = ChoiceStyleOptions.Auto;
            builder.Configuration.Yes = new string[] { "sim" };
            builder.Configuration.No = new string[] { "não" };
            // Builds an IForm<T> based on BasicForm
            return builder.Build();
        }

        public static IFormDialog<BasicForm> BuildFormDialog(FormOptions options = FormOptions.PromptInStart)
        {
            // Generated a new FormDialog<T> based on IForm<BasicForm>
            return FormDialog.FromForm(BuildForm, options);
        }
    }

}