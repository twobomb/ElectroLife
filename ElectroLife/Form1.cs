using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL;
using SharpGL.Enumerations;
using SharpGL.SceneGraph.Assets;

namespace ElectroLife
{
    public partial class Form1 : Form
    {
        private OpenGL gl;
        private World world;
        private bool isPause = false;
        private bool isStopped= false;
        private int multiply = 1;
        private float _offX = 0;
        private float _offY = 0;
        private float offLimit = 200;
        private bool isDraw = true;
        System.Diagnostics.Stopwatch watch  = new Stopwatch();
        System.Diagnostics.Stopwatch watchFreq  = new Stopwatch();

        private string fps = "";

        private float offX 
        {
            get { return _offX; }
            set
            {
                _offX = value;
                float wl = (float)(((world.wndWidth) - offLimit));
                float wr = -(float)(((world.CELL_X_COUNT*world.cellWidth) * scale - offLimit));
                if (world != null && value < wr)
                    _offX = (float) wr;
                if (world != null && value > wl)
                    _offX = wl;

            }
    }
        private float offY 
        {
            get { return _offY; }
            set
            {
                _offY = value;
                float ht = (float)(((world.wndHeight) - offLimit));
                float hb = -(float)(((world.CELL_Y_COUNT * world.cellHeight) * scale - offLimit));
                if (world != null && value < hb)
                    _offY = (float)hb;
                if (world != null && value > ht)
                    _offY = ht;
            }
    }
        private int lastX = 0;
        private int lastY = 0;
        private bool isDrag =false;
        private double _scale = 1;

        private double scale
        {
            get { return _scale; }
            set
            {
                var t = (value - _scale)/2;
                _scale = value;
                offX -= (float) (world.wndWidth* t);
                offY -= (float) (world.wndHeight * t);
            }
        }

        private Texture t;
        public Form1()
        {
            InitializeComponent();
            gl = this.openGLControl1.OpenGL;
            this.Closed += Form1_Closed;
            
            
            init();


        }

        public void init(){//Инициализацию создания новой симуляции
            Utils.next = Constant.SEED;
            world = new World() { };
            world.addBot(new Bot(world));
            int heightArea = world.CELL_Y_COUNT / 16;

            world.botTexture = new Texture();
            world.botTexture.Create(gl, new Bitmap(@"bot.png"));
            world.botTexture.Bind(gl);

            for (var i = 1; i <= 8; i++)//Создание зон с минералами
                world.areas.Add(new Area(world)
                {
                    x = 0,
                    y = (8 * heightArea - i * heightArea),
                    height = heightArea,
                    width = world.CELL_X_COUNT,
                    seasonParams = new Dictionary<Constant.Seasons, SeasonParams>(){
                {Constant.Seasons.SUMMER,new SeasonParams(0, (short) ((i >= 1 && i <=3)?1:(i >=4 && i <=6)?2:3 ))},
                {Constant.Seasons.SPRING,new SeasonParams(0, (short) ((i >= 1 && i <=3)?1:(i >=4 && i <=6)?2:3 ))},
                {Constant.Seasons.WINTER,new SeasonParams(0, (short) ((i >= 1 && i <=3)?1:(i >=4 && i <=6)?2:3))},
                {Constant.Seasons.FALL,new SeasonParams(0, (short) ((i >= 1 && i <=3)?1:(i >=4 && i <=6)?2:3 ))},
            }
                });
            openGLControl1.MouseWheel += openGLControl1_MouseWheel;


            for (var i = 1; i <= 11; i++)
            {//Создание зон с фотосинтезом
                world.areas.Add(new Area(world)
                {
                    x = 0,
                    y = world.CELL_Y_COUNT - i * heightArea,
                    height = heightArea,
                    width = world.CELL_X_COUNT,
                    seasonParams = new Dictionary<Constant.Seasons, SeasonParams>()
                    {
                        {Constant.Seasons.SUMMER,new SeasonParams((short) (12 - i),0)},
                        {Constant.Seasons.SPRING,new SeasonParams((short) (11 - i < 0 ? 0 : 11 - i),0)},
                        {Constant.Seasons.WINTER,new SeasonParams((short) (10 - i < 0 ? 0 : 10 - i),0)},
                        {Constant.Seasons.FALL,new SeasonParams((short) (11 - i < 0 ? 0 : 11 - i),0)},
                    }
                });
            }
            offX = 0;
            offY = 0;
            scale = 1;
            watch.Start();
            watchFreq.Start();

        }

        void openGLControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            var s = (float) e.Delta/480;
            if (scale + s> 0 && scale + s <= 5)
                scale += s;
            zoom.Text = "ZOOM x" + scale;
//            offY += (int)scale*-100;
            //Добавить ограничите чтобы offY был не меньше -1000...
        }

        void Form1_Closed(object sender, EventArgs e)
        {
            gl.End();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var s = new SharpGL.SceneControl();
            this.Controls.Add(s);

        }
        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args){

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            if(isStopped)return;
            var width = openGLControl1.Width;
            var height = openGLControl1.Height;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Ortho2D(0.0, width, 0.0, height);
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.LoadIdentity();
            gl.Translate(offX, offY, 0);
            gl.Scale(scale, scale, 0);

            float x = (float) (-offX/scale);
            float y = (float) (-offY / scale);
            float w = (float) (width / scale);
            float h = (float) (height / scale);

            world.viewport = new RectangleF(x,y,w,h);

            if (isDraw)
                world.draw(gl,width,height);

            int die = 0, alive = 0;
            die = world.botsList.Count(bot => bot.isDie);
            alive = world.botsList.Count - die;

            if (!isPause)
                for (int i = 0; i < multiply; i++)
                    world.step();
            if (watchFreq.ElapsedMilliseconds >= 300){
                fps = Utils.minFormat(Math.Floor(1000f/watch.ElapsedMilliseconds), 3);
                watchFreq.Restart();
            }


            gl.DrawText(30, height - 30, 0, 1f, 0, "monospace", 14f, String.Format("FPS: {0}\tSTEPS: {1}\tALIVE: {2}\tDEAD: {3}\tBOTS COUNT: {4}", fps, Utils.minFormat(this.world.cyclesCounter, 8,"0"), Utils.minFormat(alive, Constant.BOT_LIMIT.ToString().Length), Utils.minFormat(die, Constant.BOT_LIMIT.ToString().Length), Utils.minFormat(this.world.botsDraw, Constant.BOT_LIMIT.ToString().Length)));
            watch.Restart();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isPause = !isPause;
            button1.Text = isPause ? "Старт" : "Пауза";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            multiply = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            multiply = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            multiply = 3;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            multiply = 10;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            multiply = 100;
        }

        private void openGLControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left){
                lastX = e.X;
                lastY = e.Y;
                isDrag = true;
            }
        }

        private void openGLControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isDrag = false;
        }

        private void openGLControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag){
                offX += (e.X - lastX) / 1;
                offY += (lastY - e.Y)/1;
            }
            lastX = e.X;
            lastY = e.Y;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            isDraw = checkBox1.Checked;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
                multiply = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton2.Checked)
                multiply = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton3.Checked)
                multiply = 5;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton4.Checked)
                multiply = 10;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton5.Checked)
                multiply = 100;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            world.graphicMode = Constant.GraphicMode.ENERGY;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            world.graphicMode = Constant.GraphicMode.PRODUCTION;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            world.graphicMode = Constant.GraphicMode.MINERAL;
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            world.graphicMode = Constant.GraphicMode.MULTIPLY;
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            world.graphicMode = Constant.GraphicMode.AGE;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            world.isShowDied = checkBox2.Checked;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            isStopped = true;
            new_sim ns = new new_sim();
            if(ns.ShowDialog() == DialogResult.OK)
                   init();
            isStopped = false;
        }
    }
}
