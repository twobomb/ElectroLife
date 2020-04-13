using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectroLife
{
    public class SeasonParams{//Описание параметров зоны
        public short energy { get; private set; }//Сколько даёт энергии
        public short mineral { get; private set; }//Сколько даёт минералов

        public SeasonParams(){}

        public SeasonParams(short energy, short mineral)
        {
            this.energy = energy;
            this.mineral = mineral;
        }
    }
}
