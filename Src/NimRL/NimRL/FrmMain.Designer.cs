namespace NimRL
{
    partial class FrmMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 10D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 20D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 3D);
            this.pnlTransparentArea = new System.Windows.Forms.Panel();
            this.pnlAIArea = new System.Windows.Forms.Panel();
            this.lblOptionsByMatchesNb = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlLearningBarContainer = new System.Windows.Forms.Panel();
            this.pnlLearningBar = new System.Windows.Forms.Panel();
            this.lblLearning = new System.Windows.Forms.Label();
            this.lblRounds = new System.Windows.Forms.Label();
            this.lblAIArea = new System.Windows.Forms.Label();
            this.btnOpenCloseAIArea = new System.Windows.Forms.Button();
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnMinimizeForm = new System.Windows.Forms.Button();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.pnlP1 = new System.Windows.Forms.Panel();
            this.lblP1RobotMessage = new System.Windows.Forms.Label();
            this.btnP1_3 = new System.Windows.Forms.Button();
            this.btnP1_2 = new System.Windows.Forms.Button();
            this.btnP1_1 = new System.Windows.Forms.Button();
            this.lblP1Name = new System.Windows.Forms.Label();
            this.pnlRvR = new System.Windows.Forms.Panel();
            this.btnAutoPlay_100 = new System.Windows.Forms.Button();
            this.lblAutoPlay = new System.Windows.Forms.Label();
            this.btnAutoPlay_10 = new System.Windows.Forms.Button();
            this.btnAutoPlay_1 = new System.Windows.Forms.Button();
            this.pnlP2 = new System.Windows.Forms.Panel();
            this.lblP2RobotMessage = new System.Windows.Forms.Label();
            this.btnP2_3 = new System.Windows.Forms.Button();
            this.lblP2Name = new System.Windows.Forms.Label();
            this.btnP2_2 = new System.Windows.Forms.Button();
            this.btnP2_1 = new System.Windows.Forms.Button();
            this.pbxFormIcon = new System.Windows.Forms.PictureBox();
            this.pnlMatches = new System.Windows.Forms.Panel();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.cmbP1 = new System.Windows.Forms.ComboBox();
            this.cmbP2 = new System.Windows.Forms.ComboBox();
            this.pnlTransparentArea.SuspendLayout();
            this.pnlAIArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.pnlLearningBarContainer.SuspendLayout();
            this.pnlTitleBar.SuspendLayout();
            this.pnlP1.SuspendLayout();
            this.pnlRvR.SuspendLayout();
            this.pnlP2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFormIcon)).BeginInit();
            this.pnlMatches.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTransparentArea
            // 
            this.pnlTransparentArea.BackColor = System.Drawing.Color.Lime;
            this.pnlTransparentArea.Controls.Add(this.pnlAIArea);
            this.pnlTransparentArea.Location = new System.Drawing.Point(0, 450);
            this.pnlTransparentArea.Name = "pnlTransparentArea";
            this.pnlTransparentArea.Size = new System.Drawing.Size(800, 200);
            this.pnlTransparentArea.TabIndex = 7;
            // 
            // pnlAIArea
            // 
            this.pnlAIArea.BackColor = System.Drawing.Color.White;
            this.pnlAIArea.Controls.Add(this.lblOptionsByMatchesNb);
            this.pnlAIArea.Controls.Add(this.chart1);
            this.pnlAIArea.Controls.Add(this.pnlLearningBarContainer);
            this.pnlAIArea.Controls.Add(this.lblLearning);
            this.pnlAIArea.Controls.Add(this.lblRounds);
            this.pnlAIArea.Controls.Add(this.lblAIArea);
            this.pnlAIArea.Controls.Add(this.btnOpenCloseAIArea);
            this.pnlAIArea.Location = new System.Drawing.Point(100, 0);
            this.pnlAIArea.Name = "pnlAIArea";
            this.pnlAIArea.Size = new System.Drawing.Size(600, 200);
            this.pnlAIArea.TabIndex = 1;
            // 
            // lblOptionsByMatchesNb
            // 
            this.lblOptionsByMatchesNb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptionsByMatchesNb.Location = new System.Drawing.Point(5, 55);
            this.lblOptionsByMatchesNb.Name = "lblOptionsByMatchesNb";
            this.lblOptionsByMatchesNb.Size = new System.Drawing.Size(295, 25);
            this.lblOptionsByMatchesNb.TabIndex = 4;
            this.lblOptionsByMatchesNb.Text = "Options by number of matches : ";
            this.lblOptionsByMatchesNb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Location = new System.Drawing.Point(5, 98);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.IsVisibleInLegend = false;
            series2.Name = "Series1";
            series2.Points.Add(dataPoint4);
            series2.Points.Add(dataPoint5);
            series2.Points.Add(dataPoint6);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(30, 30);
            this.chart1.TabIndex = 5;
            // 
            // pnlLearningBarContainer
            // 
            this.pnlLearningBarContainer.BackColor = System.Drawing.SystemColors.Control;
            this.pnlLearningBarContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLearningBarContainer.Controls.Add(this.pnlLearningBar);
            this.pnlLearningBarContainer.Location = new System.Drawing.Point(5, 175);
            this.pnlLearningBarContainer.Name = "pnlLearningBarContainer";
            this.pnlLearningBarContainer.Size = new System.Drawing.Size(590, 20);
            this.pnlLearningBarContainer.TabIndex = 4;
            // 
            // pnlLearningBar
            // 
            this.pnlLearningBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(143)))), ((int)(((byte)(176)))));
            this.pnlLearningBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLearningBar.Location = new System.Drawing.Point(-1, -1);
            this.pnlLearningBar.Name = "pnlLearningBar";
            this.pnlLearningBar.Size = new System.Drawing.Size(100, 20);
            this.pnlLearningBar.TabIndex = 0;
            // 
            // lblLearning
            // 
            this.lblLearning.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLearning.Location = new System.Drawing.Point(5, 155);
            this.lblLearning.Name = "lblLearning";
            this.lblLearning.Size = new System.Drawing.Size(100, 20);
            this.lblLearning.TabIndex = 6;
            this.lblLearning.Text = "Learning Level : ";
            this.lblLearning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRounds
            // 
            this.lblRounds.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRounds.Location = new System.Drawing.Point(5, 30);
            this.lblRounds.Name = "lblRounds";
            this.lblRounds.Size = new System.Drawing.Size(100, 25);
            this.lblRounds.TabIndex = 2;
            this.lblRounds.Text = "Rounds : ";
            this.lblRounds.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAIArea
            // 
            this.lblAIArea.AutoSize = true;
            this.lblAIArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAIArea.Location = new System.Drawing.Point(31, 3);
            this.lblAIArea.Name = "lblAIArea";
            this.lblAIArea.Size = new System.Drawing.Size(58, 16);
            this.lblAIArea.TabIndex = 1;
            this.lblAIArea.Text = "AI Area";
            // 
            // btnOpenCloseAIArea
            // 
            this.btnOpenCloseAIArea.FlatAppearance.BorderSize = 0;
            this.btnOpenCloseAIArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenCloseAIArea.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnOpenCloseAIArea.Location = new System.Drawing.Point(0, 0);
            this.btnOpenCloseAIArea.Name = "btnOpenCloseAIArea";
            this.btnOpenCloseAIArea.Size = new System.Drawing.Size(25, 25);
            this.btnOpenCloseAIArea.TabIndex = 0;
            this.btnOpenCloseAIArea.Text = "q";
            this.btnOpenCloseAIArea.UseVisualStyleBackColor = true;
            this.btnOpenCloseAIArea.Click += new System.EventHandler(this.btnOpenCloseAiArea_Click);
            // 
            // pnlTitleBar
            // 
            this.pnlTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(64)))), ((int)(((byte)(87)))));
            this.pnlTitleBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTitleBar.Controls.Add(this.lblTitle);
            this.pnlTitleBar.Controls.Add(this.btnMinimizeForm);
            this.pnlTitleBar.Controls.Add(this.btnCloseForm);
            this.pnlTitleBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTitleBar.Name = "pnlTitleBar";
            this.pnlTitleBar.Size = new System.Drawing.Size(800, 25);
            this.pnlTitleBar.TabIndex = 0;
            this.pnlTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitleBar_MouseDown);
            this.pnlTitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTitleBar_MouseMove);
            this.pnlTitleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTitleBar_MouseUp);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(27, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "NimRL";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnMinimizeForm
            // 
            this.btnMinimizeForm.BackColor = System.Drawing.Color.White;
            this.btnMinimizeForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizeForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimizeForm.Location = new System.Drawing.Point(751, -1);
            this.btnMinimizeForm.Name = "btnMinimizeForm";
            this.btnMinimizeForm.Size = new System.Drawing.Size(25, 25);
            this.btnMinimizeForm.TabIndex = 1;
            this.btnMinimizeForm.Text = "--";
            this.btnMinimizeForm.UseVisualStyleBackColor = false;
            this.btnMinimizeForm.Click += new System.EventHandler(this.btnMinimizeForm_Click);
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.BackColor = System.Drawing.Color.IndianRed;
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseForm.Location = new System.Drawing.Point(775, -1);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(25, 25);
            this.btnCloseForm.TabIndex = 2;
            this.btnCloseForm.Text = "X";
            this.btnCloseForm.UseVisualStyleBackColor = false;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // pnlP1
            // 
            this.pnlP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pnlP1.Controls.Add(this.lblP1RobotMessage);
            this.pnlP1.Controls.Add(this.btnP1_3);
            this.pnlP1.Controls.Add(this.btnP1_2);
            this.pnlP1.Controls.Add(this.btnP1_1);
            this.pnlP1.Controls.Add(this.lblP1Name);
            this.pnlP1.Location = new System.Drawing.Point(0, 300);
            this.pnlP1.Name = "pnlP1";
            this.pnlP1.Size = new System.Drawing.Size(250, 150);
            this.pnlP1.TabIndex = 4;
            // 
            // lblP1RobotMessage
            // 
            this.lblP1RobotMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP1RobotMessage.ForeColor = System.Drawing.Color.IndianRed;
            this.lblP1RobotMessage.Location = new System.Drawing.Point(35, 60);
            this.lblP1RobotMessage.Name = "lblP1RobotMessage";
            this.lblP1RobotMessage.Size = new System.Drawing.Size(180, 35);
            this.lblP1RobotMessage.TabIndex = 1;
            this.lblP1RobotMessage.Text = "Robot is controled by AI";
            this.lblP1RobotMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblP1RobotMessage.Visible = false;
            // 
            // btnP1_3
            // 
            this.btnP1_3.BackColor = System.Drawing.Color.White;
            this.btnP1_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnP1_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnP1_3.Location = new System.Drawing.Point(180, 60);
            this.btnP1_3.Name = "btnP1_3";
            this.btnP1_3.Size = new System.Drawing.Size(35, 35);
            this.btnP1_3.TabIndex = 3;
            this.btnP1_3.Text = "3";
            this.btnP1_3.UseVisualStyleBackColor = false;
            this.btnP1_3.Click += new System.EventHandler(this.btnP1_3_Click);
            // 
            // btnP1_2
            // 
            this.btnP1_2.BackColor = System.Drawing.Color.White;
            this.btnP1_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnP1_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnP1_2.Location = new System.Drawing.Point(108, 60);
            this.btnP1_2.Name = "btnP1_2";
            this.btnP1_2.Size = new System.Drawing.Size(35, 35);
            this.btnP1_2.TabIndex = 2;
            this.btnP1_2.Text = "2";
            this.btnP1_2.UseVisualStyleBackColor = false;
            this.btnP1_2.Click += new System.EventHandler(this.btnP1_2_Click);
            // 
            // btnP1_1
            // 
            this.btnP1_1.BackColor = System.Drawing.Color.White;
            this.btnP1_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnP1_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnP1_1.Location = new System.Drawing.Point(35, 60);
            this.btnP1_1.Name = "btnP1_1";
            this.btnP1_1.Size = new System.Drawing.Size(35, 35);
            this.btnP1_1.TabIndex = 1;
            this.btnP1_1.Text = "1";
            this.btnP1_1.UseVisualStyleBackColor = false;
            this.btnP1_1.Click += new System.EventHandler(this.btnP1_1_Click);
            // 
            // lblP1Name
            // 
            this.lblP1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP1Name.Location = new System.Drawing.Point(5, 5);
            this.lblP1Name.Name = "lblP1Name";
            this.lblP1Name.Size = new System.Drawing.Size(100, 25);
            this.lblP1Name.TabIndex = 0;
            this.lblP1Name.Text = "Player 1 : ";
            // 
            // pnlRvR
            // 
            this.pnlRvR.BackColor = System.Drawing.Color.White;
            this.pnlRvR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRvR.Controls.Add(this.btnAutoPlay_100);
            this.pnlRvR.Controls.Add(this.lblAutoPlay);
            this.pnlRvR.Controls.Add(this.btnAutoPlay_10);
            this.pnlRvR.Controls.Add(this.btnAutoPlay_1);
            this.pnlRvR.Location = new System.Drawing.Point(250, 300);
            this.pnlRvR.Name = "pnlRvR";
            this.pnlRvR.Size = new System.Drawing.Size(300, 150);
            this.pnlRvR.TabIndex = 5;
            // 
            // btnAutoPlay_100
            // 
            this.btnAutoPlay_100.BackColor = System.Drawing.Color.White;
            this.btnAutoPlay_100.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoPlay_100.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoPlay_100.Location = new System.Drawing.Point(200, 55);
            this.btnAutoPlay_100.Name = "btnAutoPlay_100";
            this.btnAutoPlay_100.Size = new System.Drawing.Size(45, 45);
            this.btnAutoPlay_100.TabIndex = 3;
            this.btnAutoPlay_100.Text = "100";
            this.btnAutoPlay_100.UseVisualStyleBackColor = false;
            this.btnAutoPlay_100.Click += new System.EventHandler(this.btnAutoPlay_100_Click);
            // 
            // lblAutoPlay
            // 
            this.lblAutoPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoPlay.Location = new System.Drawing.Point(100, 5);
            this.lblAutoPlay.Name = "lblAutoPlay";
            this.lblAutoPlay.Size = new System.Drawing.Size(100, 25);
            this.lblAutoPlay.TabIndex = 0;
            this.lblAutoPlay.Text = " Auto Play";
            this.lblAutoPlay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAutoPlay_10
            // 
            this.btnAutoPlay_10.BackColor = System.Drawing.Color.White;
            this.btnAutoPlay_10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoPlay_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoPlay_10.Location = new System.Drawing.Point(128, 55);
            this.btnAutoPlay_10.Name = "btnAutoPlay_10";
            this.btnAutoPlay_10.Size = new System.Drawing.Size(45, 45);
            this.btnAutoPlay_10.TabIndex = 2;
            this.btnAutoPlay_10.Text = "10";
            this.btnAutoPlay_10.UseVisualStyleBackColor = false;
            this.btnAutoPlay_10.Click += new System.EventHandler(this.btnAutoPlay_10_Click);
            // 
            // btnAutoPlay_1
            // 
            this.btnAutoPlay_1.BackColor = System.Drawing.Color.White;
            this.btnAutoPlay_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoPlay_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoPlay_1.Location = new System.Drawing.Point(55, 55);
            this.btnAutoPlay_1.Name = "btnAutoPlay_1";
            this.btnAutoPlay_1.Size = new System.Drawing.Size(45, 45);
            this.btnAutoPlay_1.TabIndex = 1;
            this.btnAutoPlay_1.Text = "1";
            this.btnAutoPlay_1.UseVisualStyleBackColor = false;
            this.btnAutoPlay_1.Click += new System.EventHandler(this.btnAutoPlay_1_Click);
            // 
            // pnlP2
            // 
            this.pnlP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.pnlP2.Controls.Add(this.lblP2RobotMessage);
            this.pnlP2.Controls.Add(this.btnP2_3);
            this.pnlP2.Controls.Add(this.lblP2Name);
            this.pnlP2.Controls.Add(this.btnP2_2);
            this.pnlP2.Controls.Add(this.btnP2_1);
            this.pnlP2.Location = new System.Drawing.Point(550, 300);
            this.pnlP2.Name = "pnlP2";
            this.pnlP2.Size = new System.Drawing.Size(250, 150);
            this.pnlP2.TabIndex = 6;
            // 
            // lblP2RobotMessage
            // 
            this.lblP2RobotMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP2RobotMessage.ForeColor = System.Drawing.Color.IndianRed;
            this.lblP2RobotMessage.Location = new System.Drawing.Point(35, 60);
            this.lblP2RobotMessage.Name = "lblP2RobotMessage";
            this.lblP2RobotMessage.Size = new System.Drawing.Size(180, 35);
            this.lblP2RobotMessage.TabIndex = 1;
            this.lblP2RobotMessage.Text = "Robot is controled by AI";
            this.lblP2RobotMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblP2RobotMessage.Visible = false;
            // 
            // btnP2_3
            // 
            this.btnP2_3.BackColor = System.Drawing.Color.White;
            this.btnP2_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnP2_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnP2_3.Location = new System.Drawing.Point(180, 60);
            this.btnP2_3.Name = "btnP2_3";
            this.btnP2_3.Size = new System.Drawing.Size(35, 35);
            this.btnP2_3.TabIndex = 3;
            this.btnP2_3.Text = "3";
            this.btnP2_3.UseVisualStyleBackColor = false;
            this.btnP2_3.Click += new System.EventHandler(this.btnP2_3_Click);
            // 
            // lblP2Name
            // 
            this.lblP2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP2Name.Location = new System.Drawing.Point(5, 5);
            this.lblP2Name.Name = "lblP2Name";
            this.lblP2Name.Size = new System.Drawing.Size(100, 25);
            this.lblP2Name.TabIndex = 0;
            this.lblP2Name.Text = "Player 2 : ";
            // 
            // btnP2_2
            // 
            this.btnP2_2.BackColor = System.Drawing.Color.White;
            this.btnP2_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnP2_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnP2_2.Location = new System.Drawing.Point(108, 60);
            this.btnP2_2.Name = "btnP2_2";
            this.btnP2_2.Size = new System.Drawing.Size(35, 35);
            this.btnP2_2.TabIndex = 2;
            this.btnP2_2.Text = "2";
            this.btnP2_2.UseVisualStyleBackColor = false;
            this.btnP2_2.Click += new System.EventHandler(this.btnP2_2_Click);
            // 
            // btnP2_1
            // 
            this.btnP2_1.BackColor = System.Drawing.Color.White;
            this.btnP2_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnP2_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnP2_1.Location = new System.Drawing.Point(35, 60);
            this.btnP2_1.Name = "btnP2_1";
            this.btnP2_1.Size = new System.Drawing.Size(35, 35);
            this.btnP2_1.TabIndex = 1;
            this.btnP2_1.Text = "1";
            this.btnP2_1.UseVisualStyleBackColor = false;
            this.btnP2_1.Click += new System.EventHandler(this.btnP2_1_Click);
            // 
            // pbxFormIcon
            // 
            this.pbxFormIcon.Location = new System.Drawing.Point(3, 3);
            this.pbxFormIcon.Name = "pbxFormIcon";
            this.pbxFormIcon.Size = new System.Drawing.Size(19, 19);
            this.pbxFormIcon.TabIndex = 5;
            this.pbxFormIcon.TabStop = false;
            // 
            // pnlMatches
            // 
            this.pnlMatches.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.pnlMatches.Controls.Add(this.btnStartGame);
            this.pnlMatches.Location = new System.Drawing.Point(150, 75);
            this.pnlMatches.Name = "pnlMatches";
            this.pnlMatches.Size = new System.Drawing.Size(500, 175);
            this.pnlMatches.TabIndex = 2;
            // 
            // btnStartGame
            // 
            this.btnStartGame.BackColor = System.Drawing.Color.White;
            this.btnStartGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGame.Location = new System.Drawing.Point(155, 60);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(190, 55);
            this.btnStartGame.TabIndex = 4;
            this.btnStartGame.Text = "Start Game";
            this.btnStartGame.UseVisualStyleBackColor = false;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // cmbP1
            // 
            this.cmbP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbP1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbP1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbP1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbP1.ForeColor = System.Drawing.Color.Black;
            this.cmbP1.FormattingEnabled = true;
            this.cmbP1.Items.AddRange(new object[] {
            "Human",
            "Robot"});
            this.cmbP1.Location = new System.Drawing.Point(15, 85);
            this.cmbP1.Name = "cmbP1";
            this.cmbP1.Size = new System.Drawing.Size(120, 24);
            this.cmbP1.TabIndex = 1;
            this.cmbP1.SelectedIndexChanged += new System.EventHandler(this.cmbP1_SelectedIndexChanged);
            // 
            // cmbP2
            // 
            this.cmbP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.cmbP2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbP2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbP2.ForeColor = System.Drawing.Color.Black;
            this.cmbP2.FormattingEnabled = true;
            this.cmbP2.Items.AddRange(new object[] {
            "Human",
            "Robot"});
            this.cmbP2.Location = new System.Drawing.Point(665, 85);
            this.cmbP2.Name = "cmbP2";
            this.cmbP2.Size = new System.Drawing.Size(120, 24);
            this.cmbP2.TabIndex = 3;
            this.cmbP2.SelectedIndexChanged += new System.EventHandler(this.cmbP2_SelectedIndexChanged);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 650);
            this.Controls.Add(this.cmbP2);
            this.Controls.Add(this.cmbP1);
            this.Controls.Add(this.pnlMatches);
            this.Controls.Add(this.pbxFormIcon);
            this.Controls.Add(this.pnlP2);
            this.Controls.Add(this.pnlRvR);
            this.Controls.Add(this.pnlP1);
            this.Controls.Add(this.pnlTitleBar);
            this.Controls.Add(this.pnlTransparentArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "W";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.pnlTransparentArea.ResumeLayout(false);
            this.pnlAIArea.ResumeLayout(false);
            this.pnlAIArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.pnlLearningBarContainer.ResumeLayout(false);
            this.pnlTitleBar.ResumeLayout(false);
            this.pnlP1.ResumeLayout(false);
            this.pnlRvR.ResumeLayout(false);
            this.pnlP2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxFormIcon)).EndInit();
            this.pnlMatches.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTransparentArea;
        private System.Windows.Forms.Panel pnlAIArea;
        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button btnMinimizeForm;
        private System.Windows.Forms.Panel pnlP1;
        private System.Windows.Forms.Panel pnlRvR;
        private System.Windows.Forms.Panel pnlP2;
        private System.Windows.Forms.Button btnOpenCloseAIArea;
        private System.Windows.Forms.Label lblAIArea;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbxFormIcon;
        private System.Windows.Forms.Label lblRounds;
        private System.Windows.Forms.Label lblLearning;
        private System.Windows.Forms.Panel pnlLearningBarContainer;
        private System.Windows.Forms.Panel pnlLearningBar;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lblOptionsByMatchesNb;
        private System.Windows.Forms.Panel pnlMatches;
        private System.Windows.Forms.ComboBox cmbP1;
        private System.Windows.Forms.ComboBox cmbP2;
        private System.Windows.Forms.Label lblP1Name;
        private System.Windows.Forms.Label lblP2Name;
        private System.Windows.Forms.Button btnP1_3;
        private System.Windows.Forms.Button btnP1_2;
        private System.Windows.Forms.Button btnP1_1;
        private System.Windows.Forms.Button btnP2_3;
        private System.Windows.Forms.Button btnP2_2;
        private System.Windows.Forms.Button btnP2_1;
        private System.Windows.Forms.Label lblP2RobotMessage;
        private System.Windows.Forms.Label lblP1RobotMessage;
        private System.Windows.Forms.Label lblAutoPlay;
        private System.Windows.Forms.Button btnAutoPlay_100;
        private System.Windows.Forms.Button btnAutoPlay_10;
        private System.Windows.Forms.Button btnAutoPlay_1;
        private System.Windows.Forms.Button btnStartGame;
    }
}

