using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace Kidnap {

    public class GraphGenerator : MonoBehaviour
    {
        [SerializeField]
        GameObject dot;

        [SerializeField]
        GameObject Line;

        [SerializeField]
        GameObject Lines_Parent;

        [SerializeField]
        GameObject dots_Parent;

        [SerializeField]
        RectTransform DotRect;

        private float[] support = new float[10];

        float _graphWidth;

        float _graphHeight;

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
                var a = Instantiate(dot, dots_Parent.transform, true);
                a.transform.localScale = Vector3.one;
             
                RectTransform dotRT = a.GetComponent<RectTransform>();

                var value = support[i] * 0.01f;

                var x = -_graphWidth * 0.5f + (_graphWidth * 0.09f) * (i + 1) + 12.5f;
                var y = -_graphHeight * 0.5f + _graphHeight * value;

                a.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = string.Format("{0:P1}", value);

                dotRT.anchoredPosition = new Vector2(x, y);

                //var line = Instantiate(Line, Lines_Parent.transform, true);
            }

        }

        public void Awake()
        {
            DaySystem.Instance.OverDayEvents.AddListener(plusGraph);
            DaySystem.Instance.OverDayEvents.AddListener(DrawDots);
        }

        public void plusGraph()
        {
            support[DaySystem.Instance.curDay - 1] = CountrySystem.Instance.SupportCalc(CharacterSystem.Instance.player.type);
        }

        private void Start()
        {
            _graphHeight = DotRect.rect.height;
            _graphWidth = DotRect.rect.width;
            plusGraph();
            DrawDots();
        }

    }
}
