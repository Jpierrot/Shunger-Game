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

        /// ������ �̹������� ��ϵǴ� �迭�Դϴ�.
        [SerializeField]
        Sprite [] images;

        /// ���� ȭ�鿡�� �������� �ִ� �̹����Դϴ�.
        Image curImage;

        #endregion

        /// ���� ������� �ʰԵ� �����Դϴ�.
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

            // ȣ������ �ӽ÷� ������ int�� ����
            int favor = 0;

            //����Ʈ���� ���� �̸� ������ ��������
            var name = CountrySystem.Instance.Countries[this.index].CountryName;

            switch (type)
            {
                //�����湮�� ��Ȳ�� üũ
                case ShowType.visit:
                    title_text = name + "�������� �����縦 �湮";
                    favor = favor_raise_toVisit;
                    break;

                case ShowType.party:
                    title_text = name + "�������� ��縦 ����";
                    favor = favor_raise_toParty;
                    break;

                case ShowType.volunteer:
                    title_text = name + "�������� ����Ȱ�� ����";
                    favor = favor_raise_toVolunteer;
                    break;

                default:
                    Debug.LogError("������ �߻��߽��ϴ�");
                    break;
            }

            /// ȣ���� ��ġ�� �Է�
            CountrySystem.Instance.Countries[index].
                Favorability[(int)CharacterSystem.Instance.playerType] += favor;

            /// ������ �ؽ�Ʈ�� �� ���� �Է�
            content_text = name + $"������ ȣ������ {favor} ��ŭ �����߽��ϴ�";

            UpdateText();
        }

        /// ��ư �̺�Ʈ���� ��ϵǴ� �޼ҵ���Դϴ�.
        /// ShowType ���¸��� ������ �޼ҵ尡 �����մϴ�.
        #region ��ư �̺�Ʈ�� �Ҵ�Ǵ� ShowType ���� �޼ҵ��

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
