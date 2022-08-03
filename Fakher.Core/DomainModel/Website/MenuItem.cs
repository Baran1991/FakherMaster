using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.Website
{
    public class MenuItem : DbObject
    {
        public virtual string Name { get; set; }
        public virtual MenuItemType Type { get; set; }
        public virtual MenuItemPlace Place { get; set; }
        public virtual string Url { get; set; }
        [NoCascade]
        public virtual WebsiteSection WebsiteSection { get; set; }
        [NoCascade]
        public virtual Webpage Webpage { get; set; }
        public virtual IList<MenuItem> Childs { get; set; }
        [NoCascade]
        public virtual MenuItem Parent { get; set; }
        [NoCascade]
        public virtual WebsiteSection SectionContainer { get; set; }
        public virtual int Position { get; set; }

        public MenuItem()
        {
            Childs = new List<MenuItem>();
            Type = MenuItemType.StaticPage;
        }

        [NonPersistent]
        public virtual int ParentId
        {
            get
            {
                if (Parent != null)
                    return Parent.Id;
                return 0;
            }
        }

        [NonPersistent]
        public virtual string Text
        {
            get
            {
                string txt = Type.ToDescription();

                try
                {
                    if (Type == MenuItemType.StaticPage)
                        txt += " (" + Webpage.Title + ")";
                    if (Type == MenuItemType.Article)
                        txt += " (" + Webpage.Title + ")";
                    if (Type == MenuItemType.Url)
                        txt += " (" + Url + ")";
                    if (Type == MenuItemType.WebsiteSection)
                        txt += " (" + SectionContainer.Name + ")";
                }
                catch (Exception ex)
                {
                    txt = "تعریف نشده";
                }

                return txt;
            }
        }

        [NonPersistent]
        public virtual IList<MenuItem> OrderedChilds
        {
            get { return Childs.OrderBy(x => x.Position).ToList(); }
        }

        #region Static Members

        [Obsolete]
        public static IList<MenuItem> GetOldTopMenuItems()
        {
            var query = from item in DbContext.Entity<MenuItem>()
                        where item.Parent == null
                        && item.SectionContainer == null
                        orderby item.Position
                        select item;
            return query.ToList();
        }

        public static IList<MenuItem> GetTopMenuItems()
        {
            var query = from item in DbContext.Entity<MenuItem>()
                        where item.Parent == null
                        && item.Place == MenuItemPlace.MainTopMenu
                        orderby item.Position
                        select item;
            return query.ToList();
        }

        [Obsolete]
        public static IList<MenuItem> GetOldTopMenuItems(WebsiteSection sectionContainer)
        {
            var query = from item in DbContext.Entity<MenuItem>()
                        where item.SectionContainer != null
                        && item.SectionContainer.Id == sectionContainer.Id
                        && item.Parent == null
                        orderby item.Position
                        select item;
            return query.ToList();
        }

        public static IList<MenuItem> GetTopMenuItems(WebsiteSection sectionContainer)
        {
            var query = from item in DbContext.Entity<MenuItem>()
                        where item.Place == MenuItemPlace.SectionRightMenu
                        && item.SectionContainer != null
                        && item.SectionContainer.Id == sectionContainer.Id
                        && item.Parent == null
                        orderby item.Position
                        select item;
            return query.ToList();
        }

        public static IList<MenuItem> GetMenuItems(MenuItem parentItem)
        {
            var query = from item in DbContext.Entity<MenuItem>()
                        where item.Parent != null
                        && item.Parent.Id == parentItem.Id
                        orderby item.Position
                        select item;
            return query.ToList();
        }

        #endregion
    }

    public enum MenuItemType
    {
        [EnumDescription("صفحه ثابت")]
        StaticPage,
        [EnumDescription("آدرس ثابت")]
        Url,
        [EnumDescription("بخـــش")]
        WebsiteSection,
        [EnumDescription("مقاله")]
        Article,
    }

    public enum MenuItemPlace
    {
        [EnumDescription("منوی اصلی بالا")]
        MainTopMenu,
        [EnumDescription("منوی بخش")]
        SectionRightMenu,
        [EnumDescription("ویجت")]
        WidgetMenu,
    }
}