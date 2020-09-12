using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rust_timer
{
    public partial class Form1 : Form
    {
        Clock cargo;
        Clock heli;

        Timer cargoTimer;
        Timer heliTimer;
        private bool isHeliWarn = false;
        SoundPlayer player;
        private bool isCargoWarn = false;

        public Form1()
        {
            cargo = new Clock();
            heli = new Clock();
            cargoTimer = new Timer();
            cargoTimer.Interval = 1000;
            cargoTimer.Tick += new EventHandler(CargoTimerHandler);
            cargoTimer.Start();

            heliTimer = new Timer();
            heliTimer.Interval = 1000;
            heliTimer.Tick += new EventHandler(HeliTimerHandler);
            heliTimer.Start();

            
            InitializeComponent();

        }

        private void HeliTimerHandler(object sender, EventArgs e)
        {
            heli.addSecond();
            label3.Text = heli.ToString() + " Ago";
            if (heli.getHour() == 2 && !isHeliWarn)
            {
                isHeliWarn = true;
                player = new SoundPlayer(Rust_timer.Properties.Resources.heli);
                player.Play();
            }

        }

        private void CargoTimerHandler(object sender, EventArgs e)
        {
            cargo.addSecond();
            label4.Text = cargo.ToString() + " Ago";
            if(cargo.getHour() == 2 && isCargoWarn)
            {
                isCargoWarn = true;
                player = new SoundPlayer(Rust_timer.Properties.Resources.cargo);
                player.Play();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            heli.reset();
            isHeliWarn = false;
            label3.Text = heli.ToString() + " Ago";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cargo.reset();
            isCargoWarn = false;
            label4.Text = cargo.ToString() + " Ago";
        }
    }
}
