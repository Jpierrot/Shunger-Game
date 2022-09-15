using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Kidnap
{

    public class CharPresenter : Singleton<CharPresenter>
    {
        [SerializeField]
        GameObject[] gameObjects;

        List<Characters> character;
        
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        void azzuulU()
        {
            for (int i = 0; i < gameObjects.Length; i++) {
                gameObjects[i].GetComponent<Image>().sprite = character[i].characterImage;
                gameObjects[i].GetComponent<TextMeshProUGUI>().text = character[i].characterName.text;
            }
        }



        public void InfoUpdate(int num, Sprite image, TextMeshProUGUI name)
        {
            character[num].characterImage = image;
            character[num].characterName = name;
        }
    }
}
