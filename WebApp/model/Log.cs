using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;

public class Log
{
    /// <summary>
    /// 写日志(用于跟踪)
    /// </summary>
    public static void WriteLog(string strMemo)
    {
        //string appidFilePath = ConfigurationManager.AppSettings["appidFile"].ToString();
        string isLog = ConfigurationManager.AppSettings["isLog"].ToString();
        if (isLog.ToLower() == "yes")
        {
            //string filename = HttpRuntime.AppDomainAppPath + appidFilePath + "\\IndexLogs\\";
            string filename = HttpRuntime.AppDomainAppPath + "Logs\\";
            // string filename = Server.MapPath(appidFilePath + "\\logs\\");
            if (!Directory.Exists(filename))
                Directory.CreateDirectory(filename);
            strMemo = "[CreateTime:" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "]:" + strMemo;
            filename = filename + DateTime.Now.ToString("yyyy_MM_dd") + ".txt";
            StreamWriter sr = null;
            try
            {
                if (!File.Exists(filename))
                {
                    sr = File.CreateText(filename);
                }
                else
                {
                    sr = File.AppendText(filename);
                }
                sr.WriteLine(strMemo);
            }
            catch
            {

            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }
    }

    /// <summary>
    /// 写日志(用于跟踪)
    /// </summary>
    public static void WriteDebugLog(string strMemo)
    {
        //string appidFilePath = ConfigurationManager.AppSettings["appidFile"].ToString();
        //string isLog = ConfigurationManager.AppSettings["isLog"].ToString();

        //string filename = HttpRuntime.AppDomainAppPath + appidFilePath + "\\IndexLogs\\";
        string filename = HttpRuntime.AppDomainAppPath + "Logs\\";
        // string filename = Server.MapPath(appidFilePath + "\\logs\\");
        if (!Directory.Exists(filename))
            Directory.CreateDirectory(filename);
        strMemo = "[CreateTime:" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "]:" + strMemo;
        filename = filename + DateTime.Now.ToString("yyyy_MM_dd") + "_debuglog" + ".txt";
        StreamWriter sr = null;
        try
        {
            if (!File.Exists(filename))
            {
                sr = File.CreateText(filename);
            }
            else
            {
                sr = File.AppendText(filename);
            }
            sr.WriteLine(strMemo);
        }
        catch
        {

        }
        finally
        {
            if (sr != null)
                sr.Close();
        }

    }
}
