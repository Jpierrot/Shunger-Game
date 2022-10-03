using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Kidnap {

    public class MoneyPresenter : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI _moneyText;

        float _money;

        string _won = "�� ��";

        void CheckMoney()
        {
            _money = MoneySystem.Instance.curMoney;
            MoneyToString(_money);
        }

        void MoneyToString(float Money)
        {
            _moneyText.text = $"�� : <b>{_money}</b>" + _won;
        }

        private void Start()
        {
            CheckMoney();
        }

    }
}
