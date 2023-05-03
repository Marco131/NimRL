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


        // Fields
        private bool _isDraggingForm;
        private Point _startPoint;
        private bool _isAIAreaOpen;

        private GameController _gameController;


        // Ctor
        public FrmMain()
        {
            InitializeComponent();


            this._isDraggingForm = false;
            this._startPoint = new Point(0, 0);

            this.cmbP1.Text = FrmMain._DEFAULT_PLAYER1.GetName();
            this.cmbP2.Text = FrmMain._DEFAULT_PLAYER2.GetName();

            this._isAIAreaOpen = false;
            CloseAIArea();

            this._gameController = new GameController(FrmMain._DEFAULT_PLAYER1, FrmMain._DEFAULT_PLAYER2);
        }


        // Methods
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

        private void btnP1_1_Click(object sender, EventArgs e)
        {
            this._gameController.ContinuePlaying(FrmMain._PLAYER_OPTION1);
        }

        private void btnP1_2_Click(object sender, EventArgs e)
        {
            this._gameController.ContinuePlaying(FrmMain._PLAYER_OPTION2);
        }

        private void btnP1_3_Click(object sender, EventArgs e)
        {
            this._gameController.ContinuePlaying(FrmMain._PLAYER_OPTION3);
        }

        private void btnP2_1_Click(object sender, EventArgs e)
        {
            this._gameController.ContinuePlaying(FrmMain._PLAYER_OPTION1);
        }

        private void btnP2_2_Click(object sender, EventArgs e)
        {
            this._gameController.ContinuePlaying(FrmMain._PLAYER_OPTION2);
        }

        private void btnP2_3_Click(object sender, EventArgs e)
        {
            this._gameController.ContinuePlaying(FrmMain._PLAYER_OPTION3);
        }
    }
}
