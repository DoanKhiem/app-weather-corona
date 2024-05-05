namespace Tungnt.Net.WinFormApp
{
    partial class gridStudent
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gridStudent));
            toolStrip1 = new ToolStrip();
            toolNew = new ToolStripButton();
            toolEdit = new ToolStripButton();
            toolStripSeparator = new ToolStripSeparator();
            toolDelete = new ToolStripButton();
            toolRefresh = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            splitContainer1 = new SplitContainer();
            Save = new Button();
            txtProfessional = new TextBox();
            txtClass = new TextBox();
            txtStudentName = new TextBox();
            txtStudentID = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolNew, toolEdit, toolStripSeparator, toolDelete, toolRefresh, toolStripSeparator1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(778, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolNew
            // 
            toolNew.Image = (Image)resources.GetObject("toolNew.Image");
            toolNew.ImageTransparentColor = Color.Magenta;
            toolNew.Name = "toolNew";
            toolNew.Size = new Size(63, 24);
            toolNew.Text = "&New";
            toolNew.Click += toolNew_Click;
            // 
            // toolEdit
            // 
            toolEdit.Image = (Image)resources.GetObject("toolEdit.Image");
            toolEdit.ImageTransparentColor = Color.Magenta;
            toolEdit.Name = "toolEdit";
            toolEdit.Size = new Size(59, 24);
            toolEdit.Text = "&Edit";
            toolEdit.Click += toolEdit_Click;
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new Size(6, 27);
            // 
            // toolDelete
            // 
            toolDelete.Image = (Image)resources.GetObject("toolDelete.Image");
            toolDelete.ImageTransparentColor = Color.Magenta;
            toolDelete.Name = "toolDelete";
            toolDelete.Size = new Size(77, 24);
            toolDelete.Text = "&Delete";
            toolDelete.Click += toolDelete_Click;
            // 
            // toolRefresh
            // 
            toolRefresh.Image = (Image)resources.GetObject("toolRefresh.Image");
            toolRefresh.ImageTransparentColor = Color.Magenta;
            toolRefresh.Name = "toolRefresh";
            toolRefresh.Size = new Size(82, 24);
            toolRefresh.Text = "&Refresh";
            toolRefresh.Click += toolRefresh_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 27);
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 27);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(Save);
            splitContainer1.Panel1.Controls.Add(txtProfessional);
            splitContainer1.Panel1.Controls.Add(txtClass);
            splitContainer1.Panel1.Controls.Add(txtStudentName);
            splitContainer1.Panel1.Controls.Add(txtStudentID);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridView1);
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitContainer1.Size = new Size(778, 423);
            splitContainer1.SplitterDistance = 259;
            splitContainer1.TabIndex = 1;
            // 
            // Save
            // 
            Save.Location = new Point(73, 302);
            Save.Name = "Save";
            Save.Size = new Size(94, 29);
            Save.TabIndex = 8;
            Save.Text = "Save";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // txtProfessional
            // 
            txtProfessional.Location = new Point(19, 223);
            txtProfessional.Name = "txtProfessional";
            txtProfessional.Size = new Size(220, 27);
            txtProfessional.TabIndex = 7;
            // 
            // txtClass
            // 
            txtClass.Location = new Point(17, 171);
            txtClass.Name = "txtClass";
            txtClass.Size = new Size(222, 27);
            txtClass.TabIndex = 6;
            // 
            // txtStudentName
            // 
            txtStudentName.Location = new Point(19, 109);
            txtStudentName.Name = "txtStudentName";
            txtStudentName.Size = new Size(220, 27);
            txtStudentName.TabIndex = 5;
            // 
            // txtStudentID
            // 
            txtStudentID.Location = new Point(20, 48);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.Size = new Size(219, 27);
            txtStudentID.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 200);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 3;
            label4.Text = "Professional";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 144);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 2;
            label3.Text = "Class";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 81);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 1;
            label2.Text = "Student Name";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Location = new Point(13, 17);
            label1.Name = "label1";
            label1.Size = new Size(89, 25);
            label1.TabIndex = 0;
            label1.Text = "StudentID";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(515, 423);
            dataGridView1.TabIndex = 0;
            // 
            // gridStudent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 450);
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            Name = "gridStudent";
            Text = "gridStudent";
            Load += gridStudent_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton toolNew;
        private ToolStripButton toolEdit;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripButton toolDelete;
        private ToolStripButton toolRefresh;
        private ToolStripSeparator toolStripSeparator1;
        private SplitContainer splitContainer1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button Save;
        private TextBox txtProfessional;
        private TextBox txtClass;
        private TextBox txtStudentName;
        private TextBox txtStudentID;
        private DataGridView dataGridView1;
    }
}
