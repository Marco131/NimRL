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
        private const int _AI_AREA_OPEN_HEIGHT = 200;
        private const int _AI_AREA_CLOSED_HEIGHT = 25;

        private const string _AI_AREA_OPEN_BUTTON_CHAR = "q";
        private const string _AI_AREA_CLOSED_BUTTON_CHAR = "p";

        private static readonly Player _DEFAULT_PLAYER1 = new Human();
        private static readonly Player _DEFAULT_PLAYER2 = new Human();

        private const int _PLAYER_OPTION1 = 1;
        private const int _PLAYER_OPTION2 = 2;
        private const int _PLAYER_OPTION3 = 3;

        private const int _AUTO_PLAY_OPTION1 = 1;
        private const int _AUTO_PLAY_OPTION2 = 10;
        private const int _AUTO_PLAY_OPTION3 = 100;


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

            this._isDraggingForm = false;
            this._startPoint = new Point(0, 0);

            this._isAIAreaOpen = false;
            CloseAIArea();
        }


        // Methods
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
        }

        private void cmbP1_SelectedIndexChanged(object sender, EventArgs e)
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

            this._gameController.PrepareGame();
            UpdateView();
        }

        private void cmbP2_SelectedIndexChanged(object sender, EventArgs e)
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

            this._gameController.PrepareGame();
            UpdateView();
        }

        // Player 1 Options
        private void btnP1_1_Click(object sender, EventArgs e)
        {
            this._gameController.ContinuePlaying(FrmMain._PLAYER_OPTION1);
            UpdateView();
        }

        private void btnP1_2_Click(object sender, EventArgs e)
        {
            this._gameController.ContinuePlaying(FrmMain._PLAYER_OPTION2);
            UpdateView();
        }

        private void btnP1_3_Click(object sender, EventArgs e)
        {
            this._gameController.ContinuePlaying(FrmMain._PLAYER_OPTION3);
            UpdateView();
        }

        // Player 2 Options
        private void btnP2_1_Click(object sender, EventArgs e)
        {
            this._gameController.ContinuePlaying(FrmMain._PLAYER_OPTION1);
            UpdateView();
        }

        private void btnP2_2_Click(object sender, EventArgs e)
        {
            this._gameController.ContinuePlaying(FrmMain._PLAYER_OPTION2);
            UpdateView();
        }

        private void btnP2_3_Click(object sender, EventArgs e)
        {
            this._gameController.ContinuePlaying(FrmMain._PLAYER_OPTION3);
            UpdateView();
        }

        // Auto Play Options
        private void btnAutoPlay_1_Click(object sender, EventArgs e)
        {
            this._gameController.PlayGameAutomatically(FrmMain._AUTO_PLAY_OPTION1);
            UpdateView();
        }

        private void btnAutoPlay_10_Click(object sender, EventArgs e)
        {
            this._gameController.PlayGameAutomatically(FrmMain._AUTO_PLAY_OPTION2);
            UpdateView();
        }

        private void btnAutoPlay_100_Click(object sender, EventArgs e)
        {
            this._gameController.PlayGameAutomatically(FrmMain._AUTO_PLAY_OPTION3);
            UpdateView();
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
