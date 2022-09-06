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

        int DayCount = 1;

        void Start()
        {
            curTime = DayTime.Morning;
        }

        void ToNext()
        {
            if (curTime == DayTime.evening)
            {
                curTime = 0;
                DayCount++;
            }
            else
                curTime++;
        }


    }
}
