using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;

namespace TheChurchBot.Dialogs
{

    [Serializable]
    public class HelloDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            //Greet the user
            await context.PostAsync("Hey there, how are you?");

            //call context.Done
            context.Done<object>(null);
        }

    }
}
