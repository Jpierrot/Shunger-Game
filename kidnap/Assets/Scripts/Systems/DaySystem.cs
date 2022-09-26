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
        [HideInInspector] public DayTime curTime;

        //�ٲ� �ð�
        [SerializeField] DayTime nextTime;

        [SerializeField] int StartDay;

        //���� ����
        [HideInInspector] public int curDay = 1;

        void Start()
        {
            curDay = StartDay;
            curTime = DayTime.Morning;
        }

        [HideInInspector]
        public void OverTime()
        {
            if(curTime == DayTime.evening)
            {
                curTime = 0;
                curDay++;
                return;
            }
            curTime++;
        }

        [HideInInspector]
        public void OverDay()
        {
            curDay++;
        }
    }
}
