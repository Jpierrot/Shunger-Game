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

        /// <summary>
        /// �����湮�� �ö󰡴� ȣ������ ��
        /// </summary>
        [SerializeField]
        const int favor_raise = 10;

        /// <summary>
        /// ���� ������� Show ȭ���� ������ ��Ÿ���� ������
        /// �ٸ� ��ũ��Ʈ���� ȣ���� �� MakeShow �޼ҵ带 ���� ������ �����ؼ� �ʿ��� �޼ҵ带 �ĺ�
        /// </summary>
        [HideInInspector, Tooltip("���� ������� Show ȭ���� ������ ��Ÿ���� �������Դϴ�")]
        public ShowType show;

        /// <summary>
        /// �ӽ÷� ���뿡 �� �ؽ�Ʈ�� �����ϰ� ���� string �����Դϴ�.
        /// </summary>
        string content_text;

        /// <summary>
        /// �ӽ÷� ���� �� �ؽ�Ʈ�� �����ϰ� ���� string �����Դϴ�.
        /// </summary>
        string title_text;

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
                    OnVisit(num, favor_raise);
                    break;
                
                default:
                    break;
            }
        }

        /// <summary>
        /// ���� �湮�� ���ϴ� ������ ����ϴ� �޼ҵ�
        /// </summary>
        /// <param name="index">����Ʈ �ε���</param>
        /// <param name="favor_num">������ų ȣ������ ��ġ</param>
        public void OnVisit(int index, int favor_num)
        {

            //ȣ���� ��ġ�� �Է�
            CountrySystem.Instance.Countries[index].
                Favorability[(int)CharacterSystem.Instance.playerType] += favor_num;

            //����Ʈ���� ���� �̸� ������ ��������
            var name = CountrySystem.Instance.Countries[index].CountryName;

            //���� �־��ֱ�
            title_text = name + "������ �湮�Ͽ����ϴ�";
            content_text = name + $"������ ȣ������ {favor_num} ��ŭ �����߽��ϴ�";
            
            UpdateText();
        }

        /// <summary>
        /// �ӽ÷� ����� �ؽ�Ʈ�� ���� �ִ� ������Ʈ�� ����ȭ �Ҷ� ����մϴ�.
        /// </summary>
        private void UpdateText()
        {
            Titletext.text = title_text;
            textMeshPro.text = content_text;
        }

    }
}
