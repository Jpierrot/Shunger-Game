using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Kidnap
{
    /// <summary>
    /// 데이터의 복사본이 아닌, 원본을 수정해야 함으로 클래스 데이터를 사용하는게 적합.
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
    /// 뷰에 있는 그래프 <-> SupportSystem 사이에서 데이터를 받아오는 프레젠터
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