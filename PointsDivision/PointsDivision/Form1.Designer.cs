namespace PointsDivision
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
            this.GeneratePoints = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // GeneratePoints
            // 
            this.GeneratePoints.Location = new System.Drawing.Point(11, 500);
            this.GeneratePoints.Name = "GeneratePoints";
            this.GeneratePoints.Size = new System.Drawing.Size(155, 46);
            this.GeneratePoints.TabIndex = 0;
            this.GeneratePoints.Text = "Генерация точек";
            this.GeneratePoints.UseVisualStyleBackColor = true;
            this.GeneratePoints.Click += new System.EventHandler(this.GeneratePoints_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(172, 500);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 46);
            this.button2.TabIndex = 1;
            this.button2.Text = "Классифицировать";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mainPictureBox.Location = new System.Drawing.Point(12, 12);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(940, 482);
            this.mainPictureBox.TabIndex = 2;
            this.mainPictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 617);
            this.Controls.Add(this.mainPictureBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.GeneratePoints);
            this.Name = "Form1";
            this.Text = "Главное окно";
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GeneratePoints;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox mainPictureBox;
    }
}

