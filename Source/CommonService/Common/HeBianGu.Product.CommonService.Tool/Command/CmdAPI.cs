#region <�� �� ע ��>
/*
 * ========================================================================
 * Copyright(c) �����²���ʯ�ͿƼ����޹�˾, All Rights Reserved.
 * ========================================================================
 *    
 * ���ߣ�[���]   ʱ�䣺2015/11/4 10:07:26  ��������ƣ�DEV-LIHAIJUN
 *
 * �ļ�����CmdExcute
 *
 * ˵���� ִ��DOS�������չ���� 
 * 
 * 
 * �޸��ߣ�           ʱ�䣺               
 * �޸�˵����
 * ========================================================================
*/
#endregion
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.CommonService.Tool
{
    /// <summary> ִ��DOS�������չ���� </summary>
    public static class CmdAPI
    {
        /// <summary> ����DOS����  DOS�رս�������(ntsd -c q -p PID )PIDΪ���̵�ID   </summary>   
        public static string RunCmdOutPut(this string command, EventHandler endEvent = null)
        {
            //  ����һ�������M��   
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c " + command;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;

            if (endEvent != null)
            {
                p.EnableRaisingEvents = true;
                p.Exited += endEvent;
            }

            // Todo 2016-11-19 ����ݔ����ȡ��������нY�� 
            p.Start();
            
            // Todo ������Ҫ�ǵü���ExitҪ��Ȼ��һ�г�ʽִ�е�ʱ��ᵱ�� 
            p.StandardInput.WriteLine("exit");        

            //  ��ݔ����ȡ��������нY�� 
            return p.StandardOutput.ReadToEnd();

            Process.Start("notepad");

        }

        /// <summary> ����DOS����  DOS�رս�������(ntsd -c q -p PID )PIDΪ���̵�ID   </summary>   
        public static void RunCmd(string command, EventHandler endEvent = null,bool isCreateWindow=false)
        {
            //  ����һ�������M��   
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c " + command;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = false;
            p.StartInfo.RedirectStandardOutput = false;
            p.StartInfo.RedirectStandardError = false;
            p.StartInfo.CreateNoWindow = isCreateWindow;

            if (endEvent != null)
            {
                p.EnableRaisingEvents = true;
                p.Exited += endEvent;
            }

            p.Start();

        }

        /// <summary> �ص����� P1 ���̵�PID </summary>
        [Obsolete("δ����")]
        public static string CloseProcessByPid(this string pid)
        {
            return string.Format(CmdStr.CloseProcessByPid, pid).RunCmdOutPut();
        }

        /// <summary> ִ��eclipse���� </summary> 
        public static string CmdEclipseByData(this string dataFullPath)
        {
            return string.Format(CmdStr.CmdEclipseRun, dataFullPath).RunCmdOutPut();
        }


    }
}