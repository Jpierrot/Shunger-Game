using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        [SerializeField]
        public Color[] DayColors = new Color[3];

        public UnityEvent OverDayEvents;

        public UnityEvent StartDayEvents;

        //���� �ð� ����
        [HideInInspector] public DayTime curTime;

        //�ٲ� �ð�
        [SerializeField] DayTime nextTime;

        [SerializeField] int StartDay;

        public int EndDay = 10;

        //���� ����
        [HideInInspector] public int curDay = 1;

        /// <summary>
        /// �ý��ۿ� ���� �κ��� Awake���� ����
        /// </summary>
        void Awake()
        {
            curDay = StartDay;
            curTime = DayTime.Morning;
            StartDayEvents.Invoke();
        }

        [HideInInspector]
        public void OverTime()
        {
            if(curTime == DayTime.evening)
            {
                curTime = 0;
                OverDay();
                OverDayEvents.Invoke();
                return;
            }
            curTime++;
        }

        /// <summary>
        /// for test
        /// </summary>
        [HideInInspector]
        public void OverDay()
        {
            curDay++;
        }

        public Color TimeColor(DayTime time)
        {
            return DayColors[(int)time];
        }
    }
}
