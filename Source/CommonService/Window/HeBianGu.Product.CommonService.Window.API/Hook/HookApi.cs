#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 四川*******有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[HeBianGu]   时间：2018/6/13 9:26:20  QQ:908293466
 * 文件名：Class1 
 * 说明：
 * 
 * 
 * 修改者：           时间：               
 * 修改说明：
 * ========================================================================
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.CommonService.Window.API
{
    internal class HookApi
    {
        #region Windows API 函数导入

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        internal static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        internal static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, int dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        internal static extern int UnhookWindowsHookEx(int idHook);

        [DllImport("user32")]
        public static extern int GetDoubleClickTime();

        [DllImport("user32")]
        internal static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey, int fuState);

        [DllImport("user32")]
        internal static extern int GetKeyboardState(byte[] pbKeyState);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        internal static extern short GetKeyState(int vKey);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);

        #endregion
    }

    /// <summary> 钩子触发的委托 </summary>
    internal delegate int HookProc(int nCode, int wParam, IntPtr lParam);

    /// <summary> 说明 </summary>
    internal class HookType
    {
        #region Windows 常量

        //值来自微软SKD中的 Winuser.h
        /// <summary>
        /// Windows NT/2000/XP: 安装一个监控低级别的鼠标输入事件的一个钩子程序
        /// </summary>
        internal const int WH_MOUSE_LL = 14;

        /// <summary>
        /// Windows NT/2000/XP: 安装一个监控低级别的键盘输入事件的一个钩子程序
        /// </summary>
        internal const int WH_KEYBOARD_LL = 13;

        /// <summary>
        /// 安装一个监视鼠标消息钩子程序。欲了解更多信息，请参阅MouseProc钩子程序。
        /// </summary>
        internal const int WH_MOUSE = 7;

        /// <summary>
        /// 安装一个监控击键消息的钩子程序。欲了解更多信息，请参阅KeyboardProc钩子程序。
        /// </summary>
        internal const int WH_KEYBOARD = 2;

        /// <summary>
        /// 在WM_MOUSEMOVE消息发布到一个窗口时，光标移动信息。 
        /// </summary>
        internal const int WM_MOUSEMOVE = 0x200;

        /// <summary>
        /// 当用户按下鼠标左键WM_LBUTTONDOWN消息
        /// </summary>
        internal const int WM_LBUTTONDOWN = 0x201;

        /// <summary>
        /// 当用户按下鼠标右键WM_LBUTTONDOWN消息
        /// </summary>
        internal const int WM_RBUTTONDOWN = 0x204;

        /// <summary>
        /// 当用户按下鼠标中键WM_MBUTTONDOWN消息
        /// </summary>
        internal const int WM_MBUTTONDOWN = 0x207;

        /// <summary>
        /// 当用户释放鼠标左键WM_LBUTTONUP消息
        /// </summary>
        internal const int WM_LBUTTONUP = 0x202;

        /// <summary>
        /// 当用户释放鼠标右键WM_RBUTTONUP消息
        /// </summary>
        internal const int WM_RBUTTONUP = 0x205;

        /// <summary>
        /// 当用户释放鼠标中键的WM_MBUTTONUP消息
        /// </summary>
        internal const int WM_MBUTTONUP = 0x208;

        /// <summary>
        /// 该WM_LBUTTONDBLCLK消息发布时，用户双击鼠标左键
        /// </summary>
        internal const int WM_LBUTTONDBLCLK = 0x203;

        /// <summary>
        /// 该WM_RBUTTONDBLCLK消息发布时，用户双击鼠标右键
        /// </summary>
        internal const int WM_RBUTTONDBLCLK = 0x206;

        /// <summary>
        /// 当用户按下鼠标右键WM_RBUTTONDOWN消息
        /// </summary>
        internal const int WM_MBUTTONDBLCLK = 0x209;

        /// <summary>
        /// 当用户按下鼠标滚轮的WM_MOUSEWHEEL消息
        /// </summary>
        internal const int WM_MOUSEWHEEL = 0x020A;

        /// <summary>
        ///将WM_KEYDOWN消息发布到窗口的键盘焦点时，非系统
        /// </summary>
        internal const int WM_KEYDOWN = 0x100;

        /// <summary>
        /// 该WM_KEYUP消息发布到窗口的键盘焦点时，非系统
        /// </summary>
        internal const int WM_KEYUP = 0x101;

        /// <summary>
        /// 该WM_SYSKEYDOWN消息发布到窗口的键盘焦点时，用户按下F10键（激活菜单栏），或者按住ALT键，然后再按下另一个键。它也发生在没有窗口当前拥有键盘焦点;
        /// </summary>
        internal const int WM_SYSKEYDOWN = 0x104;

        /// <summary>
        /// 该WM_SYSKEYUP消息发布到窗口的键盘焦点当用户释放被按下，同时ALT键被按住一个键。它也发生在没有窗口当前拥有键盘焦点;在这种情况下，WM_SYSKEYUP消息发送到活动窗口。
        /// 接收消息的窗口可以通过检查lParam参数的上下文代码这两个上下文之间的区别。
        /// </summary>
        internal const int WM_SYSKEYUP = 0x105;

        internal const byte VK_SHIFT = 0x10;
        internal const byte VK_CAPITAL = 0x14;
        internal const byte VK_NUMLOCK = 0x90;

        #endregion
    }
}
