namespace SpaceRace
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameEngine = new System.Windows.Forms.Timer(this.components);
            this.score1 = new System.Windows.Forms.Label();
            this.score2 = new System.Windows.Forms.Label();
            this.seLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameEngine
            // 
            this.gameEngine.Interval = 20;
            this.gameEngine.Tick += new System.EventHandler(this.gameEngine_Tick);
            // 
            // score1
            // 
            this.score1.AutoSize = true;
            this.score1.ForeColor = System.Drawing.Color.White;
            this.score1.Location = new System.Drawing.Point(2, 4);
            this.score1.Name = "score1";
            this.score1.Size = new System.Drawing.Size(47, 13);
            this.score1.TabIndex = 0;
            this.score1.Text = "Score: 0";
            // 
            // score2
            // 
            this.score2.AutoSize = true;
            this.score2.ForeColor = System.Drawing.Color.White;
            this.score2.Location = new System.Drawing.Point(541, 4);
            this.score2.Name = "score2";
            this.score2.Size = new System.Drawing.Size(47, 13);
            this.score2.TabIndex = 0;
            this.score2.Text = "Score: 0";
            // 
            // seLabel
            // 
            this.seLabel.BackColor = System.Drawing.Color.Transparent;
            this.seLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seLabel.ForeColor = System.Drawing.Color.White;
            this.seLabel.Location = new System.Drawing.Point(179, 72);
            this.seLabel.Name = "seLabel";
            this.seLabel.Size = new System.Drawing.Size(208, 114);
            this.seLabel.TabIndex = 0;
            this.seLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.score2);
            this.Controls.Add(this.seLabel);
            this.Controls.Add(this.score1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameEngine;
        private System.Windows.Forms.Label score1;
        private System.Windows.Forms.Label score2;
        private System.Windows.Forms.Label seLabel;
    }
}

