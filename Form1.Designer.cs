
namespace watermark
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CorrectionAction = new System.Windows.Forms.Button();
            this.buttonPatternLoad = new System.Windows.Forms.Button();
            this.buttonOutputDirLoad = new System.Windows.Forms.Button();
            this.buttonInputDirLoad = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.buttonPocketCorrection = new System.Windows.Forms.Button();
            this.buttonLoadPattern = new System.Windows.Forms.Button();
            this.buttonSaveImageAfterCorrection = new System.Windows.Forms.Button();
            this.buttonLoadImageForCorrection = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonAddMasck = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAddMasck);
            this.groupBox1.Controls.Add(this.CorrectionAction);
            this.groupBox1.Controls.Add(this.buttonPatternLoad);
            this.groupBox1.Controls.Add(this.buttonOutputDirLoad);
            this.groupBox1.Controls.Add(this.buttonInputDirLoad);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.buttonPocketCorrection);
            this.groupBox1.Controls.Add(this.buttonLoadPattern);
            this.groupBox1.Controls.Add(this.buttonSaveImageAfterCorrection);
            this.groupBox1.Controls.Add(this.buttonLoadImageForCorrection);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(966, 553);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Удаление водяного знака";
            // 
            // CorrectionAction
            // 
            this.CorrectionAction.Location = new System.Drawing.Point(319, 19);
            this.CorrectionAction.Name = "CorrectionAction";
            this.CorrectionAction.Size = new System.Drawing.Size(154, 23);
            this.CorrectionAction.TabIndex = 9;
            this.CorrectionAction.Text = "Корректировать в ручную";
            this.CorrectionAction.UseVisualStyleBackColor = true;
            this.CorrectionAction.Click += new System.EventHandler(this.CorrectionAction_Click);
            // 
            // buttonPatternLoad
            // 
            this.buttonPatternLoad.Location = new System.Drawing.Point(583, 159);
            this.buttonPatternLoad.Name = "buttonPatternLoad";
            this.buttonPatternLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonPatternLoad.TabIndex = 8;
            this.buttonPatternLoad.Text = "Указать";
            this.buttonPatternLoad.UseVisualStyleBackColor = true;
            this.buttonPatternLoad.Click += new System.EventHandler(this.buttonPatternLoad_Click);
            // 
            // buttonOutputDirLoad
            // 
            this.buttonOutputDirLoad.Location = new System.Drawing.Point(583, 130);
            this.buttonOutputDirLoad.Name = "buttonOutputDirLoad";
            this.buttonOutputDirLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonOutputDirLoad.TabIndex = 8;
            this.buttonOutputDirLoad.Text = "Указать";
            this.buttonOutputDirLoad.UseVisualStyleBackColor = true;
            this.buttonOutputDirLoad.Click += new System.EventHandler(this.buttonOutputDirLoad_Click);
            // 
            // buttonInputDirLoad
            // 
            this.buttonInputDirLoad.Location = new System.Drawing.Point(583, 104);
            this.buttonInputDirLoad.Name = "buttonInputDirLoad";
            this.buttonInputDirLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonInputDirLoad.TabIndex = 8;
            this.buttonInputDirLoad.Text = "Указать";
            this.buttonInputDirLoad.UseVisualStyleBackColor = true;
            this.buttonInputDirLoad.Click += new System.EventHandler(this.buttonInputDirLoad_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(147, 158);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(430, 20);
            this.textBox3.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(147, 132);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(430, 20);
            this.textBox2.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(147, 106);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(430, 20);
            this.textBox1.TabIndex = 7;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(683, 32);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(272, 170);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(595, 22);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(53, 20);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // buttonPocketCorrection
            // 
            this.buttonPocketCorrection.Location = new System.Drawing.Point(12, 77);
            this.buttonPocketCorrection.Name = "buttonPocketCorrection";
            this.buttonPocketCorrection.Size = new System.Drawing.Size(137, 23);
            this.buttonPocketCorrection.TabIndex = 4;
            this.buttonPocketCorrection.Text = "Обработать каталог";
            this.buttonPocketCorrection.UseVisualStyleBackColor = true;
            this.buttonPocketCorrection.Click += new System.EventHandler(this.buttonPocketCorrection_Click);
            // 
            // buttonLoadPattern
            // 
            this.buttonLoadPattern.Location = new System.Drawing.Point(93, 19);
            this.buttonLoadPattern.Name = "buttonLoadPattern";
            this.buttonLoadPattern.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadPattern.TabIndex = 3;
            this.buttonLoadPattern.Text = "Шаблон";
            this.buttonLoadPattern.UseVisualStyleBackColor = true;
            this.buttonLoadPattern.Click += new System.EventHandler(this.buttonLoadPattern_Click);
            // 
            // buttonSaveImageAfterCorrection
            // 
            this.buttonSaveImageAfterCorrection.Location = new System.Drawing.Point(174, 19);
            this.buttonSaveImageAfterCorrection.Name = "buttonSaveImageAfterCorrection";
            this.buttonSaveImageAfterCorrection.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveImageAfterCorrection.TabIndex = 2;
            this.buttonSaveImageAfterCorrection.Text = "Сохранить";
            this.buttonSaveImageAfterCorrection.UseVisualStyleBackColor = true;
            this.buttonSaveImageAfterCorrection.Click += new System.EventHandler(this.buttonSaveImageAfterCorrection_Click);
            // 
            // buttonLoadImageForCorrection
            // 
            this.buttonLoadImageForCorrection.Location = new System.Drawing.Point(12, 19);
            this.buttonLoadImageForCorrection.Name = "buttonLoadImageForCorrection";
            this.buttonLoadImageForCorrection.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadImageForCorrection.TabIndex = 2;
            this.buttonLoadImageForCorrection.Text = "Загрузить";
            this.buttonLoadImageForCorrection.UseVisualStyleBackColor = true;
            this.buttonLoadImageForCorrection.Click += new System.EventHandler(this.buttonLoadImageForCorrection_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(486, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Дельта цвета RGB";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(685, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Шаблон водяного знака";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(470, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Стало";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Шаблон водяного знака";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Выходной каталог";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(174, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Всего обработано 0 из 0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Входной каталог";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Было";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(473, 208);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(482, 331);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(6, 208);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(461, 331);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonAddMasck
            // 
            this.buttonAddMasck.Location = new System.Drawing.Point(319, 48);
            this.buttonAddMasck.Name = "buttonAddMasck";
            this.buttonAddMasck.Size = new System.Drawing.Size(154, 23);
            this.buttonAddMasck.TabIndex = 10;
            this.buttonAddMasck.Text = "Добавить водяной знак :-)";
            this.buttonAddMasck.UseVisualStyleBackColor = true;
            this.buttonAddMasck.Click += new System.EventHandler(this.buttonAddMasck_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 553);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Удаление водяного знака - Исправленная!";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSaveImageAfterCorrection;
        private System.Windows.Forms.Button buttonLoadImageForCorrection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttonLoadPattern;
        private System.Windows.Forms.Button buttonPocketCorrection;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button buttonPatternLoad;
        private System.Windows.Forms.Button buttonOutputDirLoad;
        private System.Windows.Forms.Button buttonInputDirLoad;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CorrectionAction;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonAddMasck;
    }
}

