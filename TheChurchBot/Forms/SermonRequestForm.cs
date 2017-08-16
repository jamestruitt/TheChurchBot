using Microsoft.Bot.Builder.FormFlow;
using TheChurchBot.Models;

namespace TheChurchBot.Dialogs
{
    public class SermonRequestForm
    {
        public static IForm<SermonRequestModel> BuildForm()
        {
            return new FormBuilder<SermonRequestModel>()
                .Field(nameof(SermonRequestModel.EmailAddress))
                .Build();
        }
    }
}