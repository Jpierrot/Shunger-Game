using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;

namespace Kidnap
{
    /// <summary>
    /// 
    /// </summary>
    public class NewsData : Singleton<NewsData>
    {
        /// <summary>
        /// 텍스트 파일 경로를 가지고 있는 변수입니다.
        /// 뉴스 기능에서 필요한 텍스트를 불러올 때 사용됩니다.
        /// </summary>
        string path = @"C:\Users\user2\Desktop\Jpie\UnityPractice\Shunger-Game\kidnap\Assets\Texts\Morning.txt";

        /// <summary>
        /// 다른 클래스에 텍스트를 불러오려고 할 때 사용되는 메소드입니다.
        /// 입력 받은 시간대에 따라 알맞은 텍스트로 변환해줍니다.
        /// 시간대가 변할 때 마다 다시 호출됩니다.
        /// </summary>
        /// <param name="time">입력 받을 시간대</param>
        /// <returns>입력 받은 시간대에 맞는 텍스트 파일 경로</returns>
        public string GetText(DayTime time)
        {
            switch (time)
            {
                //아침일 경우
                case DayTime.Morning :
                    path = @"C:\Users\user2\Desktop\Jpie\UnityPractice\Shunger-Game\kidnap\Assets\Texts\Morning.txt";
                    break;
                //점심일 경우
                case DayTime.Afternoon:
                    path = @"C:\Users\user2\Desktop\Jpie\UnityPractice\Shunger-Game\kidnap\Assets\Texts\Afternoon.txt";
                    break;
                //저녁일 경우
                case DayTime.evening:
                    path = @"C:\Users\user2\Desktop\Jpie\UnityPractice\Shunger-Game\kidnap\Assets\Texts\Evening.txt";
                    break;
            }

            //switch Case 구문에서 입력한 대로 반환
            return path;
        }

    }

}
