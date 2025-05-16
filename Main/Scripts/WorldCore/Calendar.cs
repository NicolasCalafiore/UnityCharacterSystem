using UnityEngine;

public static class Calendar
{
    public static int seconds_per_minute = 60;
    public static int minutes_per_hour = 60;
    public static int hours_per_day = 24;
    public static int days_per_month = 30;
    public static int months_per_year = 12;

    public static int seconds = 0;
    public static int minutes = 0;
    public static int hours = 0;
    public static int day = 0;
    public static int month = 0;
    public static int year = 0;

    public static void AddSecond()
    {
        seconds++;
        if (seconds >= seconds_per_minute)
        {
            seconds = 0;
            minutes++;
        }
        if (minutes >= minutes_per_hour)
        {
            minutes = 0;
            hours++;
        }
        if (hours >= hours_per_day)
        {
            hours = 0;
            day++;
        }
        if (day >= days_per_month)
        {
            day = 0;
            month++;
        }
        if (month >= months_per_year)
        {
            month = 0;
            year++;
        }
    }

    public static string GetTimeString()
    {
        return string.Format("{0:D2}:{1:D2}:{2:D2} {3}/{4}/{5}", hours, minutes, seconds, day, month, year);
    }

}
