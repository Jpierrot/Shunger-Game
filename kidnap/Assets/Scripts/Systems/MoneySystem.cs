using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kidnap
{
    /// <summary>
    /// ȭ��� ���õ� ���ó���� ����ϴ� �ڵ�
    /// </summary>
    public class MoneySystem : Singleton<MoneySystem>
    {
        // ���� �ݾ�
        [SerializeField] float startMoney;

        // ������ȭ
        [HideInInspector] public float curMoney;

        void Start()
        {
            curMoney += startMoney;
            
        }

        // �� ����
        void MoneyPlus(float addMoney)
        {
            curMoney += addMoney;
            MoneyPresenter.Instance.OnChangeMoney(curMoney);
        }

        // �� ����
        void MoneyMinus(float disMoney)
        {
            curMoney -= disMoney;
            MoneyPresenter.Instance.OnChangeMoney(curMoney);
        }
    }
}
