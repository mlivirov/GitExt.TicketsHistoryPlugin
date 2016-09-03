namespace TicketsHistoryPlugin
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._firstCommitPicker = new GitUI.UserControls.CommitPickerSmallControl();
            this._lastCommitPicker = new GitUI.UserControls.CommitPickerSmallControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this._analyzeButton = new System.Windows.Forms.Button();
            this._searchPattern = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.revisionLinksSettingsPage1 = new GitUI.CommandsDialogs.SettingsDialog.Pages.RevisionLinksSettingsPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._outputFormat = new System.Windows.Forms.TextBox();
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // _firstCommitPicker
            // 
            this._firstCommitPicker.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._firstCommitPicker.Location = new System.Drawing.Point(110, 20);
            this._firstCommitPicker.MinimumSize = new System.Drawing.Size(100, 26);
            this._firstCommitPicker.Name = "_firstCommitPicker";
            this._firstCommitPicker.Size = new System.Drawing.Size(346, 26);
            this._firstCommitPicker.TabIndex = 0;
            // 
            // _lastCommitPicker
            // 
            this._lastCommitPicker.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._lastCommitPicker.Location = new System.Drawing.Point(110, 52);
            this._lastCommitPicker.MinimumSize = new System.Drawing.Size(100, 26);
            this._lastCommitPicker.Name = "_lastCommitPicker";
            this._lastCommitPicker.Size = new System.Drawing.Size(346, 26);
            this._lastCommitPicker.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "First commit:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Last commit:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(374, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnCancelButtonClicked);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(12, 160);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 4);
            this.panel1.TabIndex = 5;
            // 
            // _analyzeButton
            // 
            this._analyzeButton.Location = new System.Drawing.Point(293, 170);
            this._analyzeButton.Name = "_analyzeButton";
            this._analyzeButton.Size = new System.Drawing.Size(75, 23);
            this._analyzeButton.TabIndex = 4;
            this._analyzeButton.Text = "Analyze";
            this._analyzeButton.UseVisualStyleBackColor = true;
            this._analyzeButton.Click += new System.EventHandler(this.OnAnalyzeButtonClicked);
            // 
            // _searchPattern
            // 
            this._searchPattern.Location = new System.Drawing.Point(110, 84);
            this._searchPattern.Name = "_searchPattern";
            this._searchPattern.Size = new System.Drawing.Size(236, 20);
            this._searchPattern.TabIndex = 6;
            this._searchPattern.TextChanged += new System.EventHandler(this.OnSearchPatternChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Search Pattern:";
            // 
            // revisionLinksSettingsPage1
            // 
            this.revisionLinksSettingsPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.revisionLinksSettingsPage1.Location = new System.Drawing.Point(0, 0);
            this.revisionLinksSettingsPage1.Name = "revisionLinksSettingsPage1";
            this.revisionLinksSettingsPage1.Size = new System.Drawing.Size(930, 492);
            this.revisionLinksSettingsPage1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(107, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "- data will be converted to the lowercase";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Output format:";
            // 
            // _outputFormat
            // 
            this._outputFormat.Location = new System.Drawing.Point(110, 123);
            this._outputFormat.Name = "_outputFormat";
            this._outputFormat.Size = new System.Drawing.Size(236, 20);
            this._outputFormat.TabIndex = 9;
            this._outputFormat.TextChanged += new System.EventHandler(this.OnOutputFormatChanged);
            // 
            // _progressBar
            // 
            this._progressBar.Location = new System.Drawing.Point(15, 171);
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(272, 23);
            this._progressBar.TabIndex = 11;
            this._progressBar.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 201);
            this.Controls.Add(this._progressBar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._outputFormat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._searchPattern);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._analyzeButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._lastCommitPicker);
            this.Controls.Add(this._firstCommitPicker);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tickets History";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GitUI.UserControls.CommitPickerSmallControl _firstCommitPicker;
        private GitUI.UserControls.CommitPickerSmallControl _lastCommitPicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _analyzeButton;
        private System.Windows.Forms.TextBox _searchPattern;
        private System.Windows.Forms.Label label3;
        private GitUI.CommandsDialogs.SettingsDialog.Pages.RevisionLinksSettingsPage revisionLinksSettingsPage1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _outputFormat;
        private System.Windows.Forms.ProgressBar _progressBar;
    }
}