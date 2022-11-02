using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Kidnap {

    /// <summary>
    /// 선 그래프를 그리는 클래스입니다.
    /// 
    /// 지금 클래스의 구현 방식은 매일 새로운 점을 찍어서 그래프를 생성하는 것으로 하고있습니다.
    /// 
    /// 허나 기존에 있던 점은 굳이 지울 필요가 없는 데이터기 때문에
    /// 새롭게 추가되는 데이터에 관한 좌표만 추가하는 방식으로 변경하였으면 합니다.
    /// </summary>
    public class GraphGenerator : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI Graph_text;

        [SerializeField]
        GameObject dayObj;

        // 점 오브젝트
        [SerializeField]
        GameObject dotObj;

        // 선 오브젝트
        [SerializeField]
        GameObject Line;

        // 선 오브젝트들의 부모 오브젝트
        [SerializeField]
        GameObject Lines_Parent;

        // 점 오브젝트들의 부모 오브젝트
        [SerializeField]
        GameObject dots_Parent;

        // 점의 좌표
        [SerializeField]
        RectTransform DotArea;

        private float[] support = new float[10];

        private float _graphWidth;

        private float _graphHeight;

        /// <summary>
        /// 그래프에 기존에 생성해놨던 점들을 삭제하는 메소드
        /// </summary>
        void DestroyDots()
        {
            for(int i = 0; i < dots_Parent.transform.childCount; i++)
            {
                Destroy(dots_Parent.transform.GetChild(i).gameObject);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        void DrawDots()
        {
            DestroyDots();

            int num = DaySystem.Instance.curDay;

            for (int i = 0; i < num; i++)
            {
                var dot = Instantiate(dotObj, dots_Parent.transform, true);
                dot.transform.localScale = Vector3.one;

                var day = Instantiate(dayObj, dots_Parent.transform, true);
             
                RectTransform dotRT = dot.GetComponent<RectTransform>();
                RectTransform dayRT = day.GetComponent<RectTransform>();

                var value = support[i] * 0.01f;

                var x = -_graphWidth * 0.5f + (_graphWidth * 0.09f) * (i + 1) + 12.5f;
                var y = -_graphHeight * 0.5f + _graphHeight * value;

                dot.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = string.Format("{0:P1}", value);
                day.GetComponent<TextMeshProUGUI>().text = $"{i + 1}일차"; 

                dotRT.anchoredPosition = new Vector2(x, y);
                dayRT.anchoredPosition = new Vector2(x, -_graphHeight * 0.5f);

                //var line = Instantiate(Line, Lines_Parent.transform, true);
            }

        }

        /// <summary>
        /// 게임 시작전 데이터 받아오기
        /// 게임 시작전 이 그래프가 업데이트 되는 순간을 지정.
        /// </summary>
        public void Awake()
        {
            var ins = DaySystem.Instance;
            ins.OverDayEvents.AddListener(PlusGraph);
            ins.OverDayEvents.AddListener(DrawDots);
        }

        /// <summary>
        /// 그래프에 인덱스를 추가하는 메소드
        /// </summary>
        public void PlusGraph()
        {
            support[DaySystem.Instance.curDay - 1] = CountrySystem.Instance.SupportCalc(CharacterSystem.Instance.player.type);
        }

        private void Start()
        {
            _graphHeight = DotArea.rect.height;
            _graphWidth = DotArea.rect.width;
            PlusGraph();
            DrawDots();
        }

    }
}
