using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kidnap
{
    /// <summary>
    /// 화폐와 관련된 계산처리를 담당하는 코드
    /// </summary>
    public class MoneySystem : Singleton<MoneySystem>
    {
        // 시작 금액
        [SerializeField] float startMoney;

        // 보유재화
        [HideInInspector] public float curMoney;

        void Start()
        {
            curMoney += startMoney;
            
        }

        // 돈 가산
        void MoneyPlus(float addMoney)
        {
            curMoney += addMoney;
            MoneyPresenter.Instance.OnChangeMoney(curMoney);
        }

        // 돈 차감
        void MoneyMinus(float disMoney)
        {
            curMoney -= disMoney;
            MoneyPresenter.Instance.OnChangeMoney(curMoney);
        }
    }
}
