using NimRL.Classes.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NimRL.Classes.Model.Player;
using NimRL.Classes.Model.AI;

namespace NimRL
{
    public partial class FrmMain : Form
    {
        // Constants
        private static readonly Player _DEFAULT_PLAYER1 = new Human();
        private static readonly Player _DEFAULT_PLAYER2 = new Human();

        private const string _MATCHSTICK_PBX_NAME_SUFFIX = "pbxMatchstick";
        
        private const int _PLAYER_OPTION1 = 1;
        private const int _PLAYER_OPTION2 = 2;
        private const int _PLAYER_OPTION3 = 3;

        private const int _AUTO_PLAY_OPTION1 = 1;
        private const int _AUTO_PLAY_OPTION2 = 10;
        private const int _AUTO_PLAY_OPTION3 = 100;

        private const int _AI_AREA_OPEN_HEIGHT = 200;
        private const int _AI_AREA_CLOSED_HEIGHT = 25;

        private const string _AI_AREA_OPEN_BUTTON_CHAR = "q";
        private const string _AI_AREA_CLOSED_BUTTON_CHAR = "p";


        // Fields
        private bool _isDraggingForm;
        private Point _startPoint;
        private bool _isAIAreaOpen;

        private GameController _gameController;
        private AIController _aiController;


        // Ctor
        public FrmMain()
        {
            this._aiController = new AIController();
            this._gameController = new GameController(FrmMain._DEFAULT_PLAYER1, FrmMain._DEFAULT_PLAYER2, this._aiController);


            InitializeComponent();

            this.cmbP1.Text = FrmMain._DEFAULT_PLAYER1.GetName();
            this.cmbP2.Text = FrmMain._DEFAULT_PLAYER2.GetName();

            this.btnP1_1.Tag = FrmMain._PLAYER_OPTION1;
            this.btnP1_2.Tag = FrmMain._PLAYER_OPTION2;
            this.btnP1_3.Tag = FrmMain._PLAYER_OPTION3;

            this.btnP2_1.Tag = FrmMain._PLAYER_OPTION1;
            this.btnP2_2.Tag = FrmMain._PLAYER_OPTION2;
            this.btnP2_3.Tag = FrmMain._PLAYER_OPTION3;

            this.btnAutoPlay_1.Tag = FrmMain._AUTO_PLAY_OPTION1;
            this.btnAutoPlay_10.Tag = FrmMain._AUTO_PLAY_OPTION2;
            this.btnAutoPlay_100.Tag = FrmMain._AUTO_PLAY_OPTION3;

            this._isDraggingForm = false;
            this._startPoint = new Point(0, 0);

            this._isAIAreaOpen = false;
            CloseAIArea();
        }


        // Methods
        /// <summary>
        /// Updates the view
        /// </summary>
        private void UpdateView()
        {
            // If the game has ended
            if (this._gameController.HasGameEnded)
            {
                btnStartGame.Visible = true;

                pnlP1.Enabled = false;
                pnlP2.Enabled = false;
                pnlRvR.Visible = false;
            }
            // If the game is ongoing
            else
            {
                btnStartGame.Visible = false;
            }
            
            // If the game is between two robots
            if (this._gameController.IsRvR())
            {
                pnlRvR.Visible = true;

                lblP1RobotMessage.Visible = true;
                lblP2RobotMessage.Visible = true;
                pnlP1.Enabled = false;
                pnlP2.Enabled = false;
            }
            // If not
            else
            {
                pnlRvR.Visible = false;

                Player currentPlayer = this._gameController.GetCurrentPlayer();

                // If player1 is a Human
                if (this._gameController.Player1.PlayerType == PlayerType.Human)
                {
                    lblP1RobotMessage.Visible = false;

                    if (currentPlayer == this._gameController.Player1)
                    {
                        pnlP1.Enabled = true;
                        pnlP2.Enabled = false;
                    }
                }
                // If player1 is a Robot
                else
                {
                    lblP1RobotMessage.Visible = true;
                    pnlP1.Enabled = false;
                }

                // If player2 is a Human
                if (this._gameController.Player2.PlayerType == PlayerType.Human)
                {
                    lblP2RobotMessage.Visible = false;

                    if (currentPlayer == this._gameController.Player2)
                    {
                        pnlP2.Enabled = true;
                        pnlP1.Enabled = false;
                    }
                }
                // If player2 is a Robot
                else
                {
                    lblP2RobotMessage.Visible = true;
                    pnlP2.Enabled = false;
                }
            }

            // Draw player actions
            int[] p1Actions = this._gameController.GetPlayersGameActions()[0];
            int[] p2Actions = this._gameController.GetPlayersGameActions()[1];

            this.lblP1Actions.Text = String.Join("-", p1Actions);
            this.lblP2Actions.Text = String.Join("-", p2Actions);
        }

        /// <summary>
        /// Adds the matchsticks to the view, and sets their properties
        /// </summary>
        private void AddMatchsticksToView()
        {
            for (int i = 0; i < this._gameController.GetMatchesNb(); i++)
            {
                PictureBox matchstickPicture = new PictureBox()
                {
                    Location = new Point(5 + i * 25, 5),
                    Size = new Size(15, 195),
                    Name = FrmMain._MATCHSTICK_PBX_NAME_SUFFIX + i.ToString(),
                    Image = Properties.Resources.Matchstick,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = i + 1
                };

                this.pnlMatches.Controls.Add(matchstickPicture);
            }
        }

        /// <summary>
        /// Remove matchsticks from the view to match the matchsticks in game
        /// </summary>
        private void RemoveMatchsticksFromView()
        {
            for (int i = this.pnlMatches.Controls.Count - 1; i >= 0; i--)
            {
                Control control = this.pnlMatches.Controls[i];
                if (control is PictureBox)
                {
                    if ((int)control.Tag > this._gameController.GetMatchesNb())
                    {
                        this.pnlMatches.Controls.Remove(control);
                    }
                }
            }
        }

        private void OpenAIArea()
        {
            this.btnOpenCloseAIArea.Text = FrmMain._AI_AREA_OPEN_BUTTON_CHAR;

            this.pnlAIArea.Height = FrmMain._AI_AREA_OPEN_HEIGHT;
            this.Size = new Size(this.Size.Width, this.Size.Height + FrmMain._AI_AREA_OPEN_HEIGHT - FrmMain._AI_AREA_CLOSED_HEIGHT);
        }

        private void CloseAIArea()
        {
            this.btnOpenCloseAIArea.Text = FrmMain._AI_AREA_CLOSED_BUTTON_CHAR;

            this.pnlAIArea.Height = FrmMain._AI_AREA_CLOSED_HEIGHT;
            this.Size = new Size(this.Size.Width, this.Size.Height - FrmMain._AI_AREA_OPEN_HEIGHT + FrmMain._AI_AREA_CLOSED_HEIGHT);
        }


        // Events
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.TransparencyKey = Color.Lime;

            UpdateView();
            AddMatchsticksToView();
        }

        // Title Bar
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizeForm_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            this._isDraggingForm = true;
            this._startPoint = e.Location;
            this.Cursor = Cursors.SizeAll;
        }

        private void pnlTitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            this._isDraggingForm = false;
            this.Cursor = Cursors.Arrow;
        }

        private void pnlTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (this._isDraggingForm)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - this._startPoint.X, p.Y - this._startPoint.Y);
            }
        }

        // Game Display
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            this._gameController.PrepareGame();
            UpdateView();
            AddMatchsticksToView();
        }

        private void cmbP1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string playerTypeName = cmbP1.Text;

            if (playerTypeName == Human.NAME)
            {
                this._gameController.MakePlayerHuman(1);
            }
            else if (playerTypeName == Robot.NAME)
            {
                this._gameController.MakePlayerRobot(1, this._aiController.Agent);
            }

            this._gameController.EndGamePreventively();
            RemoveMatchsticksFromView();
            UpdateView();
        }

        private void cmbP2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string playerTypeName = cmbP2.Text;

            if (playerTypeName == Human.NAME)
            {
                this._gameController.MakePlayerHuman(2);
            }
            else if (playerTypeName == Robot.NAME)
            {
                this._gameController.MakePlayerRobot(2, this._aiController.Agent);
            }

            this._gameController.EndGamePreventively();
            RemoveMatchsticksFromView();
            UpdateView();
        }

        // Player Options
        private void pnlP1_EnabledChanged(object sender, EventArgs e)
        {
            if (this.pnlP1.Enabled)
            {
                this.pnlP1.BorderStyle = BorderStyle.FixedSingle;
            }
            else // Disabled 
            {
                this.pnlP1.BorderStyle = BorderStyle.None;
            }
        }

        private void pnlP2_EnabledChanged(object sender, EventArgs e)
        {
            if (this.pnlP2.Enabled)
            {
                this.pnlP2.BorderStyle = BorderStyle.FixedSingle;
            }
            else // Disabled 
            {
                this.pnlP2.BorderStyle = BorderStyle.None;
            }
        }

        private void btnPlayer_Option_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button button = sender as Button;

                if (button.Tag is int)
                {
                    this._gameController.ContinuePlaying((int)button.Tag);
                    UpdateView();
                    RemoveMatchsticksFromView();
                }
            }
        }

        // Auto Play Options
        private void btnAutoPlay_Option_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button button = sender as Button;

                if (button.Tag is int)
                {
                    this._gameController.PlayGameAutomatically((int)button.Tag);
                    UpdateView();
                }
            }
        }

        // AI Area
        private void btnOpenCloseAiArea_Click(object sender, EventArgs e)
        {
            if (this._isAIAreaOpen)
            {
                CloseAIArea();
            }
            else
            {
                OpenAIArea();
            }

            this._isAIAreaOpen = !this._isAIAreaOpen;
        }
    }
}
