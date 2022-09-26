using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Kidnap
{
    /// <summary>
    /// Day System�� �����ϴ� ��������.
    /// </summary>
    public class DayPresenter : MonoBehaviour
    {

        [SerializeField]
        private GameObject _panel;

        //���� View�� ��Ÿ�� �ִ� ��ħ,����,���� �̹���
        [SerializeField]
        private Image _dayImage;

        [SerializeField]
        private Sprite [] _dayImages;

        //������ ��ĥ���� ���� �ؽ�Ʈ
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
            DayText.text = $"<b>{DaySystem.Instance.curDay}</b> ��";
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
