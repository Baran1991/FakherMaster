using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using NHibernate.Linq;
using rApplicationEventFramework;
using rComponents;

namespace Fakher.Core.DomainModel
{
    [EventClass("پرسنل")]
    public class Employee : Staff
    {
        public Employee()
        {
            DailyDocument = new FinancialDocument { Description = "تراکنش های روزانه", Person = this};
        }

        public virtual string Position { get; set; }
        public virtual FinancialDocument DailyDocument { get; set; }

        public virtual void RegisterItem(FinancialItem item)
        {
//            item.RegisterDate = PersianDate.Today;
//            item.Registrar = this;
//            item.RegistrarText = FarsiFormalName;
        }

        public virtual void RegisterTransactionFor(Use use)
        {
//            use.Registrar = this;
//            use.RegistrarText = FarsiFormalName;
            foreach (FinancialItem financialItem in use.FinancialDocument.Items)
                RegisterItem(financialItem);

            FinancialItem item = new FinancialItem(FinancialType.Debt)
            {
                Amount = use.EducationalTool.LastSellPrice,
                Text = string.Format("فروش [{0}] به [{1}]",
                                  use.EducationalTool.Name,
                                  use.Person.FarsiFullname)
            };

            RegisterDailyItem(item);
        }

        public virtual void RegisterTransactionFor(Register register)
        {
//            register.Registrar = this;
//            register.RegistrarText = FarsiFormalName;
            foreach (FinancialItem financialItem in register.FinancialDocument.Items)
                RegisterItem(financialItem);

            FinancialItem item = new FinancialItem(FinancialType.Debt)
            {
                Amount = register.FinancialDocument.PayedBalance,
                Text = string.Format("ثبت نام [{0}]  ",
                                  register + "")
            };
            
            RegisterDailyItem(item);
        }

        public virtual void RegisterTransactionFor(Reserve reserve)
        {
//            reserve.Registrar = this;
//            reserve.RegistrarText = FarsiFormalName;
            foreach (FinancialItem financialItem in reserve.FinancialDocument.Items)
                RegisterItem(financialItem);

            FinancialItem item = new FinancialItem(FinancialType.Debt)
            {
                Amount = reserve.FinancialDocument.PayedBalance,
                Text = string.Format("رزرو [{0}] در {1} ",
                                  reserve.Student.FarsiFullname + "", reserve.ReserveList.Name)
            };
            
            RegisterDailyItem(item);
        }

        public virtual void RegisterTransactionFor(ExamParticipate examParticipate)
        {
//            examParticipate.Registrar = this;
//            examParticipate.RegistrarText = FarsiFormalName;
            foreach (FinancialItem financialItem in examParticipate.FinancialDocument.Items)
                RegisterItem(financialItem);

            FinancialItem item = new FinancialItem(FinancialType.Debt)
            {
                Amount = examParticipate.FinancialDocument.PayedBalance,
                Text = string.Format("ثبت نام [{0}] در [{1}] ",
                                  examParticipate.Register + "", examParticipate.ExamForm.Exam.Name)
            };

            RegisterDailyItem(item);
        }

        public virtual void RegisterDailyItem(FinancialItem item)
        {
            RegisterDailyItem(item, true);
        }

        public virtual void RegisterDailyItem(FinancialItem item, bool updateBalance)
        {
//            EnsureDailDocument();
            RegisterItem(item);
            DailyDocument.Items.Add(item);
            if (updateBalance)
                FinancialBalance += item.Balance;
            Save();
        }

//        public virtual void EnsureDailDocument()
//        {
//            if(DailyDocument == null)
//                DailyDocument = new FinancialDocument { Description = "تراکنش های روزانه", Person = this };
//        }

        public new static Employee FromName(string firstName, string lastName)
        {
            var query = from employee in DbContext.Entity<Employee>()
                        where employee.FarsiFirstName == firstName && employee.FarsiLastName == lastName
                        && !employee.Disabled
                        select employee;
            return query.FirstOrDefault();
        }

        public new static List<Employee> Search(string firstName, string lastName)
        {
            List<Employee> result = new List<Employee>();

            var query = from employee in DbContext.Entity<Employee>()
                        where employee.FarsiFirstName == firstName
                        && employee.FarsiLastName == lastName
                        select employee;
            result.UniqueAddRange(query.ToList());

            query = from employee in DbContext.Entity<Employee>()
                    where employee.FarsiFirstName.StartsWith(firstName)
                    && employee.FarsiLastName.StartsWith(lastName)
                    select employee;
            result.UniqueAddRange(query.ToList());

            query = from employee in DbContext.Entity<Employee>()
                    where employee.FarsiFirstName.Contains(firstName)
                    && employee.FarsiLastName.Contains(lastName)
                    select employee;
            result.UniqueAddRange(query.ToList());

            return result.Where(x => !x.Disabled).ToList();
        }

        //        public static IList<Employee> GetAllEmployee()
        //        {
        //            return DbContext.GetAllEntities<Employee>();
        //        }
        public virtual IEnumerable<FinancialItem> GetInsertedFinancialItems()
        {
            IQueryable<EntityEvent> entityEvents =
                GetRegisteredEntityEventsQuery<FinancialItem>(EntityEventAction.InsertObject);
            List<FinancialItem> items = GetRegisteredEntitiesQuery<FinancialItem>(entityEvents).ToList();
            return items;
        }
        public virtual IEnumerable<FinancialItem> GetInsertedFinancialItems(PersianDate registerStartDate, PersianDate registerEndDate)
        {
            IQueryable<EntityEvent> entityEvents =
                GetRegisteredEntityEventsQuery<FinancialItem>(EntityEventAction.InsertObject).Where(
                    x => x.Date >= registerStartDate && x.Date <= registerEndDate);
            List<FinancialItem> items = GetRegisteredFinancialItemsQuery<FinancialItem>(entityEvents).ToList();
            return items;
        }

        public virtual long GetFinancialBalance()
        {
            #region استخراج رویدادها از جدول رویدادها با استفاده از کد کاربر و نوع رویداد مالی و استخراج از جدول مالی و محاسبه مجموع. کد کاربر مستقیما به آیتم های مالی اضافه و محاسبه مستقیما از انجا انجام میشود
            IQueryable<EntityEvent> entityEvents =
                GetRegisteredEntityEventsQuery<FinancialItem>(EntityEventAction.InsertObject);
            List<FinancialItem> items = GetRegisteredEntitiesQuery<FinancialItem>(entityEvents).ToList();

            long sum = items.Where(x => x.IsPaying && !x.IsClone).Sum(x => x.Amount);
            //long sum = (await GetFinancialItems()).Where(x => x.IsPaying && !x.IsClone).Sum(x => x.Amount);
            #endregion
            IEnumerable<FinancialItem> payOffItems = GetDailyFinancialItems(FinancialHeading.EmployeePayOff);
            long payoffSum = payOffItems.Sum(x => x.Amount);

            return payoffSum - sum;
        }
        public virtual async Task<IEnumerable<FinancialItem>> GetFinancialItems()
        {
            var query = from item in DbContext.Entity<FinancialItem>()
                        where item.Person.Id == Id
                        select item;
            return await query.ToListAsync();
        }
        public virtual IEnumerable<FinancialItem> GetDailyFinancialItems(PersianDate startDate, PersianDate endDate, FinancialHeading heading)
        {
            var query = from item in DailyDocument.Items
                         where item.Date >= startDate
                         && item.Date <= endDate
                         && item.Heading == heading
                         select item;
            return query;
        }

        public virtual IEnumerable<FinancialItem> GetDailyFinancialItems(FinancialHeading heading)
        {
            var query = from item in DailyDocument.Items
                         where item.Heading == heading
                         select item;
            return query;
        }

        public static IQueryable<Employee> GetActiveEmployees()
        {
            var query = from employee in DbContext.Entity<Employee>()
                        where employee.Disabled == false
                        select employee;
            return query;
        }

        public static IQueryable<Employee> GetAllEmployees()
        {
            var query = from employee in DbContext.Entity<Employee>()
                        select employee;
            return query;
        }
      
        public static Employee FromId(int id)
        {
            return DbContext.FromId<Employee>(id);
        }
    }
}