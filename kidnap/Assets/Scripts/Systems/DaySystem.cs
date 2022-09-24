using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kidnap
{

    public enum DayTime
    {
        Morning,
        Afternoon,
        evening
    }

    /// <summary>
    /// ���� ��� : 
    /// 1. ���� �ѱ��
    /// 2. ����, ����, ���� �����ϱ�.
    /// 3. ���� ������ �����ϱ�
    /// </summary>
    public class DaySystem : Singleton<DaySystem>
    {
        
        //���� �ð� ����
        DayTime curTime;

        //�ٲ� �ð�
        [SerializeField]
        DayTime nextTime;

        [SerializeField]
        int StartDay;

        //���� ����
        int curDay = 1;

        void Start()
        {
            curDay = StartDay;
            curTime = DayTime.Morning;
        }

        public void OverTime()
        {
            if(curTime == DayTime.evening)
            {
                curTime = 0;
                curDay++;
                return;
            }

            curDay++;


        }

    }
}
