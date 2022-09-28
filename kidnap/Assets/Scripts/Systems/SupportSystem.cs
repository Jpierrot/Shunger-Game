using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Kidnap
{

    [System.Serializable]
    public class Country
    {

        public enum Chars
        {
            A, B, C
        }

        [HideInInspector]
        public int[] Favorability = new int[3] { 0, 0, 0 };


        int[] _supportPercent = new int[3] { 0, 0, 0 };

        [SerializeField]
        private Chars _favor = (Chars)Random.Range(0, 2);

        private int _minPercent = 15;

        private int _allFavor = 0;

        public string _countryName { get; set; }

        /// <summary>
        /// �ش� ĳ���Ϳ� ���� ȣ������ �����ϴ� �޼ҵ�
        /// </summary>
        /// <param name="type">ĳ���͸� ����</param>
        /// <param name="value">�����ϴ� ȣ������ ��</param>
        public void SupportCheck(Chars type, int value)
           => Favorability[(int)type] += value;

        public void Init()
        {
            SetSupport(_favor);
        }

        

        // ȣ���� : ������ => Ư�� �� ȣ���� / ��ü ȣ���� * ��ü ������
        private void SetSupport(Chars type)
        {
            _allFavor = ArrayCalc(Favorability);

            for(int i = 0; i < 3; i++)
            {
                var favor = Favorability[i];

                if (favor == 0 && i == (int)type)
                    _minPercent = 0;

                _supportPercent[i] = FavorCalc(_minPercent, favor);
            }

            _supportPercent[(int)_favor] += _minPercent;
            
        }

        private int FavorCalc(int min, int favor)
        {
            float fav = (favor / _allFavor);
            fav = (float)(100 - min) * fav;

            return (int)fav;
        }

        private int ArrayCalc(int[] array)
        {
            int all = 0;

            foreach (int value in array) all += value;

            return all;
        }

    }


    public class SupportSystem : Singleton<SupportSystem>
    {

        public string[] CountryNames;

        [HideInInspector]
        public List<Country> Countries;

        void SetCountries()
        {
            //������ ����Ʈ �����ϱ�
            for(int i = 0; i < CountryNames.Length; i++)
            {
                Countries.Add(new Country());
            }

            //Linq�� �̿��� foreach���� �ε��� ���ϱ�
            foreach(var (value, i) in CountryNames.Select((value, i) => (value, i)))
            { 
                Countries[i]._countryName = value;
                Debug.Log(Countries[i]._countryName + $" �ε��� : {i}");
            }

            Debug.Log("�ε��� ���� ��");
        }
        


        void Start()
        {
            SetCountries();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
