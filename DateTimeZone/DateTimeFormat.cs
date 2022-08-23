using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeZone
{
    public class DateTimeFormat
    {
        private DateTime? datetime = null;
        private string zoneId = string.Empty;

        public void GetSetDateTime()
        {
            #region Storing date and zone
            datetime = DateTime.Now;
            zoneId = TimeZoneInfo.Local.Id;
            #endregion

            #region Loading date
            string origZoneId = zoneId;
            DateTime origDatetime = (DateTime)datetime;

            DateTime utcDatetime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId
                (DateTime.SpecifyKind(origDatetime, DateTimeKind.Unspecified), origZoneId, "UTC");

            DateTime dateInLocalZone = TimeZoneInfo.ConvertTimeFromUtc(utcDatetime, TimeZoneInfo.Local);

            Console.WriteLine($"Date Time in Local / Current Timezone - {dateInLocalZone}");
            #endregion
        }

    }
}
