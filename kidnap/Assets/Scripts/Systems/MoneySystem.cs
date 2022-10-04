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
        [SerializeField] int startMoney { get; set; }

        // ������ȭ
        [HideInInspector] public int curMoney;

        void Awake()
        {
            curMoney += startMoney;
        }

        /// <summary>
        /// ȭ��� ���õ� ����� ����ϴ� �Լ�
        /// </summary>
        /// <param name="money">����� �ݾ�</param>
        /// <param name="type">���� ����(���ϱ�, ���� ��)</param>
        public void MoneyCalc(int money, Calc type)
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
