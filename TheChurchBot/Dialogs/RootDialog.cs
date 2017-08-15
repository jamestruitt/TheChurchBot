using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;

namespace TheChurchBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {

        private const string HelloOption = "Say Hello";
        private const string VerseOption = "Random Verse";

        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            PromptUser(context);
        }

        private void PromptUser(IDialogContext context)
        {
            PromptDialog.Choice(
                context,
                this.OnOptionSelected,
                // Present options to user
                new List<string>() { VerseOption, HelloOption },
                String.Format("What would you like to do?"), "Not a valid option", 3);
        }

        private async Task OnOptionSelected(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                //capture which option then selected
                var optionSelected = await result;

                switch (optionSelected)
                {

                    //case SocialServiceOption:

                    //    var socialform = new FormDialog<SocialService>(
                    //        new SocialService(),
                    //        SocialServiceForm.BuildForm,
                    //        FormOptions.PromptInStart,
                    //        null);

                    //    context.Call(socialform, this.SocialServiceFormCompleteAsync);
                    //    break;
                    //case HealthcareServiceOption:

                    //    var healthcareForm = new FormDialog<HealthcareModel>(
                    //        new HealthcareModel(),
                    //        HealthcareServiceForm.BuildForm,
                    //        FormOptions.PromptInStart,
                    //        null);

                    //    context.Call(healthcareForm, this.HealthcareServiceFormCompleteAsync);
                    //    break;
                    //case ChildcareServiceOption:

                    //    var childcareForm = new FormDialog<ChildcareModel>(
                    //        new ChildcareModel(),
                    //        ChildcareServiceForm.BuildForm,
                    //        FormOptions.PromptInStart,
                    //        null);

                    //    context.Call(childcareForm, this.ChildcareServiceFormCompleteAsync);
                    //    break;
                    case HelloOption:
                        context.Call(new HelloDialog(), this.ResumeAfterUserHelloDialog);
                        break;
                    case VerseOption:
                        context.Call(new VerseDialog(), this.ResumeAfterVerseDialog);
                        break;
                    default:
                        break;
                }
            }
            catch (TooManyAttemptsException ex)
            {
                //If too many attempts we send error to user and start all over. 
                await context.PostAsync($"Ooops! Too many attempts :( You can start again!");

                //This sets us in a waiting state, after running the prompt again. 
                context.Wait(this.MessageReceivedAsync);
            }
        }

        private async Task ResumeAfterVerseDialog(IDialogContext context, IAwaitable<object> result)
        {
            PromptUser(context);
        }

        private async Task ResumeAfterUserHelloDialog(IDialogContext context, IAwaitable<object> result)
        {
            PromptUser(context);
        }
    }
}