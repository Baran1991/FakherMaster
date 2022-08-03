using System.Linq;
using DataAccessLayer;

namespace Fakher.Core.Website
{
    public class NewsletterSubscriber : DbObject
    {
        public virtual string Mobile { get; set; }
        public virtual string Email { get; set; }

        public static IQueryable<NewsletterSubscriber> GetNewsletterSubscriber(string mobile)
        {
            var query = from subscriber in DbContext.Entity<NewsletterSubscriber>()
                        where subscriber.Mobile == mobile
                        select subscriber;
            return query;
        }

        public static IQueryable<NewsletterSubscriber> GetAllSubscriber()
        {
            var query = from subscriber in DbContext.Entity<NewsletterSubscriber>()
                        select subscriber;
            return query;
        }
    }
}