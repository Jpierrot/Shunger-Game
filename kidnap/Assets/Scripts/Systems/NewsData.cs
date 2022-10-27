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
        /// �ؽ�Ʈ ���� ��θ� ������ �ִ� �����Դϴ�.
        /// ���� ��ɿ��� �ʿ��� �ؽ�Ʈ�� �ҷ��� �� ���˴ϴ�.
        /// </summary>
        string path = @"C:\Users\user2\Desktop\Jpie\UnityPractice\Shunger-Game\kidnap\Assets\Texts\Morning.txt";

        /// <summary>
        /// �ٸ� Ŭ������ �ؽ�Ʈ�� �ҷ������� �� �� ���Ǵ� �޼ҵ��Դϴ�.
        /// �Է� ���� �ð��뿡 ���� �˸��� �ؽ�Ʈ�� ��ȯ���ݴϴ�.
        /// �ð��밡 ���� �� ���� �ٽ� ȣ��˴ϴ�.
        /// </summary>
        /// <param name="time">�Է� ���� �ð���</param>
        /// <returns>�Է� ���� �ð��뿡 �´� �ؽ�Ʈ ���� ���</returns>
        public string GetText(DayTime time)
        {
            switch (time)
            {
                //��ħ�� ���
                case DayTime.Morning :
                    path = @"C:\Users\user2\Desktop\Jpie\UnityPractice\Shunger-Game\kidnap\Assets\Texts\Morning.txt";
                    break;
                //������ ���
                case DayTime.Afternoon:
                    path = @"C:\Users\user2\Desktop\Jpie\UnityPractice\Shunger-Game\kidnap\Assets\Texts\Afternoon.txt";
                    break;
                //������ ���
                case DayTime.evening:
                    path = @"C:\Users\user2\Desktop\Jpie\UnityPractice\Shunger-Game\kidnap\Assets\Texts\Evening.txt";
                    break;
            }

            //switch Case �������� �Է��� ��� ��ȯ
            return path;
        }

    }

}
