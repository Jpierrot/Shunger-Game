using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;
using TMPro;
using UnityEngine.UI;

namespace Kidnap {

    /// <summary>
    /// 애니메이션 연출 & 일러스트 및 텍스트에 관련한 데이터를 처리하는 클래스입니다.
    /// Canvas의 Show 오브젝트에서 사용됩니다.
    /// 사용 클래스 : CountryPresenter
    /// </summary>
    public class ShowManager : Singleton<ShowManager>
    {
        /// ImageScritableObject를 받아오는 변수입니다.
        /// MakeShow 메소드에서 활용되며,
        /// 컷씬의 이미지와 제목의 내용을 받아오는데 사용합니다.
        [SerializeField]
        CutSceneScriptableObj imgScriptObj;

        /// 고정된 값을 가지고 있는 변수들 입니다.
        /// 인스펙터상에서 값을 수정할 수 있습니다.
        #region const variables

        /// 지역방문시 올라가는 호감도의 값
        /// 게임 내 변동되지 않으며 인스펙터 상에서 초기 값을 설정할 수 있습니다.
        [SerializeField]
        const int favor_raise_toVisit = 10;

        /// 자원봉사시 올라가는 호감도의 값
        /// 게임 내 변동되지 않으며 인스펙터 상에서 초기 값을 설정할 수 있습니다.
        [SerializeField]
        const int favor_raise_toVolunteer = 15;

        /// 
        /// 게임 내 변동되지 않으며 인스펙터 상에서 초기 값을 설정할 수 있습니다.
        [SerializeField]
        const int favor_raise_toParty = 20;

        #endregion

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

        /// 현재 화면에서 보여지고 있는 이미지입니다.
        [SerializeField]
        Image curImage;

        #endregion

        /// 현재 사용되지 않는 변수입니다.
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

        #endregion

        /// <summary>
        /// 애니메이션 연출이 필요할 때 사용할 메소드 입니다.
        /// 다른 클래스를 통해 필요한 순간에 호출됩니다.
        /// </summary>
        /// <param name="type">사용될 애니메이션 유형</param>
        /// <param name="num">들어갈 리스트의 인덱스</param>
        public void MakeShow(ShowType type, int index)
        {
            /// 호감도를 임시로 보관할 int형 변수
            int favor = 0;

            /// 리스트에서 지역 이름 데이터 가져오기
            var name = CountrySystem.Instance.Countries[this.index].CountryName;

            /// ShowType 유형별로 작업이 진행되는 Switch구문입니다.
            /// 컷씬에 필요한 데이터를 등록하기 위해 사용됩니다.
            /// 
            /// 1. 제목 텍스트 등록
            /// 2. 이미지 스프라이트 등록
            /// 3. 증가할 호감도 수치 입력의 순서로 실행됩니다.
            switch (type)
            {
                /// 지역방문시 상황을 체크
                case ShowType.visit:
                    title_text = name + imgScriptObj.Visit[0].title;
                    curImage.sprite = imgScriptObj.Visit[0].image;
                    favor = favor_raise_toVisit;
                    break;

                case ShowType.party:
                    title_text = name + imgScriptObj.Party[0].title;
                    curImage.sprite = imgScriptObj.Party[0].image;
                    favor = favor_raise_toParty;
                    break;

                case ShowType.volunteer:
                    title_text = name + imgScriptObj.Volunteer[0].title;
                    curImage.sprite = imgScriptObj.Volunteer[0].image;
                    favor = favor_raise_toVolunteer;
                    break;

                default:
                    Debug.LogError("오류가 발생했습니다");
                    break;
            }

            /// 호감도 수치값 입력
            CountrySystem.Instance.Countries[index].
                FavorCalc(CharacterSystem.Instance.playerType, favor);

            /// 콘텐츠 텍스트에 들어갈 내용 입력
            content_text = name + $"지역의 호감도가 {favor} 만큼 증가했습니다";

            UpdateText();
        }

        /// 버튼 이벤트에서 등록되는 메소드들입니다.
        /// ShowType 상태마다 각각의 메소드가 존재합니다.
        #region a few Methods for button event

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

        /// <summary>
        /// 임시로 저장된 텍스트를 화면으로 동기화 할때 사용합니다.
        /// </summary>
        private void UpdateText()
        {
            Titletext.text = title_text;
            textMeshPro.text = content_text;
        }

        /// <summary>
        /// 나중에 텍스트 애니메이션이 작성될 메소드입니다.
        /// 지금은 사용하지 않습니다.
        /// </summary>
        private void TextAnim()
        {

        }

    }
}
