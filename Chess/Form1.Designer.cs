namespace Chess
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.Classic = new System.Windows.Forms.Button();
			this.NineSixty = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// Classic
			// 
			this.Classic.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Classic.Location = new System.Drawing.Point(820, 23);
			this.Classic.Margin = new System.Windows.Forms.Padding(6);
			this.Classic.Name = "Classic";
			this.Classic.Size = new System.Drawing.Size(236, 44);
			this.Classic.TabIndex = 0;
			this.Classic.Text = "New Classic Game";
			this.Classic.UseVisualStyleBackColor = true;
			this.Classic.Click += new System.EventHandler(this.button1_Click);
			// 
			// NineSixty
			// 
			this.NineSixty.Cursor = System.Windows.Forms.Cursors.Hand;
			this.NineSixty.Location = new System.Drawing.Point(820, 76);
			this.NineSixty.Name = "NineSixty";
			this.NineSixty.Size = new System.Drawing.Size(236, 45);
			this.NineSixty.TabIndex = 1;
			this.NineSixty.Text = "New Chess960 Game";
			this.NineSixty.UseVisualStyleBackColor = true;
			this.NineSixty.Click += new System.EventHandler(this.button2_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1076, 771);
			this.Controls.Add(this.NineSixty);
			this.Controls.Add(this.Classic);
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Classic;
		private System.Windows.Forms.Button NineSixty;
	}
}

