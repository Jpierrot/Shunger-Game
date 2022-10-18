using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StructTypes;
using TMPro;
using UnityEngine.UI;

namespace Kidnap
{

    public class CountryPresenter : MonoBehaviour
    {
        //UI���� ��ġ�� ���
        [SerializeField]
        Transform parent;

        //��ġ�� UI ������Ʈ
        [SerializeField]
        GameObject CountryObj;

        List<CountryDatas> list;

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
            }

        }

    }
}
