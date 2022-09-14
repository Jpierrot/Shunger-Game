using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kidnap
{
    /// <summary>
    /// 화폐와 관련된 계산처리를 담당하는 코드
    /// </summary>
    public class MoneySystem : MonoBehaviour
    {
        // 시작 금액
        [SerializeField]
        float startMoney;

        // 보유재화
        float curMoney = 0;

        void Start()
        {
            curMoney += startMoney;
            //계산 발생 후 UI를 업데이트
            MoneyPresenter.Instance.OnChangeMoney(curMoney);
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
