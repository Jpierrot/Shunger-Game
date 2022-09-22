using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kidnap {
    public class SceneController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        public void LoadGame()
        {
            if (CharacterSystem.Instance.player.characterImage != null)
                SceneManager.LoadScene(1);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
