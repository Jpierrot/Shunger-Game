using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EnumTypes;

namespace Kidnap
{
    /// <summary>
    /// �������� ������ �̷������ ������ Ŭ������ ����
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

        //�ٸ� Ŭ�������� ĳ���� ���� ������ ����Ʈ
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

        /// <summary>
        /// ������ ���� �ڵ�� Awake���� ����
        /// </summary>
        private void Awake()
        {
            CharacterUpdate();
            DontDestroyOnLoad(this.gameObject);
            SetCharacters();
        }

        /// <summary>
        /// ĳ���͵� Ÿ�� �� ����
        /// </summary>
        void SetCharacters()
        {
            for(int i = 0; i < characters.Count; i++)
            {
                characters[i].type = (Chars)i;
            }
        }

        /// <summary>
        /// ĳ���Ϳ� ���� ����� ������ �˻�
        /// </summary>
        void CharacterUpdate()
        {
            if (characters == null)
            {
                Debug.Log("ĳ���� �����Ͱ� �����ϴ�.");
                return;
            }
            /*    foreach(var value in characters)
                {
                    Debug.Log($"{characters.IndexOf(value) + 1} ��° ĳ���Ͱ� ��ϵ�" +
                 $"ĳ���� �̸� : {value.characterName}");
                }*/

            for (int i = 0; i < characters.Count; i++)
            {
                Debug.Log($"{i + 1} ��° ĳ���Ͱ� ��ϵ�\n" +
                    $"ĳ���� �̸� : {characters[i].characterName}");
            }
        }

    }
}
