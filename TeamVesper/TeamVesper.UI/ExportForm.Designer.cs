namespace TeamVesper.UI
{
    partial class ExportForm
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
            this.ReportJSON = new System.Windows.Forms.Button();
            this.ReportPDF = new System.Windows.Forms.Button();
            this.ReportXML = new System.Windows.Forms.Button();
            this.ReportExcel = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReportJSON
            // 
            this.ReportJSON.BackColor = System.Drawing.Color.Black;
            this.ReportJSON.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReportJSON.ForeColor = System.Drawing.Color.Aqua;
            this.ReportJSON.Location = new System.Drawing.Point(29, 170);
            this.ReportJSON.Name = "ReportJSON";
            this.ReportJSON.Size = new System.Drawing.Size(161, 100);
            this.ReportJSON.TabIndex = 2;
            this.ReportJSON.Text = "Report to JSON files";
            this.ReportJSON.UseVisualStyleBackColor = false;
            this.ReportJSON.Click += new System.EventHandler(this.ReportJSON_Click);
            // 
            // ReportPDF
            // 
            this.ReportPDF.BackColor = System.Drawing.Color.Black;
            this.ReportPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReportPDF.ForeColor = System.Drawing.Color.Aqua;
            this.ReportPDF.Location = new System.Drawing.Point(213, 170);
            this.ReportPDF.Name = "ReportPDF";
            this.ReportPDF.Size = new System.Drawing.Size(161, 100);
            this.ReportPDF.TabIndex = 3;
            this.ReportPDF.Text = "Report to PDF file";
            this.ReportPDF.UseVisualStyleBackColor = false;
            this.ReportPDF.Click += new System.EventHandler(this.ReportPDF_Click);
            // 
            // ReportXML
            // 
            this.ReportXML.BackColor = System.Drawing.Color.Black;
            this.ReportXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReportXML.ForeColor = System.Drawing.Color.Aqua;
            this.ReportXML.Location = new System.Drawing.Point(397, 170);
            this.ReportXML.Name = "ReportXML";
            this.ReportXML.Size = new System.Drawing.Size(161, 100);
            this.ReportXML.TabIndex = 4;
            this.ReportXML.Text = "Report to XML file";
            this.ReportXML.UseVisualStyleBackColor = false;
            this.ReportXML.Click += new System.EventHandler(this.ReportXML_Click);
            // 
            // ReportExcel
            // 
            this.ReportExcel.BackColor = System.Drawing.Color.Black;
            this.ReportExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReportExcel.ForeColor = System.Drawing.Color.Aqua;
            this.ReportExcel.Location = new System.Drawing.Point(581, 170);
            this.ReportExcel.Name = "ReportExcel";
            this.ReportExcel.Size = new System.Drawing.Size(161, 100);
            this.ReportExcel.TabIndex = 5;
            this.ReportExcel.Text = "Report to Excel file";
            this.ReportExcel.UseVisualStyleBackColor = false;
            this.ReportExcel.Click += new System.EventHandler(this.ReportExcel_Click);
            // 
            // Back
            // 
            this.Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Back.Location = new System.Drawing.Point(310, 350);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(150, 60);
            this.Back.TabIndex = 7;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TeamVesper.UI.Properties.Resources._1;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.ReportExcel);
            this.Controls.Add(this.ReportXML);
            this.Controls.Add(this.ReportPDF);
            this.Controls.Add(this.ReportJSON);
            this.Name = "ExportForm";
            this.Text = "Export";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ReportJSON;
        private System.Windows.Forms.Button ReportPDF;
        private System.Windows.Forms.Button ReportXML;
        private System.Windows.Forms.Button ReportExcel;
        private System.Windows.Forms.Button Back;
    }
}