using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace Kidnap {

    /// <summary>
    /// 선 그래프를 그리는 클래스
    /// </summary>
    public class GraphGenerator : MonoBehaviour
    {
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

        void DestroyDots()
        {
            for(int i = 0; i < dots_Parent.transform.childCount; i++)
            {
                Destroy(dots_Parent.transform.GetChild(i).gameObject);
            }
        }

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
