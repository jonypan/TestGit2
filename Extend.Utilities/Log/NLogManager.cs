using System;
using System.Diagnostics;
using System.Text;
using NLog;
using NLog.Targets;
using NLog.Config;

namespace Extend.Utilities
{
    public static class NLogManager
    {
        /// <summary>
        /// 
        /// </summary>
        volatile static Logger Log = LogManager.GetLogger("CardGame");
        volatile static Logger AuthenLog = LogManager.GetLogger("Authen");


        //private static Logger Log
        //{
        //    get
        //    {
        //        if (_log == null)
        //        {
        //            try
        //            {
        //                if (LogManager.Configuration != null && LogManager.Configuration.LoggingRules.Count > 0)
        //                {
        //                    _log = LogManager.GetCurrentClassLogger();

        //                    return _log;
        //                }
        //            }
        //            catch
        //            {
        //            }

        //            FileTarget target = new FileTarget();
        //            target.Layout = "${longdate} ${logger} ${message}";
        //            target.FileName = "${basedir}/_LOG/${date:format=yyyyMMdd}_Debug.txt";
        //            target.ArchiveFileName = "${basedir}/archives/${date:format=yyyyMMdd}_Debug_log.txt";
        //            target.ArchiveAboveSize = 1024 * 1024 * 100; // archive files greater than 10 KB
        //            //   target.ArchiveNumbering = FileTarget.ArchiveNumberingMode.Sequence;
        //            target.Name = "Debug";
        //            // this speeds up things when no other processes are writing to the file
        //            target.ConcurrentWrites = true;

        //            NLog.Config.SimpleConfigurator.ConfigureForTargetLogging(target, LogLevel.Debug);

        //            FileTarget warning = new FileTarget();
        //            warning.Layout = "${longdate} ${logger} ${message}";
        //            warning.FileName = "${basedir}/_LOG/${date:format=yyyyMMdd}_CardGame.txt";
        //            warning.ArchiveFileName = "${basedir}/archives/${date:format=yyyyMMdd}_CardGame_log.txt";
        //            warning.ArchiveAboveSize = 1024 * 1024 * 100; // archive files greater than 10 KB
        //            //   warning.ArchiveNumbering = FileTarget.ArchiveNumberingMode.Sequence;
        //            warning.Name = "Warning";
        //            // this speeds up things when no other processes are writing to the file
        //            warning.ConcurrentWrites = true;
        //            NLog.Config.SimpleConfigurator.ConfigureForTargetLogging(warning, LogLevel.Warn);
        //            _log = LogManager.GetLogger("CardGame");
        //        }

        //        return _log;
        //    }
        //}

        /// <summary>
        /// Writes an Error to the log.
        /// </summary>
        /// <param name="ex"></param>
        public static void PublishException(Exception ex)
        {
            Log.Error(string.Format("\t{0}{1}{2}{3}{4}", GetCalleeString(), Environment.NewLine, ex.Message, Environment.NewLine, ex.StackTrace));
        }

        public static void LogError(string message)
        {
            Log.Error(":\t" + GetCalleeString() + Environment.NewLine + "\t" + message);
        }

        /// <summary>
        /// Writes an Error to the log.
        /// </summary>
        /// <param name="ex"></param>
        public static void LogMessage(string message)
        {

            ////Log.Error(string.Format(":\t{0}{1}\t{2}", GetCalleeString(), Environment.NewLine, message));
            //FileTarget target = new FileTarget();
            //target.Layout = "${longdate} ${logger} ${message}";
            //target.FileName = "${basedir}/_LOG/" + "/${date:format=yyyyMMdd}_CardGame.txt";
            //target.ArchiveFileName = "${basedir}/archives/${date:format=yyyyMMdd}_CardGame_Log.txt";
            //target.ArchiveAboveSize = 1024 * 1024 * 100; // archive files greater than 10 KB
            //target.Name = "Debug";
            //target.ConcurrentWrites = true;
            //target.ConcurrentWrites = true;
            //NLog.Config.SimpleConfigurator.ConfigureForTargetLogging(target, LogLevel.Debug);
            //Log.Factory.Configuration.AddTarget("CardGame", target);

            Log.Info(":\t" + GetCalleeString() + Environment.NewLine + "\t" + message);
        }

        public static void WarningAuthen(string message)
        {
            AuthenLog.Warn(message);
        }

        public static void LogMessageAuthen(string message)
        {
            AuthenLog.Info(message);
        }

        public static void ExceptionAuthen(Exception ex)
        {
            AuthenLog.Error(ex);
        }

        /// <summary>
        /// Writes an Error to the log.
        /// </summary>
        /// <param name="ex"></param>
        public static void Warning(string message)
        {
            Log.Warn(string.Format(":\t{0}{1}\t{2}", GetCalleeString(), Environment.NewLine, message));
        }

        /// <summary>
        /// Writes an Debug to the log.
        /// </summary>
        /// <param name="ex"></param>
        public static void Debug(string message)
        {
            Log.Error(string.Format(":\t{0}{1}\t{2}", GetCalleeString(), Environment.NewLine, message));
        }

        public static string GetValueOfObject(object ob)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                foreach (System.Reflection.PropertyInfo piOrig in ob.GetType().GetProperties())
                {
                    object editedVal = ob.GetType().GetProperty(piOrig.Name).GetValue(ob, null);
                    sb.AppendFormat("{0}:{1}\t ", piOrig.Name, editedVal);
                }
            }
            catch
            {
            }
            return sb.ToString();
        }

        private static string GetCalleeString()
        {
            foreach (StackFrame sf in new StackTrace().GetFrames())
            {
                if (!string.IsNullOrEmpty(sf.GetMethod().ReflectedType.Namespace) && !typeof(NLogManager).FullName.StartsWith(sf.GetMethod().ReflectedType.Namespace))
                {
                    return string.Format("{0}.{1} ", sf.GetMethod().ReflectedType.Name, sf.GetMethod().Name);
                }
            }

            return string.Empty;
        }
    }
}