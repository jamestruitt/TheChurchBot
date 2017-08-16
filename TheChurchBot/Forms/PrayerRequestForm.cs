using Microsoft.Bot.Builder.FormFlow;
using TheChurchBot.Models;

namespace TheChurchBot.Forms
{
    public class PrayerRequestForm
    {

        public static IForm<PrayerRequestModel> BuildForm()
        {
            return new FormBuilder<PrayerRequestModel>()
                .Field(nameof(PrayerRequestModel.FirstName))
                .Field(nameof(PrayerRequestModel.LastName))
                .Field(nameof(PrayerRequestModel.EmailAddress))
                .Field(nameof(PrayerRequestModel.PhoneNumber))
                .Field(nameof(PrayerRequestModel.Request))
                .Build();
        }
    }
}