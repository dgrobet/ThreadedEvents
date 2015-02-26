using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadedEvents
{
    class GraphCounter : System.Windows.Forms.Control
    {
        int ticks;
        bool stop = true;
        public int Ticks
        {
            get { return ticks; }
            private set 
            { 
                ticks = value;
                if (CountChanged!=null)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(CountChanged, this, EventArgs.Empty);
                    }
                    else
                    {
                        CountChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        public event EventHandler CountChanged;

        Thread counter;
        public int Interval { get; set; }

        public GraphCounter() : base()
        {
            counter = new Thread(Count);
            Interval = 100;
        }

        private void Count()
        {
            while (!stop)
            {
                Ticks++;
                Thread.Sleep(Interval);
            }

        }

        public void Start()
        {
            stop = false;
            counter.Start();
        }
        public void Stop()
        {
            stop = true;
        }
    }
}
