using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;
using UnityEngine.UI;
using TMPro;

namespace Kidnap
{
    /// <summary>
    /// DaySystem에 있는 데이터와 UI를 연결하는 프레젠터.
    /// </summary>
    public class DayPresenter : MonoBehaviour
    {

        [SerializeField]
        private GameObject _panel;

        //현재 View에 나타나 있는 아침,점심,저녁 이미지
        [SerializeField]
        private Image _dayImage;

        [SerializeField]
        private Sprite [] _dayImages;

        //오늘이 며칠인지 관한 텍스트
        public TextMeshProUGUI DayText;

        public TextMeshProUGUI GraphText;

        void Start()
        { 
            CheckUI();
        }

        /// <summary>
        /// 행동력을 소모할때마다 시간대를 변경하는 메소드
        /// </summary>
        public void OnActed()
        {
            DaySystem.Instance.OverTime();
            CheckUI();
        }

        /// <summary>
        /// UI 업데이트를 담당하는 메소드
        /// </summary>
        void CheckUI()
        {
            DayText.text = $"<b>{DaySystem.Instance.curDay}</b> 일";
            int num = (int)DaySystem.Instance.curTime;
            _dayImage.sprite = _dayImages[num];
            var a = DaySystem.Instance.TimeColor((DayTime)num);
            a.a = 1;
            _panel.GetComponent<Image>().color = a;
        }

        /// <summary>
        /// 날짜 변경
        /// </summary>
        public void OnDayChanged()
        {
            DaySystem.Instance.OverDay();
            GraphText.text = "(" + DaySystem.Instance.curDay + "일차)";
            CheckUI();
        }

    }
}
