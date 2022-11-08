using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using ClassData;
using EnumTypes;

namespace Kidnap
{
    /// <summary>
    /// 각 지역이 담고있어야할 데이터를 보관하는 클래스입니다.
    /// 그에 필요한 변수들과 다른 클래스에서 값을 얻어올 때 계산 해주는 메소드를 포합하고 있습니다.
    /// 
    /// 추가로 구현이 필요한 기능 : 
    /// * 현재 호감도에 따른 지지율을 매일 갱신
    /// * 인구수에 비례한 지지율 계산
    /// 
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

        //인구수
        public int people = 0;

        //지역이 선호하는 캐릭터
        [SerializeField]
        private Chars _favor;

        //지지율
        private int[] _supportPercent = new int[3] { 0, 0, 0 };

        //최저 지지율
        private int _minPercent = 15;

        //총 호감도
        private int _allFavor = 0;

        //최소 호감도
        readonly int minFavor = 10;

        #endregion

        /// <summary>
        /// 해당 캐릭터에 대한 호감도를 증감하는 메소드
        /// </summary>
        /// <param name="type">캐릭터를 지정</param>
        /// <param name="value">증감하는 호감도의 값</param>
        public void FavorCalc(Chars type, int value)
           => Favorability[(int)type] += value;


        /// 리스트가 생성된 뒤 수행되는 메소드입니다.
        /// 다른 클래스에서 Country클래스를 요구하는 리스트를 생성할시
        /// 이 메소드를 실행해야 합니다.
        public void Init(int min, int max)
        {
            _favor = (Chars)Random.Range(0, 3);
            SetSupport((int)_favor, _minPercent);

            people = Random.Range(min, max);
        }

        /// <summary>
        /// 변동된 호감도에 따라 새로운 지지율을 계산하는 메소드입니다.
        /// </summary>
        public void SetSupportPer()
        {

        }

        /// <summary>
        /// 지지율을 반환해주는 메소드
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
        /// <param name="min">최소 호감도</param>
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
        /// 최대 인구수
        [SerializeField, Tooltip("")]
        private int maxPeople;
        
        /// 최소 인구수 
        [SerializeField]
        private int minPeople;

        /// 인스펙터 상에서 사전에 입력받은 데이터
        public List<CountryData> CDlist;

        /// 새롭게 생성되는 List형 데이터
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
                CDlist[i].CountryPop = Countries[i].people;
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
            /// 평균 지지율 값을 담게되는 flaot형 변수
            float avg = 0;

            /// 모든 지역의 지지율을 더해서 지역 수 만큼으로 나누기
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
