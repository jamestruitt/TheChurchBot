using Microsoft.Bot.Builder.FormFlow;
using TheChurchBot.Models;

namespace TheChurchBot.Forms
{
    public class EventSignUpForm
    {
        public static IForm<EventSignUpModel> BuildForm()
        {
            return new FormBuilder<EventSignUpModel>()
                .Field(nameof(EventSignUpModel.FirstName))
                .Field(nameof(EventSignUpModel.LastName))
                .Field(nameof(EventSignUpModel.EmailAddress))
                .Field(nameof(EventSignUpModel.PhoneNumber))
                .Field(nameof(EventSignUpModel.EventName))
                .Build();
        }
    }
}