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

    public class DaySystem : MonoBehaviour
    {
        
        //현재 시간 상태
        DayTime curTime;

        //바뀔 시간
        [SerializeField]
        DayTime nextTime;

        [SerializeField]
        int DayCount = 1;

        void Start()
        {
            nextTime = 0;
            curTime = nextTime;
        }

        void ToNext()
        {
            if (curTime == DayTime.evening)
            {
                nextTime = 0;
                ++DayCount;
                DayPresenter.Instance.OnDayChanged(DayCount);
            }
            else
                nextTime++;

            curTime = nextTime;
            DayPresenter.Instance.OnTimeChanged(curTime);
        }

        private void FixedUpdate()
        {
            if(curTime != nextTime)
            {
                curTime = nextTime;
                DayPresenter.Instance.OnTimeChanged(curTime);
            }
        }




    }
}
