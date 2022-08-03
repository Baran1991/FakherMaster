using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;

namespace Fakher.Core.Website
{
    public class WebsiteWidget : DbObject
    {
        public virtual string Title { get; set; }
        public virtual string Text { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual int Position { get; set; }
        [NoCascade]
        public virtual MenuItem MenuItem { get; set; }

        public WebsiteWidget()
        {
            IsActive = true;
            MenuItem = new MenuItem {Place = MenuItemPlace.WidgetMenu, Type = MenuItemType.Url};
        }

        [NonPersistent]
        public virtual string StatusText
        {
            get
            {
                if (IsActive)
                    return "فعال";
                return "غیرفعال";
            }
        }

        #region Static Members

        public static IList<WebsiteWidget> GetActiveWidgets()
        {
            var query = from widget in DbContext.Entity<WebsiteWidget>()
                        where widget.IsActive
                        orderby widget.Position, widget.Id descending 
                        select widget;
            return query.ToList();
        }

        public static IList<WebsiteWidget> GetWidgets()
        {
            var query = from widget in DbContext.Entity<WebsiteWidget>()
                        orderby widget.Position, widget.Id descending 
                        select widget;
            return query.ToList();
        }

        #endregion
    }
}