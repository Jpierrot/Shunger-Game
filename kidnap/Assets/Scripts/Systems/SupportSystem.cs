using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Kidnap
{
    // 캐릭터 종류를 나타낸 enum
    public enum Chars
    {
        A, B, C
    }

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

        //지지율
        private int[] _supportPercent = new int[3] { 0, 0, 0 };

        private int _minPercent = 15;

        private int _allFavor = 0;

        #endregion

        /// <summary>
        /// 해당 캐릭터에 대한 호감도를 증감하는 메소드
        /// </summary>
        /// <param name="type">캐릭터를 지정</param>
        /// <param name="value">증감하는 호감도의 값</param>
        public void SupportCheck(Chars type, int value)

           => Favorability[(int)type] += value;


        //리스트가 생성된 뒤 시작해야할 메소드.
        public void Init()
        {
            _favor = (Chars)Random.Range(0, 3);
            SetSupport((int)_favor, _minPercent);
        }

        //for test

        public int GetSupportPerCent(int index)
        {
            return _supportPercent[index];
        }

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


    public class SupportSystem : Singleton<SupportSystem>
    {

        public string[] CountryNames;

        [HideInInspector]
        public List<Country> Countries;

        void SetCountries()
        {
            //지역별 리스트 생성하기
            for (int i = 0; i < CountryNames.Length; i++)
            {
                Countries.Add(new Country());
                Countries[i].Init();

            }

            //Linq를 이용한 foreach구문 인덱스 구하기
            foreach (var (value, i) in CountryNames.Select((value, i) => (value, i)))
            {
                Countries[i].CountryName = value;
                Debug.Log(Countries[i].CountryName + $" 인덱스 : {i}");
            }

            Debug.Log("인덱스 정렬 끝");
        }

        /// <summary>
        /// 특정 캐릭터의 지지율 평균을 계산해주는 메소드
        /// </summary>
        /// <param name="type">계산할 캐릭터</param>
        /// <returns></returns>
        public int SupportCalc(Chars type)
        {

            int avg = 0;

            for(int i = 0; i < Countries.Count; i++)
                avg += Countries[i].GetSupportPerCent((int)type);

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
