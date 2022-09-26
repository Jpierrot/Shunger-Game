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
    /// 구현 목록 : 
    /// 1. 일자 넘기기
    /// 2. 오전, 오후, 저녁 구분하기.
    /// 3. 일자 데이터 저장하기
    /// </summary>
    public class DaySystem : Singleton<DaySystem>
    {
        
        //현재 시간 상태
        [HideInInspector] public DayTime curTime;

        //바뀔 시간
        [SerializeField] DayTime nextTime;

        [SerializeField] int StartDay;

        //현재 일자
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
