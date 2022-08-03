<%@ Application Language="C#" %>
<%@ Import Namespace="DataAccessLayer" %>
<%@ Import Namespace="NHibernate" %>
<%@ Import Namespace="Fakher.Core" %>
<%@ Import Namespace="Fakher.Core.Website" %>
<%@ Import Namespace="NHibernate.Context" %>
<%@ Import Namespace="rComponents" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        WebsiteManager.AppPhysicalPath = Server.MapPath("~");
        WebsiteManager.PicturesPhysicalPath = Server.MapPath("~/Pictures");
        WebsiteManager.LogFolderPath = Server.MapPath("~/App_Log");
//        WebsiteManager.LogFolderPath = Server.MapPath("../logs");
            
        DbContext.InitializeDb();

        WebsiteManager.SaveLog(null, "Application Start");
    }

    void Application_BeginRequest(object sender, EventArgs e)
    {
        Services.InitializePersianNumberFormat();
        WebsiteManager.AppUrl = "http://" + Request.Url.Authority + Request.ApplicationPath;
        if (WebsiteManager.AppUrl.EndsWith("/"))
            WebsiteManager.AppUrl = WebsiteManager.AppUrl.Substring(0, WebsiteManager.AppUrl.Length - 1);
        WebsiteManager.PicturesPath = WebsiteManager.AppUrl + "/Pictures";
    }
    
    void Application_EndRequest(object sender, EventArgs e)
    {
        
    }
    
    void Application_PreRequestHandlerExecute(object sender, EventArgs e)
    {
//        Services.InitializePersianNumberFormat();
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown
        
        DbContext.CloseDb();
        WebsiteManager.SaveLog(null, "Application End");
    }
        
    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs
        Exception exception = Server.GetLastError();
        if (exception != null)
        {
            if (exception.InnerException != null)
                WebsiteManager.SaveException(null, exception.InnerException);
            else
                WebsiteManager.SaveException(null, exception);
        }
    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

//        WebsiteHandler.CurrentDbISession = DbContext.OpenUnitOfWork();
//        WebsiteHandler.TotalUserCount++;
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

//        if(WebsiteHandler.CurrentDbISession != null)
//            DbContext.CloseUnitOfWork(WebsiteHandler.CurrentDbISession);
//        WebsiteHandler.TotalUserCount--;
    }
       
</script>
