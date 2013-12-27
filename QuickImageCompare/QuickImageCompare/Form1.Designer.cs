namespace QuickImageCompare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.folderFind = new System.Windows.Forms.FolderBrowserDialog();
            this.bGetFolder = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.thisPic = new System.Windows.Forms.PictureBox();
            this.nextPic = new System.Windows.Forms.PictureBox();
            this.zoomNext = new System.Windows.Forms.PictureBox();
            this.zoomThis = new System.Windows.Forms.PictureBox();
            this.lblndex = new System.Windows.Forms.Label();
            this.navBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.thisPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomThis)).BeginInit();
            this.SuspendLayout();
            // 
            // folderFind
            // 
            this.folderFind.ShowNewFolderButton = false;
            // 
            // bGetFolder
            // 
            this.bGetFolder.Image = global::QuickImageCompare.Properties.Resources.folderSearchSized;
            this.bGetFolder.Location = new System.Drawing.Point(12, 8);
            this.bGetFolder.Name = "bGetFolder";
            this.bGetFolder.Size = new System.Drawing.Size(38, 30);
            this.bGetFolder.TabIndex = 0;
            this.bGetFolder.UseVisualStyleBackColor = true;
            this.bGetFolder.Click += new System.EventHandler(this.bGetFolder_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder.Enabled = false;
            this.txtFolder.Location = new System.Drawing.Point(56, 12);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(1206, 20);
            this.txtFolder.TabIndex = 2;
            // 
            // thisPic
            // 
            this.thisPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thisPic.Location = new System.Drawing.Point(12, 44);
            this.thisPic.Name = "thisPic";
            this.thisPic.Size = new System.Drawing.Size(250, 250);
            this.thisPic.TabIndex = 3;
            this.thisPic.TabStop = false;
            this.thisPic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.thisPic_MouseMove);
            this.thisPic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.thisPic_MouseMove);
            // 
            // nextPic
            // 
            this.nextPic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nextPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nextPic.Location = new System.Drawing.Point(1084, 44);
            this.nextPic.Name = "nextPic";
            this.nextPic.Size = new System.Drawing.Size(250, 250);
            this.nextPic.TabIndex = 4;
            this.nextPic.TabStop = false;
            this.nextPic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.thisPic_MouseMove);
            this.nextPic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.thisPic_MouseMove);
            // 
            // zoomNext
            // 
            this.zoomNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomNext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zoomNext.Location = new System.Drawing.Point(1084, 300);
            this.zoomNext.Name = "zoomNext";
            this.zoomNext.Size = new System.Drawing.Size(250, 250);
            this.zoomNext.TabIndex = 6;
            this.zoomNext.TabStop = false;
            this.zoomNext.MouseDown += new System.Windows.Forms.MouseEventHandler(this.zoomNext_MouseDown);
            // 
            // zoomThis
            // 
            this.zoomThis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zoomThis.Location = new System.Drawing.Point(12, 300);
            this.zoomThis.Name = "zoomThis";
            this.zoomThis.Size = new System.Drawing.Size(250, 250);
            this.zoomThis.TabIndex = 5;
            this.zoomThis.TabStop = false;
            this.zoomThis.MouseDown += new System.Windows.Forms.MouseEventHandler(this.zoomThis_MouseDown);
            // 
            // lblndex
            // 
            this.lblndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblndex.AutoSize = true;
            this.lblndex.Location = new System.Drawing.Point(1298, 15);
            this.lblndex.Name = "lblndex";
            this.lblndex.Size = new System.Drawing.Size(36, 13);
            this.lblndex.TabIndex = 13;
            this.lblndex.Text = "0/100";
            this.lblndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // navBox
            // 
            this.navBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.navBox.Location = new System.Drawing.Point(963, 929);
            this.navBox.Name = "navBox";
            this.navBox.Size = new System.Drawing.Size(1, 20);
            this.navBox.TabIndex = 0;
            this.navBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.navBox_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 939);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(621, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Keep (UP)   -   Delete (DOWN)   -   Retouch (END)   -   Previous (LEFT)   -   Nex" +
    "t (RIGHT)   -   Process (ENTER)   -   Save (HOME)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1346, 961);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.navBox);
            this.Controls.Add(this.lblndex);
            this.Controls.Add(this.zoomNext);
            this.Controls.Add(this.zoomThis);
            this.Controls.Add(this.nextPic);
            this.Controls.Add(this.thisPic);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.bGetFolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Quick Image Comparer - by Kevin Cole";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.thisPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomThis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderFind;
        private System.Windows.Forms.Button bGetFolder;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.PictureBox thisPic;
        private System.Windows.Forms.PictureBox nextPic;
        private System.Windows.Forms.PictureBox zoomNext;
        private System.Windows.Forms.PictureBox zoomThis;
        private System.Windows.Forms.Label lblndex;
        private System.Windows.Forms.TextBox navBox;
        private System.Windows.Forms.Label label1;
    }
}

