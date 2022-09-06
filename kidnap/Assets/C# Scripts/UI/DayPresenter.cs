using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Kidnap
{

    public class DayPresenter : MonoBehaviour
    {
        //MVP에서 프레젠터를 담당하는 요소 

        //현재 View에 나타나 있는 아침,점심,저녁 이미지
        public Image dayImage;

        //오늘이 며칠인지 관한 텍스트
        public TextMeshProUGUI dayText;

        // Start is called before the first frame update
        void Start()
        {

        }

        public void OnTimeChanged(DayTime dayTime)
        {

        }



        // Update is called once per frame
        void Update()
        {

        }
    }
}
