using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectroLife
{
    public class Constant
    {
        //команды ботов
        public enum Commands : byte
        {
            PHOTOSINTEZ = 1,//фотосинтез
            EAT = 2,// съесть
            MOVE = 3,//двигаться
            DUBLE = 4,//раздвоение
            CHANGE_DIR = 5,//сменить  направление
            GET_MINERAL = 6,//добыть минерал
            GIVE_ENERGY = 7,//отдать энергию
            GIVE_MINERAL = 8,//отдать минерал
            GEN_ATACK = 9,//атака геном
            MINERAL_ENERGY = 10//минерал в энергию
        };
        //Цветовой режим отображения
        public enum GraphicMode: byte{
            PRODUCTION = 1,//Основной источник получения энергии фотосинтез\минералы\еда
            ENERGY = 2,//Энергия
            MINERAL= 3,//Минералы
            MULTIPLY = 4,//Многоклеточные\одноклеточные
            AGE = 5,//Возраст
        };

        public enum Seasons
        {
            SUMMER = 1,
            FALL = 2,
            WINTER = 3,
            SPRING = 4
        };


        public static int BOT_COUNT_X  = 50;//Количество ботов в ширину
        public static int BOT_COUNT_Y = 50;//Количество ботов в высоту

        public static int BOT_LIMIT  = 10000;//Максимальное количество ботов
        public static int SEASON_CYCLE  = 1000;//Количество циклов в сезоне
        public static int COUNT_COMMAND = 16  ;//Количество команд в геноме
        public static short ENERGY_COMMAND = 4;//Количество энергии которое тратиться на выполнение команды
        public static int MAX_ENERGY = 1000;//Максимальное количество энергии после которого бот раздваивается
        public static short MAX_MINERALS = 100;//Максимальное количество минералов
        public static int MAX_AGE = 1000;//Максимальный возраст бота
        public static int TIME_DECOMPOSITION = 3000;//Количество шагов через которые разложится бот после смерти(удалится)
        public static int COST_DUPLICATE = 150;//Количество энергии для раздваивания
        public static short ENERGY_MINERAL_COST = 4;//Сколько энергии дает 1 минерал
        public static int SEED = 5;//Семя псеворандома
    }
}
