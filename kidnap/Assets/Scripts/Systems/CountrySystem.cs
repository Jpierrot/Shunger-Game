using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using StructTypes;
using EnumTypes;

namespace Kidnap
{
    /// <summary>
    /// 각 지역과 관련된 호감도를 담아낼 클래스
    /// </summary>
    [System.Serializable]
    public class Country
    {
        #region 선언된 변수들

        //호감도
        [HideInInspector]
        public int[] Favorability = new int[3] { 10, 10, 10 };

        //지역 이름
        public string CountryName { get; set; }

        //지역이 선호하는 캐릭터
        [SerializeField]
        private Chars _favor;

        //인구수
        private int people = 0; 

        //지지율
        private int[] _supportPercent = new int[3] { 0, 0, 0 };

        //최저 지지율
        private int _minPercent = 15;

        //총 호감도
        private int _allFavor = 0;

        #endregion

        /// <summary>
        /// 해당 캐릭터에 대한 호감도를 증감하는 메소드
        /// </summary>
        /// <param name="type">캐릭터를 지정</param>
        /// <param name="value">증감하는 호감도의 값</param>
        public void SupportCalc(Chars type, int value)
           => Favorability[(int)type] += value;


        //리스트가 생성된 뒤 시작해야할 메소드.
        public void Init(int min, int max)
        {
            _favor = (Chars)Random.Range(0, 3);
            SetSupport((int)_favor, _minPercent);

            people = Random.Range(min, max);
        }

        /// <summary>
        /// 지지율을 반환해주는 코드
        /// </summary>
        /// <param name="type">캐릭터 종류 입력</param>
        /// <returns>입력된 캐릭터의 지지율 반환</returns>
        public int GetSupportPerCent(Chars type)
        {
            return _supportPercent[(int)type];
        }

        // 선호하는 캐릭터를 반환해주는 메소드
        public int GetChar()
        {
            return (int)_favor;
        }

        #region for Calc Method

        /// <summary>
        /// 모든 캐릭터의 호감도를 계산해주는 메소드
        /// 호감도 : 지지율 => 특정 후 호감도 / 전체 호감도 * 전체 지지율
        /// </summary>
        /// <param name="type">해당 클래스가 선호하는 캐릭터</param>
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

        //호감도 계산기
        private int FavorCalc(int min, int favor)
        {
            float fav = (float)favor / _allFavor;
            fav = (100 - min) * fav;

            return (int)fav;
        }

        //배열 합 계산
        private int ArrayCalc(int[] array)
        {
            int all = 0;

            foreach (int value in array) all += value;

            return all;
        }

        #endregion 
    }

    /// <summary>
    /// 게임 내 지역(+ 지지율)에 관한 데이터를 다루는 클래스
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
        /// 등록된 지역들을 리스트로 구현해주는 메소드
        /// </summary>
        void SetCountries()
        {
            //지역별 리스트 생성하기
            for (int i = 0; i < CDlist.Count; i++)
            {
                Countries.Add(new Country());
                Countries[i].Init(minPeople, maxPeople);
            }

            //Linq를 이용한 foreach구문 인덱스 구하기
            foreach (var (value, i) in CDlist.Select((value, i) => (value, i)))
            {
                Countries[i].CountryName = value.CountryName;
                Debug.Log(Countries[i].CountryName + $" 인덱스 : {i}");
            }

            Debug.Log("인덱스 정렬 끝");

        }

        /// <summary>
        /// 특정 캐릭터의 지지율 평균을 계산해주는 메소드
        /// </summary>
        /// <param name="type">계산할 캐릭터</param>
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
        /// 데이터 & 시스템적인 부분은 Awake에서 등록
        /// </summary>
        private void Awake()
        {
            SetCountries();
        }
    }
}
