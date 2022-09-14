using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Kidnap
{
    //MVP에서 프레젠터를 담당하는 요소 
    public class DayPresenter : Singleton<DayPresenter>
    {

        [SerializeField]
        private GameObject panel;

        //현재 View에 나타나 있는 아침,점심,저녁 이미지
        [SerializeField]
        private Image dayImage;

        [SerializeField]
        private Sprite [] dayImages;

        //오늘이 며칠인지 관한 텍스트
        public TextMeshProUGUI dayText;

        void Start()
        {
            //dayImage = GetComponent<Image>();
        }

        public void OnDayChanged(int daycount)
        {
            dayText.text = "Day <b>" + daycount + "</b>";
        }

        public void OnTimeChanged(DayTime dayTime)
        {
            dayImage.sprite = dayImages[((int)dayTime)];
        }

    }
}
