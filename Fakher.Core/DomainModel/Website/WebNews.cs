using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.Website
{
    public class WebNews : DbObject
    {
        public virtual PersianDate Date { get; set; }
        public virtual int Hour { get; set; }
        public virtual int Minute { get; set; }
        [MaximumLength]
        public virtual string Title { get; set; }
        public virtual WebNewsCategory Category { get; set; }
        [MaximumLength]
        public virtual string AbstractHtml { get; set; }
        [MaximumLength]
        public virtual string TextHtml { get; set; }
        public virtual bool HasTicker { get; set; }
        public virtual bool IsRed { get; set; }
        public virtual int Hits { get; set; }

        public WebNews()
        {
            Date = PersianDate.Today;
            Hour = DateTime.Now.Hour;
            Minute = DateTime.Now.Minute;
            Hits = 0;
        }

        [NonPersistent]
        public virtual string CategoryText
        {
            get { return Category.ToDescription(); }
        }

        #region Static Members

        public static IList<WebNews> GetWebNews()
        {
            var query = from news in DbContext.Entity<WebNews>()
                        orderby news.Id descending, news.Date descending
                        select news;
            return query.ToList();
        }

        public static WebNews FromId(int id)
        {
            return DbContext.FromId<WebNews>(id);
        }

        public static IList<WebNews> GetLastNews(WebNewsCategory category, int count)
        {
            var query = from webnews in DbContext.Entity<WebNews>()
                        where webnews.Category == category
                        orderby webnews.Id descending, webnews.Date descending
                        select webnews;
            return query.Take(count).ToList();
        }

        public static IList<WebNews> GetLastTickerNews(int count)
        {
            var query = from webnews in DbContext.Entity<WebNews>()
                        where webnews.HasTicker
                        orderby webnews.Id descending, webnews.Date descending
                        select webnews;
            return query.Take(count).ToList();
        }

        #endregion

        public virtual void IncrementHits()
        {
            Hits++;
        }
    }

    public enum WebNewsCategory
    {
        [EnumDescription("خبر داخلی موسسه")]
        InstituteNews,
        [EnumDescription("خبر حوزه آموزش کشور")]
        EducationalNews
    }
}