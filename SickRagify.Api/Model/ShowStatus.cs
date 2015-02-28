using System.Runtime.Serialization;

namespace SickRagify.Model
{
    public enum ShowStatus
    {
        Unknown = 0,

        Continuing,

        Ended,

        [EnumMember(Value = "New Series")]
        NewSeries,

        [EnumMember(Value = "Returning Series")]
        ReturningSeries,
    }
}