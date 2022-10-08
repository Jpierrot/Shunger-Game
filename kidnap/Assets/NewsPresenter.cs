using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Kidnap {

    public class NewsPresenter : MonoBehaviour
    {
        [SerializeField]
        Transform parent;

        [SerializeField]
        GameObject TextObj;

        [SerializeField]
        int time;

        string[] _texts;

        string _path;


        void Start()
        {
            StartCoroutine(CheckMessage());
        }

        IEnumerator CheckMessage()
        {
            while (true)
            {
                _path = NewsSystem.Instance.GetText(DaySystem.Instance.curTime);
                _texts = System.IO.File.ReadAllLines(_path);

                if (parent.transform.childCount < 1)
                {
                    var a = Instantiate(TextObj, parent);
                    a.GetComponent<TextMeshProUGUI>().text = _texts[Random.Range(0, _texts.Length - 1)];
                }

                
                yield return new WaitForSecondsRealtime(1);
            }
        }
    }

}
