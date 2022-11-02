using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClassData;
using TMPro;
using EnumTypes;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

namespace Kidnap
{
    /// <summary>
    /// 지역에 관련한 버튼들을 생성하고
    /// 이벤트 처리를 부여하는 클래스 입니다
    /// 사용 클래스 : ShowManager, CountrySystem
    /// </summary>
    public class CountryPresenter : MonoBehaviour
    {
        /// <summary>
        /// 버튼 클릭시 발행될 이벤트를 가지고 있는 대리자입니다.
        /// </summary>
        [SerializeField]
        UnityEvent Onclick_event;

        //UI들이 배치될 장소
        [SerializeField]
        Transform parent;

        //배치될 UI 오브젝트
        [SerializeField]
        GameObject CountryObj;

        /// <summary>
        /// 가져올 
        /// </summary>
        List<CountryData> list;

        void Start()
        {
            Onclick_event.AddListener(DaySystem.Instance.OverTime);

            //Rect = parent.GetComponent<RectTransform>();
            list = CountrySystem.Instance.CDlist;
            SetCountry();
        }

        void SetShow(int index)
        {
            ShowManager.Instance.MakeShow(ShowType.visit, index);
        }

        string TransPop(int pop)
        {
            

            int a = pop / 100000;
            string num = a + "0만명";

            return num;
        }

        void SetCountry()
        {
            ///버튼에 이벤트 부여
            foreach (var value in list)
            {

                //인구수를 작성하는 string 텍스트
                string poptext = TransPop(value.CountryPop);

                var obj = Instantiate(CountryObj, parent);

               
                //버튼에 내용들을 부여하는 스크립트
                obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = value.CountryName;
                obj.transform.GetChild(1).GetComponent<Image>().sprite = value.CountryImage;
                obj.transform.GetChild(2).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = poptext;
                  
                obj.name = list.IndexOf(value).ToString();

                obj.GetComponent<Button>().onClick.AddListener(Onclick_event.Invoke);
                obj.GetComponent<Button>().onClick.AddListener(
                    delegate
                    { 
                        SetShow(list.IndexOf(value)); 
                    });
            }

        }

    }
}
