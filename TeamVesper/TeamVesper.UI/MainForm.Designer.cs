namespace TeamVesper.UI
{
    partial class MainForm
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
            this.CreateDB = new System.Windows.Forms.Button();
            this.Import = new System.Windows.Forms.Button();
            this.Transfer = new System.Windows.Forms.Button();
            this.Export = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateDB
            // 
            this.CreateDB.BackColor = System.Drawing.Color.Black;
            this.CreateDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateDB.ForeColor = System.Drawing.Color.Aqua;
            this.CreateDB.Location = new System.Drawing.Point(39, 170);
            this.CreateDB.Name = "CreateDB";
            this.CreateDB.Size = new System.Drawing.Size(146, 100);
            this.CreateDB.TabIndex = 0;
            this.CreateDB.Text = "CreateDB";
            this.CreateDB.UseVisualStyleBackColor = false;
            this.CreateDB.Click += new System.EventHandler(this.CreateDB_Click);
            // 
            // Import
            // 
            this.Import.BackColor = System.Drawing.Color.Black;
            this.Import.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Import.ForeColor = System.Drawing.Color.Aqua;
            this.Import.Location = new System.Drawing.Point(215, 170);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(146, 100);
            this.Import.TabIndex = 1;
            this.Import.Text = "Import";
            this.Import.UseVisualStyleBackColor = false;
            this.Import.Click += new System.EventHandler(this.Import_Click);
            // 
            // Transfer
            // 
            this.Transfer.BackColor = System.Drawing.Color.Black;
            this.Transfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Transfer.ForeColor = System.Drawing.Color.Aqua;
            this.Transfer.Location = new System.Drawing.Point(567, 170);
            this.Transfer.Name = "Transfer";
            this.Transfer.Size = new System.Drawing.Size(146, 100);
            this.Transfer.TabIndex = 2;
            this.Transfer.Text = "Transfer";
            this.Transfer.UseVisualStyleBackColor = false;
            this.Transfer.Click += new System.EventHandler(this.Transfer_Click);
            // 
            // Export
            // 
            this.Export.BackColor = System.Drawing.Color.Black;
            this.Export.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Export.ForeColor = System.Drawing.Color.Aqua;
            this.Export.Location = new System.Drawing.Point(391, 170);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(146, 100);
            this.Export.TabIndex = 3;
            this.Export.Text = "Export";
            this.Export.UseVisualStyleBackColor = false;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // Exit
            // 
            this.Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Exit.Location = new System.Drawing.Point(310, 350);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(150, 60);
            this.Exit.TabIndex = 4;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TeamVesper.UI.Properties.Resources._1;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Export);
            this.Controls.Add(this.Transfer);
            this.Controls.Add(this.Import);
            this.Controls.Add(this.CreateDB);
            this.Name = "MainForm";
            this.Text = "TeamVesper";
            this.Load += new System.EventHandler(this.TeamVesper_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateDB;
        private System.Windows.Forms.Button Import;
        private System.Windows.Forms.Button Transfer;
        private System.Windows.Forms.Button Export;
        private System.Windows.Forms.Button Exit;
    }
}

