using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using StructTypes;
using EnumTypes;

namespace Kidnap
{
    /// <summary>
    /// �� ������ ���õ� ȣ������ ��Ƴ� Ŭ����
    /// </summary>
    [System.Serializable]
    public class Country
    {
        #region ����� ������

        //ȣ����
        [HideInInspector]
        public int[] Favorability = new int[3] { 10, 10, 10 };

        //���� �̸�
        public string CountryName { get; set; }

        //������ ��ȣ�ϴ� ĳ����
        [SerializeField]
        private Chars _favor;

        //�α���
        private int people = 0; 

        //������
        private int[] _supportPercent = new int[3] { 0, 0, 0 };

        //���� ������
        private int _minPercent = 15;

        //�� ȣ����
        private int _allFavor = 0;

        #endregion

        /// <summary>
        /// �ش� ĳ���Ϳ� ���� ȣ������ �����ϴ� �޼ҵ�
        /// </summary>
        /// <param name="type">ĳ���͸� ����</param>
        /// <param name="value">�����ϴ� ȣ������ ��</param>
        public void SupportCalc(Chars type, int value)
           => Favorability[(int)type] += value;


        //����Ʈ�� ������ �� �����ؾ��� �޼ҵ�.
        public void Init(int min, int max)
        {
            _favor = (Chars)Random.Range(0, 3);
            SetSupport((int)_favor, _minPercent);

            people = Random.Range(min, max);
        }

        /// <summary>
        /// �������� ��ȯ���ִ� �ڵ�
        /// </summary>
        /// <param name="type">ĳ���� ���� �Է�</param>
        /// <returns>�Էµ� ĳ������ ������ ��ȯ</returns>
        public int GetSupportPerCent(Chars type)
        {
            return _supportPercent[(int)type];
        }

        // ��ȣ�ϴ� ĳ���͸� ��ȯ���ִ� �޼ҵ�
        public int GetChar()
        {
            return (int)_favor;
        }

        #region for Calc Method

        /// <summary>
        /// ��� ĳ������ ȣ������ ������ִ� �޼ҵ�
        /// ȣ���� : ������ => Ư�� �� ȣ���� / ��ü ȣ���� * ��ü ������
        /// </summary>
        /// <param name="type">�ش� Ŭ������ ��ȣ�ϴ� ĳ����</param>
        private void SetSupport(int type, int min)
        {
            int minPercent = min;
            _allFavor = ArrayCalc(Favorability);

            if (Favorability[type] <= 0)
                minPercent = 0;

            for (int i = 0; i < 3; i++)
            {
                var favor = Favorability[i];

                _supportPercent[i] = FavorCalc(minPercent, favor);
            }

            _supportPercent[type] += minPercent;
        }

        //ȣ���� ����
        private int FavorCalc(int min, int favor)
        {
            float fav = (float)favor / _allFavor;
            fav = (100 - min) * fav;

            return (int)fav;
        }

        //�迭 �� ���
        private int ArrayCalc(int[] array)
        {
            int all = 0;

            foreach (int value in array) all += value;

            return all;
        }

        #endregion 
    }

    /// <summary>
    /// ���� �� ����(+ ������)�� ���� �����͸� �ٷ�� Ŭ����
    /// </summary>
    public class CountrySystem : Singleton<CountrySystem>
    {
        [SerializeField]
        private int minPeople;

        [SerializeField]
        private int maxPeople;

        public List<CountryDatas> CDlist;

        [HideInInspector]
        public List<Country> Countries;

        /// <summary>
        /// ��ϵ� �������� ����Ʈ�� �������ִ� �޼ҵ�
        /// </summary>
        void SetCountries()
        {
            //������ ����Ʈ �����ϱ�
            for (int i = 0; i < CDlist.Count; i++)
            {
                Countries.Add(new Country());
                Countries[i].Init(minPeople, maxPeople);
            }

            //Linq�� �̿��� foreach���� �ε��� ���ϱ�
            foreach (var (value, i) in CDlist.Select((value, i) => (value, i)))
            {
                Countries[i].CountryName = value.CountryName;
                Debug.Log(Countries[i].CountryName + $" �ε��� : {i}");
            }

            Debug.Log("�ε��� ���� ��");

        }

        /// <summary>
        /// Ư�� ĳ������ ������ ����� ������ִ� �޼ҵ�
        /// </summary>
        /// <param name="type">����� ĳ����</param>
        /// <returns></returns>
        public float SupportCalc(Chars type)
        {

            float avg = 0;

            for(int i = 0; i < Countries.Count; i++)
                avg += Countries[i].GetSupportPerCent(type);

            avg /= Countries.Count;

            return avg;
        }

        /// <summary>
        /// ������ & �ý������� �κ��� Awake���� ���
        /// </summary>
        private void Awake()
        {
            SetCountries();
        }
    }
}
