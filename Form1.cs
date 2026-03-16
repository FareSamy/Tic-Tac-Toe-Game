using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tic_tac_toe.Properties;

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PictureBox[] Cells;

        int[][] Wins = new int[][]
        {
            new[] {0,1,2,},
            new[] {3,4,5,},
            new[] {6,7,8,},
            new[] {0,3,6},
            new[] {1,4,7},
            new[] {2,5,8},
            new[] {0,4,8}, 
            new[] {2,4,6},

        };

        private void Cell_Click(object sender, EventArgs e)
        {
            PictureBox cell = sender as PictureBox;

            if (cell.Tag.ToString() != "0")
            {
                MessageBox.Show("Wrong Choice","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (lblPlayer.Text == "Player 1")
            {
                cell.Image = Resources.X;
                cell.Tag = "1";
                lblPlayer.Text = "Player 2";
            }
            else
            {
                cell.Image = Resources.O;
                cell.Tag = "2";
                lblPlayer.Text = "Player 1";
            }
            CheckWinner();

            CheckDraw();
       
             
        }

        void  CheckWinner()
        {
            foreach (var w in Wins)
            {

                string a = Cells[w[0]].Tag.ToString();
                string b = Cells[w[1]].Tag.ToString();
                string c = Cells[w[2]].Tag.ToString();

                if (a != "0" && a == b && b == c)
                {
                    string winner = (a == "1") ? "Player 1" : "Player 2";

                    lblInProgress.Text = "   " + winner;
                    Cells[w[0]].BackColor = Color.Yellow;
                    Cells[w[1]].BackColor = Color.Yellow;
                    Cells[w[2]].BackColor = Color.Yellow;
                    MessageBox.Show(winner + " Wins!","Game Over",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    return;
                }
             
            }
        }

        bool CheckDraw()
        {

            foreach (var cell in Cells)
            {
                if (cell.Tag.ToString() == "0")
                {
                    return false;

                }
            }
            lblInProgress.Text = "     Draw";
            MessageBox.Show("Draw", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            return true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.FromArgb(255, 255, 255);
            Pen Pen = new Pen(White);
            Pen.Width = 10;


            e.Graphics.DrawLine(Pen, 610, 140, 610, 500);
            e.Graphics.DrawLine(Pen, 800, 140, 800, 500);


            e.Graphics.DrawLine(Pen, 450, 230, 960, 230);
            e.Graphics.DrawLine(Pen, 450, 370, 960, 370);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cells = new PictureBox[]
            {
                pictureBox1 , pictureBox2 , pictureBox3,
                pictureBox4 , pictureBox5 , pictureBox6,
                pictureBox7 , pictureBox8 , pictureBox9
            };

            foreach (var Cell in Cells)
            {
                Cell.Tag = "0";
                Cell.Click += Cell_Click;
            }
           
        }
        private void butRestartGame_Click(object sender, EventArgs e)
        {
            foreach (var cell in Cells)
            {
                cell.Tag = "0";
                cell.Image = Resources.question_mark_96;
                cell.BackColor = Color.Black;
                
            }
            lblPlayer.Text = "Player 1";
            lblInProgress.Text = "In Progress";

        }
    }
}
