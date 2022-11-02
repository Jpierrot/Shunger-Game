using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Kidnap {

    /// <summary>
    /// �� �׷����� �׸��� Ŭ�����Դϴ�.
    /// 
    /// ���� Ŭ������ ���� ����� ���� ���ο� ���� �� �׷����� �����ϴ� ������ �ϰ��ֽ��ϴ�.
    /// 
    /// �㳪 ������ �ִ� ���� ���� ���� �ʿ䰡 ���� �����ͱ� ������
    /// ���Ӱ� �߰��Ǵ� �����Ϳ� ���� ��ǥ�� �߰��ϴ� ������� �����Ͽ����� �մϴ�.
    /// </summary>
    public class GraphGenerator : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI Graph_text;

        [SerializeField]
        GameObject dayObj;

        // �� ������Ʈ
        [SerializeField]
        GameObject dotObj;

        // �� ������Ʈ
        [SerializeField]
        GameObject Line;

        // �� ������Ʈ���� �θ� ������Ʈ
        [SerializeField]
        GameObject Lines_Parent;

        // �� ������Ʈ���� �θ� ������Ʈ
        [SerializeField]
        GameObject dots_Parent;

        // ���� ��ǥ
        [SerializeField]
        RectTransform DotArea;

        private float[] support = new float[10];

        private float _graphWidth;

        private float _graphHeight;

        /// <summary>
        /// �׷����� ������ �����س��� ������ �����ϴ� �޼ҵ�
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
                day.GetComponent<TextMeshProUGUI>().text = $"{i + 1}����"; 

                dotRT.anchoredPosition = new Vector2(x, y);
                dayRT.anchoredPosition = new Vector2(x, -_graphHeight * 0.5f);

                //var line = Instantiate(Line, Lines_Parent.transform, true);
            }

        }

        /// <summary>
        /// ���� ������ ������ �޾ƿ���
        /// ���� ������ �� �׷����� ������Ʈ �Ǵ� ������ ����.
        /// </summary>
        public void Awake()
        {
            var ins = DaySystem.Instance;
            ins.OverDayEvents.AddListener(PlusGraph);
            ins.OverDayEvents.AddListener(DrawDots);
        }

        /// <summary>
        /// �׷����� �ε����� �߰��ϴ� �޼ҵ�
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
