using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.Core.Website
{
    public class Webpage : DbObject
    {
        public virtual PersianDate Date { get; set; }
        public virtual int Hour { get; set; }
        public virtual int Minute { get; set; }
        public virtual WebpageType Type { get; set; }
        public virtual string Title { get; set; }
        [MaximumLength]
        public virtual string Html { get; set; }
        public virtual int Position { get; set; }
        public virtual int Hits { get; set; }
        public virtual bool IsRed { get; set; }
        public virtual bool PreEnrollmentListBinding { get; set; }
        [NoCascade]
        public virtual PreEnrollmentList PreEnrollmentList { get; set; }
        [NoCascade]
        public virtual WebsiteSection WebsiteSection { get; set; }
        public virtual IList<WebMedia> Attachments { get; set; }

        public Webpage()
        {
            Type = WebpageType.StaticPage;
            Attachments = new List<WebMedia>();
            Date = PersianDate.Today;
            Hour = DateTime.Now.Hour;
            Minute = DateTime.Now.Minute;
            Hits = 0;
            Position = 0;
        }

        #region Static Members

        public static Webpage FromId(int id)
        {
            return DbContext.FromId<Webpage>(id);
        }

        public static IList<Webpage> GetPages()
        {
            return DbContext.GetAllEntities<Webpage>();
        }

        public static IQueryable<Webpage> GetWebpages(WebpageType type)
        {
            var query = from page in DbContext.Entity<Webpage>()
                        where page.Type == type
                        orderby page.Position descending, page.Id descending 
                        select page;
            return query.AsQueryable();
        }

        #endregion

        public override void BeforeSave()
        {
            if(Position == 0 && Type == WebpageType.Article)
            {
                var query = from webpage in DbContext.Entity<Webpage>()
                            where webpage.Type == WebpageType.Article
                            orderby webpage.Position descending 
                            select webpage.Position;
                int max = query.FirstOrDefault();
                Position = max + 1;
            }
        }

        public override string ToString()
        {
            return Title;
        }

        public virtual void IncrementHits()
        {
            Hits++;
        }
    }

    public enum WebpageType
    {
        [EnumDescription("صفحه ثابت")]
        StaticPage,
        [EnumDescription("مقاله")]
        Article,
    }
}