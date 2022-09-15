using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Kidnap
{
    [System.Serializable]
    class Characters
    {
        public Sprite characterImage;
        public TextMeshProUGUI characterName;

        public Characters(Sprite image, TextMeshProUGUI name)
        {
            characterImage = image;
            characterName = name;
        } 
    }

    public class CharacterSystem : MonoBehaviour
    {
        [SerializeField]
        List<Characters> characters;

        private void Awake()
        {
            CharacterUpdate();
        }

        void CharacterUpdate()
        {
            for(int i = 0; i < characters.Count; i++)
            {
                CharPresenter.Instance.InfoUpdate(i, characters[i].characterImage, characters[i].characterName);
            }
        }




    }
}
