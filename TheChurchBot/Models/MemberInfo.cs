using System;
using Microsoft.Bot.Builder.FormFlow;

namespace TheChurchBot.Models
{
    [Serializable]
    public class MemberInfo
    {
        [Prompt(new string[] { "Please enter your {&} " })]
        public string FirstName { get; set; }

        [Prompt(new string[] { "Please enter your {&} " })]
        public string LastName { get; set; }

        [Prompt(new string[] { "Please enter your {&} " })]
        public string EmailAddress { get; set; }

        [Prompt(new string[] { "Please enter your {&} " })]
        public string PhoneNumber { get; set; }
    }
}
