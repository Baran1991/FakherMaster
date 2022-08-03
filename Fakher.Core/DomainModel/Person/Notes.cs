using DataAccessLayer;
using rComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakher.Core.DomainModel
{
    public   class Notes : DbObject
    {
        public virtual bool Financial { get; set; } = false;
        public virtual PersianDate Date { get; set; }
       
        public virtual string Title { get; set; }
        [MaximumLength]
        public virtual string Text { get; set; }

        public virtual Person Person { get; set; }
        public virtual NotesType NotesType { get; set; }
        [NonPersistent]
        public static IQueryable<Notes> GetNotesByType(NotesType type)
        {
            var query1 = from notes in DbContext.Entity<Notes>()
                         where notes.NotesType == type
                         select notes;

            return query1.AsQueryable();
        }

    }
    public enum NotesType
    {
        [EnumDescription("توضیحات آموزشی- مالی")]
        Explanations_EduFa,
        [EnumDescription("پاسخ های پیش فرض")]
        DefaultAnswers,
        [EnumDescription("توضیحات درخواست ها")]
        Explanations_Req
    }
   
   

}
