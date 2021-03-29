using System;
using System.Collections.Generic;
using System.Text;

namespace BankShot
{
    public struct Map
    {
        //Fields
        private GameObject[] map;
        //Properties
        public GameObject[] MapArray
        {
            get { return map; }
            set { map = value; }
        }

        public GameObject this[int index]
        {
            get { return map[index]; }
        }
    }
}
