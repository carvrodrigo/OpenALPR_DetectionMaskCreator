namespace DetectionMaskTool
{
    partial class DetectionMaskForm
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
            this.pcbMask = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClearMask = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnLoadImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMask)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbMask
            // 
            this.pcbMask.BackColor = System.Drawing.SystemColors.Control;
            this.pcbMask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbMask.Location = new System.Drawing.Point(2, 2);
            this.pcbMask.Name = "pcbMask";
            this.pcbMask.Size = new System.Drawing.Size(400, 400);
            this.pcbMask.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbMask.TabIndex = 0;
            this.pcbMask.TabStop = false;
            this.pcbMask.Paint += new System.Windows.Forms.PaintEventHandler(this.pcbMask_Paint);
            this.pcbMask.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pcbMask_MouseClick);
            this.pcbMask.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pcbMask_MouseDown);
            this.pcbMask.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcbMask_MouseMove);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(405, 221);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save and Exit";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClearMask
            // 
            this.btnClearMask.Enabled = false;
            this.btnClearMask.Location = new System.Drawing.Point(405, 192);
            this.btnClearMask.Name = "btnClearMask";
            this.btnClearMask.Size = new System.Drawing.Size(100, 23);
            this.btnClearMask.TabIndex = 3;
            this.btnClearMask.Text = "Clear Mask";
            this.btnClearMask.UseVisualStyleBackColor = true;
            this.btnClearMask.Click += new System.EventHandler(this.btnClearMask_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "mask.jpg";
            this.saveFileDialog1.Filter = "\"JPeg Image|*.jpg\";";
            this.saveFileDialog1.Title = "Save mask";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "\"JPeg Image|*.jpg|Bitmap Image|*.bmp|PNG Image|*.png\";";
            this.openFileDialog1.Title = "Open image to create the mask";
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(405, 163);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(100, 23);
            this.btnLoadImage.TabIndex = 4;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // DetectionMaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(527, 429);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.btnClearMask);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pcbMask);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DetectionMaskForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OpenALPR - Detection Mask Creator v1.0 (by Joel Vargas)";
            this.Load += new System.EventHandler(this.DetectionMaskForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbMask)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbMask;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClearMask;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnLoadImage;
    }
}

