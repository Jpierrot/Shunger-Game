using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kidnap
{
    /// <summary>
    /// ȭ��� ���õ� ���ó���� ����ϴ� �ڵ�
    /// </summary>
    public class MoneySystem : MonoBehaviour
    {
        // ���� �ݾ�
        [SerializeField]
        float startMoney;

        // ������ȭ
        float curMoney = 0;

        void Start()
        {
            curMoney += startMoney;
            //��� �߻� �� UI�� ������Ʈ
            MoneyPresenter.Instance.OnChangeMoney(curMoney);
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
