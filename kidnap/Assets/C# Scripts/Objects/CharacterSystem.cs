using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Kidnap
{
    [System.Serializable]
    public struct Characters
    {

        public Sprite characterImage;
        public string characterName;

        public Characters(Sprite image, string name)
        {
            characterImage = image;
            characterName = name;
        }
    }

    public class CharacterSystem : Singleton<CharacterSystem>
    {

        //다른 클래스에서 캐릭터 값을 참조할 리스트
        public List<Characters> characters;

        public Characters player;

        public Characters Player
        {
            get
            {
                return player;
            }

            private set
            {
                player = value;
            }
        }

        public void PlayerSet(int num)
        {
            player = characters[num - 1];
        }



        private void Awake()
        {
            CharacterUpdate();
            DontDestroyOnLoad(this.gameObject);
        }

        
        void CharacterUpdate()
        {
            if (characters == null)
            {
                Debug.Log("캐릭터 데이터가 없습니다.");
                return;
            }
            
            /*    foreach(var value in characters)
                {
                    Debug.Log($"{characters.IndexOf(value) + 1} 번째 캐릭터가 등록됨" +
                 $"캐릭터 이름 : {value.characterName}");
                }*/

            for (int i = 0; i < characters.Count; i++)
            {
                Debug.Log($"{i + 1} 번째 캐릭터가 등록됨\n" +
                    $"캐릭터 이름 : {characters[i].characterName}");
            }
        }

    }
}
