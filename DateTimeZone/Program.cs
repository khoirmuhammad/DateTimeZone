// See https://aka.ms/new-console-template for more information
using DateTimeZone;

EpochTimeMillisecs epochTime = new EpochTimeMillisecs();
DateTimeFormat dateTimeFormat = new DateTimeFormat();

epochTime.GetSetDateTime();
Console.WriteLine("--------------------------------------------------");
dateTimeFormat.GetSetDateTime();
