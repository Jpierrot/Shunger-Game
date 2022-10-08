using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kidnap
{

    

    public class NewsSystem : Singleton<NewsSystem>
    {

        public string text;

        string path = @"C:\Users\user2\Desktop\Jpie\UnityPractice\Shunger-Game\kidnap\Assets\Texts\Afternoon.txt";

        string[] texts;

        void Awake()
        {
            
        }

        void Update()
        {

        }

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
