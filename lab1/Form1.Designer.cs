namespace lab1
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
            this.GenerateRegister = new System.Windows.Forms.Button();
            this.CreateIndex = new System.Windows.Forms.Button();
            this.SearchString = new System.Windows.Forms.TextBox();
            this.IndexSearch = new System.Windows.Forms.Button();
            this.DumbSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GenerateRegister
            // 
            this.GenerateRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GenerateRegister.Location = new System.Drawing.Point(41, 95);
            this.GenerateRegister.Name = "GenerateRegister";
            this.GenerateRegister.Size = new System.Drawing.Size(196, 60);
            this.GenerateRegister.TabIndex = 0;
            this.GenerateRegister.Text = "создать 1000 записей";
            this.GenerateRegister.UseVisualStyleBackColor = true;
            this.GenerateRegister.Click += new System.EventHandler(this.GenerateRegister_Click);
            // 
            // CreateIndex
            // 
            this.CreateIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateIndex.Location = new System.Drawing.Point(41, 172);
            this.CreateIndex.Name = "CreateIndex";
            this.CreateIndex.Size = new System.Drawing.Size(196, 60);
            this.CreateIndex.TabIndex = 1;
            this.CreateIndex.Text = "индексировать файл";
            this.CreateIndex.UseVisualStyleBackColor = true;
            this.CreateIndex.Click += new System.EventHandler(this.CreateIndex_Click);
            // 
            // SearchString
            // 
            this.SearchString.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchString.Location = new System.Drawing.Point(827, 106);
            this.SearchString.Name = "SearchString";
            this.SearchString.Size = new System.Drawing.Size(196, 35);
            this.SearchString.TabIndex = 2;
            this.SearchString.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // IndexSearch
            // 
            this.IndexSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IndexSearch.Location = new System.Drawing.Point(565, 172);
            this.IndexSearch.Name = "IndexSearch";
            this.IndexSearch.Size = new System.Drawing.Size(196, 60);
            this.IndexSearch.TabIndex = 3;
            this.IndexSearch.Text = "искать через индекс";
            this.IndexSearch.UseVisualStyleBackColor = true;
            this.IndexSearch.Click += new System.EventHandler(this.IndexSearch_Click);
            // 
            // DumbSearch
            // 
            this.DumbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DumbSearch.Location = new System.Drawing.Point(565, 249);
            this.DumbSearch.Name = "DumbSearch";
            this.DumbSearch.Size = new System.Drawing.Size(196, 60);
            this.DumbSearch.TabIndex = 4;
            this.DumbSearch.Text = "искать последовательно";
            this.DumbSearch.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(37, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Подготовить данные";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(561, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Строка поиска";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(561, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Выполнить поиск";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(833, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Затраченное время";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(833, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "0 мс";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(833, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "0 мс";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(265, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 24);
            this.label7.TabIndex = 11;
            this.label7.Text = "Размер файла:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(246, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 24);
            this.label8.TabIndex = 12;
            this.label8.Text = "Размер индекса:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(478, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 24);
            this.label9.TabIndex = 13;
            this.label9.Text = "0 МБ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(478, 190);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 24);
            this.label10.TabIndex = 14;
            this.label10.Text = "0 МБ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(37, 349);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 24);
            this.label11.TabIndex = 15;
            this.label11.Text = "0 мс";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(37, 387);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 24);
            this.label12.TabIndex = 16;
            this.label12.Text = "0 мс";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(37, 423);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 24);
            this.label13.TabIndex = 17;
            this.label13.Text = "0 мс";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 499);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DumbSearch);
            this.Controls.Add(this.IndexSearch);
            this.Controls.Add(this.SearchString);
            this.Controls.Add(this.CreateIndex);
            this.Controls.Add(this.GenerateRegister);
            this.Name = "Form1";
            this.Text = "Индексный поиск";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GenerateRegister;
        private System.Windows.Forms.Button CreateIndex;
        private System.Windows.Forms.TextBox SearchString;
        private System.Windows.Forms.Button IndexSearch;
        private System.Windows.Forms.Button DumbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}

