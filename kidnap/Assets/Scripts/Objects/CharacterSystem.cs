using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Kidnap
{
    /// <summary>
    /// 데이터의 수정이 이루어지기 때문에 클래스가 적합
    /// </summary>
    [System.Serializable]
    public class Characters
    {
        public Chars type;

        public Sprite characterImage;
        public string characterName;

        public Characters(Sprite image, string name, Chars type)
        {
            characterImage = image;
            characterName = name;
            this.type = type;
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

            private set => player = value;
        }

        public void PlayerSet(int num)
        {
            player = characters[num - 1];
            player.type = characters[num - 1].type;

        }

        private void Awake()
        {
            CharacterUpdate();
            DontDestroyOnLoad(this.gameObject);
            SetCharacters();
        }

        void SetCharacters()
        {

            for(int i = 0; i < characters.Count; i++)
            {
                characters[i].type = (Chars)i;
            }
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
