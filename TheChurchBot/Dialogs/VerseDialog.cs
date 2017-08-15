using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;
using TheChurchBot.Services;

namespace TheChurchBot.Dialogs
{
    [Serializable]
    public class VerseDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            var verse = RandomVerseService.GetRandomVerse();

            await context.PostAsync(verse);

            //call context.Done
            context.Done<object>(null);
        }
    }
}
