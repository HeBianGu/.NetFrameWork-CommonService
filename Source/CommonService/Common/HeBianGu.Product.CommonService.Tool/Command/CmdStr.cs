#region <�� �� ע ��>
/*
 * ========================================================================
 * Copyright(c) �����²���ʯ�ͿƼ����޹�˾, All Rights Reserved.
 * ========================================================================
 *    
 * ���ߣ�[���]   ʱ�䣺2015/11/4 10:11:07  ��������ƣ�DEV-LIHAIJUN
 *
 * �ļ�����Cmd
 *
 * ˵����
 * 
 * 
 * �޸��ߣ�           ʱ�䣺               
 * �޸�˵����
 * ========================================================================
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.CommonService.Tool
{
   public class CmdStr
    {
        /// <summary> DOS�رս�������(ntsd -c q -p PID )PIDΪ���̵�ID </summary>
        public const string CloseProcessByPid = "ntsd -c q -p {0}";

        /// <summary> D����eclipse(eclrun eclipse) </summary>
        public const string CmdEclipseRun = "eclrun eclipse {0}";

        /// <summary>  �鿴��������������Ϣ "/c ipconfig /all" </summary>
        public const string CmdIpConfigerAll = "/c ipconfig /all";

        /// <summary> ��ʱ�ػ� string.Format("/c shutdown -s -t {0}", shijian) </summary>
        public const string CmdShutDown = "/c shutdown -s -t {0}";

        /// <summary> ȡ����ʱ�ػ� "/c shutdown -a" </summary>
        public const string CmdClearShutDown = "/c shutdown -a";

        /// <summary>  ��������ip��ַ "/c ping {0}" </summary>
        public const string CmdPing = "/c ping {0}";

        /// <summary> ��ʾ�������Ӻ������˿� "/c  netstat -an" </summary>
        public const string CmdNetStat = "/c  netstat -an";

        /// <summary> ��ʾ·�ɱ����� "/c  netstat -r" </summary>
        public const string CmdNetStat_R = "/c  netstat -r";

        /// <summary>  ��ѯ����ϵͳ "/c winver" </summary>
        public const string CmdWinver = "/c winver";

        /// <summary> IP��ַ����� "/c  Nslookup" </summary>
        public const string CmdNslookup = "/c  Nslookup";

        /// <summary> �򿪴��������� "/c  cleanmgr" </summary>
        public const string CmdCleanmgr = "/c  cleanmgr";

        /// <summary> ��ϵͳ��ע��� "/c  regedit" </summary>
        public const string CmdRegedit = "/c  regedit";

        /// <summary> �ҵĵ��� "/c  regedit" </summary>
        public const string CmdMyCompute = "explorer.exe ::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";

        /// <summary> ����վ "/c  regedit" </summary>
        public const string CmdDushbin = "explorer.exe ::{645FF040-5081-101B-9F08-00AA002F954E}";

        /// <summary> ������� "/c  regedit" </summary>
        public const string CmdControl = "control";

        /// <summary> ���߼���� </summary>
        public const string CmdSleep = "shutdown /h";

        /// <summary> ��ͼ���� </summary>
        public const string Cmdmspaint = "mspaint";

        /// <summary> Զ������ </summary>
        public const string Cmdmstsc= "mstsc";

        /// <summary> ���±� </summary>
        public const string Cmdnotepad= "notepad";

        /// <summary>    </summary>
        public const string Cmdsnippingtool = "snippingtool";

    }
}