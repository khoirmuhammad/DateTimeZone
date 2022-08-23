# DateTimeZone
Best practice to deal with datetime in case user access in several time zone

As developers, we might be faced about timezone issue. For instance user A insert data into database at 7.00 pm (SE Time Standard / UTC+7 Bangkok, Hanoi, Jakarta), then we might see on database table "2022-08-23 19:00:00". In different location  (suppose Singapore) user B try to retrieve the data, then will get "2022-08-23 19:00:00" from database.
So user B will get wrong date time information, He / She should get "2022-08-23 20:00:00" as SGT time

##Here are 2 ways to deal with these issues
### A. Storing Epoch Time / Timestamps
We will get milliseconds value from 1 Januari 1970 00:00:00 - Datetime.UtcNow. After that we will insert the milliseconds value into long data type. In other word the data stored in database is based on UTC time

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

Basically user able to insert data from Jakarta / Singapore / UK / USA and able to retrieve from many countries as well

```
datetime = DateTime.Now;
zoneId = TimeZoneInfo.Local.Id;
```
Notes : Storing Datetime and Timezone ID to database

```
string origZoneId = zoneId;
DateTime origDatetime = (DateTime)datetime;

DateTime utcDatetime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.SpecifyKind(origDatetime, DateTimeKind.Unspecified), origZoneId, "UTC");
```
Notes : Retrieving data from database and convert the datetime in particular timezone into UTC timezone

```
DateTime dateInLocalZone = TimeZoneInfo.ConvertTimeFromUtc(utcDatetime, TimeZoneInfo.Local);

Console.WriteLine($"Date Time in Local / Current Timezone - {dateInLocalZone}");
```
Notes : Then converting datetime UTC into user timezone
