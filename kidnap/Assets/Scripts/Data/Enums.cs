using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ӿ� ���Ǵ� enum���� ������ ���� Ŭ����
/// </summary>
namespace EnumTypes
{

    // ĳ���� ������ ��Ÿ�� enum
    public enum Chars
    {
        A, B, C
    }

    // �ð��븦 �����ϴ� enum
    public enum DayTime
    {
        Morning,
        Afternoon,
        evening
    }

    /// <summary>
    /// ShowManager���� ���Ǵ� enum �������Դϴ�.
    /// 
    /// </summary>
    public enum ShowType
    {
        visit,
        party,
        volunteer
    }

    /// <summary>
    /// MoneySystem���� ���Ǵ� enum �������Դϴ�.
    /// ��꿡 �ʿ��� enum �����Դϴ�.
    /// </summary>
    public enum Calc
    {
        plus,
        minus
    }

    
}
