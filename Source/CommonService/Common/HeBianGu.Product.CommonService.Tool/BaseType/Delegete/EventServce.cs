#region <�� �� ע ��>
/*
 * ========================================================================
 * Copyright(c) �����²���ʯ�ͿƼ����޹�˾, All Rights Reserved.
 * ========================================================================
 *    
 * ���ߣ�[���]   ʱ�䣺2015/10/30 9:25:11  ��������ƣ�DEV-LIHAIJUN
 *
 * �ļ�����Event
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
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HHeBianGu.Product.CommonService.Tool
{
    public static class EventServce
    {

        /// <summary> �������ע���¼� ( ��֤���� ) </summary>
        /// <param name="objectHasEvents"> ��˭���¼� </param>
        /// <param name="eventName"> �¼��� (����) </param>
        public static void ClearAllEvents(this object objectHasEvents, string eventName)
        {
            if (objectHasEvents == null)
            {
                return;
            }

            try
            {
                //  ��ȡ��Ա�����¼�
                EventInfo[] events = objectHasEvents.GetType().GetEvents(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (events == null || events.Length < 1)
                {
                    return;
                }

                for (int i = 0; i < events.Length; i++)
                {
                    EventInfo ei = events[i];

                    if (ei.Name == eventName)
                    {
                        //  ���¼�ת�����ֶ�
                        FieldInfo fi = ei.DeclaringType.GetField(eventName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                        if (fi != null)
                        {
                            //  ����¼��ֶ�
                            fi.SetValue(objectHasEvents, null);
                        }

                        break;
                    }
                }
            }
            catch
            {
            }
        }


        /// <summary> ��������ע����Ϣ </summary>
        /// <param name="pEventInfo"> Ҫ������¼� </param>
        /// <param name="objectHasEvents"> ��˭���¼� </param>
        [Obsolete("�÷���δ����", true)]
        public static bool ClearAll(this EventInfo pEventInfo, object objectHasEvents)
        {
            if (pEventInfo == null)
            {
                return true;
            }

            try
            {
                FieldInfo fi = pEventInfo.DeclaringType.GetField(pEventInfo.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (fi != null)
                {
                    fi.SetValue(objectHasEvents, null);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary> �����߳�ѡ���Ƿ��첽ִ�� </summary>
        public static void DoThread<T>(this EventHandler handle, EventArgs args)
        {
            if (handle == null) return;

            if (handle.Target is System.ComponentModel.ISynchronizeInvoke)
            {
                System.ComponentModel.ISynchronizeInvoke aSynch = handle.Target as System.ComponentModel.ISynchronizeInvoke;

                if (aSynch.InvokeRequired)
                {
                    object[] a = new object[] { handle, args };
                    // Todo ������Ƿ��첽���� 
                    aSynch.BeginInvoke(handle, a);
                }
                else
                {
                    // Todo �����ͬ������ 
                    handle(handle, args);
                }
            }

        }


    }
}