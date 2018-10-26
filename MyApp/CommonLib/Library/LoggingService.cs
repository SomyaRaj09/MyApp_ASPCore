using CommonLib.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Library
{
    public class LoggingService
    {
        //public static NLog.Logger logger;
        //private static bool _LogInitDone = false;

        //static LoggingService()
        //{
        //    //InitializeConfigurations();
        //    logger = NLog.LogManager.GetLogger("NLOG");
        //}

        //public static LoggingService GetLogger()
        //{
        //    return new LoggingService();
        //}

        //public static async Task LogMessage(string message, ILoggedInUser user, object moreInfo = null)
        //{
        //    await LogMessage(message, string.Empty, user, moreInfo);
        //}

        //public static async Task LogMessage(string message, string title, ILoggedInUser user, object moreInfo = null)
        //{
        //    Log log = new Log();
        //    log.Message = message;
        //    log.Title = title;
        //    if (user != null)
        //        log.StaffID = user.StaffId;

        //    //Console.WriteLine(JsonConvert.SerializeObject(user));

        //    await InitializeLog(log);
        //    await Log(log, NLog.LogLevel.Info, moreInfo);
        //}

        //public static async Task LogError(Exception exception, ILoggedInUser user)
        //{
        //    Log log = new Log();

        //    if (user != null)
        //        log.StaffID = user.StaffId;
        //    await InitializeErrorLog(exception, log);
        //    await Log(log, NLog.LogLevel.Error, null, null);
        //}

        //public static async Task LogError(Exception exception, Log log, ILoggedInUser user, object moreInfo = null)
        //{
        //    if (user != null)
        //        log.StaffID = user.StaffId;
        //    await InitializeErrorLog(exception, log);
        //    await Log(log, NLog.LogLevel.Error, null, moreInfo);
        //}

        //public static async Task LogError(Exception exception, object loggerClass, ILoggedInUser user, object moreInfo = null)
        //{
        //    await LogError(exception, loggerClass, string.Empty, string.Empty, user, moreInfo);
        //}

        //public static async Task LogError(Exception exception, object loggerClass, string moduleName, string title, ILoggedInUser user, object moreInfo = null)
        //{
        //    Log log = new Log();
        //    log.Title = title;
        //    if (user != null)
        //        log.StaffID = user.StaffId;
        //    await InitializeErrorLog(exception, log);
        //    await Log(log, NLog.LogLevel.Error, loggerClass, moreInfo);
        //}

        //private static async Task Log(Log log, NLog.LogLevel logLevel, object loggerClass, object moreInfo = null)
        //{
        //    InitializeConfigurations();

        //    //if (loggerClass == null)
        //    //    loggerClass = this;

        //    //NLog.Logger logger = NLog.LogManager.GetLogger(loggerClass.GetType().Name);

        //    NLog.LogEventInfo logEvent = new NLog.LogEventInfo(logLevel, "NLOG", log.Message);
        //    logEvent.Properties["title"] = log.Title;
        //    logEvent.Properties["message"] = log.Message;
        //    logEvent.Properties["usertoken"] = log.SessionID;
        //    logEvent.Properties["staffid"] = log.StaffID;
        //    logEvent.Properties["applicationidentifier"] = log.ApplicationIdentifier;
        //    logEvent.Properties["ipaddress"] = log.IpAddress;
        //    logEvent.Properties["url"] = log.Url;
        //    logEvent.Properties["referrerurl"] = log.ReferrerUrl;
        //    logEvent.Properties["headers"] = log.Headers;
        //    logEvent.Properties["stacktrace"] = log.StackTrace;
        //    logEvent.Properties["innerexception"] = log.InnerException;

        //    if (moreInfo != null)
        //        logEvent.Properties["moreinfo"] = JsonConvert.SerializeObject(moreInfo);
        //    else
        //        logEvent.Properties["moreinfo"] = log.MoreInfo;

        //    logger.Log(logEvent);
        //}

        //private static async Task InitializeLog(Log log)
        //{
        //    log.ApplicationIdentifier = AppSettings.ApplicationIdentifier;
        //}

        //private static async Task InitializeErrorLog(Exception exception, Log log)
        //{
        //    log.Message = exception.Message;
        //    if (exception.InnerException != null)
        //        log.InnerException = exception.InnerException.ToString();
        //    log.StackTrace = exception.StackTrace;
        //    log.ApplicationIdentifier = AppSettings.ApplicationIdentifier;
        //}

        //public static void InitializeConfigurations()
        //{
        //    GlobalDiagnosticsContext.Set("connectionString", AppSettings.LoggingConnectionString);

        //    if (_LogInitDone)
        //        return;

        //    try
        //    {
        //        NLog.LogManager.Configuration = new XmlLoggingConfiguration("nlog.config");

        //        //Get the logging connection string from app settings
        //        NLog.Targets.DatabaseTarget dbTarget = (NLog.Targets.DatabaseTarget)NLog.LogManager.Configuration.FindTargetByName("db");
        //        if (dbTarget != null)
        //            dbTarget.ConnectionString = AppSettings.LoggingConnectionString;

        //        NLog.LogManager.Configuration.Reload();
        //        logger = NLog.LogManager.GetLogger("NLOG");
        //        _LogInitDone = true;
        //    }
        //    catch (Exception e)
        //    {
        //        //throw e;
        //    }
        //}
    }
}
