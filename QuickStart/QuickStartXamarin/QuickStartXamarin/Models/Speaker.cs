using System;
using Newtonsoft.Json;

namespace QuickStartXamarin.Models
{
    public class Speaker
    {
        
        public string SpeakerName { get; set; }

        public string SpeakerDescription { get; set; }

        public string Avatar { get; set; }

        public int SpeakerId { get; set; }
    }
}
