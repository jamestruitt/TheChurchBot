using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using TheChurchBot.Forms;
using TheChurchBot.Models;

namespace TheChurchBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {

        private const string HelloOption = "Say Hello";
        private const string VerseOption = "Random Verse";
        private const string PrayerRequestOption = "Prayer Request";
        private const string SermonRequestOption =  "Sermon Archive";
        private const string EventSignUpOption = "Event Sign Up";

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
                new List<string>() { VerseOption, PrayerRequestOption, SermonRequestOption, EventSignUpOption ,HelloOption },
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
                    case EventSignUpOption:
                        var eventSignUpForm = new FormDialog<EventSignUpModel>(
                            new EventSignUpModel(),
                            EventSignUpForm.BuildForm,
                            FormOptions.PromptInStart,
                            null);

                        context.Call(eventSignUpForm, this.EventSignUpFormCompleteAsync);
                        break;
                    case SermonRequestOption:
                        var sermonRequestForm = new FormDialog<SermonRequestModel>(
                            new SermonRequestModel(),
                            SermonRequestForm.BuildForm,
                            FormOptions.PromptInStart,
                            null);

                        context.Call(sermonRequestForm, this.SermonRequestFormCompleteAsync);
                        break;
                    case PrayerRequestOption:
                        var prayerRequestForm = new FormDialog<PrayerRequestModel>(
                            new PrayerRequestModel(),
                            PrayerRequestForm.BuildForm,
                            FormOptions.PromptInStart,
                            null);

                        context.Call(prayerRequestForm, this.PrayerRequestFormFormCompleteAsync);
                        break;
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

        private async Task EventSignUpFormCompleteAsync(IDialogContext context, IAwaitable<EventSignUpModel> result)
        {
            var eventRequestInfo = await result;

            await context.PostAsync(
                $"Thank you {eventRequestInfo.FirstName} for submitting a Event Request. See you at the event");

            PromptUser(context);
        }

        private async Task SermonRequestFormCompleteAsync(IDialogContext context, IAwaitable<SermonRequestModel> result)
        {
            var sermonRequestInfo = await result;

            await context.PostAsync(
                $"Thank you {sermonRequestInfo.EmailAddress} for submitting a Sermon Request. Someone will be in contact for followup");

            PromptUser(context);
        }

        private async Task PrayerRequestFormFormCompleteAsync(IDialogContext context, IAwaitable<PrayerRequestModel> result)
        {
            var prayerRequestInfo = await result;

            await context.PostAsync(
                $"Thank you {prayerRequestInfo.FirstName} for submitting a Prayer Request. Someone will be in contact for followup");

            PromptUser(context);
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