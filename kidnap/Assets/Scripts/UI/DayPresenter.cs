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

        void Start()
        { 
            // 최초 UI 정렬
            CheckUI();

            // 인스턴스 받아옴
            var ins = DaySystem.Instance;

            // DaySystem에서 이벤트가 발생시 프레젠터도 호출
            ins.StartDayEvents.AddListener(CheckUI);
            ins.OvertimeEvents.AddListener(OnActed);
        }

        /// <summary>
        /// 행동력을 소모할때마다 시간대를 변경하는 메소드
        /// </summary>
        public void OnActed()
        {             
            CheckUI();
        }

        /// <summary>
        /// UI 업데이트를 담당하는 메소드
        /// </summary>
        void CheckUI()
        {
            // day 게임 오브젝트에 표시될 텍스트 지정
            DayText.text = $"<b>{DaySystem.Instance.curDay}</b> 일";

            // 사전에 정의된 시간대별 day Sprite로 변경
            int num = (int)DaySystem.Instance.CurTime;
            _dayImage.sprite = _dayImages[num];

            // 사전에 정의된 시간대별 day 색상 등록
            var a = DaySystem.Instance.TimeColor((DayTime)num);
            a.a = 1;

            // day를 표시하는 게임 오브젝트의 색깔 변경
            _panel.GetComponent<Image>().color = a;
        }

        
    }
}
