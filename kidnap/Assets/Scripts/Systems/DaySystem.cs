using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;
using UnityEngine.Events;

namespace Kidnap
{

    /// <summary>
    /// 구현 목록 : 
    /// 1. 일자 넘기기
    /// 2. 오전, 오후, 저녁 구분하기.
    /// 3. 일자 데이터 저장하기
    /// 게임 내 시간 흐름에 관한 데이터들을 처리할 클래스 입니다.
    /// 시간이 지나거나 하루가 넘어갈 때 마다 동작하는 메소드들을 관리합니다.
    /// </summary>
    public class DaySystem : Singleton<DaySystem>
    {
        // 인스펙터에서 수정하는 변수들
        #region forInspector variables

        [SerializeField]
        public Color[] DayColors = new Color[3];

        //하루가 처음 시작할 때 동작할 메소드
        public UnityEvent StartDayEvents;

        //하루가 넘어갈 때 마다 동작할 메소드 
        public UnityEvent OverDayEvents;

        //시간대가 바뀔 때 마다 동작할 메소드
        public UnityEvent OvertimeEvents;

        #endregion

        /// 현재 시간 상태를 담고 있는 변수입니다.
        DayTime curTime;

        /// <summary>
        /// curTime을 다른 클래스에서 사용하도록 하는 프로퍼티입니다.
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

        //시작하는 날짜
        [SerializeField] int StartDay;

        //게임이 끝나는 날짜
        public int EndDay = 10;

        //현재 일자
        public int curDay = 1;



        /// <summary>
        /// 시스템에 관한 부분은 Awake에서 실행
        /// </summary>
        void Awake()
        {
            curDay = StartDay;
            CurTime = DayTime.Morning;
            StartDayEvents.Invoke();
        }

        /// <summary>
        /// 시간대를 다음으로 넘기는 메소드입니다.
        /// 플레이어가 특정 행동을 할 때 마다 호출됩니다.
        /// 다른 클래스(프레젠터)에서 이벤트가 수행될 때 호출됩니다.
        /// </summary>
        public void OverTime()
        {

            Debug.Log("하루 지남");

            // 만약 저녁일 경우 시간대를 더이상 증가시키지 않고 하루를 넘김
            if (CurTime == DayTime.evening)
            {
                OvertimeEvents.Invoke();
                OverDay();
                return;
            }

            // 저녁이 아니면 curTime(시간대)를 증가
            CurTime++;

            // 시간대 변경마다 필요한 이벤트를 호출
            OvertimeEvents.Invoke();
        }

        /// <summary>
        /// 하루를 넘기는 메소드입니다.
        /// </summary>
        public void OverDay()
        {
            CurTime = 0;
            curDay++;
            OverDayEvents.Invoke();
        }

        /// <summary>
        /// 데이터에 저장되어 있는 시간대별 배경 색깔에 대한 정보를 받아오는 메소드입니다.
        /// </summary>
        /// <param name="time">시간대를 담고 있는 변수</param>
        /// <returns>입력받은 시간대에 대한 배경색을 반환합니다</returns>
        public Color TimeColor(DayTime time)
        {
            return DayColors[(int)time];
        }
    }
}
