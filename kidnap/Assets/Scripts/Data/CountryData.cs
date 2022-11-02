using EnumTypes;
using UnityEngine;
using UnityEngine.UI;

namespace ClassData { 

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

    /// <summary>
    /// �������� ������ �̷������ ������ Ŭ������ ����
    /// </summary>
    [System.Serializable]
    public class Characters
    {
        public Chars type;

        public Sprite characterImage;
        public string characterName;

        public Characters(Sprite image, string name, Chars type)
        {
            characterImage = image;
            characterName = name;
            this.type = type;
        }
    }

}