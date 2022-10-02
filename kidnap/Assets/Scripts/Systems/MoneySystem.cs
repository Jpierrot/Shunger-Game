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
    /// ȭ��� ���õ� ���ó���� ����ϴ� �ڵ�
    /// </summary>
    public class MoneySystem : Singleton<MoneySystem>
    {
        // ���� �ݾ�
        [SerializeField] int startMoney;

        // ������ȭ
        [HideInInspector] public int curMoney;

        void Start()
        {
            curMoney += startMoney;

        }

        // �� ����ϴ� �Լ�
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
