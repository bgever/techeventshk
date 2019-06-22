using System.ComponentModel;

namespace Tehk.Sourcers.Meetup.Svc.Services
{
    public enum EventsScrollEnum
    {
        [Description("")]
        Undefined = 0,

        [Description("recent_past")]
        RecentPast,

        [Description("next_upcoming")]
        NextUpcoming,

        [Description("future_or_past")]
        FutureOrPast
    }

    public static class EventsScrollEnumExtensions
    {
        /// <summary>
        /// Turn the value into a descriptive string.
        /// </summary>
        /// <returns>String value as defined in the API.</returns>
        public static string ToDescriptionString(this EventsScrollEnum value)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])value
               .GetType()
               .GetField(value.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}