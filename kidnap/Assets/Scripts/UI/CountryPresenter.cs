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
    /// ������ ������ ��ư���� �����ϰ�
    /// �̺�Ʈ ó���� �ο��ϴ� Ŭ���� �Դϴ�
    /// ��� Ŭ���� : ShowManager, CountrySystem
    /// </summary>
    public class CountryPresenter : MonoBehaviour
    {
        /// <summary>
        /// ��ư Ŭ���� ����� �̺�Ʈ�� ������ �ִ� �븮���Դϴ�.
        /// </summary>
        [SerializeField]
        UnityEvent Onclick_event;

        //UI���� ��ġ�� ���
        [SerializeField]
        Transform parent;

        //��ġ�� UI ������Ʈ
        [SerializeField]
        GameObject CountryObj;

        /// <summary>
        /// ������ 
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
            string num = a + "0����";

            return num;
        }

        void SetCountry()
        {
            ///��ư�� �̺�Ʈ �ο�
            foreach (var value in list)
            {

                //�α����� �ۼ��ϴ� string �ؽ�Ʈ
                string poptext = TransPop(value.CountryPop);

                var obj = Instantiate(CountryObj, parent);

               
                //��ư�� ������� �ο��ϴ� ��ũ��Ʈ
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
