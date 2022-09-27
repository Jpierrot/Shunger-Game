using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kidnap
{

    [System.Serializable]
    public class Country
    {

        public enum Chars
        {
            A, B, C
        }

        public int[] Favorability = new int[3] { 0, 0, 0 };

        public int[] SupportPercent = new int[3] { 0, 0, 0 };

        

        private Chars _favor = (Chars)Random.Range(0, System.Enum.GetValues(typeof(Chars)).Length);

        private int _minPercent = 15;

        private int _allFavor = 0;

        public void SupportCheck(Chars type, int favor) => 
            Favorability[(int)type] = favor;

        public void CheckFavor()
        {
            foreach (int a in Favorability)
            {
                _allFavor += a;
            }
        }

        // 호감도 : 지지율 => 특정 호감도 / 전체 호감도 * 전체 지지율
        public void SetCountry()
        {
            for(int i = 0; i < 3; i++)
            {
                var favor = Favorability[i];

                if (favor == 0)
                    _minPercent = 0;

                SupportPercent[i] = (100 - _minPercent) * (favor / _allFavor);
            }
            
        }



    }


    public class SupportSystem : Singleton<SupportSystem>
    {
        public List<Country> Countries;



        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
