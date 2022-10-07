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
            StartCoroutine(MessageWriter());
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

        IEnumerator MessageWriter()
        {
            int count = 0;
            texts = System.IO.File.ReadAllLines(path);

            while (true)
            {
                text = texts[count];
                yield return new WaitForSecondsRealtime(5f);
                count++;

                if (count == texts.Length) count = 0;
            }

        }

    }

}
