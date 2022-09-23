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
        GameObject confirm;
        
        [SerializeField]
        GameObject[] gameObjects;

        Image confirmImage;

        private int playerNum = 99;

        private Characters[] characters;

        private void Start()
        {
            confirmImage = confirm.GetComponent<Image>();

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

            /*
            foreach (var i in gameObjects)
            {

                if (gameObjects[num] == i) 
                { 
                    i.transform.GetChild(0).gameObject.SetActive(true); 
                }
                else
                    i.transform.GetChild(0).gameObject.SetActive(false);
            }
            */

            for(int i = 0; i < gameObjects.Length; i++)
            {
                if(i == num)
                    gameObjects[i].transform.GetChild(0).gameObject.SetActive(true);
                else
                    gameObjects[i].transform.GetChild(0).gameObject.SetActive(false);
            }

            playerNum = num + 1;
            confirmImage.color = new Color(1 , (float)180 / 255 , (float)180 / 255, 1);
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
