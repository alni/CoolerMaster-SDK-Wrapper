namespace Test
{
    partial class form
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.devices = new System.Windows.Forms.ComboBox();
            this.control = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_layout = new System.Windows.Forms.TextBox();
            this.get_layout = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.effects = new System.Windows.Forms.ComboBox();
            this.set_effect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.row = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.column = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.single_red = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.single_green = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.single_blue = new System.Windows.Forms.NumericUpDown();
            this.set_single = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.set_all = new System.Windows.Forms.Button();
            this.all_blue = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.all_green = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.all_red = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.row)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.column)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.single_red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.single_green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.single_blue)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.all_blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.all_green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.all_red)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Device: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "LED Control: ";
            // 
            // devices
            // 
            this.devices.DropDownHeight = 200;
            this.devices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.devices.DropDownWidth = 100;
            this.devices.FormattingEnabled = true;
            this.devices.IntegralHeight = false;
            this.devices.Location = new System.Drawing.Point(90, 7);
            this.devices.Name = "devices";
            this.devices.Size = new System.Drawing.Size(140, 21);
            this.devices.TabIndex = 2;
            this.devices.SelectedIndexChanged += new System.EventHandler(this.devices_SelectedIndexChanged);
            // 
            // control
            // 
            this.control.Location = new System.Drawing.Point(90, 35);
            this.control.Name = "control";
            this.control.Size = new System.Drawing.Size(75, 23);
            this.control.TabIndex = 3;
            this.control.Text = "Enable";
            this.control.UseVisualStyleBackColor = true;
            this.control.Click += new System.EventHandler(this.control_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Layout";
            // 
            // txt_layout
            // 
            this.txt_layout.Location = new System.Drawing.Point(240, 37);
            this.txt_layout.Name = "txt_layout";
            this.txt_layout.ReadOnly = true;
            this.txt_layout.Size = new System.Drawing.Size(50, 20);
            this.txt_layout.TabIndex = 5;
            // 
            // get_layout
            // 
            this.get_layout.Location = new System.Drawing.Point(296, 35);
            this.get_layout.Name = "get_layout";
            this.get_layout.Size = new System.Drawing.Size(50, 23);
            this.get_layout.TabIndex = 6;
            this.get_layout.Text = "Get";
            this.get_layout.UseVisualStyleBackColor = true;
            this.get_layout.Click += new System.EventHandler(this.get_layout_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "LED Effect: ";
            // 
            // effects
            // 
            this.effects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.effects.FormattingEnabled = true;
            this.effects.Location = new System.Drawing.Point(90, 67);
            this.effects.Name = "effects";
            this.effects.Size = new System.Drawing.Size(140, 21);
            this.effects.TabIndex = 8;
            // 
            // set_effect
            // 
            this.set_effect.Location = new System.Drawing.Point(240, 65);
            this.set_effect.Name = "set_effect";
            this.set_effect.Size = new System.Drawing.Size(75, 23);
            this.set_effect.TabIndex = 9;
            this.set_effect.Text = "Set";
            this.set_effect.UseVisualStyleBackColor = true;
            this.set_effect.Click += new System.EventHandler(this.set_effect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.set_single);
            this.groupBox1.Controls.Add(this.single_blue);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.single_green);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.single_red);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.column);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.row);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(10, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 126);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Key Color";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Row: ";
            // 
            // row
            // 
            this.row.Location = new System.Drawing.Point(51, 18);
            this.row.Name = "row";
            this.row.Size = new System.Drawing.Size(35, 20);
            this.row.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(92, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Column: ";
            // 
            // column
            // 
            this.column.Location = new System.Drawing.Point(146, 18);
            this.column.Name = "column";
            this.column.Size = new System.Drawing.Size(35, 20);
            this.column.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "R: ";
            // 
            // single_red
            // 
            this.single_red.Location = new System.Drawing.Point(37, 68);
            this.single_red.Name = "single_red";
            this.single_red.Size = new System.Drawing.Size(70, 20);
            this.single_red.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(121, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "G: ";
            // 
            // single_green
            // 
            this.single_green.Location = new System.Drawing.Point(148, 68);
            this.single_green.Name = "single_green";
            this.single_green.Size = new System.Drawing.Size(70, 20);
            this.single_green.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(232, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "B: ";
            // 
            // single_blue
            // 
            this.single_blue.Location = new System.Drawing.Point(258, 68);
            this.single_blue.Name = "single_blue";
            this.single_blue.Size = new System.Drawing.Size(70, 20);
            this.single_blue.TabIndex = 10;
            // 
            // set_single
            // 
            this.set_single.Location = new System.Drawing.Point(37, 94);
            this.set_single.Name = "set_single";
            this.set_single.Size = new System.Drawing.Size(291, 23);
            this.set_single.TabIndex = 11;
            this.set_single.Text = "Set";
            this.set_single.UseVisualStyleBackColor = true;
            this.set_single.Click += new System.EventHandler(this.set_single_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.set_all);
            this.groupBox2.Controls.Add(this.all_blue);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.all_red);
            this.groupBox2.Controls.Add(this.all_green);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(10, 232);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(336, 79);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Set All Keys Color";
            // 
            // set_all
            // 
            this.set_all.Location = new System.Drawing.Point(37, 45);
            this.set_all.Name = "set_all";
            this.set_all.Size = new System.Drawing.Size(291, 23);
            this.set_all.TabIndex = 18;
            this.set_all.Text = "Set";
            this.set_all.UseVisualStyleBackColor = true;
            this.set_all.Click += new System.EventHandler(this.set_all_Click);
            // 
            // all_blue
            // 
            this.all_blue.Location = new System.Drawing.Point(258, 19);
            this.all_blue.Name = "all_blue";
            this.all_blue.Size = new System.Drawing.Size(70, 20);
            this.all_blue.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(232, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "B: ";
            // 
            // all_green
            // 
            this.all_green.Location = new System.Drawing.Point(148, 19);
            this.all_green.Name = "all_green";
            this.all_green.Size = new System.Drawing.Size(70, 20);
            this.all_green.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(121, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "G: ";
            // 
            // all_red
            // 
            this.all_red.Location = new System.Drawing.Point(37, 19);
            this.all_red.Name = "all_red";
            this.all_red.Size = new System.Drawing.Size(70, 20);
            this.all_red.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "R: ";
            // 
            // form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 391);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.set_effect);
            this.Controls.Add(this.effects);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.get_layout);
            this.Controls.Add(this.txt_layout);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.control);
            this.Controls.Add(this.devices);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "form";
            this.Text = "Sharp SDK";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.row)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.column)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.single_red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.single_green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.single_blue)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.all_blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.all_green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.all_red)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox devices;
        private System.Windows.Forms.Button control;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_layout;
        private System.Windows.Forms.Button get_layout;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox effects;
        private System.Windows.Forms.Button set_effect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown row;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown column;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button set_single;
        private System.Windows.Forms.NumericUpDown single_blue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown single_green;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown single_red;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button set_all;
        private System.Windows.Forms.NumericUpDown all_blue;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown all_red;
        private System.Windows.Forms.NumericUpDown all_green;
        private System.Windows.Forms.Label label11;
    }
}

