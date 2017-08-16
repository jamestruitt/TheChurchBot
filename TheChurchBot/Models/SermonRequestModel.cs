using System;
using Microsoft.Bot.Builder.FormFlow;

namespace TheChurchBot.Models
{
    [Serializable]
    public class SermonRequestModel
    {
        [Prompt(new string[] { "Please enter {&} " })]
        public string EmailAddress { get; set; }
    }
}