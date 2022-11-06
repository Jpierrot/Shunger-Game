using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;
using TMPro;

namespace Kidnap {

    /// <summary>
    /// �ִϸ��̼� ���� & �Ϸ���Ʈ �� �ؽ�Ʈ�� ������ �����͸� ó���ϴ� Ŭ�����Դϴ�.
    /// Canvas�� Show ������Ʈ���� ���˴ϴ�.
    /// ��� Ŭ���� : CountryPresenter
    /// </summary>
    public class ShowManager : Singleton<ShowManager>
    {

        /// �����湮�� �ö󰡴� ȣ������ ��
        /// ���� �� �������� ������ �ν����� �󿡼� �ʱ� ���� ������ �� �ֽ��ϴ�.
        [SerializeField]
        const int favor_raise_toVisit = 10;

        /// �ڿ������ �ö󰡴� ȣ������ ��
        /// ���� �� �������� ������ �ν����� �󿡼� �ʱ� ���� ������ �� �ֽ��ϴ�.
        [SerializeField]
        const int favor_raise_toVolunteer = 10;

        /// 
        /// ���� �� �������� ������ �ν����� �󿡼� �ʱ� ���� ������ �� �ֽ��ϴ�.
        [SerializeField]
        const int favor_raise_toParty = 10;

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

        #endregion

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

        /// <summary>
        /// �ִϸ��̼� ������ �ʿ��� �� ����� �޼ҵ� �Դϴ�.
        /// �ٸ� Ŭ������ ���� �ʿ��� ������ ȣ��˴ϴ�.
        /// </summary>
        /// <param name="type">���� �ִϸ��̼� ����</param>
        /// <param name="num">�� ����Ʈ�� �ε���</param>
        public void MakeShow(ShowType type, int num)
        {
            switch (type)
            {
                //�����湮�� ��Ȳ�� üũ
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

        /// MakeShow���� ���� �޼ҵ���Դϴ�.
        /// ShowType ���¸��� ������ �޼ҵ尡 �����մϴ�.
        #region ShowType ���¸��� �����ϴ� �޼ҵ��

        /// <summary>
        /// ���� �湮�� ���ϴ� ������ ����ϴ� �޼ҵ�
        /// </summary>
        /// <param name="index">����Ʈ �ε���</param>
        /// <param name="favor_num">������ų ȣ������ ��ġ</param>
        private void OnVisit(int index, int favor_num)
        {

            //ȣ���� ��ġ�� �Է�
            CountrySystem.Instance.Countries[index].
                Favorability[(int)CharacterSystem.Instance.playerType] += favor_num;

            //����Ʈ���� ���� �̸� ������ ��������
            var name = CountrySystem.Instance.Countries[index].CountryName;

            //���� �־��ֱ�
            title_text = name + "������ �����縦 �������ϴ�";
            content_text = name + $"������ ȣ������ {favor_num} ��ŭ �����߽��ϴ�";
            
        }


        private void OnVolunteer(int index, int favor_num)
        {

            //ȣ���� ��ġ�� �Է�
            CountrySystem.Instance.Countries[index].
                Favorability[(int)CharacterSystem.Instance.playerType] += favor_num;

            //����Ʈ���� ���� �̸� ������ ��������
            var name = CountrySystem.Instance.Countries[index].CountryName;

            title_text = name + "�������� ����Ȱ���� �Ͽ����ϴ�";
            content_text = name + $"������ ȣ������ {favor_num} ��ŭ �����߽��ϴ�";

        }

        private void OnParty(int index, int favor_num)
        {

            //ȣ���� ��ġ�� �Է�
            CountrySystem.Instance.Countries[index].
                Favorability[(int)CharacterSystem.Instance.playerType] += favor_num;

            //����Ʈ���� ���� �̸� ������ ��������
            var name = CountrySystem.Instance.Countries[index].CountryName;

            title_text = name + "������翡 �����߽��ϴ�";
            content_text = name + $"������ ȣ������ {favor_num} ��ŭ �����߽��ϴ�";

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

    }
}
