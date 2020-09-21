/*
 * Description:     A basic PONG simulator
 * Author:     Adam Wingert       
 * Date:       21-9-2020     
 */

#region libraries

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;

#endregion

namespace Pong
{
    public partial class Form1 : Form
    {
        #region global values

        //graphics objects for drawing
        SolidBrush drawBrush = new SolidBrush(Color.White);
        Font drawFont = new Font("Courier New", 20);

        // Sounds for game
        SoundPlayer scoreSound = new SoundPlayer(Properties.Resources.score);
        SoundPlayer collisionSound = new SoundPlayer(Properties.Resources.collision);

        //determines whether a key is being pressed or not
        Boolean aKeyDown, zKeyDown, jKeyDown, mKeyDown, wKeyDown, eKeyDown, uKeyDown, iKeyDown;

        // check to see if a new game can be started
        Boolean newGameOk = true;

        //ball directions, speed, and rectangle
        Boolean ballMoveRight = true;
        Boolean ballMoveDown = true;
        const int BALL_SPEED = 5;
        Rectangle ball;

        //paddle speeds and rectangles
        const int PADDLE_SPEED = 4;
        Rectangle p1, p2, p3, p4;
        Rectangle MegaRightWall, MegaLeftWall;
        //player and game scores
        int player1Score = 0;
        int player2Score = 0;
        int player3Score = 0;
        int player4Score = 0;


        int gameWinScore = 3;  // number of points needed to win game

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //check to see if a key is pressed and set is KeyDown value to true if it has
            switch (e.KeyCode)
            {
                case Keys.A:
                    aKeyDown = true;
                    break;
                case Keys.Z:
                    zKeyDown = true;
                    break;
                case Keys.J:
                    jKeyDown = true;
                    break;
                case Keys.M:
                    mKeyDown = true;
                    break;
                case Keys.W:
                    wKeyDown = true;
                    break;
                case Keys.E:
                    eKeyDown = true;
                    break;
                case Keys.U:
                    uKeyDown = true;
                    break;
                case Keys.I:
                    iKeyDown = true;
                    break;
                case Keys.Space:
                    break;
                case Keys.N:
                    if (newGameOk)
                    {
                        Close();
                    }
                    break;
            }
        }

        private void inputBox_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    aKeyDown = false;
                    break;
                case Keys.Z:
                    zKeyDown = false;
                    break;
                case Keys.J:
                    jKeyDown = false;
                    break;
                case Keys.M:
                    mKeyDown = false;
                    break;
                case Keys.W:
                    wKeyDown = false;
                    break;
                case Keys.E:
                    eKeyDown = false;
                    break;
                case Keys.U:
                    uKeyDown = false;
                    break;
                case Keys.I:
                    iKeyDown = false;
                    break;
            }
        }

        int gameMode; // sets gamemode

        #endregion

        public Form1()
        {
            InitializeComponent();
        }
        private void singlePlayerButton_Click(object sender, EventArgs e)
        {
            gameMode = 1;
            SetParameters();
        }

        private void multiplayerButton_Click(object sender, EventArgs e)
        {
            gameMode = 2;
            SetParameters();
        }

        private void megaplayerButton_Click(object sender, EventArgs e)
        {
            gameMode = 4;
            SetParameters();
        }

        /// <summary>
        /// sets the ball and paddle positions for game start
        /// </summary>
        private void SetParameters()
        {
            if (newGameOk)
            {
                Refresh();
                if (gameMode == 4)
                {
                    player1Score = player2Score = player3Score = player4Score = 3;
                }
                else
                {
                    player1Score = player2Score = 0;
                }
                newGameOk = false;
                startLabel.Visible = false;
                singlePlayerButton.Hide();
                multiplayerButton.Hide();
                megaplayerButton.Hide();
                gameUpdateLoop.Start();
                backingLabel.Hide();

                inputBox.Focus();
            }

            //set starting position for paddles on new game and point scored 
            const int PADDLE_EDGE = 20;  // buffer distance between screen edge and paddle            

            p1.Width = p2.Width = p3.Height = p4.Height = 10;    //height for both paddles set the same
            p1.Height = p2.Height = p3.Width = p4.Width = 40;  //width for both paddles set the same

            if (gameMode != 4)
            {
                //p1 starting position
                p1.X = PADDLE_EDGE;
                p1.Y = this.Height / 2 - p1.Height / 2;

                //p2 starting position
                p2.X = this.Width - PADDLE_EDGE - p2.Width;
                p2.Y = this.Height / 2 - p2.Height / 2;
            }

            // TODO set Width and Height of ball
            ball.Width = 20;
            ball.Height = 20;

            // TODO set starting X position for ball to middle of screen, (use this.Width and ball.Width)
            ball.X = this.Width / 2 - ball.Width / 2;
            ball.Y = this.Height / 2 - ball.Height / 2;
            // TODO set starting Y position for ball to middle of screen, (use this.Height and ball.Height)
            if (gameMode == 4)
            {
                MegaLeftWall.Width = MegaRightWall.Width = 5;
                MegaLeftWall.Height = MegaRightWall.Height = this.Height;

                MegaLeftWall.X = this.Width / 2 - this.Height / 2 - 5;
                MegaRightWall.X = this.Width / 2 + this.Height / 2 + 5;
                MegaRightWall.Y = MegaLeftWall.Y = 0;

                p1.X = MegaLeftWall.X + PADDLE_EDGE + p1.Width;
                p1.Y = this.Height / 2 - p1.Height / 2;

                p2.X = MegaRightWall.X - PADDLE_EDGE - p2.Width;
                p2.Y = this.Height / 2 - p2.Height / 2;

                p3.X = this.Width / 2 - p3.Width / 2;
                p3.Y = PADDLE_EDGE;

                p4.X = this.Width / 2 - p4.Width / 2;
                p4.Y = this.Height - PADDLE_EDGE;
            }
        }

        /// <summary>
        /// This method is the game engine loop that updates the position of all elements
        /// and checks for collisions.
        /// </summary>
        private void gameUpdateLoop_Tick(object sender, EventArgs e)
        {
            if (gameMode == 2)
            {
                #region update paddle positions

                if (aKeyDown == true && p1.Y > 0)
                {
                    p1.Y -= PADDLE_SPEED;
                }

                if (zKeyDown == true && p1.Y < this.Height - p1.Height)
                {
                    p1.Y += PADDLE_SPEED;
                }

                if (jKeyDown == true && p2.Y > 0)
                {
                    p2.Y -= PADDLE_SPEED;
                }

                if (mKeyDown == true && p2.Y < this.Height - p2.Height)
                {
                    p2.Y += PADDLE_SPEED;
                }
                #endregion

                #region ball collision with side walls (point scored)

                if (ball.X < 0)  // ball hits left wall logic
                {
                    // TODO
                    scoreSound.Play();
                    player2Score++;

                    // TODO use if statement to check to see if player 2 has won the game. If true run 
                    // GameOver method. Else change direction of ball and call SetParameters method.
                    if (player2Score == gameWinScore)
                    {
                        GameOver("Player 2");
                    }
                    else
                    {
                        ballMoveRight = !ballMoveRight;
                        ballMoveDown = !ballMoveDown;
                        SetParameters();
                    }

                }
                if (ball.X >= this.Width - ball.Width)
                {

                    // TODO
                    scoreSound.Play();
                    player1Score++;

                    // TODO use if statement to check to see if player 2 has won the game. If true run 
                    // GameOver method. Else change direction of ball and call SetParameters method.
                    if (player1Score == gameWinScore)
                    {
                        GameOver("Player 1");
                    }
                    else
                    {
                        ballMoveRight = !ballMoveRight;
                        ballMoveDown = !ballMoveDown;
                        SetParameters();
                    }

                }
                // TODO same as above but this time check for collision with the right wall

                #endregion

                #region ball collision with top and bottom lines

                if (ball.Y < 0) // if ball hits top line
                {
                    ballMoveDown = true;
                    collisionSound.Play();
                }
                else if (ball.Y >= this.Height - ball.Height)
                {
                    ballMoveDown = false;
                    collisionSound.Play();
                }

                #endregion

            }
            else if (gameMode == 1)
            {
                #region update paddle positions

                if (aKeyDown == true && p1.Y > 0)
                {
                    p1.Y -= PADDLE_SPEED;
                }

                if (zKeyDown == true && p1.Y < this.Height - p1.Height)
                {
                    p1.Y += PADDLE_SPEED;
                }

                if (ball.Y < p2.Y && p2.Y > 0)
                {
                    p2.Y -= PADDLE_SPEED;
                }

                if (ball.Y > p2.Y && p2.Y < this.Height - p2.Height)
                {
                    p2.Y += PADDLE_SPEED;
                }
                #endregion

                #region ball collision with side walls (point scored)

                if (ball.X < 0)  // ball hits left wall logic
                {
                    // TODO
                    scoreSound.Play();
                    player2Score++;

                    // TODO use if statement to check to see if player 2 has won the game. If true run 
                    // GameOver method. Else change direction of ball and call SetParameters method.
                    if (player2Score == gameWinScore)
                    {
                        GameOver("CPU");
                    }
                    else
                    {
                        ballMoveRight = !ballMoveRight;
                        ballMoveDown = !ballMoveDown;
                        SetParameters();
                    }

                }
                if (ball.X >= this.Width - ball.Width)
                {

                    // TODO
                    scoreSound.Play();
                    player1Score++;

                    // TODO use if statement to check to see if player 2 has won the game. If true run 
                    // GameOver method. Else change direction of ball and call SetParameters method.
                    if (player1Score == gameWinScore)
                    {
                        GameOver("Player 1");
                    }
                    else
                    {
                        ballMoveRight = !ballMoveRight;
                        ballMoveDown = !ballMoveDown;
                        SetParameters();
                    }

                }
                // TODO same as above but this time check for collision with the right wall

                #endregion

                #region ball collision with top and bottom lines

                if (ball.Y < 0) // if ball hits top line
                {
                    ballMoveDown = true;
                    collisionSound.Play();
                }
                else if (ball.Y >= this.Height - ball.Height)
                {
                    ballMoveDown = false;
                    collisionSound.Play();
                }

                #endregion

            }
            else if (gameMode == 4)
            {
                #region update paddle positions

                if (aKeyDown == true && p1.Y > 0)
                {
                    p1.Y -= PADDLE_SPEED;
                }

                if (zKeyDown == true && p1.Y < this.Height - p1.Height)
                {
                    p1.Y += PADDLE_SPEED;
                }

                if (jKeyDown == true && p2.Y > 0)
                {
                    p2.Y -= PADDLE_SPEED;
                }

                if (mKeyDown == true && p2.Y < this.Height - p2.Height)
                {
                    p2.Y += PADDLE_SPEED;
                }

                if (wKeyDown == true && p3.X > MegaLeftWall.X + 5)
                {
                    p3.X -= PADDLE_SPEED;
                }

                if (eKeyDown == true && p3.X < MegaRightWall.X - 5)
                {
                    p3.X += PADDLE_SPEED;
                }

                if (uKeyDown == true && p4.X > MegaLeftWall.X + 5)
                {
                    p4.X -= PADDLE_SPEED;
                }

                if (iKeyDown == true && p4.X < MegaRightWall.X - 5)
                {
                    p4.X += PADDLE_SPEED;
                }
                #endregion

                #region ball collision with side walls (point scored)

                if (ball.IntersectsWith(MegaLeftWall)) // ball hits left wall logic
                {
                    // TODO
                    scoreSound.Play();
                    player2Score--;

                    if (player2Score == 0)
                    {
                        GameOver("Player 2");
                    }
                    else
                    {
                        ballMoveRight = !ballMoveRight;
                        ballMoveDown = !ballMoveDown;
                        SetParameters();
                    }

                }
                if (ball.IntersectsWith(MegaRightWall))
                {

                    scoreSound.Play();
                    player1Score--;
                    if (player1Score == 0)
                    {
                        GameOver("Player 1");
                    }
                    else
                    {
                        ballMoveRight = !ballMoveRight;
                        ballMoveDown = !ballMoveDown;
                        SetParameters();
                    }
                }
                if (ball.Y <= 0)
                {
                    scoreSound.Play();
                    player3Score--;
                    if (player3Score == 0)
                    {
                        GameOver("Player 3");
                    }
                    else
                    {
                        ballMoveRight = !ballMoveRight;
                        ballMoveDown = !ballMoveDown;
                        SetParameters();
                    }
                    if (ball.Y >= this.Height - ball.Height)
                    {
                        scoreSound.Play();
                        player4Score--;
                        if (player4Score == 0)
                        {
                            GameOver("Player 4");
                        }
                        else
                        {
                            ballMoveRight = !ballMoveRight;
                            ballMoveDown = !ballMoveDown;
                            SetParameters();
                        }
                    }
                    // TODO same as above but this time check for collision with the right wall

                    #endregion

                    #region ball collision with top and bottom lines

                    if (ball.Y < 0) // if ball hits top line
                    {
                        ballMoveDown = true;
                        collisionSound.Play();
                    }
                    else if (ball.Y >= this.Height - ball.Height)
                    {
                        ballMoveDown = false;
                        collisionSound.Play();
                    }

                    #endregion
                }
            }
            #region update ball position

            // TODO create code to move ball either left or right based on ballMoveRight and using BALL_SPEED
            if (ballMoveRight != true)
            {
                ball.X = ball.X - BALL_SPEED;
            }
            else
            {
                ball.X = ball.X + BALL_SPEED;
            }
            // TODO create code move ball either down or up based on ballMoveDown and using BALL_SPEED
            if (ballMoveDown != true)
            {
                ball.Y = ball.Y - BALL_SPEED;
            }
            else
            {
                ball.Y = ball.Y + BALL_SPEED;
            }
            #endregion

            #region ball collision with paddles
            /*
                        if (ball.IntersectsWith(p1) || ball.IntersectsWith(p2))
                        {
                            ballMoveRight = !ballMoveRight;
                            collisionSound.Play();
                        }
            */
            if (ball.IntersectsWith(p1))
            {
                ballMoveRight = !ballMoveRight;
                collisionSound.Play();
                ball.X = p1.X + p1.Width + 3;
            }

            if (ball.IntersectsWith(p2))
            {
                ballMoveRight = !ballMoveRight;
                collisionSound.Play();
                ball.X = p2.X - ball.Width - 3;
            }

            if (ball.IntersectsWith(p3))
            {
                ballMoveDown = !ballMoveDown;
                collisionSound.Play();
                ball.Y = p3.Y + p3.Height + 3;
            }

            if (ball.IntersectsWith(p4))
            {
                ballMoveDown = !ballMoveDown;
                collisionSound.Play();
                ball.Y = p4.Y - ball.Width - 3;
            }
            /*  ENRICHMENT
             *  Instead of using two if statments as noted above see if you can create one
             *  if statement with multiple conditions to play a sound and change direction
             */

            #endregion
            //refresh the screen, which causes the Form1_Paint method to run
            this.Refresh();
        }

        /// <summary>
        /// Displays a message for the winner when the game is over and allows the user to either select
        /// to play again or end the program
        /// </summary>
        /// <param name="winner">The player name to be shown as the winner</param>
        private void GameOver(string winner)
        {
            newGameOk = true;
            backingLabel.Show();
            // TODO create game over logic
            // --- stop the gameUpdateLoop
            gameUpdateLoop.Stop();
            // --- show a message on the startLabel to indicate a winner, (need to Refresh).
            startLabel.Show();
            if (gameMode == 4)
            {
                startLabel.Text = $"{winner} Loses!";
            }
            else
            {
                startLabel.Text = $"{winner} Wins!";
            }

            startLabel.Refresh();
            // --- pause for two seconds 
            Thread.Sleep(2000);
            // --- use the startLabel to ask the user if they want to play again
            startLabel.Text = "Play Again? \n(Space)";

            singlePlayerButton.Show();
            multiplayerButton.Show();
            megaplayerButton.Show();

            singlePlayerButton.Focus();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // TODO draw paddles using FillRectangle
            e.Graphics.FillRectangle(drawBrush, p1);
            e.Graphics.FillRectangle(drawBrush, p2);


            // TODO draw ball using FillRectangle
            e.Graphics.FillRectangle(drawBrush, ball);

            // TODO draw scores to the screen using DrawString


            e.Graphics.DrawString(Convert.ToString("P1:" + player1Score), drawFont, drawBrush, this.Width / 2 - 70, this.Height / 2);
            e.Graphics.DrawString(Convert.ToString("P2:" + player2Score), drawFont, drawBrush, this.Width / 2, this.Height / 2);

            if (gameMode == 4)
            {
                e.Graphics.FillRectangle(drawBrush, MegaLeftWall);
                e.Graphics.FillRectangle(drawBrush, MegaRightWall);

                e.Graphics.FillRectangle(drawBrush, p3);
                e.Graphics.FillRectangle(drawBrush, p4);

                e.Graphics.DrawString(Convert.ToString("P3:" + player3Score), drawFont, drawBrush, this.Width / 2 - 35, this.Height / 2 - 25);
                e.Graphics.DrawString(Convert.ToString("P4:" + player4Score), drawFont, drawBrush, this.Width / 2 - 35, this.Height / 2 + 25);
            }
        }

    }
}
