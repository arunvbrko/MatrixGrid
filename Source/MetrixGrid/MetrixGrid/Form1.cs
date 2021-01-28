using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace MetrixGrid
{
    public partial class Form1 : Form
    {
        //Add the member variables
        public int m_width; //Width of the grid cell

        public int m_Height; // The height of the Cell

        public int m_NoOfRows; // The Number Of Rows

        public int m_NoOfCols; // The Number Of Columns

        public int m_XOffset; //Offset from which drawing start
        public int m_YOffset;
        public int rc = 8;
        public const int DEFAULT_X_OFFSET = 100;
        public const int DEFAULT_Y_OFFSET = 75;
        public const int DEFAULT_NO_ROWS = 2;
        public const int DEFAULT_NO_COLS = 2;
        public const int DEFAULT_WIDTH = 60;
        public const int DEFAULT_HEIGHT = 60;
        
        public Form1()
        {
            Initialize();
            InitializeComponent();
            status = false;
            
        }
        public void Initialize()
        {
            //Put all the default values
            m_NoOfRows = DEFAULT_NO_ROWS;
            m_NoOfCols = DEFAULT_NO_COLS;
            m_width = DEFAULT_WIDTH;
            m_Height = DEFAULT_HEIGHT;
            m_XOffset = DEFAULT_X_OFFSET;
            m_YOffset = DEFAULT_Y_OFFSET;

        }

        private void DrawGrid()
        {
            
            Graphics boardLayout = this.CreateGraphics();
            Pen layoutPen = new Pen(Color.Blue);
            layoutPen.Width = 5;
            int counter = 2;
            while(counter<=rc)
            {
                Thread.Sleep(500);
                
                if (counter != rc)
                {
                    m_NoOfRows = counter;
                    m_NoOfCols = counter;
                    //boardLayout.DrawLine(layoutPen, 0, 0, 100, 0);
                    int X = DEFAULT_X_OFFSET;
                    int Y = DEFAULT_Y_OFFSET;
                    //Draw The rows
                    for (int i = 0; i <= m_NoOfRows; i++)
                    {
                        boardLayout.DrawLine(layoutPen, X, Y, X + this.m_width * this.m_NoOfCols, Y);
                        Y = Y + m_Height;
                    }

                    //Draw The Cols
                    X = DEFAULT_X_OFFSET;
                    Y = DEFAULT_Y_OFFSET;
                    for (int j = 0; j <= m_NoOfCols; j++)
                    {
                        boardLayout.DrawLine(layoutPen, X, Y, X, Y + this.m_Height * this.m_NoOfRows);
                        X = X + this.m_width;
                    }

                    counter++;
                }
                else
                {
                    counter = 2;
                    Invalidate();
                }

            }

        }
       
        private void buttonStart(object sender, EventArgs e)
        {
            mythread = new Thread(new ThreadStart(DrawGrid));
            mythread.Start();
            Invalidate();
        }

        [Obsolete]
        private void buttonStop(object sender, EventArgs e)
        {
            mythread.Suspend();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            rc = 4;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            rc = 5;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            rc = 6;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            rc = 7;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            rc = 8;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            rc = 9;
        }
    }
}
