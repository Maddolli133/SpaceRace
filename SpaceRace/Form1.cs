using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace SpaceRace
//Maddox Ollivier, 2022-05-17, This Space Race game is to be summited for the summative

{
    public partial class Form1 : Form
    {
        //Players and astroids
        Rectangle player1 = new Rectangle(260, 350, 10, 30);
        Rectangle player2 = new Rectangle(315, 350, 10, 30);
        //Obstacles lists
        List<Rectangle> leftAs = new List<Rectangle>();
        List<Rectangle> rightAs = new List<Rectangle>();
        //Center of screen
        Rectangle centerLine = new Rectangle(290, 0, 3, 1000);
        //Finish line
        Rectangle finish1 = new Rectangle(230, 5, 60, 10);
        Rectangle finish2 = new Rectangle(291, 5, 63, 10);
        //Players and astroids values
        int player1Score = 0;
        int player2Score = 0;
        int playerSpeed = 4;
        int counter = 0;
        //What the keys are set for player one
        bool wDown = false;
        bool sDown = false;
        //What the keys are set for player two
        bool upArrowDown = false;
        bool downArrowDown = false;
        //Different brushes/pens
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        Pen whitePen = new Pen(Color.White);
        //Random values
        Random randGen = new Random();
        //Sounds
        SoundPlayer Hit = new SoundPlayer(Properties.Resources.Hit);
        SoundPlayer Yay = new SoundPlayer(Properties.Resources.Yay);

        string gameState = "waiting";

        public Form1()
        {
            InitializeComponent();
            leftAs.Add(new Rectangle(0, 0, 3, 3));
            rightAs.Add(new Rectangle(590, 0, 3, 3));
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) //Keys used in game
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Space:
                    if (gameState == "waiting" || gameState == "win1" || gameState == "win2")
                    {
                        GameInitialize();
                    }
                    break;
            }
        }

        public void GameInitialize()
        {
            gameEngine.Enabled = true;
            gameState = "running";
            player1Score = 0;
            player2Score = 0;
            seLabel.Text = "";
            leftAs.Clear();
            rightAs.Clear();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)//Keys used in game
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
             }
        }

        private void gameEngine_Tick(object sender, EventArgs e)
        {
            //move player 1 
            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= playerSpeed;
            }
            else if (sDown == true && player1.Y > 5)
            {
                player1.Y += playerSpeed;
            }

            //move player 2 
            if (upArrowDown == true && player2.Y > 0)
            {
                player2.Y -= playerSpeed;
            }
            else if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += playerSpeed;
            }

            //move asteroids left to right
            for (int i = 0; i < leftAs.Count(); i++)
            {
                //find the new postion of x based on speed
                int x = leftAs[i].X + 8;
                //replace the rectangle in the list with updated one using new y 
                leftAs[i] = new Rectangle(x, leftAs[i].Y, leftAs[i].Width, leftAs[i].Height);
            }
            //move asteroids right to left
            for (int i = 0; i < rightAs.Count(); i++)
            {
                //find the new postion of y based on speed 
                int x = rightAs[i].X - 8;
                //replace the rectangle in the list with updated one using new y 
                rightAs[i] = new Rectangle(x, rightAs[i].Y, rightAs[i].Width, rightAs[i].Height);
            }
            counter++;
            int y;
            int y2;
            y = randGen.Next(0, 325);
            y2 = randGen.Next(0, 325);
            if (counter == 6)
            {
                leftAs.Add(new Rectangle(0, y, 3, 3));
                rightAs.Add(new Rectangle(590, y2, 3, 3));
                counter = 0;
            }

            //Players scoring
            if (player1.IntersectsWith (finish1))
            {
                player1 = new Rectangle(260, 350, 10, 30);
                player1Score++;
                Yay.Play();
            }

            if (player2.IntersectsWith(finish2))
            {
                player2 = new Rectangle(315, 350, 10, 30);
                player2Score++;
                Yay.Play();
            }


            if (player1Score == 3)
            {
                gameEngine.Enabled = false;
                gameState = "win1";
            }


            if (player2Score == 3)
            {
                gameEngine.Enabled = false;
                gameState = "win2";

            }

            //Astroid hitting player
            for (int i = 0; i < leftAs.Count(); i++)
            {
                if (player1.IntersectsWith (leftAs[i]))
                {
                    player1 = new Rectangle(260, 350, 10, 30);
                    Hit.Play();
                }
            }
            for (int i = 0; i < leftAs.Count(); i++)
            {
                if (player2.IntersectsWith(leftAs[i]))
                {
                    player2 = new Rectangle(315, 350, 10, 30);
                    Hit.Play();
                }
            }
            for (int i = 0; i < rightAs.Count(); i++)
            {
                if (player2.IntersectsWith(rightAs[i]))
                {
                    player2 = new Rectangle(315, 350, 10, 30);
                    Hit.Play();
                }
            }
            for (int i = 0; i < rightAs.Count(); i++)
            {
                if (player1.IntersectsWith(rightAs[i]))
                {
                    player1 = new Rectangle(260, 350, 10, 30);
                    Hit.Play();
                }
            }
            Refresh();
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == "waiting")
            {
                seLabel.Text = $"Press space to start";
                score1.Text = "";
                score2.Text = "";
            }
            else if (gameState == "running")
            {
                //Object colors
                e.Graphics.FillRectangle(whiteBrush, player1);
                e.Graphics.FillRectangle(whiteBrush, player2);
                e.Graphics.FillRectangle(whiteBrush, centerLine);
                e.Graphics.DrawRectangle(whitePen, finish1);
                e.Graphics.DrawRectangle(whitePen, finish2);

                score1.Text = $"Score:{player1Score}";
                score2.Text = $"Score:{player2Score}";

                for (int i = 0; i < leftAs.Count(); i++)
                {
                    e.Graphics.FillRectangle(whiteBrush, leftAs[i]);
                }
                for (int i = 0; i < rightAs.Count(); i++)
                {
                    e.Graphics.FillRectangle(whiteBrush, rightAs[i]);
                }
            }
            else if (gameState == "win1")
            {
                seLabel.Text = $"Player 1 Wins!\nPress space to restart";
                score1.Text = "";
                score2.Text = "";
            }
            else if (gameState == "win2")
            {
                seLabel.Text = $"Player 2 Wins!\nPress space to restart";
                score1.Text = "";
                score2.Text = "";
            }
        }
    }
}
