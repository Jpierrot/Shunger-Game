using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Kidnap
{
    //MVP���� �������͸� ����ϴ� ��� 
    public class DayPresenter : Singleton<DayPresenter>
    {

        [SerializeField]
        private GameObject panel;

        //���� View�� ��Ÿ�� �ִ� ��ħ,����,���� �̹���
        [SerializeField]
        private Image dayImage;

        [SerializeField]
        private Sprite [] dayImages;

        //������ ��ĥ���� ���� �ؽ�Ʈ
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
