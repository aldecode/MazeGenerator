namespace MazeGenerator
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.createBtn = new System.Windows.Forms.Button();
            this.picMaze = new System.Windows.Forms.PictureBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.solveBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.picMaze)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Height";
            // 
            // txtWidth
            // 
            this.txtWidth.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtWidth.Location = new System.Drawing.Point(55, 281);
            this.txtWidth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(77, 22);
            this.txtWidth.TabIndex = 2;
            this.txtWidth.Text = "20";
            // 
            // txtHeight
            // 
            this.txtHeight.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtHeight.Location = new System.Drawing.Point(188, 281);
            this.txtHeight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(77, 22);
            this.txtHeight.TabIndex = 2;
            this.txtHeight.Text = "20";
            // 
            // createBtn
            // 
            this.createBtn.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createBtn.Location = new System.Drawing.Point(12, 310);
            this.createBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.createBtn.Name = "createBtn";
            this.createBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.createBtn.Size = new System.Drawing.Size(120, 23);
            this.createBtn.TabIndex = 5;
            this.createBtn.Text = "Create Maze";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // picMaze
            // 
            this.picMaze.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.picMaze.BackColor = System.Drawing.Color.Black;
            this.picMaze.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picMaze.Location = new System.Drawing.Point(12, 13);
            this.picMaze.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picMaze.MinimumSize = new System.Drawing.Size(381, 260);
            this.picMaze.Name = "picMaze";
            this.picMaze.Size = new System.Drawing.Size(381, 260);
            this.picMaze.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMaze.TabIndex = 4;
            this.picMaze.TabStop = false;
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Location = new System.Drawing.Point(272, 281);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(121, 52);
            this.saveBtn.TabIndex = 5;
            this.saveBtn.Text = "Save IMG";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // solveBtn
            // 
            this.solveBtn.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.solveBtn.Location = new System.Drawing.Point(145, 310);
            this.solveBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.solveBtn.Name = "solveBtn";
            this.solveBtn.Size = new System.Drawing.Size(120, 23);
            this.solveBtn.TabIndex = 6;
            this.solveBtn.Text = "Solve Maze";
            this.solveBtn.UseVisualStyleBackColor = true;
            this.solveBtn.Click += new System.EventHandler(this.solveBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(405, 341);
            this.Controls.Add(this.solveBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.picMaze);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(421, 380);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MazeGenerator";
            ((System.ComponentModel.ISupportInitialize) (this.picMaze)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.PictureBox picMaze;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button solveBtn;
    }
}