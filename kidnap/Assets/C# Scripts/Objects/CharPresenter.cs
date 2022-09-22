using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Kidnap
{

    //뷰에서 캐릭터에 대한 인풋과 정보를 받아오는 프레젠터
    public class CharPresenter : MonoBehaviour
    {

        private GameObject CharObj;

        [SerializeField]
        GameObject[] gameObjects;

        private int playerNum = 99;

        private Characters[] characters;

        private void Start()
        {
            //순차정렬을 편하게 하기 위해서 List 형태로 있는 캐릭터 데이터를 배열로 받아옴.
            characters = CharacterSystem.Instance.characters.ToArray();
            CharactersSet();
        }

        /// <summary>
        /// 시스템에서 받아온 데이터를 뷰에 넘겨주기
        /// </summary>
        public void CharactersSet()
        {
            if(gameObjects.Length != characters.Length)
            {
                Debug.Log("인덱스 갯수가 일치하지 않음");
                return;
            }

            for (int i = 0; i < gameObjects.Length; i++) {
                gameObjects[i].transform.GetChild(1).GetComponent<Image>().sprite = characters[i].characterImage;
                gameObjects[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = characters[i].characterName;
            }
        }

        public void PlayerSet(int num)
        {
            playerNum = num;
        }

        public void PlayerConfirm()
        {
            if(playerNum == 99)
            {
                Debug.LogError("캐릭터를 선택하지 않았습니다.");
                return;
            }

            CharacterSystem.Instance.PlayerSet(playerNum);
        }

    }
}
