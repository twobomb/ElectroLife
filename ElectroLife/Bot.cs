using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms.PropertyGridInternal;
using System.Xml;
using SharpGL;
using SharpGL.Enumerations;

namespace ElectroLife
{
    public class Bot
    {
        private byte[] genom;
        private World world;
        public int x { get; set; }
        public int y { get; private set; }
        public bool isDie = false;//Мертв?
        private int age = 0;//Количество циклов жизни
        private int ptr = 0;//указатель текущей команды
        private byte dir = 0;//направление движения, 0 - R, 1 -RB, 2 - B, 3- LB, 4 - L, 5- LT, 6 - T, 7 - RT (R - right,T - top, L -left, B - bottom)
        public short energy = 1000;//Количество энергии
        private short minerals = 0;//Количество минералов
        private bool isMulti = false;//многоклеточная
        private int decomposition = 0;//Количество циклов после смерти
        public int familyUid;//Уникальный ID семьи, для многоклеточных
        public List<Bot> familyBots = new List<Bot>();//Боты семьи

        public int[] energyFrom= new int[3]{0,0,0};//От чего сколько энергии получил [фотосинтез,минералы, еда]

    public Bot(World world)
        {
            this.world = world;
        x = 15;
        y = this.world.CELL_Y_COUNT - 1;
        this.genom = new byte[Constant.COUNT_COMMAND];
        for (var i = 0; i < genom.Length;i++)
            this.genom[i] = (byte) Constant.Commands.PHOTOSINTEZ;//По умолчанию заполняет массив команд фотосинтезом
    }


        public void next(short count = 1){//перемещение указателя команды
        this.ptr = (this.ptr + count)%this.genom.Length;
    }

    public double getAngle(){//Получить угол поворота
        return this.dir*45;
    }
    public Constant.Commands getCommand(){//Получить команду
        return (Constant.Commands) this.genom[this.ptr];
    }


        public double[] getColor(){
            double[] color = new double[3]{0,0,0};
            if (isDie)
            {
                color[0] = 0.4f;
                color[1] = 0.3f;
                return color;
            }
            switch (this.world.graphicMode){//Получить цвет в зависимости от режима
                    case Constant.GraphicMode.PRODUCTION://
                    double sum = energyFrom.Sum();
                    if (energyFrom[0] > energyFrom[1] && energyFrom[0] > energyFrom[2])
                        color[1] = (double) energyFrom[0]/sum;
                    else if (energyFrom[1] > energyFrom[0] && energyFrom[1] > energyFrom[2]){
                        color[2] = (double) energyFrom[1]/sum;
                    }
                    else if (energyFrom[2] > energyFrom[0] && energyFrom[2] > energyFrom[1]){
                        color[0] = (double) energyFrom[2]/sum;
                    }
                    break;
                    case Constant.GraphicMode.ENERGY:
                        color[0] = (double)energy / (double)Constant.MAX_ENERGY;
                        color[1] = .8f * ((double)energy / (double)Constant.MAX_ENERGY);
                    break;
                    case Constant.GraphicMode.MINERAL:
                        color[2] = (double)minerals/ (double)Constant.MAX_MINERALS;
                        color[1] = .7f * ((double)minerals / (double)Constant.MAX_MINERALS);
                    break;
                    case Constant.GraphicMode.MULTIPLY:
                    if (isMulti){
                        color[0] = 1f;
                        color[2] = .8f;
                    }
                    else{
                        color[0] = .8f;
                        color[1] = 1f;
                    }
                    break;
                    case Constant.GraphicMode.AGE:
                        color[0] = color[1] = color[2] =  1f - ((double)age/(double)Constant.MAX_AGE);
                        
                    break;
            }
            return color;
        }
    public void draw(OpenGL gl){//Рисование бота
        if (isDie && !this.world.isShowDied)return;
        gl.Color(this.getColor());
/*
        gl.Begin(OpenGL.GL_POLYGON);
        gl.Vertex(this.x * world.cellWidth, this.y*world.cellHeight);
        gl.Vertex(this.x* world.cellWidth + world.cellWidth, this.y * world.cellHeight);
        gl.Vertex(this.x * world.cellWidth  + world.cellWidth , this.y * world.cellHeight + world.cellHeight);
        gl.Vertex(this.x*world.cellWidth , this.y*world.cellHeight+ world.cellHeight);
        gl.End();*/

        gl.PushMatrix();
        gl.Enable(OpenGL.GL_ALPHA_TEST);
        gl.AlphaFunc(OpenGL.GL_GREATER, .8f);
        gl.Enable(OpenGL.GL_TEXTURE_2D);
        gl.Translate(this.x * world.cellWidth + world.cellWidth / 2, this.y * world.cellHeight + world.cellHeight/2, 0);
        gl.Rotate(this.getAngle(), 0, 0, 1);

        gl.Begin(BeginMode.Quads);
        gl.TexCoord(0, 1);
        gl.Vertex(-world.cellWidth/2,  -world.cellHeight/2);
        gl.TexCoord(1, 1);
        gl.Vertex(-world.cellWidth/2 + world.cellWidth,  -world.cellHeight/2);
        gl.TexCoord(1, 0);
        gl.Vertex( -world.cellWidth/2 + world.cellWidth,  -world.cellHeight/2 + world.cellHeight);
        gl.TexCoord(0, 0);
        gl.Vertex(-world.cellWidth/2, -world.cellHeight/2 + world.cellHeight);
        gl.End();
        gl.Disable(OpenGL.GL_TEXTURE_2D);
        gl.Disable(OpenGL.GL_ALPHA_TEST);
        gl.PopMatrix();

    }
    public void move(int x,int y){
        world.bots[this.x, this.y] = null;
        this.x = x;
        this.y = y;
        world.bots[this.x, this.y] = this;
    }
    public void move(Point pos){
        if(!this.isMulti)
            this.move(pos.X,pos.Y);
    }
    public Point getNextPos(){//Получить следующую позицию, учитывая движение
        var x = this.x;
        var y = this.y;
        if(this.dir == 0 || this.dir == 1 || this.dir == 7)
            x++;
        if(this.dir == 3 || this.dir == 4 || this.dir == 5)
            x--;
        if(this.dir == 5 || this.dir == 6 || this.dir == 7 )
            y--;
        if(this.dir == 1 || this.dir == 2 || this.dir == 3)
            y++;
        x = (x + this.world.CELL_X_COUNT)%this.world.CELL_X_COUNT;
        y = (y + this.world.CELL_Y_COUNT)%this.world.CELL_Y_COUNT;
        return new Point(x,y);
    }
    public void changeGen(){//Изменяет рандомный ген
        this.genom[Utils.getRandInt(0,this.genom.Length-1)] = (byte) Utils.getRandInt(1,10);//Генерим рандомный ген 
    }
    public void step(){//шаг жизни
        if (this.isDie){
            if(++this.decomposition >= Constant.TIME_DECOMPOSITION)
                this.world.deleteBot(this);
            return;
        }
        if (++this.age >= Constant.MAX_AGE){
            this.die();
            return;
        }
        if (isMulti && !isHaveFamilyBeside()){//Если рядом нет членов семьи, а ты многоклеточный, то ты одноклеточный
            isMulti = false;
            familyUid = 0;
            familyBots.Remove(this);
            familyBots = new List<Bot>();
        }
        switch (this.getCommand()) {
            case Constant.Commands.PHOTOSINTEZ:case Constant.Commands.GET_MINERAL:
                this.world.areas.ForEach(a => a.apply(this,this.world.getSeason(),this.getCommand()));
                break;
            case Constant.Commands.MOVE:{//Движение
                var nextpos = this.getNextPos();
                if (this.world.getBot(nextpos.X, nextpos.Y) == null)
                    this.move(nextpos);
            }
                break;
            case Constant.Commands.EAT:{//Съесть бота по ходу движения
                var nextpos = this.getNextPos();
                var b = this.world.getBot(nextpos.X, nextpos.Y);
                if (b != null){
                    if (this.isMulti && b.isMulti && this.familyUid == b.familyUid)//Не есть клетки своей семьи
                        break;

                    if (this.energy < b.energy){//Если у нас энергии меньше чем у жертвы, то тратим 75% нашей энергии и не съедаем жертву
                        this.addEnergy((short) -((double) this.energy*.75f));
                    }
                    else{
                        this.addEnergy((short) (b.energy > 400 ? 400 : b.energy));//Добавить энергию бота, но не больше 400
                        this.energyFrom[2]++;
                        this.world.deleteBot(b);
                        this.move(nextpos);
                    }
                }
            }
                break;
            case Constant.Commands.DUBLE://раздвоение
                this.duplicate();
                break;
            case Constant.Commands.CHANGE_DIR://Смена направления
                var newdir = Utils.getRandInt(0,7);
                while (newdir == this.dir)
                    newdir = Utils.getRandInt(0,7);
                this.dir = (byte) newdir;
                break;
            case Constant.Commands.GIVE_ENERGY:{//Отдать половину энергии
                var nextpos= this.getNextPos();
                var b = this.world.getBot(nextpos);
                if (b!=null){
                    b.addEnergy((short) Math.Round((double) (this.energy/2)));
                    this.addEnergy((short) -Math.Round((double) (this.energy/2)));
                }
            }
                break;
            case Constant.Commands.GIVE_MINERAL:{//Отдать половину минералов
                var nextpos = this.getNextPos();
                var b = this.world.getBot(nextpos);
                if (b != null){
                    b.addMineral((short) Math.Round((double) (this.minerals/2)));
                    this.addMineral((short) -Math.Round((double) (this.minerals/2)));
                }
            }
                break;
            case Constant.Commands.GEN_ATACK:{//Атака геном
                var nextpos = this.getNextPos();
                var b = this.world.getBot(nextpos);
                if (b != null && !b.isDie)
                    b.changeGen();
            }
                break;
            case Constant.Commands.MINERAL_ENERGY:
                if(this.minerals > 0) {
                    this.addMineral(-1);
                    this.addEnergy(Constant.ENERGY_MINERAL_COST);
                    this.energyFrom[1]++;
                }
                break;
            default:
                throw new Exception(String.Format("Неизвестная команда '{0}'",this.getCommand().ToString()));
        }

        this.next();
        this.addEnergy((short) -Constant.ENERGY_COMMAND);
    }
    public void die(){
         this.energy = 0;
         this.isDie = true;
         familyBots.Remove(this);
    }
    public void addEnergyNoReq(short num){//Добавить энерегию без передачи другим(для многоклеточных), чтобы не упасть в бесконечную рекурсию
        this.energy+= num; 
        if(this.energy >= Constant.MAX_ENERGY) 
            this.energy = (short) Constant.MAX_ENERGY;
    }
    public void addEnergy(short num){//Добавить энерегию
    /*    short giveAll = (short) ((double)num/2f);
        if (isMulti && giveAll > 0){//Дать половину полученной энергии каждой клетке семьи
            for (int i = 0; i < familyBots.Count; i++)
                familyBots[i].addEnergyNoReq(giveAll);
        }*/
//        if (isMulti && num > 0)
//            num *= (short) (familyBots.Count > 10 ? 10 : familyBots.Count);
        if (isMulti && num > 0 && familyBots.Count > 100){
            num = (short) Math.Ceiling((double) num/((double) familyBots.Count/20f));
        }
        this.energy+= num; 
        if(this.energy <= 0)
            this.die();
        if(this.energy >= Constant.MAX_ENERGY) {
            this.energy = (short) Constant.MAX_ENERGY;
            this.duplicate();
        }
    }
    public void duplicate(){//раздвоить
        this.addEnergy((short)-Constant.COST_DUPLICATE);
        Point? cell = this.getRandFreeCell();

        if (cell == null){//Если окружен и он не многоклеточный то умирает
            if (!isMulti)
                this.die();
            return;
        }
        byte[] arr = (byte[]) this.genom.Clone();
        var ef = new int[]{0,0,0};
        ef[energyFrom.ToList().IndexOf(energyFrom.Max())]++;
        var newbot = new Bot(this.world){
            x = cell.Value.X,
            y = cell.Value.Y,
            genom = arr,
            energy =  (short) Math.Round((double) (this.energy/2)),//При создании нового бота, у него половина энергии родителя
            minerals =  (short) Math.Round((double) (this.minerals/2)),//При создании нового бота, у него половина минералов родителя
            dir = this.dir,
            energyFrom = ef
        };
        if(Utils.rand() < .25)
            newbot.changeGen();


        if (Utils.rand() < .01 || this.isMulti){//Шанс стать многоклеточным,Если родитель многоклеточный то и новый будет многоклеточный
            if (!this.isMulti)
                this.familyUid = this.world.familyUidStart++;
            if (familyBots.Count == 0)
                familyBots.Add(this);
            familyBots.Add(newbot);
            newbot.familyBots = familyBots;
            newbot.familyUid = this.familyUid;
            newbot.isMulti = true;
            this.isMulti = true;
        }
        this.world.addBot(newbot);
    }
    public Point? getRandFreeCell(){//получить рандомную свободную ячейку вокруг бота если она есть
        var t = this.getFreeCells();
        if(t.Length == 0)return null;
        return t[Utils.getRandInt(0,t.Length-1)];
    }

        public Bot[] getBotBeside(){//Получить всех ботов вокруг
            List<Point> posBeside = new List<Point>(){
            new Point(this.x+1, this.y),
            new Point(this.x+1, this.y+1),
            new Point(this.x, this.y+1),
            new Point(this.x-1, this.y+1),
            new Point(this.x-1, this.y),
            new Point(this.x-1, this.y-1),
            new Point(this.x, this.y-1),
            new Point(this.x+1, this.y+1),
    };
            return posBeside.Select(el =>
            {
                el.X = (el.X + this.world.CELL_X_COUNT) % this.world.CELL_X_COUNT;
                el.Y = (el.Y + this.world.CELL_Y_COUNT) % this.world.CELL_Y_COUNT;
                return this.world.getBot(el);
            }).Where(el => el != null).ToArray();    
        }
        public bool isHaveFamilyBeside(){//есть ли родственный бот рядом(для многоклеточных)
            if (!isMulti) return false;
            return this.getBotBeside().Count(bot => !bot.isDie && bot.isMulti && bot.familyUid == this.familyUid) > 0;
        }

        public Point[] getFreeCells(){//получить свободные ячейки вокруг бота
        List<Point> freeCell = new List<Point>(){
            new Point(this.x+1, this.y),
            new Point(this.x+1, this.y+1),
            new Point(this.x, this.y+1),
            new Point(this.x-1, this.y+1),
            new Point(this.x-1, this.y),
            new Point(this.x-1, this.y-1),
            new Point(this.x, this.y-1),
            new Point(this.x+1, this.y+1),
    };
        return freeCell.Select(el =>
        {
            el.X = (el.X + this.world.CELL_X_COUNT)%this.world.CELL_X_COUNT;
            el.Y = (el.Y + this.world.CELL_Y_COUNT)%this.world.CELL_Y_COUNT;
            return el;
        }).Where(el => this.world.getBot(el) == null).ToArray();
    }
    public void addMineral(short num){//добавить минералы
        this.minerals += num;
        if(this.minerals < 0 )
            this.minerals = 0;
        if(this.minerals > Constant.MAX_MINERALS)
            this.minerals = Constant.MAX_MINERALS;
    }
}
}
