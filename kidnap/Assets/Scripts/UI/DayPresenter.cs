using UnityEngine;
using EnumTypes;
using UnityEngine.UI;
using TMPro;

namespace Kidnap
{
    /// <summary>
    /// DaySystem�� �ִ� �����Ϳ� UI�� �����ϴ� ��������.
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
            // ���� UI ����
            CheckUI();

            // �ν��Ͻ� �޾ƿ�
            var ins = DaySystem.Instance;

            // DaySystem���� �̺�Ʈ�� �߻��� �������͵� ȣ��
            ins.StartDayEvents.AddListener(CheckUI);
            ins.OvertimeEvents.AddListener(OnActed);
        }

        /// <summary>
        /// �ൿ���� �Ҹ��Ҷ����� �ð��븦 �����ϴ� �޼ҵ�
        /// </summary>
        public void OnActed()
        {             
            CheckUI();
        }

        /// <summary>
        /// UI ������Ʈ�� ����ϴ� �޼ҵ�
        /// </summary>
        void CheckUI()
        {
            // day ���� ������Ʈ�� ǥ�õ� �ؽ�Ʈ ����
            DayText.text = $"<b>{DaySystem.Instance.curDay}</b> ��";

            // ������ ���ǵ� �ð��뺰 day Sprite�� ����
            int num = (int)DaySystem.Instance.CurTime;
            _dayImage.sprite = _dayImages[num];

            // ������ ���ǵ� �ð��뺰 day ���� ���
            var a = DaySystem.Instance.TimeColor((DayTime)num);
            a.a = 1;

            // day�� ǥ���ϴ� ���� ������Ʈ�� ���� ����
            _panel.GetComponent<Image>().color = a;
        }

        
    }
}
