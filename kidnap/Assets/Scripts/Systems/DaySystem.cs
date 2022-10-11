using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;
using UnityEngine.Events;

namespace Kidnap
{ 

    /// <summary>
    /// 구현 목록 : 
    /// 1. 일자 넘기기
    /// 2. 오전, 오후, 저녁 구분하기.
    /// 3. 일자 데이터 저장하기
    /// </summary>
    public class DaySystem : Singleton<DaySystem>
    {
        [SerializeField]
        public Color[] DayColors = new Color[3];

        //하루가 넘어갈 때 마다 동작할 메소드 
        public UnityEvent OverDayEvents;

        //하루가 처음 시작할 때 동작할 메소드
        public UnityEvent StartDayEvents;

        //현재 시간 상태
        [HideInInspector] public DayTime curTime;

        //바뀔 시간
        [SerializeField] DayTime nextTime;

        //시작하는 날짜
        [SerializeField] int StartDay;

        //게임이 끝나는 날짜
        public int EndDay = 10;

        //현재 일자
        [HideInInspector] public int curDay = 1;

        /// <summary>
        /// 시스템에 관한 부분은 Awake에서 실행
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
