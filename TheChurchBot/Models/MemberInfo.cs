using System;
using Microsoft.Bot.Builder.FormFlow;

namespace TheChurchBot.Models
{
    [Serializable]
    public class MemberInfo
    {
        [Prompt(new string[] { " {&} " })]
        public string FirstName { get; set; }

        [Prompt(new string[] { " {&} " })]
        public string LastName { get; set; }

        [Prompt(new string[] { " {&} " })]
        public string EmailAddress { get; set; }

        [Prompt(new string[] { " {&} " })]
        public string PhoneNumber { get; set; }
    }
}
