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

        //다른 클래스에서 캐릭터 값을 참조할 리스트
        public List<Characters> characters;

        /// <summary>
        /// 플레이어에 관한 데이터를 임시 보관할 
        /// </summary>
        public Characters player;

        public Chars playerType;

        /// <summary>
        /// 플레이어 데이터 변수를 처리할
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
        /// 플레이어 확정
        /// </summary>
        /// <param name="num"></param>
        public void PlayerSet(int num)
        {
            player = characters[num - 1];
            player.type = characters[num - 1].type;
            playerType = player.type;

        }

        /// <summary>
        /// 데이터 관련 코드는 Awake에서 동작
        /// </summary>
        private void Awake()
        {
            CharacterUpdate();
            DontDestroyOnLoad(this.gameObject);
            SetCharacters();
        }

        /// <summary>
        /// 캐릭터들 타입 재 정렬
        /// </summary>
        void SetCharacters()
        {
            for(int i = 0; i < characters.Count; i++)
            {
                characters[i].type = (Chars)i;
            }
        }

        /// <summary>
        /// 캐릭터에 값이 제대로 들어갔는지 검사
        /// </summary>
        void CharacterUpdate()
        {
            if (characters == null)
            {
                Debug.Log("캐릭터 데이터가 없습니다.");
                return;
            }

            for (int i = 0; i < characters.Count; i++)
            {
                Debug.Log($"{i + 1} 번째 캐릭터가 등록됨\n" +
                    $"캐릭터 이름 : {characters[i].characterName}");
            }
        }

    }
}
