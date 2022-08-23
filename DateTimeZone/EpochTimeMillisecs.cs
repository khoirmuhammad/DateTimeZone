using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeZone
{
    public class EpochTimeMillisecs
    {
        private long timestamps = 0;

        public void GetSetDateTime()
        {
            #region Storing timestamps data
            long utcStoreMilliseconds = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            timestamps = utcStoreMilliseconds;
            #endregion

            #region Loading timestamps data
            long utcLoadMilliseconds = timestamps;
            DateTimeOffset dateTimeOffsetUtc = DateTimeOffset.FromUnixTimeMilliseconds(utcLoadMilliseconds);

            DateTime dateInLocalTimezone = dateTimeOffsetUtc.LocalDateTime;

            Console.WriteLine($"Date Time in Local / Current Timezone - {dateInLocalTimezone}");
            #endregion
        }

    }
}
