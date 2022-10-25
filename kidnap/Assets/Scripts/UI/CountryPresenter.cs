using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StructTypes;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

namespace Kidnap
{

    public class CountryPresenter : MonoBehaviour
    {
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
            //Rect = parent.GetComponent<RectTransform>();
            list = CountrySystem.Instance.CDlist;
            SetCountry();
        }

        void SetCountry()
        {

            foreach(var value in list)
            {
                var obj = Instantiate(CountryObj, parent);
                obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = value.CountryName;
                obj.transform.GetChild(1).GetComponent<Image>().sprite = value.CountryImage;
                obj.transform.GetChild(2).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = value.CountryPop.ToString();

                obj.GetComponent<Button>().onClick.AddListener(Onclick_event.Invoke);

            }

        }

    }
}
