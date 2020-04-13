using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SharpGL;
using SharpGL.SceneGraph.Assets;

namespace ElectroLife
{
    public class World
    {
        public int CELL_X_COUNT { get; private set; }
        public int CELL_Y_COUNT { get; private set; }
        
        public Bot[,] bots;//Боты
        public List<Bot> botsList = new List<Bot>(); 
        public int cyclesCounter = 0;//Количество  циклов
        private int seasonPtr = 0;//Текущий сезон
        private int seasonCount = 0;//Количество циклов текущего сезона
        private Constant.Seasons[] seasons;//Доступные сезоны
        public List<Area> areas = new List<Area>(); //Зоны
        public float cellWidth = 10;
        public float cellHeight= 10;
        public float wndWidth = 10;
        public float wndHeight= 10;
        public int familyUidStart = 1;//Идентификатор следующей многоклеточной, +1 при каждой новой для уникальности
        public Constant.GraphicMode graphicMode = Constant.GraphicMode.PRODUCTION;
        public bool isShowDied = true;//Показывать погибших
        public RectangleF viewport;//Зона видимости, для оптимизации будет рисовать только то что входит в неё
        public int botsDraw = 0;

        public Texture botTexture;
        
    public World() {

        this.CELL_X_COUNT = Constant.BOT_COUNT_X;//Количество клеток по ширине
        this.CELL_Y_COUNT = Constant.BOT_COUNT_Y;//Количество клеток по высоте
        bots = new Bot[this.CELL_X_COUNT,this.CELL_Y_COUNT];
        seasons = new Constant.Seasons[]{
            Constant.Seasons.SUMMER,
            Constant.Seasons.FALL,
            Constant.Seasons.WINTER,
            Constant.Seasons.SPRING
        };
    }
    public Constant.Seasons getSeason(){
        return this.seasons[this.seasonPtr];
    }
    public void step(){
        this.cyclesCounter++;
        this.seasonStep();
        for(var i = this.botsList.Count-1;i >= 0;i--)
            this.botsList[i].step();
    }
    public void seasonStep(){
        if(++this.seasonCount >= Constant.SEASON_CYCLE){//Смена сезонов,
            this.seasonCount = 0;
            this.seasonPtr = (this.seasonPtr + 1) % this.seasons.Length;
            Utils.log(String.Format("СМЕНА СЕЗОНА на '{0}'",this.getSeason()));
        }
    }

    public void addBot(Bot b){
        if (botsList.Count >= Constant.BOT_LIMIT)return;
        if (bots[b.x, b.y] != null)
            botsList.Remove(bots[b.x, b.y]);
        botsList.Add(b);
        bots[b.x, b.y] = b;
    }
    public Bot getBot(Point p){
        return getBot(p.X, p.Y);
    }
    public Bot getBot(int x, int y){
        return bots[x, y];
    }
    public void deleteBot(Bot bot){
        bots[bot.x, bot.y] = null;
        this.botsList.Remove(bot);
    }
    public void draw(OpenGL gl,int wndWidth,int wndHeight)
    {
        var min = Math.Min(wndWidth/this.CELL_X_COUNT, wndHeight/this.CELL_Y_COUNT);
        if (min < 1)
            min = 1;

        var vp = new Rectangle(
            (int) Math.Ceiling(this.viewport.X / this.cellWidth),
            (int) Math.Ceiling(this.viewport.Y / this.cellHeight),
            (int) Math.Ceiling(this.viewport.Width / this.cellWidth),
            (int) Math.Ceiling(this.viewport.Height/ this.cellHeight)
            );

        this.cellWidth = min;
        this.cellHeight = min;
        this.wndHeight = wndHeight;
        this.wndWidth = wndWidth;
        this.areas.ForEach(el=> el.draw(gl));
        botsDraw = 0;
        this.botsList.ForEach(el =>{
            if (el.x +1 >= vp.X && el.x<= vp.X + vp.Width && el.y +1 >= vp.Y &&
                el.y  <= vp.Y + vp.Height)
            {
                botsDraw++;
                el.draw(gl);
            }
        });
    }
}
}
