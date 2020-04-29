using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace PetrolTruelyUnlimited
{
    class Pump
    {
        private Panel panel;
        System.Windows.Forms.Timer timer;
        private bool available = true;
        Random random = new Random();
        private double unleadedDispensed = 0;
        private double LPGDispensed = 0;
        private double dieselDispensed = 0;
        private int FuelIntervalTime = 0;
        public Pump()
        {

        }
        public Pump(Panel panel)
        {
            this.panel = panel;
            timer = new System.Windows.Forms.Timer();
            updatePanel();
            available = false;
            int randomNumber = random.Next(17000, 19001);
            FuelIntervalTime = randomNumber;
            timer.Interval = randomNumber;
            timer.Start();
            timer.Tick += new EventHandler(Timer_Tick);

        }
        private void updatePanel()
        {
            if (available == true)
            {
                panel.BackColor = Color.Red;
            }
            else panel.BackColor = Color.Lime;
        }
        public void Timer_Tick(object sender, EventArgs eArgs)
        {
            updatePanel();
            available = true;
            timer.Stop();
        }
        public bool getStatus()
        {
            return available;
        }
        public void AddUnleadedDispensed(double unleaded)
        {
            unleadedDispensed += unleaded;
        }
        public void AddLPGDispensed(double LPG)
        {
            LPGDispensed += LPG;
        }
        public void AddDieselDispensed(double diesel)
        {
            dieselDispensed += diesel;
        }
        public int getFuelIntervalTime()
        {
            return FuelIntervalTime;
        }
    }
}
