using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;
using UnityEngine.Events;

namespace Kidnap
{

    /// <summary>
    /// ���� ��� : 
    /// 1. ���� �ѱ��
    /// 2. ����, ����, ���� �����ϱ�.
    /// 3. ���� ������ �����ϱ�
    /// ���� �� �ð� �帧�� ���� �����͵��� ó���� Ŭ���� �Դϴ�.
    /// �ð��� �����ų� �Ϸ簡 �Ѿ �� ���� �����ϴ� �޼ҵ���� �����մϴ�.
    /// </summary>
    public class DaySystem : Singleton<DaySystem>
    {
        // �ν����Ϳ��� �����ϴ� ������
        #region forInspector variables

        [SerializeField]
        public Color[] DayColors = new Color[3];

        //�Ϸ簡 ó�� ������ �� ������ �޼ҵ�
        public UnityEvent StartDayEvents;

        //�Ϸ簡 �Ѿ �� ���� ������ �޼ҵ� 
        public UnityEvent OverDayEvents;

        //�ð��밡 �ٲ� �� ���� ������ �޼ҵ�
        public UnityEvent OvertimeEvents;

        #endregion

        /// ���� �ð� ���¸� ��� �ִ� �����Դϴ�.
        DayTime curTime;

        /// <summary>
        /// curTime�� �ٸ� Ŭ�������� ����ϵ��� �ϴ� ������Ƽ�Դϴ�.
        /// </summary>
        public DayTime CurTime
        {
            get
            {
                return curTime;
            }

            private set
            {
                curTime = value;
            }
        }

        //�����ϴ� ��¥
        [SerializeField] int StartDay;

        //������ ������ ��¥
        public int EndDay = 10;

        //���� ����
        public int curDay = 1;



        /// <summary>
        /// �ý��ۿ� ���� �κ��� Awake���� ����
        /// </summary>
        void Awake()
        {
            curDay = StartDay;
            CurTime = DayTime.Morning;
            StartDayEvents.Invoke();
        }

        /// <summary>
        /// �ð��븦 �������� �ѱ�� �޼ҵ��Դϴ�.
        /// �÷��̾ Ư�� �ൿ�� �� �� ���� ȣ��˴ϴ�.
        /// �ٸ� Ŭ����(��������)���� �̺�Ʈ�� ����� �� ȣ��˴ϴ�.
        /// </summary>
        public void OverTime()
        {

            Debug.Log("�Ϸ� ����");

            // ���� ������ ��� �ð��븦 ���̻� ������Ű�� �ʰ� �Ϸ縦 �ѱ�
            if (CurTime == DayTime.evening)
            {
                OvertimeEvents.Invoke();
                OverDay();
                return;
            }

            // ������ �ƴϸ� curTime(�ð���)�� ����
            CurTime++;

            // �ð��� ���渶�� �ʿ��� �̺�Ʈ�� ȣ��
            OvertimeEvents.Invoke();
        }

        /// <summary>
        /// �Ϸ縦 �ѱ�� �޼ҵ��Դϴ�.
        /// </summary>
        public void OverDay()
        {
            CurTime = 0;
            curDay++;
            OverDayEvents.Invoke();
        }

        /// <summary>
        /// �����Ϳ� ����Ǿ� �ִ� �ð��뺰 ��� ���� ���� ������ �޾ƿ��� �޼ҵ��Դϴ�.
        /// </summary>
        /// <param name="time">�ð��븦 ��� �ִ� ����</param>
        /// <returns>�Է¹��� �ð��뿡 ���� ������ ��ȯ�մϴ�</returns>
        public Color TimeColor(DayTime time)
        {
            return DayColors[(int)time];
        }
    }
}
