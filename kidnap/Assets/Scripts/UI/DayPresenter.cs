using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Kidnap
{
    /// <summary>
    /// Day System을 추적하는 프레젠터.
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

        void Start()
        {
            CheckUI();
            //dayImage = GetComponent<Image>();
        }

        public void OnActed(int daycount)
        {
            DaySystem.Instance.OverTime();
            CheckUI();
        }

        void CheckUI()
        {
            DayText.text = $"<b>{DaySystem.Instance.curDay}</b> 일";
            int num = (int)DaySystem.Instance.curTime;
            _dayImage.sprite = _dayImages[num];
        }

        public void OnDayChanged()
        {
            DaySystem.Instance.OverDay();
            CheckUI();
        }

    }
}
