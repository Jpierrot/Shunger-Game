using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Kidnap {

    public class MoneyPresenter : Singleton<MoneyPresenter>
    {
        [SerializeField]
        TextMeshProUGUI moneyText;

        float money;

        string won = "¾ï ¿ø";

        public void OnChangeMoney(float curMoney)
        {
            money = curMoney;
            MoneyToString(money);
        }

        void MoneyToString(float Money)
        {
            moneyText.text = $"µ· : <b>{money}</b>" + won;
        }

    }
}
