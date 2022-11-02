using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ClassData;
using EnumTypes;

namespace Kidnap
{
    
    public class CharacterSystem : Singleton<CharacterSystem>
    {

        //�ٸ� Ŭ�������� ĳ���� ���� ������ ����Ʈ
        public List<Characters> characters;

        /// <summary>
        /// �÷��̾ ���� �����͸� �ӽ� ������ 
        /// </summary>
        public Characters player;

        public Chars playerType;

        /// <summary>
        /// �÷��̾� ������ ������ ó����
        /// </summary>
        public Characters Player
        {
            get
            {
                return player;
            }

            private set => 
                player = value;
        }

        /// <summary>
        /// �÷��̾� Ȯ��
        /// </summary>
        /// <param name="num"></param>
        public void PlayerSet(int num)
        {
            player = characters[num - 1];
            player.type = characters[num - 1].type;
            playerType = player.type;

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

            for (int i = 0; i < characters.Count; i++)
            {
                Debug.Log($"{i + 1} ��° ĳ���Ͱ� ��ϵ�\n" +
                    $"ĳ���� �̸� : {characters[i].characterName}");
            }
        }

    }
}
