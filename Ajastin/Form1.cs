using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;




namespace Ajastin
{
    public partial class CountdownForm : Form
    {
        private int kokonaisaika;
        public CountdownForm()
        {
            InitializeComponent();
        }

        private void AjastinTM_Tick(object sender, EventArgs e)
        {
            if(kokonaisaika > 0)
            {
                kokonaisaika--;
                int minuutit = kokonaisaika / 60;
                int sekuntit = kokonaisaika * 60;
                AikaLB.Text = minuutit + ":" + sekuntit;
            }
            else
            {
                AjastinTM.Stop();
                MessageBox.Show("Aikasi loppui!");
            }
                
        }

        private void CountdownForm_Load(object sender, EventArgs e)
        {
            StopBT.Enabled = false;
            for(int  i=0; i < 60; i++)
            {
                minuutitCB.Items.Add(i.ToString());
                sekuntitCB.Items.Add(i.ToString());
            }
            minuutitCB.SelectedIndex = 30;
            sekuntitCB.SelectedIndex = 0;
        }

        private void StartBT_Click(object sender, EventArgs e)
        {
            StartBT.Enabled = false;
            StopBT.Enabled = true;
            int minuutit = int.Parse(minuutitCB.SelectedItem.ToString());
            int sekuntit = int.Parse(sekuntitCB.SelectedItem.ToString());
            kokonaisaika = (minuutit * 60) + sekuntit;
            AjastinTM.Enabled = true;
        }

        private void StopBT_Click(object sender, EventArgs e)
        {
            StartBT.Enabled = true;
            StopBT.Enabled = false;
            kokonaisaika = 0;
            AjastinTM.Enabled = false;
            AikaLB.Text = "00:00";
        }
    }
}