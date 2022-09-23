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
        
        //�ٲ����� ����
        [SerializeField]
        int nextDay;

        void Start()
        {
            curDay = StartDay;
            curTime = DayTime.Morning;
        }

        void OverDay()
        {

        }

    }
}
