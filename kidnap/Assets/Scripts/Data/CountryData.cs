using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StructTypes;
using UnityEngine.UI;

namespace StructTypes { 


public struct CountryDatas
{

    

}
    [System.Serializable]
    public class CountryData
{
        public string CountryName;
        public Sprite CountryImage;
        public int CountryPop;

        public void CountryDatas(string name, Sprite image, int pop)
        {
            CountryPop = pop;
            CountryName = name;
            CountryImage = image;
        }
    }

}