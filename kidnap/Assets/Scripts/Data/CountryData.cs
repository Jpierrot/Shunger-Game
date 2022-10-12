using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StructTypes;
using UnityEngine.UI;

namespace StructTypes { 

[System.Serializable]
public struct CountryDatas
{

    public string CountryName;
    public Sprite CountryImage;

    public CountryDatas(string name, Sprite image)
    {
        CountryName = name;
        CountryImage = image;
    }

}

public class CountryData
{

}

}