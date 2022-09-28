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
        /// 해당 캐릭터에 대한 호감도를 증감하는 메소드
        /// </summary>
        /// <param name="type">캐릭터를 지정</param>
        /// <param name="value">증감하는 호감도의 값</param>
        public void SupportCheck(Chars type, int value)
           => Favorability[(int)type] += value;

        public void Init()
        {
            SetSupport(_favor);
        }

        

        // 호감도 : 지지율 => 특정 후 호감도 / 전체 호감도 * 전체 지지율
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
            //지역별 리스트 생성하기
            for(int i = 0; i < CountryNames.Length; i++)
            {
                Countries.Add(new Country());
            }

            //Linq를 이용한 foreach구문 인덱스 구하기
            foreach(var (value, i) in CountryNames.Select((value, i) => (value, i)))
            { 
                Countries[i]._countryName = value;
                Debug.Log(Countries[i]._countryName + $" 인덱스 : {i}");
            }

            Debug.Log("인덱스 정렬 끝");
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
