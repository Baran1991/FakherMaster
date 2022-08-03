using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.SessionState;
using DataAccessLayer;
using Fakher.Core.Website;
using NHibernate;
using NHibernate.Context;

public class DbSessionModule : IHttpModule
{
    public DbSessionModule()
    {

    }

    public void Init(HttpApplication context)
    {
        //        context.PostAcquireRequestState += new EventHandler(context_PostAcquireRequestState);
        context.BeginRequest += new EventHandler(context_BeginRequest);
        context.EndRequest += new EventHandler(context_EndRequest);
//        context.Error += new EventHandler(context_Error);
        //        context.PreSendRequestContent += new EventHandler(context_PreSendRequestContent);
        //        context.Disposed += new EventHandler(context_Disposed);
    }

//    void context_PreSendRequestContent(object sender, EventArgs e)
//    {
//        ISession session = CurrentSessionContext.Unbind(DbContext.SessionFactory);
//        session.Close();
//        session.Dispose();
//    }

    void context_BeginRequest(object sender, EventArgs e)
    {
        HttpRequest httpRequest = HttpContext.Current.Request;
        string fileExtension = Path.GetExtension(httpRequest.PhysicalPath).ToLower();
        if (fileExtension == ".aspx")
        {
            ISession session = DbContext.SessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);

//            WebsiteHandler.TotalUserCount++;
        }
    }

    void context_EndRequest(object sender, EventArgs e)
    {
        ISession session = CurrentSessionContext.Unbind(DbContext.SessionFactory);
        if (session != null)
        {
//            session.Clear();
            session.Close();
//            session.Dispose();

//            if (WebsiteHandler.TotalUserCount > 0)
//                WebsiteHandler.TotalUserCount--;
        }
        //        DbContext.CloseUnitOfWork(session);

        //        if (WebsiteHandler.CurrentDbISession != null)
        //        {
        //            HttpApplication app = sender as HttpApplication;
        //            app.CompleteRequest();
        //            app.Dispose();
        //            DbContext.CloseUnitOfWork(WebsiteHandler.CurrentDbISession);
        //        }
    }

//    void context_Error(object sender, EventArgs e)
//    {
//        ISession session = CurrentSessionContext.Unbind(DbContext.SessionFactory);
//        if (session != null)
//            DbContext.CloseUnitOfWork(session);
//    }

//    void context_PostAcquireRequestState(object sender, EventArgs e)
//    {
//        // -> at this point session state should be available
//        HttpRequest httpRequest = HttpContext.Current.Request;
//        string fileExtension = Path.GetExtension(httpRequest.PhysicalPath).ToLower();
//        if (fileExtension == ".aspx")
//            WebsiteHandler.CurrentDbISession = DbContext.OpenUnitOfWork();
//    }
//
    public void Dispose()
    {

    }
}