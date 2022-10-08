using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Kidnap
{
    /// <summary>
    /// �������� ���纻�� �ƴ�, ������ �����ؾ� ������ Ŭ���� �����͸� ����ϴ°� ����.
    /// </summary>
    [System.Serializable]
    public class Charts
    {
        public TextMeshProUGUI Name;
        public Slider Slider;
        public TextMeshProUGUI score;

        public Charts(TextMeshProUGUI name, int per)
        {
            Name = name;
            Slider.value = (float)(per * 0.01);
            Debug.Log(Slider.value);
        }
    }

    /// <summary>
    /// �信 �ִ� �׷��� <-> SupportSystem ���̿��� �����͸� �޾ƿ��� ��������
    /// </summary>
    public class GraphPresenter : MonoBehaviour
    {
        [SerializeField]
        public List<Charts> charts;

        void SetPer()
        {
            foreach (var i in charts)
            {
                float value = CountrySystem.Instance.SupportCalc((Chars)charts.IndexOf(i)) * 0.01f;
                i.Slider.value = value;
                i.Name.text = CharacterSystem.Instance.characters[charts.IndexOf(i)].characterName;
                i.score.text = string.Format("{0:P1}", value);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            SetPer();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}