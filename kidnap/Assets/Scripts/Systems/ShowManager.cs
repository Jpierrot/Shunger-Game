using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;
using TMPro;
using UnityEngine.UI;

namespace Kidnap {

    /// <summary>
    /// �ִϸ��̼� ���� & �Ϸ���Ʈ �� �ؽ�Ʈ�� ������ �����͸� ó���ϴ� Ŭ�����Դϴ�.
    /// Canvas�� Show ������Ʈ���� ���˴ϴ�.
    /// ��� Ŭ���� : CountryPresenter
    /// </summary>
    public class ShowManager : Singleton<ShowManager>
    {
        /// ImageScritableObject�� �޾ƿ��� �����Դϴ�.
        /// MakeShow �޼ҵ忡�� Ȱ��Ǹ�,
        /// �ƾ��� �̹����� ������ ������ �޾ƿ��µ� ����մϴ�.
        [SerializeField]
        CutSceneScriptableObj imgScriptObj;

        /// ������ ���� ������ �ִ� ������ �Դϴ�.
        /// �ν����ͻ󿡼� ���� ������ �� �ֽ��ϴ�.
        #region const variables

        /// �����湮�� �ö󰡴� ȣ������ ��
        /// ���� �� �������� ������ �ν����� �󿡼� �ʱ� ���� ������ �� �ֽ��ϴ�.
        [SerializeField]
        const int favor_raise_toVisit = 10;

        /// �ڿ������ �ö󰡴� ȣ������ ��
        /// ���� �� �������� ������ �ν����� �󿡼� �ʱ� ���� ������ �� �ֽ��ϴ�.
        [SerializeField]
        const int favor_raise_toVolunteer = 15;

        /// 
        /// ���� �� �������� ������ �ν����� �󿡼� �ʱ� ���� ������ �� �ֽ��ϴ�.
        [SerializeField]
        const int favor_raise_toParty = 20;

        #endregion

        /// UI�� ���õ� �����Դϴ�.
        /// �ν����ͻ󿡼� UI������Ʈ�� ��� �� ������ �� �ֽ��ϴ�.
        #region UI variables

        /// <summary>
        /// ���뿡 �� TMP �����Դϴ�.
        /// </summary>
        [SerializeField]
        TextMeshProUGUI textMeshPro;

        /// <summary>
        /// ���� �� TMP �����Դϴ�.
        /// </summary>
        [SerializeField]
        TextMeshProUGUI Titletext;

        /// ���� ȭ�鿡�� �������� �ִ� �̹����Դϴ�.
        [SerializeField]
        Image curImage;

        #endregion

        /// ���� ������ �ʴ� �����Դϴ�.
        #region deleted variable

        /// <summary>
        /// ���� ������� Show ȭ���� ������ ��Ÿ���� ������
        /// �ٸ� ��ũ��Ʈ���� ȣ���� �� MakeShow �޼ҵ带 ���� ������ �����ؼ� �ʿ��� �޼ҵ带 �ĺ�
        /// </summary>
        [Tooltip("���� ������� Show ȭ���� ������ ��Ÿ���� �������Դϴ�")]
        ShowType m_show;

        #endregion

        /// ���� ���Ǵ� priavte ��� �����Դϴ�.
        #region private m_variables

        /// <summary>
        /// �ӽ÷� ���뿡 �� �ؽ�Ʈ�� �����ϰ� ���� string �����Դϴ�.
        /// </summary>
        string content_text;

        /// <summary>
        /// �ӽ÷� ���� �� �ؽ�Ʈ�� �����ϰ� ���� string �����Դϴ�.
        /// </summary>
        string title_text;

        /// <summary>
        /// �ӽ÷� CountryData���� �Ѿ�� �μ��� ������ int �����Դϴ�.
        /// makeShow�޼ҵ带 ���� ���˴ϴ�.
        /// </summary>
        private int index;

        /// <summary>
        /// index ��� ������ �����ϴ� ������Ƽ
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
        /// �ִϸ��̼� ������ �ʿ��� �� ����� �޼ҵ� �Դϴ�.
        /// �ٸ� Ŭ������ ���� �ʿ��� ������ ȣ��˴ϴ�.
        /// </summary>
        /// <param name="type">���� �ִϸ��̼� ����</param>
        /// <param name="num">�� ����Ʈ�� �ε���</param>
        public void MakeShow(ShowType type, int index)
        {
            /// ȣ������ �ӽ÷� ������ int�� ����
            int favor = 0;

            /// ����Ʈ���� ���� �̸� ������ ��������
            var name = CountrySystem.Instance.Countries[this.index].CountryName;

            /// ShowType �������� �۾��� ����Ǵ� Switch�����Դϴ�.
            /// �ƾ��� �ʿ��� �����͸� ����ϱ� ���� ���˴ϴ�.
            /// 
            /// 1. ���� �ؽ�Ʈ ���
            /// 2. �̹��� ��������Ʈ ���
            /// 3. ������ ȣ���� ��ġ �Է��� ������ ����˴ϴ�.
            switch (type)
            {
                /// �����湮�� ��Ȳ�� üũ
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
                    Debug.LogError("������ �߻��߽��ϴ�");
                    break;
            }

            /// ȣ���� ��ġ�� �Է�
            CountrySystem.Instance.Countries[index].
                FavorCalc(CharacterSystem.Instance.playerType, favor);

            /// ������ �ؽ�Ʈ�� �� ���� �Է�
            content_text = name + $"������ ȣ������ {favor} ��ŭ �����߽��ϴ�";

            UpdateText();
        }

        /// ��ư �̺�Ʈ���� ��ϵǴ� �޼ҵ���Դϴ�.
        /// ShowType ���¸��� ������ �޼ҵ尡 �����մϴ�.
        #region a few Methods for button event

        /// <summary>
        /// �ٸ� ��ư���� �ν����� �� �̺�Ʈ�� ����ϴ� �뵵�� ���̴� �޼ҵ��Դϴ�.
        /// ShowType�� �Է¹޽��ϴ�.
        /// </summary>
        [SerializeField]
        public void SetVisit()
        {
            var show = ShowType.visit;
            MakeShow(show, index);
        }

        /// <summary>
        /// �ٸ� ��ư���� �ν����� �� �̺�Ʈ�� ����ϴ� �뵵�� ���̴� �޼ҵ��Դϴ�.
        /// ShowType�� �Է¹޽��ϴ�.
        /// 
        /// </summary>
        [SerializeField]
        public void SetVolunteer()
        {
            var show = ShowType.volunteer;
            MakeShow(show, index);
        }

        /// <summary>
        /// �ٸ� ��ư���� �ν����� �� �̺�Ʈ�� ����ϴ� �뵵�� ���̴� �޼ҵ��Դϴ�.
        /// ShowType�� �Է¹޽��ϴ�.
        /// </summary>
        [SerializeField]
        public void SetParty()
        {
            var show = ShowType.party;
            MakeShow(show, index);
        }

        #endregion

        /// <summary>
        /// �ӽ÷� ����� �ؽ�Ʈ�� ȭ������ ����ȭ �Ҷ� ����մϴ�.
        /// </summary>
        private void UpdateText()
        {
            Titletext.text = title_text;
            textMeshPro.text = content_text;
        }

        /// <summary>
        /// ���߿� �ؽ�Ʈ �ִϸ��̼��� �ۼ��� �޼ҵ��Դϴ�.
        /// ������ ������� �ʽ��ϴ�.
        /// </summary>
        private void TextAnim()
        {

        }

    }
}
