using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;

namespace Kidnap
{
    public class NewsSystem : Singleton<NewsSystem>
    {

        string path = @"C:\Users\user2\Desktop\Jpie\UnityPractice\Shunger-Game\kidnap\Assets\Texts\Afternoon.txt";

        public string GetText(DayTime time)
        {
            switch (time)
            {
                case DayTime.Morning :
                    path = @"C:\Users\user2\Desktop\Jpie\UnityPractice\Shunger-Game\kidnap\Assets\Texts\Morning.txt";
                    break;
                case DayTime.Afternoon:
                    path = @"C:\Users\user2\Desktop\Jpie\UnityPractice\Shunger-Game\kidnap\Assets\Texts\Afternoon.txt";
                    break;
                case DayTime.evening:
                    path = @"C:\Users\user2\Desktop\Jpie\UnityPractice\Shunger-Game\kidnap\Assets\Texts\Evening.txt";
                    break;
            }

            return path;
        }

    }

}
