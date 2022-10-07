using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Kidnap {

    public class NewsPresenter : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI text;

        [SerializeField]
        int time;

        string[] texts;
        string path;

        void Start()
        {
            StartCoroutine(CheckMessage());
        }

        private void Update()
        {
            
        }

        IEnumerator CheckMessage()
        {
            while (true)
            {
                path = NewsSystem.Instance.GetText(DaySystem.Instance.curTime);
                texts = System.IO.File.ReadAllLines(path);
                text.text = texts[Random.Range(0, texts.Length - 1)];
                yield return new WaitForSeconds(time);
            }
        }
    }

}
