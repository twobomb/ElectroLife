using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ElectroLife
{
    public partial class new_sim : Form
    {
        public new_sim()
        {
            InitializeComponent();
            numericUpDown1.Value = Constant.BOT_COUNT_X;
            numericUpDown2.Value =Constant.BOT_COUNT_Y;
            numericUpDown3.Value =Constant.BOT_LIMIT;
            numericUpDown4.Value =Constant.SEASON_CYCLE;
            numericUpDown5.Value =Constant.COUNT_COMMAND;
            numericUpDown6.Value =Constant.ENERGY_COMMAND;
            numericUpDown7.Value =Constant.MAX_ENERGY;
            numericUpDown8.Value =Constant.MAX_MINERALS;
            numericUpDown9.Value =Constant.MAX_AGE;
            numericUpDown10.Value =Constant.TIME_DECOMPOSITION;
            numericUpDown11.Value =Constant.COST_DUPLICATE;
            numericUpDown12.Value =Constant.ENERGY_MINERAL_COST;
            numericUpDown13.Value =Constant.SEED;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Constant.BOT_COUNT_X = (int) numericUpDown1.Value;
            Constant.BOT_COUNT_Y = (int) numericUpDown2.Value;
            Constant.BOT_LIMIT = (int)numericUpDown3.Value;
            Constant.SEASON_CYCLE = (int)numericUpDown4.Value;
            Constant.COUNT_COMMAND = (int)numericUpDown5.Value;
            Constant.ENERGY_COMMAND = (short) numericUpDown6.Value;
            Constant.MAX_ENERGY = (int)numericUpDown7.Value;
            Constant.MAX_MINERALS = (short) numericUpDown8.Value;
            Constant.MAX_AGE = (int)numericUpDown9.Value;
            Constant.TIME_DECOMPOSITION = (int)numericUpDown10.Value;
            Constant.COST_DUPLICATE = (int)numericUpDown11.Value;
            Constant.ENERGY_MINERAL_COST = (short) numericUpDown12.Value;
            Constant.SEED = (int)numericUpDown13.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
