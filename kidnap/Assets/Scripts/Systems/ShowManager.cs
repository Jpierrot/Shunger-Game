using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;
using TMPro;

namespace Kidnap {

    /// <summary>
    /// 애니메이션 연출 & 일러스트 및 텍스트에 관련한 데이터를 처리하는 클래스입니다.
    /// Canvas의 Show 오브젝트에서 사용됩니다.
    /// 사용 클래스 : CountryPresenter
    /// </summary>
    public class ShowManager : Singleton<ShowManager>
    {
        /// <summary>
        /// 내용에 들어갈 TMP 변수입니다.
        /// </summary>
        [SerializeField]
        TextMeshProUGUI textMeshPro;

        /// <summary>
        /// 제목에 들어갈 TMP 변수입니다.
        /// </summary>
        [SerializeField]
        TextMeshProUGUI Titletext;

        /// <summary>
        /// 지역방문시 올라가는 호감도의 값
        /// </summary>
        [SerializeField]
        const int favor_raise = 10;

        /// <summary>
        /// 현재 사용중인 Show 화면의 유형을 나타내는 데이터
        /// 다른 스크립트에서 호출할 때 MakeShow 메소드를 통해 유형을 선정해서 필요한 메소드를 식별
        /// </summary>
        [HideInInspector, Tooltip("현재 사용중인 Show 화면의 유형을 나타내는 데이터입니다")]
        public ShowType show;

        /// <summary>
        /// 임시로 내용에 들어갈 텍스트를 보관하고 있을 string 변수입니다.
        /// </summary>
        string content_text;

        /// <summary>
        /// 임시로 제목에 들어갈 텍스트를 보관하고 있을 string 변수입니다.
        /// </summary>
        string title_text;

        /// <summary>
        /// 애니메이션 연출이 필요할 때 사용할 메소드 입니다.
        /// 다른 클래스를 통해 필요한 순간에 호출됩니다.
        /// </summary>
        /// <param name="type">사용될 애니메이션 유형</param>
        /// <param name="num">들어갈 리스트의 인덱스</param>
        public void MakeShow(ShowType type, int num)
        {
            switch (type)
            {
                //지역방문시 상황을 체크
                case ShowType.visit:
                    OnVisit(num, favor_raise);
                    break;
                
                default:
                    break;
            }
        }

        /// <summary>
        /// 지역 방문시 변하는 값들을 담당하는 메소드
        /// </summary>
        /// <param name="index">리스트 인덱스</param>
        /// <param name="favor_num">증가시킬 호감도의 수치</param>
        public void OnVisit(int index, int favor_num)
        {

            //호감도 수치값 입력
            CountrySystem.Instance.Countries[index].
                Favorability[(int)CharacterSystem.Instance.playerType] += favor_num;

            //리스트에서 지역 이름 데이터 가져오기
            var name = CountrySystem.Instance.Countries[index].CountryName;

            //값을 넣어주기
            title_text = name + "지역을 방문하였습니다";
            content_text = name + $"지역의 호감도가 {favor_num} 만큼 증가했습니다";
            
            UpdateText();
        }

        /// <summary>
        /// 임시로 저장된 텍스트를 씬에 있는 오브젝트에 동기화 할때 사용합니다.
        /// </summary>
        private void UpdateText()
        {
            Titletext.text = title_text;
            textMeshPro.text = content_text;
        }

    }
}
