// todo solve never chosen actions bug
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
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;
using System.IO;
using NimRL.Classes;

namespace NimRL
{
    public partial class FrmMain : Form
    {
        // Constants
        private const string _MATCHSTICK_PBX_NAME_SUFFIX = "pbxMatchstick";

        private const string _CHART_NAME_PREFIX = "chr";
        private const string _SERIES_NAME_PREFIX = "series";
        private const string _CHARTAREA_NAME_PREFIX = "chrArea";
        private const string _CHART_LBL_NAME_PREFIX = "lblChart";
        
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

        private BackupManager _backupManager;


        // Ctor
        public FrmMain()
        {
            InitializeComponent();

            this._aiController = new AIController(UpdateAIDisplay);
            this._gameController = new GameController(this._aiController, UpdateView_Play, UpdateView_EndedGame, UpdateView_GameStart);

            this._backupManager = new BackupManager();

            this.cmbP1.Text = this._gameController.Player1.GetName();
            this.cmbP2.Text = this._gameController.Player2.GetName();

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
        /// Updates the view after someone played
        /// </summary>
        private void UpdateView_Play()
        {
            RemoveMatchsticksFromView();

            Player currentPlayer = this._gameController.GetCurrentPlayer();
            if (currentPlayer == this._gameController.Player1)
            {
                pnlP1.Enabled = true;
                pnlP2.Enabled = false;
            }
            // currentPlayer == Player2
            else
            {
                pnlP2.Enabled = true;
                pnlP1.Enabled = false;
            }


            DrawPlayerActions();
        }

        /// <summary>
        /// Updates the view after the game ended
        /// </summary>
        private void UpdateView_EndedGame()
        {
            RemoveMatchsticksFromView();

            btnStartGame.Visible = true;

            pnlP1.Enabled = false;
            pnlP2.Enabled = false;

            DrawPlayerActions();

            // Draw graphs
            Dictionary<int, Dictionary<int, int>> valuesMapByMatchesNb = this._aiController.GetActionValues();
            for (int i = 1; i <= GameController.INITIAL_MATCHES_NB; i++)
            {
                Control foundControl = this.pnlAIArea.Controls.Find($"{_CHART_NAME_PREFIX}{i}", false)[0];

                if (valuesMapByMatchesNb.ContainsKey(i) && foundControl is Chart)
                {
                    Dictionary<int, int> valueByActionDict = valuesMapByMatchesNb[i];

                    Chart chart = foundControl as Chart;
                    chart.Series[0].Points.Clear();
                    chart.Series[0].Points.AddXY(0, valueByActionDict[1]);
                    chart.Series[0].Points.AddXY(1, valueByActionDict[2]);
                    chart.Series[0].Points.AddXY(2, valueByActionDict[3]);
                }
            }
        }

        /// <summary>
        /// Updates the view after the game start
        /// </summary>
        private void UpdateView_GameStart()
        {
            btnStartGame.Visible = false;

            Player currentPlayer = this._gameController.GetCurrentPlayer();
            if (currentPlayer == this._gameController.Player1)
            {
                pnlP1.Enabled = true;
                pnlP2.Enabled = false;
            }
            // currentPlayer == Player2
            else
            {
                pnlP2.Enabled = true;
                pnlP1.Enabled = false;
            }

            AddMatchsticksToView();
        }

        /// <summary>
        /// Updates the view after a mode switch
        /// </summary>
        private void UpdateView_SwitchedGameMode()
        {
            // If player1 is a Human
            if (this._gameController.Player1.PlayerType == PlayerType.Human)
            {
                lblP1RobotMessage.Visible = false;
                pnlP1.Enabled = true;
            }
            // If player1 is a Robot
            else
            {
                lblP1RobotMessage.Visible = true;
                pnlP1.Enabled = false;
            }

            pnlP2.Enabled = false;
            // If player2 is a Human
            if (this._gameController.Player2.PlayerType == PlayerType.Human)
            {
                lblP2RobotMessage.Visible = false;
            }
            // If player2 is a Robot
            else
            {
                lblP2RobotMessage.Visible = true;
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
            else
            {
                pnlRvR.Visible = false;
            }
        }

        /// <summary>
        /// Updates the display of AI information
        /// </summary>
        private void UpdateAIDisplay()
        {
            const string ROUNDS_PREFIX = "Rounds : ";
            
            float learningPercentage = this._aiController.CalculateLearningPercentage();
            this.pnlLearningBar.Width = Convert.ToInt32(this.pnlLearningBarContainer.Width * learningPercentage);

            this.lblRounds.Text = ROUNDS_PREFIX + this._aiController.Agent.RoundsNb;
        }

        /// <summary>
        /// Draws the lists of players' actions
        /// </summary>
        private void DrawPlayerActions()
        {
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

            // Draw graphs and graph labels
            for (int i = 1; i <= GameController.INITIAL_MATCHES_NB; i++)
            {
                // Draw graph
                ChartArea chrArea = new ChartArea();
                Series chrSeries = new Series();
                Chart chr = new Chart();

                chrArea.Name = $"{FrmMain._CHARTAREA_NAME_PREFIX}{i}";
                chr.ChartAreas.Add(chrArea);
                chr.Location = new System.Drawing.Point(3 + (i - 1) * 30, 85);
                chr.Name = $"{FrmMain._CHART_NAME_PREFIX}{i}";
                chrSeries.ChartArea = $"{FrmMain._CHARTAREA_NAME_PREFIX}{i}";
                chrSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                chrSeries.IsVisibleInLegend = false;
                chrSeries.Name = $"{FrmMain._SERIES_NAME_PREFIX}{i}";
                chr.Series.Add(chrSeries);
                chr.Size = new System.Drawing.Size(24, 24);
                chr.TabStop = false;
                chr.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
                chr.BorderlineDashStyle = ChartDashStyle.Solid;
                chr.BorderlineColor = Color.White;

                // Draw label
                Label graphLabel = new Label();
                graphLabel.Location = new System.Drawing.Point(3 + (i - 1) * 30, 110);
                graphLabel.Name = $"{FrmMain._CHART_LBL_NAME_PREFIX}{i}";
                graphLabel.Size = new System.Drawing.Size(24, 24);
                graphLabel.Text = i.ToString();
                graphLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                this.pnlAIArea.Controls.Add(chr);
                this.pnlAIArea.Controls.Add(graphLabel);
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._backupManager.Serialize(this._aiController, this._gameController);
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
            if (this._gameController.IsRvR())
            {
                this._gameController.PlayGameAutomatically(FrmMain._AUTO_PLAY_OPTION1);
            }
            else
            {
                this._gameController.PrepareGame();
            }
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

            UpdateView_SwitchedGameMode();
            this._gameController.EndGamePreventively();
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

            UpdateView_SwitchedGameMode();
            this._gameController.EndGamePreventively();
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
