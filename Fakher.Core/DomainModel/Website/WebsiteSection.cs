using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Fakher.Core.DomainModel;

namespace Fakher.Core.Website
{
    public class WebsiteSection : DbObject
    {
        public virtual string Name { get; set; }
        public virtual bool DepartmentBinding { get; set; }
        public virtual bool ShowCalendar { get; set; }
        [NoCascade]
        public virtual Department Department { get; set; }
        public virtual IList<Webpage> Pages { get; set; }

        public WebsiteSection()
        {
            Pages = new List<Webpage>();
        }

        #region Static Members

        public static WebsiteSection FromId(int id)
        {
            return DbContext.FromId<WebsiteSection>(id);
        }

        public static IList<WebsiteSection> GetWebsiteSections()
        {
            return DbContext.GetAllEntities<WebsiteSection>();
        }
        #endregion

        public virtual void AddPage(Webpage webpage)
        {
            webpage.WebsiteSection = this;
            Pages.Add(webpage);
        }

        public override string ToString()
        {
            return Name;
        }

        public virtual IQueryable<Webpage> GetWebpages(WebpageType type)
        {
            var query = from page in Pages
                        where page.Type == type
                        select page;
            return query.AsQueryable();
        }
    }
}