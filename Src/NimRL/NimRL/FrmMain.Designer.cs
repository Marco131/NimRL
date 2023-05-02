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
            this.pnlTransparentArea = new System.Windows.Forms.Panel();
            this.pnlAIArea = new System.Windows.Forms.Panel();
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.pnlTransparentArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTransparentArea
            // 
            this.pnlTransparentArea.BackColor = System.Drawing.Color.Lime;
            this.pnlTransparentArea.Controls.Add(this.pnlAIArea);
            this.pnlTransparentArea.Location = new System.Drawing.Point(0, 400);
            this.pnlTransparentArea.Name = "pnlTransparentArea";
            this.pnlTransparentArea.Size = new System.Drawing.Size(800, 202);
            this.pnlTransparentArea.TabIndex = 0;
            // 
            // pnlAIArea
            // 
            this.pnlAIArea.BackColor = System.Drawing.SystemColors.Control;
            this.pnlAIArea.Location = new System.Drawing.Point(175, 0);
            this.pnlAIArea.Name = "pnlAIArea";
            this.pnlAIArea.Size = new System.Drawing.Size(431, 199);
            this.pnlAIArea.TabIndex = 1;
            // 
            // pnlTitleBar
            // 
            this.pnlTitleBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTitleBar.Name = "pnlTitleBar";
            this.pnlTitleBar.Size = new System.Drawing.Size(800, 25);
            this.pnlTitleBar.TabIndex = 1;
            this.pnlTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitleBar_MouseDown);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnlTitleBar);
            this.Controls.Add(this.pnlTransparentArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "NimRL";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.pnlTransparentArea.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTransparentArea;
        private System.Windows.Forms.Panel pnlAIArea;
        private System.Windows.Forms.Panel pnlTitleBar;
    }
}

