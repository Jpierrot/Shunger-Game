using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kidnap
{

    public enum Calc
    {
        plus,
        minus
    }
    /// <summary>
    /// 화폐와 관련된 계산처리를 담당하는 코드
    /// </summary>
    public class MoneySystem : Singleton<MoneySystem>
    {
        // 시작 금액
        [SerializeField] int startMoney;

        // 보유재화
        [HideInInspector] public int curMoney;

        void Start()
        {
            curMoney += startMoney;

        }

        // 돈 계산하는 함수
        void MoneyCalc(int money, Calc type)
        {
            switch ((int)type)
            {
                case 0:
                    curMoney += money;
                    break;
                case 1:
                    curMoney -= money;
                    break;
            }

        }
    }
}
