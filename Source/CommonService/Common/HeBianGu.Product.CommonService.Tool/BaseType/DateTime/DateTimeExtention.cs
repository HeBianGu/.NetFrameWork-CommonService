#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 四川*******有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[HeBianGu]   时间：2018/6/12 17:28:48  QQ:908293466
 * 文件名：Class1 
 * 说明：
 * 
 * 
 * 修改者：           时间：               
 * 修改说明：
 * ========================================================================
*/
#endregion
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.CommonService.Tool
{
    public static partial class DateTimeExtention
    {

        /// <summary> 比较两个日期天数部分是否相等 </summary>
        public static bool IsEqulByDay(this DateTime ptime, DateTime comTime)
        {
            TimeSpan span = ptime - comTime;
            if (span.TotalDays == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary> 字符串转换成日期 string format = "ddMMMyyyy"; </summary>
        public static DateTime ToDateTime(this string str, string format)
        {
            DateTime ss = DateTime.ParseExact(str, format, CultureInfo.InvariantCulture);

            return ss;
        }

        /// <summary> 根据指定天数截取时间(包含时间和结束事件) </summary>
        public static List<DateTime> SplitDTsByDay(this DateTime start, DateTime end, int daySpan)
        {

            List<DateTime> times = new List<DateTime>();

            if (start > end)
            {
                return null;
            }

            TimeSpan span = end - start;

            double totalDays = span.TotalDays;

            DateTime pTime = start;

            times.Add(pTime);

            while (totalDays > 0)
            {
                pTime = pTime.AddDays(daySpan);

                //  小于最后时间
                span = end - pTime;
                if (span.Days > 0)
                {
                    times.Add(pTime);
                }

                totalDays -= daySpan;
            }
            times.Add(end);

            return times;
        }

        /// <summary> 根据指定月数截取时间(包含时间和结束事件) </summary>
        public static List<DateTime> SplitDTsByMonth(this DateTime start, DateTime end, int monthSpan)
        {

            List<DateTime> times = new List<DateTime>();

            if (start > end)
            {
                return null;
            }

            TimeSpan span = end - start;

            DateTime pTime = start;

            times.Add(pTime);

            while (true)
            {
                pTime = pTime.AddMonths(monthSpan);

                //  小于最后时间
                span = end - pTime;
                if (span.TotalDays > 0 && (end.Month != start.Month))
                {
                    times.Add(pTime);
                }
                else
                {
                    break;
                }

            }
            times.Add(end);

            return times;
        }


    }

    /// <summary> 日期查找扩展方法 </summary>
    public static partial class DateTimeExtention
    {
        /// <summary> 根据时间返回几个月前,几天前,几小时前,几分钟前,几秒前 </summary>
        public static string DateStringFromNow(this DateTime dt)
        {
            TimeSpan span = DateTime.Now - dt;
            if (span.TotalDays > 60)
            {
                return dt.ToShortDateString();
            }
            else if (span.TotalDays > 30)
            {
                return "1个月前";
            }
            else if (span.TotalDays > 14)
            {
                return "2周前";
            }
            else if (span.TotalDays > 7)
            {
                return "1周前";
            }
            else if (span.TotalDays > 1)
            {
                return string.Format("{0}天前", (int)Math.Floor(span.TotalDays));
            }
            else if (span.TotalHours > 1)
            {
                return string.Format("{0}小时前", (int)Math.Floor(span.TotalHours));
            }
            else if (span.TotalMinutes > 1)
            {
                return string.Format("{0}分钟前", (int)Math.Floor(span.TotalMinutes));
            }
            else if (span.TotalSeconds >= 1)
            {
                return string.Format("{0}秒前", (int)Math.Floor(span.TotalSeconds));
            }
            else
            {
                return "1秒前";
            }
        }

        /// <summary> 计算两个时间的差值,返回的是x天x小时x分钟x秒 </summary>
        public static string DateDiff(this DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            //TimeSpan ts=ts1.Add(ts2).Duration();
            dateDiff = ts.Days.ToString() + "天" + ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分钟" + ts.Seconds.ToString() + "秒";
            return dateDiff;
        }

        /// <summary> 时间相差值,返回时间差调用时,isTotal为true时,返回的时带小数的天数,否则返回的是整数 </summary>
        public static string DateDiff(this DateTime DateTime1, DateTime DateTime2, bool isTotal)
        {
            TimeSpan ts = DateTime2 - DateTime1;
            if (isTotal)
                //带小数的天数，比如1天12小时结果就是1.5 
                return ts.TotalDays.ToString();
            else
                //整数天数，1天12小时或者1天20小时结果都是1 
                return ts.Days.ToString();
        }

        /// <summary> 日期比较 比较天数 大于天数返回true，小于返回false </summary>
        public static bool CompareDate(string today, string writeDate, int n)
        {
            DateTime Today = Convert.ToDateTime(today);
            DateTime WriteDate = Convert.ToDateTime(writeDate);
            WriteDate = WriteDate.AddDays(n);
            if (Today >= WriteDate)
                return false;
            else
                return true;
        }

        /// <summary> 根据英文的星期几返回中文的星期几 如WhichDay("Sunday"),返回星期日 </summary>
        public static string WhichDay(string enWeek)
        {
            switch (enWeek.Trim())
            {
                case "Sunday":
                    return "星期日";
                case "Monday":
                    return "星期一";
                case "Tuesday":
                    return "星期二";
                case "Wednesday":
                    return "星期三";
                case "Thursday":
                    return "星期四";
                case "Friday":
                    return "星期五";
                case "Saturday":
                    return "星期六";
                default:
                    return enWeek;
            }
        }

        /// <summary> 根据出生年月进行生日提醒 </summary>
        public static string GetBirthdayTip(DateTime birthday)
        {
            DateTime now = DateTime.Now;
            //TimeSpan span = DateTime.Now - birthday;
            int nowMonth = now.Month;
            int birtMonth = birthday.Month;
            if (nowMonth == 12 && birtMonth == 1)
                return string.Format("下月{0}号", birthday.Day);
            if (nowMonth == 1 && birtMonth == 12)
                return string.Format("上月{0}号", birthday.Day);
            int months = now.Month - birthday.Month;
            //int days = now.Day - birthday.Day;
            if (months == 1)
                return string.Format("上月{0}号", birthday.Day);
            else if (months == -1)
                return string.Format("下月{0}号", birthday.Day);
            else if (months == 0)
            {
                if (now.Day == birthday.Day)
                    return "今天";
                return string.Format("本月{0}号", birthday.Day);
            }
            else if (months > 1)
                return string.Format("已过{0}月", months);
            else
                return string.Format("{0}月{1}日", birthday.Month, birthday.Day);
        }

    }

    /// <summary> 日期查找扩展方法 </summary>
    public static partial class DateTimeExtention
    {
        /// <summary> 周日 上周-1 下周+1 本周0 </summary>
        public static string GetSunday(this DateTime dateTime, int? weeks)
        {
            int week = weeks ?? 0;

            return dateTime.AddDays(Convert.ToDouble((0 - Convert.ToInt16(dateTime.DayOfWeek))) + 7 * week).ToShortDateString();
        }

        /// <summary> 周六 上周-1 下周+1 本周0</summary>
        public static string GetSaturday(this DateTime dateTime, int? weeks)
        {
            int week = weeks ?? 0;
            return dateTime.AddDays(Convert.ToDouble((6 - Convert.ToInt16(dateTime.DayOfWeek))) + 7 * week).ToShortDateString();
        }

        /// <summary> 月第一天 上月-1 本月0 下月1 </summary>
        public static string GetFirstDayOfMonth(this DateTime dateTime, int? months)
        {
            int month = months ?? 0;
            return DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(month).ToShortDateString();
        }

        /// <summary> 月最后一天 上月0 本月1 下月2 </summary>
        public static string GetLastDayOfMonth(this DateTime dateTime, int? months)
        {
            int month = months ?? 0;
            return DateTime.Parse(dateTime.ToString("yyyy-MM-01")).AddMonths(month).AddDays(-1).ToShortDateString();
        }

        /// <summary> 年度第一天 </summary>
        public static string GetFirstDayOfYear(this DateTime dateTime)
        {
            int year = Convert.ToInt32(dateTime.Year);
            return DateTime.Parse(dateTime.ToString("yyyy-01-01")).AddYears(year).ToShortDateString();
        }

        /// <summary> 年度最后一天 </summary>
        public static string GetLastDayOfYear(this DateTime dateTime)
        {
            int year = Convert.ToInt32(dateTime.Year);
            return DateTime.Parse(dateTime.ToString("yyyy-01-01")).AddYears(year).AddDays(-1).ToShortDateString();
        }

        /// <summary> 季度第一天 上季度-1 下季度+1 </summary>
        public static string GetFirstDayOfQuarter(this DateTime dateTime, int? quarters)
        {
            int quarter = quarters ?? 0;
            return dateTime.AddMonths(quarter * 3 - ((dateTime.Month - 1) % 3)).ToString("yyyy-MM-01");
        }

        /// <summary> 季度最后一天 上季度0 本季度1 下季度2 </summary>
        public static string GetLastDayOfQuarter(this DateTime dateTime, int? quarters)
        {
            int quarter = quarters ?? 0;
            return
                DateTime.Parse(dateTime.AddMonths(quarter * 3 - ((dateTime.Month - 1) % 3)).ToString("yyyy-MM-01")).AddDays(-1).
                    ToShortDateString();
        }

        /// <summary> 中文星期 </summary>
        public static string GetDayOfWeekCN(this DateTime dateTime)
        {
            var day = new[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            return day[Convert.ToInt16(dateTime.DayOfWeek)];
        }

        /// <summary> 获取星期数字形式,周一开始 </summary>
        public static int GetDayOfWeekNum(this DateTime dateTime)
        {
            int day = (Convert.ToInt16(dateTime.DayOfWeek) == 0) ? 7 : Convert.ToInt16(dateTime.DayOfWeek);
            return day;
        }

        /// <summary>  取指定日期是一年中的第几周 </summary> 
        public static int GetWeekofyear(this DateTime dtime)
        {
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(dtime, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }

        /// <summary> 取指定日期是一月中的第几天 </summary> 
        public static int GetDayofmonth(this DateTime dtime)
        {
            return CultureInfo.CurrentCulture.Calendar.GetDayOfMonth(dtime);
        }
    }

    /// <summary>
    /// 时间类
    /// 1、SecondToMinute(int Second) 把秒转换成分钟
    /// </summary>
    public static partial class DateTimeExtention
    {
        /// <summary>
        /// 将时间格式化成 年月日 的形式,如果时间为null，返回当前系统时间
        /// </summary>
        /// <param name="dt">年月日分隔符</param>
        /// <param name="Separator"></param>
        /// <returns></returns>
        public static string GetFormatDate(this DateTime dt, char Separator)
        {
            if (dt != null && !dt.Equals(DBNull.Value))
            {
                string tem = string.Format("yyyy{0}MM{1}dd", Separator, Separator);
                return dt.ToString(tem);
            }
            else
            {
                return GetFormatDate(DateTime.Now, Separator);
            }
        }
        /// <summary>
        /// 将时间格式化成 时分秒 的形式,如果时间为null，返回当前系统时间
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="Separator"></param>
        /// <returns></returns>
        public static string GetFormatTime(this DateTime dt, char Separator)
        {
            if (dt != null && !dt.Equals(DBNull.Value))
            {
                string tem = string.Format("hh{0}mm{1}ss", Separator, Separator);
                return dt.ToString(tem);
            }
            else
            {
                return GetFormatDate(DateTime.Now, Separator);
            }
        }
        /// <summary>
        /// 把秒转换成分钟
        /// </summary>
        /// <returns></returns>
        public static int SecondToMinute(int Second)
        {
            decimal mm = (decimal)((decimal)Second / (decimal)60);
            return Convert.ToInt32(Math.Ceiling(mm));
        }

        #region 返回某年某月最后一天
        /// <summary>
        /// 返回某年某月最后一天
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns>日</returns>
        public static int GetMonthLastDate(int year, int month)
        {
            DateTime lastDay = new DateTime(year, month, new System.Globalization.GregorianCalendar().GetDaysInMonth(year, month));
            int Day = lastDay.Day;
            return Day;
        }
        #endregion

        #region 返回时间差
        public static string DateDiff1(this DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            try
            {
                //TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
                //TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
                //TimeSpan ts = ts1.Subtract(ts2).Duration();
                TimeSpan ts = DateTime2 - DateTime1;
                if (ts.Days >= 1)
                {
                    dateDiff = DateTime1.Month.ToString() + "月" + DateTime1.Day.ToString() + "日";
                }
                else
                {
                    if (ts.Hours > 1)
                    {
                        dateDiff = ts.Hours.ToString() + "小时前";
                    }
                    else
                    {
                        dateDiff = ts.Minutes.ToString() + "分钟前";
                    }
                }
            }
            catch
            { }
            return dateDiff;
        }
        #endregion

        #region 获得两个日期的间隔
        /// <summary>
        /// 获得两个日期的间隔
        /// </summary>
        /// <param name="DateTime1">日期一。</param>
        /// <param name="DateTime2">日期二。</param>
        /// <returns>日期间隔TimeSpan。</returns>
        public static TimeSpan DateDiff2(this DateTime DateTime1, DateTime DateTime2)
        {
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            return ts;
        }
        #endregion

        #region 格式化日期时间
        /// <summary>
        /// 格式化日期时间
        /// </summary>
        /// <param name="dateTime1">日期时间</param>
        /// <param name="dateMode">显示模式</param>
        /// <returns>0-9种模式的日期</returns>
        public static string FormatDate(this DateTime dateTime1, string dateMode)
        {
            switch (dateMode)
            {
                case "0":
                    return dateTime1.ToString("yyyy-MM-dd");
                case "1":
                    return dateTime1.ToString("yyyy-MM-dd HH:mm:ss");
                case "2":
                    return dateTime1.ToString("yyyy/MM/dd");
                case "3":
                    return dateTime1.ToString("yyyy年MM月dd日");
                case "4":
                    return dateTime1.ToString("MM-dd");
                case "5":
                    return dateTime1.ToString("MM/dd");
                case "6":
                    return dateTime1.ToString("MM月dd日");
                case "7":
                    return dateTime1.ToString("yyyy-MM");
                case "8":
                    return dateTime1.ToString("yyyy/MM");
                case "9":
                    return dateTime1.ToString("yyyy年MM月");
                default:
                    return dateTime1.ToString();
            }
        }
        #endregion

        #region 得到随机日期
        /// <summary>
        /// 得到随机日期
        /// </summary>
        /// <param name="time1">起始日期</param>
        /// <param name="time2">结束日期</param>
        /// <returns>间隔日期之间的 随机日期</returns>
        public static DateTime GetRandomTime(this DateTime time1, DateTime time2)
        {
            Random random = new Random();
            DateTime minTime = new DateTime();
            DateTime maxTime = new DateTime();

            System.TimeSpan ts = new System.TimeSpan(time1.Ticks - time2.Ticks);

            // 获取两个时间相隔的秒数
            double dTotalSecontds = ts.TotalSeconds;
            int iTotalSecontds = 0;

            if (dTotalSecontds > System.Int32.MaxValue)
            {
                iTotalSecontds = System.Int32.MaxValue;
            }
            else if (dTotalSecontds < System.Int32.MinValue)
            {
                iTotalSecontds = System.Int32.MinValue;
            }
            else
            {
                iTotalSecontds = (int)dTotalSecontds;
            }


            if (iTotalSecontds > 0)
            {
                minTime = time2;
                maxTime = time1;
            }
            else if (iTotalSecontds < 0)
            {
                minTime = time1;
                maxTime = time2;
            }
            else
            {
                return time1;
            }

            int maxValue = iTotalSecontds;

            if (iTotalSecontds <= System.Int32.MinValue)
                maxValue = System.Int32.MinValue + 1;

            int i = random.Next(System.Math.Abs(maxValue));

            return minTime.AddSeconds(i);
        }
        #endregion
    }
}
