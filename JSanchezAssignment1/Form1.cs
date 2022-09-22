using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSanchezAssignment1
{
    public partial class frmTicTacToe : Form
    {
        bool player = true;
        int movements = 0;
        public frmTicTacToe()
        {
            InitializeComponent();

        }



        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;


            btn.Text = player ? "X" : "O";
            btn.Enabled = false;
            player = !player;
            movements++;
            this.CheckWinner(btn);

        }


        private void CheckWinner(Button btn)
        {
            bool winner = false;
            string rowColumn = btn.Name.Replace("btn", "");
            int currentRow = int.Parse(rowColumn[0].ToString());
            int currentColumn = int.Parse(rowColumn[1].ToString());

            if (CheckVertical(currentRow, currentColumn))
            {
                winner = true;
            }
            else if (CheckHorizontal(currentRow, currentColumn))
            {
                winner = true;
            }
            else if (CheckDiagonalRight(currentRow, currentColumn))
            {
                winner = true;
            }
            else if (CheckDiagonalLeft(currentRow, currentColumn))
            {
                winner = true;
            }


            if (winner)
            {
                DialogResult result = MessageBox.Show($"The {btn.Text} wins this match!!", "Winner");

                if (result == DialogResult.OK)
                {
                    ResetGame();
                }

            }
            else if (movements == 9 && !winner)
            {
                DialogResult result = MessageBox.Show($"This is a Tie match!!", "Tie");

                if (result == DialogResult.OK)
                {
                    ResetGame();
                }
            }

        }

        private void ResetGame()
        {
            player = true;
            movements = 0;
            foreach (Button btn in this.Controls.OfType<Button>())
            {
                btn.Text = "";
                btn.Enabled = true;
            }
        }

        private bool CheckVertical(int row, int column)
        {
            int counter = 0;
            string text = this.Controls.Find($"btn{row}{column}", true)[0].Text;
            for (int i = 0; i < 3; i++)
            {
                if (this.Controls.Find($"btn{i}{column}", true)[0].Text == text)
                {
                    counter++;
                }
            }
            return counter == 3;
        }
        private bool CheckHorizontal(int row, int column)
        {
            int counter = 0;
            string text = this.Controls.Find($"btn{row}{column}", true)[0].Text;
            for (int i = 0; i < 3; i++)
            {
                if (this.Controls.Find($"btn{row}{i}", true)[0].Text == text)
                {
                    counter++;
                }
            }
            return counter == 3;
        }

        private bool CheckDiagonalRight(int row, int column)
        {
            int counter = 0;
            string text = this.Controls.Find($"btn{row}{column}", true)[0].Text;
            for (int i = 0; i < 3; i++)
            {
                if (this.Controls.Find($"btn{i}{i}", true)[0].Text == text)
                {
                    counter++;
                }
            }
            return counter == 3;
        }

        private bool CheckDiagonalLeft(int row, int column)
        {
            int counter = 0;
            string text = this.Controls.Find($"btn{row}{column}", true)[0].Text;
            for (int i = 2, j = 0; i >= 0; i--, j++)
            {
                if (this.Controls.Find($"btn{i}{j}", true)[0].Text == text)
                {
                    counter++;
                }
            }
            return counter == 3;
        }


    }
}
