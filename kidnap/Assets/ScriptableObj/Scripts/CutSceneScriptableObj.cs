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
    /// 컷씬에서 사용될 이미지입니다
    public Sprite image;

    /// 컷씬에서 제목에 들어갈 텍스트입니다
    public string title;
    
    /// 컷씬에서 내용에 들어갈 텍스트입니다
    public string content;

    /// 생성자
    public CutSceneData(Sprite img, string title, string text)
    {
        image = img;
        content = text;
        this.title = title;
    }
}



