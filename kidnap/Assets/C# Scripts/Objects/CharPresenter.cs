using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Kidnap
{

    public class CharPresenter : Singleton<CharPresenter>
    {

        GameObject CharObj;

        [SerializeField]
        GameObject[] gameObjects;
        
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }



        public void SetCharacters(Characters [] characters)
        {
            for (int i = 0; i < gameObjects.Length; i++) {
                gameObjects[i].transform.GetChild(1).GetComponent<Image>().sprite = characters[i].characterImage;
                gameObjects[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = characters[i].characterName;
            }
        }
        

        public void SetCharInfo(GameObject obj)
        {
            CharObj = obj;
        }

        [HideInInspector]
        public string GetCharInfo()
        {
            return CharObj.name;
        }

        public void InfoUpdate(Sprite image, string name)
        {
            
        }
    }
}
