using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThreadedEvents
{
    public partial class Form1 : Form
    {
        GraphCounter counter;
        public Form1()
        {
            InitializeComponent();

            counter = new GraphCounter();
            counter.CountChanged+=new EventHandler(c_CounterChanged);
            this.Controls.Add(counter);
        }

        private void c_CounterChanged(object sender, EventArgs e)
        {
            labelCounter.Text = counter.Ticks.ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            counter.Stop();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            counter.Start();
        }
    }
}
