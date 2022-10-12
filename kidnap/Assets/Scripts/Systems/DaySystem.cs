using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;
using UnityEngine.Events;

namespace Kidnap
{ 

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

        //�Ϸ簡 �Ѿ �� ���� ������ �޼ҵ� 
        public UnityEvent OverDayEvents;

        //�Ϸ簡 ó�� ������ �� ������ �޼ҵ�
        public UnityEvent StartDayEvents;

        //���� �ð� ����
        [HideInInspector] public DayTime curTime;

        //�ٲ� �ð�
        [SerializeField] DayTime nextTime;

        //�����ϴ� ��¥
        [SerializeField] int StartDay;

        //������ ������ ��¥
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
