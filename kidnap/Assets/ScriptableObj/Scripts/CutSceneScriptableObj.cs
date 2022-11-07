using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/Image", order = 0)]
public class CutSceneScriptableObj : ScriptableObject
{

    public CutSceneData[] Visit;

    public CutSceneData [] Party;

    public CutSceneData [] Volunteer;
}

[System.Serializable]
public struct CutSceneData
{
    /// �ƾ����� ���� �̹����Դϴ�
    public Sprite image;

    /// �ƾ����� ���� �� �ؽ�Ʈ�Դϴ�
    public string title;
    
    /// �ƾ����� ���뿡 �� �ؽ�Ʈ�Դϴ�
    public string content;

    /// ������
    public CutSceneData(Sprite img, string title, string text)
    {
        image = img;
        content = text;
        this.title = title;
    }
}



