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

    public class DaySystem : Singleton<DaySystem>
    {
        
        //현재 시간 상태
        DayTime curTime;

        //바뀔 시간
        [SerializeField]
        DayTime nextTime;

        //현재 일자
        int curDay = 1;
        
        //바뀌어야할 일자
        [SerializeField]
        int nextDay;

        void Start()
        {
            nextTime = 0;
            curTime = nextTime;

            nextDay = 1;
            curDay = nextDay;
        }

        void ToNext()
        {
            if (curTime == DayTime.evening)
            {
                nextTime = 0;
                ++nextDay;
                curDay = nextDay;
                DayPresenter.Instance.OnDayChanged(curDay);
            }
            else
                nextTime++;

            curTime = nextTime;
            DayPresenter.Instance.OnTimeChanged(curTime);
        }

        /// <summary>
        /// 테스트를 위해 업데이트로 판별.
        /// 실제로 게임 동작시에는 사라질 코드
        /// </summary>
        private void FixedUpdate()
        {
            if(curTime != nextTime)
            {
                curTime = nextTime;
                DayPresenter.Instance.OnTimeChanged(curTime);
            }

            if(curDay != nextDay)
            {
                curDay = nextDay;
                DayPresenter.Instance.OnDayChanged(curDay);
            }
        }

    }
}
