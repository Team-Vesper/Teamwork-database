namespace TeamVesper.UI
{
    partial class TransferForm
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
            this.SqlServerToMySQL = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SqlServerToMySQL
            // 
            this.SqlServerToMySQL.BackColor = System.Drawing.Color.Black;
            this.SqlServerToMySQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SqlServerToMySQL.ForeColor = System.Drawing.Color.Aqua;
            this.SqlServerToMySQL.Location = new System.Drawing.Point(312, 170);
            this.SqlServerToMySQL.Name = "SqlServerToMySQL";
            this.SqlServerToMySQL.Size = new System.Drawing.Size(146, 100);
            this.SqlServerToMySQL.TabIndex = 1;
            this.SqlServerToMySQL.Text = "Sql Server To MySQL";
            this.SqlServerToMySQL.UseVisualStyleBackColor = false;
            this.SqlServerToMySQL.Click += new System.EventHandler(this.SqlServerToMySQL_Click);
            // 
            // Back
            // 
            this.Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Back.Location = new System.Drawing.Point(310, 350);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(150, 60);
            this.Back.TabIndex = 5;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // TransferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TeamVesper.UI.Properties.Resources._1;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.SqlServerToMySQL);
            this.Name = "TransferForm";
            this.Text = "Transfer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SqlServerToMySQL;
        private System.Windows.Forms.Button Back;
    }
}