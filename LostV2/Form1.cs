/// created by : 
/// date       : 
/// description: A basic text adventure game engine

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
using System.Threading;

namespace LostV2
{
    public partial class Form1 : Form
    {
        // tracks what part of the game the user is at
        int scene = 0;

        SoundPlayer player;

        // random number generator

        public Form1()
        {
            InitializeComponent();

            // play an initial sound
            player = new SoundPlayer(Properties.Resources.jungle);
            player.Play();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            /// check to see what button has been pressed and advance
            /// to the next appropriate scene
            if (e.KeyCode == Keys.M)       //red button press
            {
                if (scene == 0) { scene = 1; }
                else if (scene == 1) { scene = 3; }
                else if (scene == 2) { scene = 0; }
                else if (scene == 3) { scene = 0; }
                else if (scene == 4) { scene = 5; }
                else if (scene == 5) { scene = 0; }
                else if (scene == 6) { scene = 0; }
                else if (scene == 7) { scene = 0; }
            }
            else if (e.KeyCode == Keys.B)  //blue button press
            {
                if (scene == 0) { scene = 2; }
                else if (scene == 1) { scene = 4; }
                else if (scene == 2) { scene = 99; }
                else if (scene == 3) { scene = 99; }
                else if (scene == 4) { scene = 6; }
                else if (scene == 5) { scene = 99; }
                else if (scene == 6) { scene = 99; }
                else if (scene == 7) { scene = 99; }
            }

            /// Display text and game options to screen based on the current scene
            switch (scene)
            {
                case 0:
                    player = new SoundPlayer(Properties.Resources.jungle);
                    player.Play();

                    pictureBox.BackgroundImage = Properties.Resources.deepBrush;

                    outputLabel.Text = "You're lost in a forest";
                    redLabel.Text = "Go north";
                    blueLabel.Text = "Go south";
                    break;
                case 1:
                    //setting a new sound will automatically stop the previous sound
                    player = new SoundPlayer(Properties.Resources.brook);
                    player.Play();

                    pictureBox.BackgroundImage = Properties.Resources.forestLake;

                    outputLabel.Text = "You come to a lake. Suddenly you realize how thirsty you are.";
                    redLabel.Text = "Drink water";
                    blueLabel.Text = "Don't drink water";
                    break;
                case 2:
                    outputLabel.Text = "You fall in a pit and die. \n\nPlay Again?";
                    redLabel.Text = "Yes";
                    blueLabel.Text = "No";
                    break;
                case 3:
                    outputLabel.Text = "The water is stagnant. You die of cholera. \n\nPlay Again?";
                    redLabel.Text = "Yes";
                    blueLabel.Text = "No";
                    break;
                case 4:
                    outputLabel.Text = "You notice a horse swimming across the water.";
                    redLabel.Text = "Ride it";
                    blueLabel.Text = "Leave it alone";
                    break;
                case 5:
                    outputLabel.Text = "You tamed the horse and rode to safety. \n\nPlay Again?";
                    redLabel.Text = "Yes";
                    blueLabel.Text = "No";
                    break;
                case 6:
                    outputLabel.Text = "The horse walks past. You die of lonliness \n\nPlay Again?";
                    redLabel.Text = "Yes";
                    blueLabel.Text = "No";
                    break;
                case 99:
                    outputLabel.Text = "Thanks for playing.";
                    outputLabel.Refresh();
                    Thread.Sleep(1000);
                    Close();
                    break;
                default:
                    break;
            }
        }

    }

}
