namespace SearchBar
{
    partial class PopupFileSearchForm
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
            this.ListViewFileSearch = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // ListViewFileSearch
            // 
            this.ListViewFileSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewFileSearch.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ListViewFileSearch.Location = new System.Drawing.Point(9, 6);
            this.ListViewFileSearch.Name = "ListViewFileSearch";
            this.ListViewFileSearch.Size = new System.Drawing.Size(330, 440);
            this.ListViewFileSearch.TabIndex = 0;
            this.ListViewFileSearch.UseCompatibleStateImageBehavior = false;
            this.ListViewFileSearch.View = System.Windows.Forms.View.List;
            // 
            // PopupFileSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 450);
            this.Controls.Add(this.ListViewFileSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PopupFileSearchForm";
            this.Text = "Form2";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ListViewFileSearch;
    }
}