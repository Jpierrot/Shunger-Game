using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Kidnap
{
    public class PlayerPresenter : MonoBehaviour
    {
        [SerializeField]
        GameObject playerImage;

        [SerializeField]
        TextMeshProUGUI playerName;

        void Start()
        {
            SetPlayerProfil();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void SetPlayerProfil()
        {
            playerImage.GetComponent<Image>().sprite = CharacterSystem.Instance.player.characterImage;
            playerName.text = CharacterSystem.Instance.player.characterName;
        }
    }
}
