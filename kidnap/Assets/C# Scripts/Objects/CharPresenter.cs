using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Kidnap
{

    //�信�� ĳ���Ϳ� ���� ��ǲ�� ������ �޾ƿ��� ��������
    public class CharPresenter : MonoBehaviour
    {

        private GameObject CharObj;

        [SerializeField]
        GameObject[] gameObjects;

        private int playerNum = 99;

        private Characters[] characters;

        private void Start()
        {
            //���������� ���ϰ� �ϱ� ���ؼ� List ���·� �ִ� ĳ���� �����͸� �迭�� �޾ƿ�.
            characters = CharacterSystem.Instance.characters.ToArray();
            CharactersSet();
        }

        /// <summary>
        /// �ý��ۿ��� �޾ƿ� �����͸� �信 �Ѱ��ֱ�
        /// </summary>
        public void CharactersSet()
        {
            if(gameObjects.Length != characters.Length)
            {
                Debug.Log("�ε��� ������ ��ġ���� ����");
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
                Debug.LogError("ĳ���͸� �������� �ʾҽ��ϴ�.");
                return;
            }

            CharacterSystem.Instance.PlayerSet(playerNum);
        }

    }
}
