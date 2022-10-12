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
            float per = CountrySystem.Instance.SupportCalc(CharacterSystem.Instance.player.type);
            _supportText.text = $"ÁöÁöÀ² : <b>{per * 0.01f:P1}</b>";
        }

    }
}
