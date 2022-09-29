using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Kidnap
{

    public class SupportPresenter : MonoBehaviour
    {

        [SerializeField]
        TextMeshProUGUI _supportText;

        // Start is called before the first frame update
        void Start()
        {
            UpdateSupport();
        }

        void UpdateSupport()
        {
            int per = SupportSystem.Instance.SupportCalc(CharacterSystem.Instance.player.type);
            _supportText.text = $"ÁöÁöÀ² : <b>{per}</b>%";

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
