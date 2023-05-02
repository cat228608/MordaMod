namespace MordaMod
{
    partial class profil
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
            this.loads = new System.Windows.Forms.Label();
            this.user_avatar = new System.Windows.Forms.PictureBox();
            this.exit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.number = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.user_avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // loads
            // 
            this.loads.AutoSize = true;
            this.loads.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loads.Location = new System.Drawing.Point(175, 132);
            this.loads.Name = "loads";
            this.loads.Size = new System.Drawing.Size(78, 16);
            this.loads.TabIndex = 0;
            this.loads.Text = "Загрузка...";
            // 
            // user_avatar
            // 
            this.user_avatar.Location = new System.Drawing.Point(12, 12);
            this.user_avatar.Name = "user_avatar";
            this.user_avatar.Size = new System.Drawing.Size(115, 104);
            this.user_avatar.TabIndex = 1;
            this.user_avatar.TabStop = false;
            // 
            // exit
            // 
            this.exit.AutoSize = true;
            this.exit.BackColor = System.Drawing.Color.Transparent;
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit.ForeColor = System.Drawing.Color.Red;
            this.exit.Location = new System.Drawing.Point(400, 0);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(21, 20);
            this.exit.TabIndex = 2;
            this.exit.Text = "X";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Имя великого лорда:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Номер жителя в нашем городе:";
            // 
            // number
            // 
            this.number.AutoSize = true;
            this.number.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.number.Location = new System.Drawing.Point(226, 165);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(78, 16);
            this.number.TabIndex = 0;
            this.number.Text = "Загрузка...";
            // 
            // profil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 286);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.user_avatar);
            this.Controls.Add(this.number);
            this.Controls.Add(this.loads);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "profil";
            this.Text = "Профиль";
            ((System.ComponentModel.ISupportInitialize)(this.user_avatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loads;
        private System.Windows.Forms.PictureBox user_avatar;
        private System.Windows.Forms.Label exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label number;
    }
}