using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임에 사용되는 enum들을 열거해 놓은 클래스
/// </summary>
namespace EnumTypes
{

    // 캐릭터 종류를 나타낸 enum
    public enum Chars
    {
        A, B, C
    }

    // 시간대를 구분하는 enum
    public enum DayTime
    {
        Morning,
        Afternoon,
        evening
    }

    /// <summary>
    /// ShowManager에서 사용되는 enum 종류들입니다.
    /// 
    /// </summary>
    public enum ShowType
    {
        visit,
        party,
        volunteer
    }

    /// <summary>
    /// MoneySystem에서 사용되는 enum 종류들입니다.
    /// 계산에 필요한 enum 유형입니다.
    /// </summary>
    public enum Calc
    {
        plus,
        minus
    }

    
}
