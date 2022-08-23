# DateTimeZone
Best practice to deal with datetime in case user access in several time zone

As developers, we might be faced about timezone issue. For instance user A insert data into database at 7.00 pm (SE Time Standard / UTC+7 Bangkok, Hanoi, Jakarta), then we might see on database table "2022-08-23 19:00:00". In different location  (suppose Singapore) user B try to retrieve the data, then will get "2022-08-23 19:00:00" from database.
So user B will get wrong date time information, He / She should get "2022-08-23 20:00:00" as SGT time

##Here are 2 ways to deal with these issues
### A. Storing Epoch Time / Timestamps
We will get milliseconds value from 1 Januari 1970 00:00:00 - Datetime.UtcNow. After that we will insert the milliseconds value into long data type

```
long utcStoreMilliseconds = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
timestamps = utcStoreMilliseconds;
```
Notes : Getting miiliseconds difference from 1970-01-01 00:00:00 - Datetime.UtcNow, and storing data to database

```
long utcLoadMilliseconds = timestamps;
DateTimeOffset dateTimeOffsetUtc = DateTimeOffset.FromUnixTimeMilliseconds(utcLoadMilliseconds);
```
Notes : Retrieve data from database and convert it to datetime format

```
DateTime dateInLocalTimezone = dateTimeOffsetUtc.LocalDateTime;

Console.WriteLine($"Date Time in Local / Current Timezone - {dateInLocalTimezone}");
```
Notes : Finally we get local datetime

### B. Storing Actual Datetime and its Timezone
For example Datetime "2022-08-23 19:00:00" Timezone "SE Standard Time" (South East Standard Time)
