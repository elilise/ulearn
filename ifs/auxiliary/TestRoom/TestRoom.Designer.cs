namespace TestingRoom
{
	partial class TestRoom
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestRoom));
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("test # 1", 1);
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("test # 2", 0);
			this.listViewImages = new System.Windows.Forms.ImageList(this.components);
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.testCasesList = new System.Windows.Forms.ListView();
			this.pictureLogSplit = new System.Windows.Forms.SplitContainer();
			this.logTextBox = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureLogSplit)).BeginInit();
			this.pictureLogSplit.Panel2.SuspendLayout();
			this.pictureLogSplit.SuspendLayout();
			this.SuspendLayout();
			// 
			// listViewImages
			// 
			this.listViewImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("listViewImages.ImageStream")));
			this.listViewImages.TransparentColor = System.Drawing.Color.Transparent;
			this.listViewImages.Images.SetKeyName(0, "unknown");
			this.listViewImages.Images.SetKeyName(1, "ok");
			this.listViewImages.Images.SetKeyName(2, "fail");
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.testCasesList);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.pictureLogSplit);
			this.splitContainer.Size = new System.Drawing.Size(939, 533);
			this.splitContainer.SplitterDistance = 311;
			this.splitContainer.TabIndex = 2;
			// 
			// testCasesList
			// 
			this.testCasesList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.testCasesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.testCasesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.testCasesList.HideSelection = false;
			this.testCasesList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
			this.testCasesList.LargeImageList = this.listViewImages;
			this.testCasesList.Location = new System.Drawing.Point(0, 0);
			this.testCasesList.Margin = new System.Windows.Forms.Padding(0);
			this.testCasesList.MultiSelect = false;
			this.testCasesList.Name = "testCasesList";
			this.testCasesList.Size = new System.Drawing.Size(311, 533);
			this.testCasesList.SmallImageList = this.listViewImages;
			this.testCasesList.TabIndex = 1;
			this.testCasesList.UseCompatibleStateImageBehavior = false;
			this.testCasesList.View = System.Windows.Forms.View.List;
			this.testCasesList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.testCasesList_ItemSelectionChanged);
			this.testCasesList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.testCasesList_MouseClick);
			// 
			// pictureLogSplit
			// 
			this.pictureLogSplit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureLogSplit.Location = new System.Drawing.Point(0, 0);
			this.pictureLogSplit.Name = "pictureLogSplit";
			this.pictureLogSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// pictureLogSplit.Panel2
			// 
			this.pictureLogSplit.Panel2.Controls.Add(this.logTextBox);
			this.pictureLogSplit.Size = new System.Drawing.Size(624, 533);
			this.pictureLogSplit.SplitterDistance = 374;
			this.pictureLogSplit.TabIndex = 1;
			// 
			// logTextBox
			// 
			this.logTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.logTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.logTextBox.Location = new System.Drawing.Point(0, 0);
			this.logTextBox.Multiline = true;
			this.logTextBox.Name = "logTextBox";
			this.logTextBox.ReadOnly = true;
			this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.logTextBox.Size = new System.Drawing.Size(624, 155);
			this.logTextBox.TabIndex = 0;
			this.logTextBox.WordWrap = false;
			// 
			// TestRoom
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(939, 533);
			this.Controls.Add(this.splitContainer);
			this.DoubleBuffered = true;
			this.Name = "TestRoom";
			this.Text = "Test room";
			this.Load += new System.EventHandler(this.TestRoom_Load);
			this.Shown += new System.EventHandler(this.TestRoom_Shown);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.pictureLogSplit.Panel2.ResumeLayout(false);
			this.pictureLogSplit.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureLogSplit)).EndInit();
			this.pictureLogSplit.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ImageList listViewImages;
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.ListView testCasesList;
		private System.Windows.Forms.SplitContainer pictureLogSplit;
		private System.Windows.Forms.TextBox logTextBox;
	}
}

