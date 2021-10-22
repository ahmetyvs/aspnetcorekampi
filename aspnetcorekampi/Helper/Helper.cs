using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nufusmevzuati.Helper
{
    public static class Helper
    {
        public static string XZaman(this DateTime date)
        {
            //Bugünden gelen tarihinin farkını alıyorum
            var timeSpan = DateTime.Now - date;
            //Geçen Süre 60 saniyeden küçükse 
            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                return string.Format("{0} Saniye Önce", timeSpan.Seconds);
            }
            //Geçen Süre 60 dakikadan küçükse
            else if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                return timeSpan.Minutes > 1 ? string.Format("{0} Dakika Önce", timeSpan.Minutes) : "Yaklaşık bir dakika önce";
            }
            //Geçen Süre 24 saatten küçükse
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                return timeSpan.Hours > 1 ? String.Format("{0} Saat Önce", timeSpan.Hours) : "Yaklaşık bir saat önce";
            }
            //Geçen Süre 30 günden küçükse
            else if (timeSpan <= TimeSpan.FromDays(30))
            {
                return timeSpan.Days > 1 ? String.Format("{0} Gün Önce", timeSpan.Days) : "Dün";
            }
            ////Geçen Süre 30 günden küçükse Hafta Hesabı
            //else if (timeSpan <= TimeSpan.FromDays(30))
            //    return timeSpan.Days > 1 ? String.Format("{0} gün önce", timeSpan.Days) : "dün";
            //Geçen Süre 365 günden küçükse
            else if (timeSpan <= TimeSpan.FromDays(365))
            {
                return timeSpan.Days > 30 ? String.Format("{0} Ay önce", timeSpan.Days / 30) : "Yaklaşık bir ay önce";
            }
            //Yıl 
           return timeSpan.Days > 365 ? String.Format("{0} yıl önce", timeSpan.Days / 365) : "yaklaşık bir yıl önce";
        }
    }
}