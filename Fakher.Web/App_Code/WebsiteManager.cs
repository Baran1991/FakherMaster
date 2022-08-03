using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Caching;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using NHibernate;
using System.Drawing;
using System.IO;
using mshtml;
using System.Web.UI;
using rComponents;

public static class WebsiteManager
{
    private static object LogLock = new object();
    private static object ExamLogLock = new object();
    private static object EnrollmentLogLock = new object();

    public static string AppUrl { get; set; }
    public static string AppPhysicalPath { get; set; }
    public static string PicturesPath { get; set; }
    public static string PicturesPhysicalPath { get; set; }
    public static string LogFolderPath { get; set; }

    public static void SaveLog(Page page, Person person, string message)
    {
        SaveLog(person, message);
    }

    public static void SaveExamLog(Page page, ExamParticipate examParticipate, string message)
    {
        string path = String.Format("{0}\\ExamLog-{1}.txt", LogFolderPath, PersianDate.Today.ToShortDateString().Replace("/", ""));
        string participateText = examParticipate == null ? "No ExamParticipate" : examParticipate.Person.FarsiFullname + " (" + examParticipate.Id + ")";

        try
        {
            lock(ExamLogLock)
            {
                File.AppendAllText(path, string.Format("{0}|{1}|{2}|{3}|{4}|{5}\r\n", page.Request.Url + "", DateTime.Now.ToLongTimeString(), participateText, message, page.Session.SessionID, page.Request.UserHostAddress));
            }
        }
        catch (Exception e)
        {
            
        }
    }

    public static void SaveEnrollmentLog(Page page, Student student , string message)
    {
        string path = String.Format("{0}\\EnrollmentLog-{1}.txt", LogFolderPath, PersianDate.Today.ToShortDateString().Replace("/", ""));
        string participateText = student == null ? "No Student" : student.FarsiFullname + " (" + student.Id + ")";

        try
        {
            lock (EnrollmentLogLock)
            {
                File.AppendAllText(path, string.Format("{0}|{1}|{2}|{3}|{4}|{5}\r\n", page.Request.Url + "", DateTime.Now.ToLongTimeString(), participateText, message, page.Session.SessionID, page.Request.UserHostAddress));
            }
        }
        catch (Exception e)
        {
            
        }
    }

    public static void SaveLog(Person person, string message)
    {
        string personText = person == null ? "No Person" : person.FarsiFullname + " (" + person.Id + ")";

        try
        {
            lock (LogLock)
            {
//                string path = string.Format("{0}\\Log.txt", LogFolderPath);
                string path = GetTodayLogPath();
                File.AppendAllText(path, DateTime.Now.ToLongTimeString() + " -- " + personText + " -- " + message + "\r\n");
            }
        }
        catch (Exception ex)
        {

        }
    }

    public static void SaveException(Page page, Exception ex)
    {
        string path = string.Format("{0}\\Exceptions.txt", LogFolderPath);
        string type = "Normal Exception";
        string text = "";
        text += "\r\n -------------------------- \r\n";

        if(page == null)
        {
            type = "App Exception";
        }
        if (ex is PayException)
        {
            text += "PayException Code: " + (ex as PayException).RawCode + " \r\n";
            type = "Pay Exception";
        }

        text += "Type:" + type + "\r\n";
        text += "Ex:" + ex + "\r\n";
        if (page != null)
        {
            text += "Page:" + page + "\r\n";
            text += "IsPostBack:" + page.IsPostBack + "\r\n";
        }
        text += "DateTime:" + PersianDate.Today + " " + DateTime.Now.ToLongTimeString() + "\r\n";
        text += ex.Message + "\r\n";
        text += ex.StackTrace + "\r\n";
        if (ex.InnerException != null)
        {
            text += "\r\n InnerException: \r\n";
            text += "Ex:" + ex.InnerException + "\r\n";
            text += ex.InnerException.Message + "\r\n";
            text += ex.InnerException.StackTrace + "\r\n";
        }
        text += "\r\n -------------------------- \r\n";

        try
        {
            lock (LogLock)
            {

                File.AppendAllText(path, text);
            }
        }
        catch(Exception exception)
        {
            
        }
    }

    public static string GetTodayLogPath()
    {
        return GetLogPath(PersianDate.Today);
    }

    public static string GetLogPath(PersianDate persianDate)
    {
        return String.Format("{0}\\{1}.txt", LogFolderPath, persianDate.ToShortDateString().Replace("/", ""));
    }

    public static string PrepareHtml(string html)
    {
        if (string.IsNullOrEmpty(html))
            return html;
        try
        {
            IHTMLDocument2 doc = new HTMLDocumentClass();
            doc.write(new object[] { html });
            IHTMLElementCollection images = doc.images;
            for (int i = 0; i < images.length; i++)
            {
                HTMLImgClass item = (HTMLImgClass)images.item(i, 0);
                string name = item.name;
                string href = item.href;
                string mimeType = href.Substring(href.IndexOf(":") + 1, href.IndexOf(";") - href.IndexOf(":") - 1);
                string imageExtention = "";
                ImageFormat imageFormat = ImageFormat.Png;
                string imageFile = "";

                if (mimeType == "image/jpeg")
                {
                    imageFormat = ImageFormat.Jpeg;
                    imageExtention = ".jpg";
                }
                if (mimeType == "image/png")
                {
                    imageFormat = ImageFormat.Png;
                    imageExtention = ".png";
                }

                imageFile = name + imageExtention;

                if (!File.Exists(PicturesPhysicalPath))
                {
                    string substring = "";
                    if (imageFormat == ImageFormat.Jpeg)
                        substring = href.Substring(23);
                    if (imageFormat == ImageFormat.Png)
                        substring = href.Substring(22);

                    byte[] bytes = Convert.FromBase64String(substring);
                    using (MemoryStream stream = new MemoryStream(bytes))
                    {
                        using (Image image = Bitmap.FromStream(stream))
                        {
                            image.Save(PicturesPhysicalPath + "\\" + imageFile, imageFormat);
                        }
                    }
                }
                item.setAttribute("src", PicturesPath + "/" + imageFile, 1);
            }

            doc.close();
            string resultHtml = doc.body.innerHTML;
            return resultHtml;
        }
        catch (Exception ex)
        {
            return html;
        }


        /*
        int index = html.IndexOf("<IMG");
        int lastIndex = html.IndexOf(">", index);
        string imgString = html.Substring(index, (lastIndex - index + 1));

        //find name
        int nameIndex = imgString.IndexOf("name");
        int spaceIndex = imgString.IndexOfAny(new [] {' '}, nameIndex + 5);
        string name = imgString.Substring(nameIndex+5, (spaceIndex - nameIndex - 5));

        //find data
        int srcIndex = imgString.IndexOf("src");
        int srcSpaceIndex = imgString.IndexOfAny(new[] { ' ' }, srcIndex + 27);

        int dataStartIndex = srcIndex + 5;
        int dataEndIndex = srcSpaceIndex - 6;
        string data = imgString.Substring(dataStartIndex, (dataEndIndex - srcIndex));

        string path = HttpContext.Current.Server.MapPath("~/Pictures");
        string appPath = VirtualPathUtility.ToAbsolute("~");
        string imagePhysicalPath = path + "/" + name + ".jpg";

        if (!File.Exists(imagePhysicalPath))
        {
            string substring = data.Substring(22);
            byte[] bytes = Convert.FromBase64String(substring.Trim());
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                using (Image image = Bitmap.FromStream(stream))
                {
                    image.Save(imagePhysicalPath, ImageFormat.Jpeg);
                }
            }
        }

        html = html.Replace(data, appPath + "/Pictures/" + name + ".jpg");
        return html;
         * */
    }

    public static T GetAppSetting<T>(string key)
    {
        return GetAppSetting<T, T>(key);
//        if (HttpRuntime.Cache[key] == null)
//        {
//            string setting = AppSetting.GetSetting(key);
//            object value = setting;
//            if (typeof(T) != typeof(string) && string.IsNullOrEmpty(setting))
//                value = default(T);
//            HttpRuntime.Cache.Add(key, value, null, DateTime.Now.AddMinutes(10), Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
//        }
//
//        return (T)Convert.ChangeType(HttpRuntime.Cache[key], typeof(T));
    }

    public static TResult GetAppSetting<T1, TResult>(string key)
    {
        if (HttpRuntime.Cache[key] == null)
        {
            string setting = AppSetting.GetSetting(key);
            object value = setting;
            if (typeof(T1) != typeof(string) && string.IsNullOrEmpty(setting))
                value = default(T1);
            HttpRuntime.Cache.Add(key, value, null, DateTime.Now.AddMinutes(10), Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
        }

        return (TResult)Convert.ChangeType(HttpRuntime.Cache[key], typeof(T1));
    }

    public static string GetNavigateUrl(MenuItem menuItem)
    {
        if (menuItem.Type == MenuItemType.StaticPage)
            if (menuItem.Webpage != null && menuItem.SectionContainer != null)
                return string.Format("{0}/Section/Page.aspx?id={1}&&pageid={2}", AppUrl, menuItem.SectionContainer.Id, menuItem.Webpage.Id);
        if (menuItem.Type == MenuItemType.Url)
            return menuItem.Url;
        if (menuItem.Type == MenuItemType.WebsiteSection)
            if (menuItem.WebsiteSection != null)
                return string.Format("{0}/Section/Default.aspx?id={1}", AppUrl, menuItem.WebsiteSection.Id);
        return AppUrl + "#";
    }

    public static void IsInEnrollmentPhase()
    {
        if (WebsiteHandler.CurrentStudent == null ||
            WebsiteHandler.CurrentRegister == null)
            throw new Exception("خطا در فرآیند ثبت نام");


//        string key = "EnrollingStudent-" + WebsiteHandler.CurrentStudent.Id;
//        int id = Convert.ToInt32(HttpRuntime.Cache[key]);
//        if (id == 0)
//        {
//            InsertIntoCache(key, WebsiteHandler.CurrentRegister.Id + "", 20, new CacheItemRemovedCallback(OnRegisterEnrollmentExpired));
//        }

        WebsiteHandler.IsInEnrollmentPhase = true;
    }

    public static void IsInExamEnrollmentPhase()
    {
        if (WebsiteHandler.CurrentStudent == null ||
            WebsiteHandler.CurrentRegister == null)
            throw new Exception("خطا در فرآیند ثبت نام در آزمون");


        string key = "ExamEnrollingRegister-" + WebsiteHandler.CurrentRegister.Id;
        int id = Convert.ToInt32(HttpRuntime.Cache[key]);
        if (id == 0)
        {
            InsertIntoCache(key, WebsiteHandler.CurrentRegister.Id + "", 20, new CacheItemRemovedCallback(OnExamEnrollmentExpired));
        }

        WebsiteHandler.IsInExamEnrollmentPhase = true;
    }

    private static void InsertIntoCache(string key, string value, int timeout, CacheItemRemovedCallback callback)
    {
//        const int timeout = 20;
        //            int timeout = 1;
        HttpRuntime.Cache.Add(key, value, null,
                                      Cache.NoAbsoluteExpiration,
                                      TimeSpan.FromMinutes(timeout), CacheItemPriority.Normal,
                                      callback);
        //            HttpRuntime.Cache.Add(key + "-" + WebsiteHandler.CurrentDbISessionKey, WebsiteHandler.CurrentDbISession, null,
        //                                          Cache.NoAbsoluteExpiration,
        //                                          Cache.NoSlidingExpiration, CacheItemPriority.Normal,
        //                                          null);

    }

    public static void OnRegisterEnrollmentExpired(string key, object value, CacheItemRemovedReason reason)
    {
        return;
        try
        {
            int id = Convert.ToInt32(value);
            ISession session = DbContext.SessionFactory.OpenSession();
            Register register = session.Get<Register>(id);

            if (register != null)
            {
                if (register.InternetRegisteration && !register.EnrollmentConfirmed)
                {
                    SaveLog(null, string.Format("Clearing Register #{0} [{1}]", id, register.Student.FarsiFullname));

                    bool changed = false;
                    for (int i = register.Participates.Count - 1; i >= 0; i--)
                    {
                        Participate participate = register.Participates[i];
                        if (participate.InternetRegisteration && !participate.EnrollmentConfirmed)
                        {
                            SaveLog(null,
                                    string.Format("Clearing Participate #{0} of Register #{1} [{2} - {3}] [{4}]",
                                                  participate.Id,
                                                  participate.Register.Id,
                                                  participate.SectionItem.Lesson.Name,
                                                  participate.SectionItem.Section.GroupNumber,
                                                  participate.Register.Student.FarsiFullname));
                            register.RemoveParticipate(participate);
                            participate.Delete(session);
                            changed = true;
                        }
                    }

                    if (changed)
                        register.Save(session);
                }
            }
            session.Close();
            session.Dispose();
        }
        catch (Exception e)
        {
            //            string cachekey = "EnrollingStudent-" + WebsiteHandler.CurrentStudent.Id;
            //            InsertIntoCache(cachekey, value + "");
        }
    }

    public static void OnExamEnrollmentExpired(string key, object value, CacheItemRemovedReason reason)
    {
        return;
        try
        {
            int id = Convert.ToInt32(value);
            ISession session = DbContext.SessionFactory.OpenSession();
            Register register = session.Get<Register>(id);

            if (register != null)
            {
                SaveLog(null, string.Format("Clearing Register #{0} [{1}] for ExamParticipates", id, register.Student.FarsiFullname));

                bool changed = false;
                IQueryable<ExamParticipate> examParticipates = register.GetExamParticipates();
                for (int i = examParticipates.Count() - 1; i >= 0; i--)
                {
                    ExamParticipate examParticipate = examParticipates.ElementAt(i);
                    if (examParticipate.InternetRegisteration && !examParticipate.EnrollmentConfirmed)
                    {
                        SaveLog(null,
                                string.Format("Clearing ExamParticipate #{0} of Register #{1} [{2}] [{3}]",
                                              examParticipate.Id,
                                              examParticipate.Register.Id,
                                              examParticipate.Register.Student.FarsiFullname,
                                              examParticipate.ExamForm.Exam.FarsiText));
                        register.RemoveExamParticipate(examParticipate);
                        examParticipate.Delete(session);
                        changed = true;
                    }
                }

                if (changed)
                    register.Save(session);
            }
            session.Close();
            session.Dispose();
        }
        catch (Exception e)
        {

        }
    }
}

