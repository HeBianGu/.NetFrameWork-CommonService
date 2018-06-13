#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 四川*******有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[HeBianGu]   时间：2018/6/13 9:33:08  QQ:908293466
 * 文件名：Class3 
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeBianGu.Product.CommonService.Window.API
{
    class VideoService
    {
        string path = string.Empty;

        /// <summary> 此方法的说明 </summary>
        public void RunMethod()
        {
            Control c = new Control();//picCapture.Handle


            VideoEntity video = new VideoEntity(c.Handle, 640, 480);

            //打开视频  
            //if (video.StartWebCam(320, 240))  
            if (video.StartWebCam())
            {
                video.get();
                video.Capparms.fYield = true;
                video.Capparms.fAbortLeftMouse = false;
                video.Capparms.fAbortRightMouse = false;
                video.Capparms.fCaptureAudio = false;
                video.Capparms.dwRequestMicroSecPerFrame = 0x9C40; // 设定帧率25fps： 1*1000000/25 = 0x9C40  
                video.set();
                //setCap();  
                //VideoStart = true;  
            }
            //开始录像  
            video.StarKinescope(System.IO.Path.Combine(path, System.DateTime.Now.ToString("yyyy-MM-dd(HH.mm.ss)") + ".avi"));
            //停止录像  
            video.StopKinescope();
            //压缩（压缩效率还是很低，不要用于实际开发）  
            video.CompressVideoFfmpeg();
        }
    }
}
