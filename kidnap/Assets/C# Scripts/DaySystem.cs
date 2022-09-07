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
        
        //���� �ð� ����
        DayTime curTime;

        //�ٲ� �ð�
        [SerializeField]
        DayTime nextTime;

        //���� ����
        int curDay = 1;
        
        //�ٲ����� ����
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
