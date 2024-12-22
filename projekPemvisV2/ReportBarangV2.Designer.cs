namespace projekPemvisV2
{
    partial class ReportBarangV2
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
            this.crystalReportViewer_Tampil = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewer_Tampil
            // 
            this.crystalReportViewer_Tampil.ActiveViewIndex = -1;
            this.crystalReportViewer_Tampil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer_Tampil.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer_Tampil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer_Tampil.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer_Tampil.Name = "crystalReportViewer_Tampil";
            this.crystalReportViewer_Tampil.Size = new System.Drawing.Size(800, 450);
            this.crystalReportViewer_Tampil.TabIndex = 0;
            this.crystalReportViewer_Tampil.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ReportBarangV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crystalReportViewer_Tampil);
            this.Name = "ReportBarangV2";
            this.Text = "ReportBarangV2";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer_Tampil;
    }
}