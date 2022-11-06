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

        /// 지역방문시 올라가는 호감도의 값
        /// 게임 내 변동되지 않으며 인스펙터 상에서 초기 값을 설정할 수 있습니다.
        [SerializeField]
        const int favor_raise_toVisit = 10;

        /// 자원봉사시 올라가는 호감도의 값
        /// 게임 내 변동되지 않으며 인스펙터 상에서 초기 값을 설정할 수 있습니다.
        [SerializeField]
        const int favor_raise_toVolunteer = 10;

        /// 
        /// 게임 내 변동되지 않으며 인스펙터 상에서 초기 값을 설정할 수 있습니다.
        [SerializeField]
        const int favor_raise_toParty = 10;

        /// UI와 관련된 변수입니다.
        /// 인스펙터상에서 UI오브젝트를 등록 및 수정할 수 있습니다.
        #region UI variables

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

        #endregion

        /// 현재 사용하지 않게된 변수입니다.
        #region deleted variable

        /// <summary>
        /// 현재 사용중인 Show 화면의 유형을 나타내는 데이터
        /// 다른 스크립트에서 호출할 때 MakeShow 메소드를 통해 유형을 선정해서 필요한 메소드를 식별
        /// </summary>
        [Tooltip("현재 사용중인 Show 화면의 유형을 나타내는 데이터입니다")]
        ShowType m_show;

        #endregion

        /// 현재 사용되는 priavte 멤버 변수입니다.
        #region private m_variables

        /// <summary>
        /// 임시로 내용에 들어갈 텍스트를 보관하고 있을 string 변수입니다.
        /// </summary>
        string content_text;

        /// <summary>
        /// 임시로 제목에 들어갈 텍스트를 보관하고 있을 string 변수입니다.
        /// </summary>
        string title_text;

        /// <summary>
        /// 임시로 CountryData에서 넘어온 인수를 보관할 int 변수입니다.
        /// makeShow메소드를 통해 사용됩니다.
        /// </summary>
        private int index;

        #endregion

        /// <summary>
        /// index 멤버 변수를 공유하는 프로퍼티
        /// </summary>
        public int Index 
        {
            private get {

                return index;
            }

            set {

                index = value;
            }
        }

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
                    OnVisit(num, favor_raise_toVisit);
                    break;

                case ShowType.party:
                    OnParty(num, favor_raise_toParty);
                    break;

                case ShowType.volunteer:
                    OnVolunteer(num, favor_raise_toVolunteer);
                    break;
                
                default:
                    break;
            }

            UpdateText();
        }

        /// 버튼 이벤트에서 등록되는 메소드들입니다.
        /// ShowType 상태마다 각각의 메소드가 존재합니다.
        #region 버튼 이벤트에 할당되는 ShowType 관련 메소드들

        /// <summary>
        /// 다른 버튼들이 인스펙터 상에 이벤트에 등록하는 용도로 쓰이는 메소드입니다.
        /// ShowType을 입력받습니다.
        /// </summary>
        [SerializeField]
        public void SetVisit()
        {
            var show = ShowType.visit;
            MakeShow(show, index);
        }

        /// <summary>
        /// 다른 버튼들이 인스펙터 상에 이벤트에 등록하는 용도로 쓰이는 메소드입니다.
        /// ShowType을 입력받습니다.
        /// 
        /// </summary>
        [SerializeField]
        public void SetVolunteer()
        {
            var show = ShowType.volunteer;
            MakeShow(show, index);
        }

        /// <summary>
        /// 다른 버튼들이 인스펙터 상에 이벤트에 등록하는 용도로 쓰이는 메소드입니다.
        /// ShowType을 입력받습니다.
        /// </summary>
        [SerializeField]
        public void SetParty()
        {
            var show = ShowType.party;
            MakeShow(show, index);
        }

        #endregion

        /// MakeShow에서 사용될 메소드들입니다.
        /// ShowType 상태마다 각각의 메소드가 존재합니다.
        #region ShowType 상태마다 동작하는 메소드들

        /// <summary>
        /// 지역 방문시 변하는 값들을 담당하는 메소드
        /// </summary>
        /// <param name="index">리스트 인덱스</param>
        /// <param name="favor_num">증가시킬 호감도의 수치</param>
        private void OnVisit(int index, int favor_num)
        {

            //호감도 수치값 입력
            CountrySystem.Instance.Countries[index].
                Favorability[(int)CharacterSystem.Instance.playerType] += favor_num;

            //리스트에서 지역 이름 데이터 가져오기
            var name = CountrySystem.Instance.Countries[index].CountryName;

            //값을 넣어주기
            title_text = name + "지역의 도지사를 만났습니다";
            content_text = name + $"지역의 호감도가 {favor_num} 만큼 증가했습니다";
            
        }


        private void OnVolunteer(int index, int favor_num)
        {

            //호감도 수치값 입력
            CountrySystem.Instance.Countries[index].
                Favorability[(int)CharacterSystem.Instance.playerType] += favor_num;

            //리스트에서 지역 이름 데이터 가져오기
            var name = CountrySystem.Instance.Countries[index].CountryName;

            title_text = name + "지역에서 봉사활동을 하였습니다";
            content_text = name + $"지역의 호감도가 {favor_num} 만큼 증가했습니다";

        }

        private void OnParty(int index, int favor_num)
        {

            //호감도 수치값 입력
            CountrySystem.Instance.Countries[index].
                Favorability[(int)CharacterSystem.Instance.playerType] += favor_num;

            //리스트에서 지역 이름 데이터 가져오기
            var name = CountrySystem.Instance.Countries[index].CountryName;

            title_text = name + "지역행사에 참관했습니다";
            content_text = name + $"지역의 호감도가 {favor_num} 만큼 증가했습니다";

        }

        #endregion

        /// <summary>
        /// 임시로 저장된 텍스트를 화면으로 동기화 할때 사용합니다.
        /// </summary>
        private void UpdateText()
        {
            Titletext.text = title_text;
            textMeshPro.text = content_text;
        }

    }
}
