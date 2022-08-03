using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.DomainModel.Consult;
using rComponents;

namespace Fakher.Core.Website
{
    public class WebMedia : DbObject
    {
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual WebMediaType Type { get; set; }
        public virtual string FileName { get; set; }
        public virtual string FileExtension { get; set; }
        public virtual string MimeType { get; set; }
        public virtual string OriginalPath { get; set; }
        public virtual PersianDate StartDate { get; set; }
        public virtual int StartHour { get; set; }
        public virtual int StartMinute { get; set; }
        public virtual PersianDate EndDate { get; set; }
        public virtual int EndHour { get; set; }
        public virtual int EndMinute { get; set; }
        [MaximumLength]
        public virtual byte[] Bytes { get; set; }

        public virtual int Hits { get; set; }

        [NoCascade]
        public virtual Webpage Webpage { get; set; }

        [NoCascade]
        public virtual Section Section { get; set; }

        [NoCascade]
        public virtual Exam Exam { get; set; }

        [NoCascade]
        public virtual Message Message { get; set; }

        public WebMedia()
        {
            Type = WebMediaType.Attachment;
            Code = Guid.NewGuid().ToString();
            StartDate = PersianDate.Today;
            StartHour = DateTime.Now.Hour;
            StartMinute = DateTime.Now.Minute;
            EndDate = PersianDate.Today;
            EndHour = 23;
            EndMinute = 59;
        }
        [NonPersistent]
        public virtual string StartTime
        {
            get { return StartHour.ToString("D2") + ":" + StartMinute.ToString("D2"); }
            set
            {
                string[] timeItems = value.Split(':', ' ');

                if (timeItems.Length < 2)
                    throw new ArgumentException();
                StartHour = Convert.ToInt32(timeItems[0]);
                StartMinute = Convert.ToInt32(timeItems[1]);
            }
        }
        [NonPersistent]
        public virtual string EndTime
        {
            get { return EndHour.ToString("D2") + ":" + EndMinute.ToString("D2"); }
            set
            {
                string[] timeItems = value.Split(':', ' ');

                if (timeItems.Length < 2)
                    throw new ArgumentException();
                EndHour = Convert.ToInt32(timeItems[0]);
                EndMinute = Convert.ToInt32(timeItems[1]);
            }
        }
        public virtual void SetFile(string filePath)
        {
            Name = FileName = Path.GetFileName(filePath);
            FileExtension = Path.GetExtension(filePath);
            OriginalPath = filePath;
            MimeType = MIMEAssistant.GetMIMEType(filePath);
            Bytes = File.ReadAllBytes(filePath);
        }

        public virtual void IncrementHits()
        {
            Hits++;
        }

        #region Static Members

        public static WebMedia FromCode(string code)
        {
            var query = from media in DbContext.Entity<WebMedia>()
                        where media.Code == code
                        select media;
            return query.FirstOrDefault();
        }

        public static IQueryable<WebMedia> FromSection(Section section)
        {
            var query = from media in DbContext.Entity<WebMedia>()
                        where media.Section != null
                              && media.Section.Id == section.Id
                        select media;
            return query;
        }

        public static IQueryable<WebMedia> FromExam(Exam exam)
        {
            var query = from media in DbContext.Entity<WebMedia>()
                        where media.Exam != null
                              && media.Exam.Id == exam.Id
                        select media;
            return query;
        }

        public static long GenerateCode(int id)
        {
            DateTime now = DateTime.Now;
            long preNum = now.Ticks%10000;
            string prefix = preNum.ToString();
            while (prefix.Length < 4)
            {
                int random = new Random().Next(1, 9);
                prefix = random + prefix;
            }

            string number = prefix.Substring(0, 2) + id.ToString() + prefix.Substring(2, 2);
            long code = Convert.ToInt64(number);
            return code;
        }

        public static WebMedia FromFileName(string filePath, WebMediaType type)
        {
            WebMedia media = new WebMedia();
            media.Code = Guid.NewGuid().ToString();
            media.Type = type;
            media.SetFile(filePath);
            //            media.Name = Path.GetFileName(filePath);
            //            media.OriginalPath = filePath;
            //            media.MimeType = MIMEAssistant.GetMIMEType(filePath);
            //            media.Bytes = File.ReadAllBytes(filePath);
            return media;
        }

        public static IQueryable<WebMedia> GetAllMediaQuery(WebMediaType type)
        {
            var query = from media in DbContext.Entity<WebMedia>()
                        where media.Type == type
                        orderby media.Id descending
                        select media;
            return query;
        }

        public static IList<WebMedia> GetAllMedia(WebMediaType type)
        {
            return GetAllMediaQuery(type).ToList();
        }

        #endregion

        public virtual void SaveTo(string fileName)
        {
            File.WriteAllBytes(fileName, Bytes);
        }

        public virtual WebMedia Clone()
        {
            WebMedia clone = Services.Clone(this);
            clone.Bytes = Bytes;

            return clone;
        }
        [NonPersistent]
        public virtual DateTime AttachmentStartDateTime
        {
            get
            {
                DateTime systemDateTime = StartDate.ToSystemDateTime();
                return new DateTime(systemDateTime.Year, systemDateTime.Month, systemDateTime.Day, StartHour, StartMinute, 0);
            }
        }
        [NonPersistent]
        public virtual DateTime AttachmentEndDateTime
        {
            get
            {
                DateTime systemDateTime = EndDate.ToSystemDateTime();
                return new DateTime(systemDateTime.Year, systemDateTime.Month, systemDateTime.Day, EndHour, EndMinute, 0);
            }
        }
        public virtual bool CanViewAttachment()
        {
          

            DateTime now = DateTime.Now;

            return now >= AttachmentStartDateTime && now<=AttachmentEndDateTime;

           
        }
    }

    public enum WebMediaType
    {
        Attachment,
        Media,
    }
}