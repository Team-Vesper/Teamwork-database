namespace TeamVesper.UI
{
    partial class ImportForm
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
            this.ImportMongoDB = new System.Windows.Forms.Button();
            this.ImportXML = new System.Windows.Forms.Button();
            this.ImportExcel = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ImportMongoDB
            // 
            this.ImportMongoDB.BackColor = System.Drawing.Color.Black;
            this.ImportMongoDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ImportMongoDB.ForeColor = System.Drawing.Color.Aqua;
            this.ImportMongoDB.Location = new System.Drawing.Point(108, 170);
            this.ImportMongoDB.Name = "ImportMongoDB";
            this.ImportMongoDB.Size = new System.Drawing.Size(161, 100);
            this.ImportMongoDB.TabIndex = 2;
            this.ImportMongoDB.Text = "Import from MongoDB";
            this.ImportMongoDB.UseVisualStyleBackColor = false;
            this.ImportMongoDB.Click += new System.EventHandler(this.ImportMongoDB_Click);
            // 
            // ImportXML
            // 
            this.ImportXML.BackColor = System.Drawing.Color.Black;
            this.ImportXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ImportXML.ForeColor = System.Drawing.Color.Aqua;
            this.ImportXML.Location = new System.Drawing.Point(310, 170);
            this.ImportXML.Name = "ImportXML";
            this.ImportXML.Size = new System.Drawing.Size(161, 100);
            this.ImportXML.TabIndex = 3;
            this.ImportXML.Text = "Import from XML";
            this.ImportXML.UseVisualStyleBackColor = false;
            this.ImportXML.Click += new System.EventHandler(this.ImportXML_Click);
            // 
            // ImportExcel
            // 
            this.ImportExcel.BackColor = System.Drawing.Color.Black;
            this.ImportExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ImportExcel.ForeColor = System.Drawing.Color.Aqua;
            this.ImportExcel.Location = new System.Drawing.Point(504, 170);
            this.ImportExcel.Name = "ImportExcel";
            this.ImportExcel.Size = new System.Drawing.Size(161, 100);
            this.ImportExcel.TabIndex = 4;
            this.ImportExcel.Text = "Import from Excel Zip";
            this.ImportExcel.UseVisualStyleBackColor = false;
            this.ImportExcel.Click += new System.EventHandler(this.ImportExcel_Click);
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.Black;
            this.Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Back.ForeColor = System.Drawing.Color.Red;
            this.Back.Location = new System.Drawing.Point(310, 350);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(150, 60);
            this.Back.TabIndex = 6;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TeamVesper.UI.Properties.Resources._1;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.ImportExcel);
            this.Controls.Add(this.ImportXML);
            this.Controls.Add(this.ImportMongoDB);
            this.Name = "ImportForm";
            this.Text = "Import";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ImportMongoDB;
        private System.Windows.Forms.Button ImportXML;
        private System.Windows.Forms.Button ImportExcel;
        private System.Windows.Forms.Button Back;
    }
}