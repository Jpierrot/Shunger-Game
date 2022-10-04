using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Kidnap {

    public class MoneyPresenter : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI _moneyText;

        int _money;

        string _won = "�� ��";

        void CheckMoney()
        {
            _money = MoneySystem.Instance.curMoney;
            MoneyToString(_money);
        }

        public void PlusMoney(int money)
        {
            MoneySystem.Instance.MoneyCalc(money, Calc.plus);
            CheckMoney();
        }

        public void MinusMoney(int money)
        {
            MoneySystem.Instance.MoneyCalc(money, Calc.minus);
            CheckMoney();
        }
        void MoneyToString(int Money)
        {
            _moneyText.text = $"�� : <b>{_money}</b>" + _won;
        }

        private void Start()
        {
            CheckMoney();
        }

    }
}
