using System;
using System.Collections.Generic;
using Microsoft.Bot.Builder.FormFlow;

namespace TheChurchBot.Models
{
    
    [Serializable]
    public class EventSignUpModel : MemberInfo
    {
        public enum AvailableEvents
        {
            MOB = 1,
            DIVAS
        };

        [Prompt("Please select the {&} {||}",ChoiceFormat = "{1}")]
        public AvailableEvents EventName { get; set; }
    }
}