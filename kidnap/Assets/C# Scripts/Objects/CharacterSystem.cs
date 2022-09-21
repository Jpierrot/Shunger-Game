using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Kidnap
{
    [System.Serializable]
    public class Characters
    {

        public Sprite characterImage;
        public string characterName;


        public Characters(int num, Sprite image, string name)
        {
            characterImage = image;
            characterName = name;
        } 
    }

    public class CharacterSystem : MonoBehaviour
    {
        [SerializeField]
        List<Characters> characters;

        Characters Player;

        private void Awake()
        {
            CharacterUpdate();
            CharPresenter.Instance.SetCharacters(characters.ToArray());
        }

        public void SetPlayer()
        {
            var a = CharPresenter.Instance.GetCharInfo();
            int num = System.Convert.ToInt32(a);
            Player = characters[num];
        }

        void CharacterUpdate()
        {
            if (characters != null)
            {
                for (int i = 0; i < characters.Count; i++)
                {
                    Debug.Log($"{i} 번째 캐릭터가 등록됨" +
                        $"캐릭터 이름 : {characters[i].characterName}");
                }
            }
            else
                Debug.Log("캐릭터 데이터가 없습니다.");
        }




    }
}
