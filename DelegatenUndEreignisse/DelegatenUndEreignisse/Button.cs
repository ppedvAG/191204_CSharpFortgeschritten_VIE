using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatenUndEreignisse
{
    class Button
    {
        // Variante "lang"
        //private Action KlickLogik;
        //public event Action KlickEvent
        //{
        //    add
        //    {
        //        KlickLogik += value;
        //    }
        //    remove
        //    {
        //        KlickLogik -= value;
        //    }
        //}


        public event Action KlickEvent;// "AutoProperty"
        public void Klick()
        {
            // Logik
            if(KlickEvent != null)
                KlickEvent();
        }
    }
}
