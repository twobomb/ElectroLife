using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SharpGL;

namespace ElectroLife
{
    public class Area{//Зоны
        public int x { get;  set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get;set; }
        private World world;

        public Dictionary<Constant.Seasons,SeasonParams> seasonParams = new Dictionary<Constant.Seasons, SeasonParams>(); 
    public Area(World w){
        this.world = w;

    }
    public bool inZone(Bot bot){//Бот в зоне?
        return this.x <= bot.x && this.x + this.width >= bot.x &&
            this.y <= bot.y && this.y + this.height >= bot.y;
    }
    public void draw(OpenGL gl)
    {
        double r = 0, g = 0, b = 0;

        if (seasonParams[this.world.getSeason()].energy == 0 && seasonParams[this.world.getSeason()].mineral == 0)
            return;
        if (seasonParams[this.world.getSeason()].energy > 0){
            r = .8 - ( .5/seasonParams[this.world.getSeason()].energy)%1;
            g = .5 - ( .5 / seasonParams[this.world.getSeason()].energy)%1;
        }

        if (seasonParams[this.world.getSeason()].mineral> 0)
            b = (b + 0.8 * (seasonParams[this.world.getSeason()].mineral)/4)%1;

        gl.Begin(OpenGL.GL_POLYGON);
        gl.Color(r,g,b);
        gl.Vertex(this.x * this.world.cellWidth , this.y * this.world.cellHeight );
        gl.Vertex(this.x * this.world.cellWidth + this.width * this.world.cellWidth, this.y * this.world.cellHeight);
        gl.Vertex(this.x * this.world.cellWidth + this.width * this.world.cellWidth, this.y * this.world.cellHeight + this.height * this.world.cellHeight);
        gl.Vertex(this.x * this.world.cellWidth, this.y * this.world.cellHeight + this.height * this.world.cellHeight);
        gl.End();
    }
    public void apply(Bot bot,Constant.Seasons season, Constant.Commands action){//Совершить фотосинтез или добыть минерал
        if(!this.inZone(bot))return;
        SeasonParams param;
        if (!seasonParams.TryGetValue(season, out param))
            throw new Exception(String.Format("Не найдены параметры зоны [{0},{1},{2},{3}] для сезона {4}", this.x.ToString(),
                this.y.ToString(), this.width.ToString(), this.height.ToString(), season.ToString()));
        if (action == Constant.Commands.PHOTOSINTEZ && param.energy > 0)
        {
            bot.addEnergy(param.energy);
            bot.energyFrom[0]++;
        }
        if (action == Constant.Commands.GET_MINERAL && param.mineral > 0)
            bot.addMineral(param.mineral);
    }
}
}
