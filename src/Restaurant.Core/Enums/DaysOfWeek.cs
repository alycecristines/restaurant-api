using System;

namespace Restaurant.Core.Enums
{
    [Flags]
    public enum DaysOfWeek
    {
        Sunday = 1,
        Monday = 2,
        Tuesday = 4,
        Wednesday = 8,
        Thursday = 16,
        Friday = 32,
        Saturday = 64,

        Daily = Sunday + Monday + Tuesday + Wednesday + Thursday + Friday + Saturday,
        Weekdays = Monday + Tuesday + Wednesday + Thursday + Friday,
        Weekends = Sunday + Saturday
    }
}
