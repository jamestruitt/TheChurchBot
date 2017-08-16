using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.FormFlow;

namespace TheChurchBot.Models
{
    [Serializable]
    public class PrayerRequestModel : MemberInfo
    {
        [Prompt(new string[] { "Please enter your prayer request " })]
        public string Request { get; set; }
    }
}
