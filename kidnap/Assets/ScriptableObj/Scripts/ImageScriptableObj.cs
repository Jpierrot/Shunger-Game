using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/Image", order = 0)]
public class ImageScriptableObj : ScriptableObject
{

    public ImageData[] Visit;

    public ImageData [] Party;

    public ImageData [] Volunteer;
}

[System.Serializable]
public struct ImageData
{
    /// �ƾ����� ���� �̹����Դϴ�
    public Sprite image;

    /// �ƾ����� ���� �� �ؽ�Ʈ�Դϴ�
    public string title;
    
    /// �ƾ����� ���뿡 �� �ؽ�Ʈ�Դϴ�
    public string content;

    /// ������
    public ImageData(Sprite img, string title, string text)
    {
        image = img;
        content = text;
        this.title = title;
    }
}



