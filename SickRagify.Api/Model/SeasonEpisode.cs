using System;

namespace SickRagify.Model
{
    public class SeasonEpisode
    {
        public string Name { get; set; }

        public DateTime? AirDate { get; set; }

        public string Quality { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}