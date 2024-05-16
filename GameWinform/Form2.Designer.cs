namespace GameWinform
{
    partial class Form2
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
            this.Start_Button = new System.Windows.Forms.Button();
            this.Exit_Buttom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Start_Button
            // 
            this.Start_Button.BackgroundImage = global::GameWinform.Properties.Resources.startbutton;
            this.Start_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Start_Button.Location = new System.Drawing.Point(401, 407);
            this.Start_Button.Name = "Start_Button";
            this.Start_Button.Size = new System.Drawing.Size(151, 51);
            this.Start_Button.TabIndex = 0;
            this.Start_Button.UseVisualStyleBackColor = true;
            this.Start_Button.Click += new System.EventHandler(this.Start_Button_Click);
            // 
            // Exit_Buttom
            // 
            this.Exit_Buttom.BackgroundImage = global::GameWinform.Properties.Resources.EXITGAMEbUTTOM;
            this.Exit_Buttom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Exit_Buttom.Location = new System.Drawing.Point(401, 496);
            this.Exit_Buttom.Name = "Exit_Buttom";
            this.Exit_Buttom.Size = new System.Drawing.Size(151, 51);
            this.Exit_Buttom.TabIndex = 1;
            this.Exit_Buttom.UseVisualStyleBackColor = true;
            this.Exit_Buttom.Click += new System.EventHandler(this.Exit_Buttom_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GameWinform.Properties.Resources.start_game;
            this.ClientSize = new System.Drawing.Size(940, 700);
            this.Controls.Add(this.Exit_Buttom);
            this.Controls.Add(this.Start_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(940, 700);
            this.MinimumSize = new System.Drawing.Size(940, 700);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Start_Button;
        private System.Windows.Forms.Button Exit_Buttom;
    }
}