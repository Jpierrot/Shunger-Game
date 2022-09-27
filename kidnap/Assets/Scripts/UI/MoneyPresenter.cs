using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Kidnap {

    public class MoneyPresenter : Singleton<MoneyPresenter>
    {
        [SerializeField]
        TextMeshProUGUI _moneyText;

        float _money;

        string _won = "�� ��";

        public void OnChangeMoney(float curMoney)
        {
            _money = curMoney;
            MoneyToString(_money);
        }

        void MoneyToString(float Money)
        {
            _moneyText.text = $"�� : <b>{_money}</b>" + _won;
        }

        private void Start()
        {
            
        }

    }
}
