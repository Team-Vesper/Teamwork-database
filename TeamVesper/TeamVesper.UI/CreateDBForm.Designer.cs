namespace TeamVesper.UI
{
    partial class CreateDBForm
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
            this.CreateMongoDbButton = new System.Windows.Forms.Button();
            this.CreateSQLServerButton = new System.Windows.Forms.Button();
            this.CreateSQLiteButton = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.CreateMySQL = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateMongoDbButton
            // 
            this.CreateMongoDbButton.BackColor = System.Drawing.Color.Black;
            this.CreateMongoDbButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateMongoDbButton.ForeColor = System.Drawing.Color.Aqua;
            this.CreateMongoDbButton.Location = new System.Drawing.Point(27, 170);
            this.CreateMongoDbButton.Name = "CreateMongoDbButton";
            this.CreateMongoDbButton.Size = new System.Drawing.Size(161, 100);
            this.CreateMongoDbButton.TabIndex = 1;
            this.CreateMongoDbButton.Text = "Create MongoDb";
            this.CreateMongoDbButton.UseVisualStyleBackColor = false;
            this.CreateMongoDbButton.Click += new System.EventHandler(this.CreateMongoDB_Click);
            // 
            // CreateSQLServerButton
            // 
            this.CreateSQLServerButton.BackColor = System.Drawing.Color.Black;
            this.CreateSQLServerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateSQLServerButton.ForeColor = System.Drawing.Color.Aqua;
            this.CreateSQLServerButton.Location = new System.Drawing.Point(221, 170);
            this.CreateSQLServerButton.Name = "CreateSQLServerButton";
            this.CreateSQLServerButton.Size = new System.Drawing.Size(161, 100);
            this.CreateSQLServerButton.TabIndex = 2;
            this.CreateSQLServerButton.Text = "Create SQL Server";
            this.CreateSQLServerButton.UseVisualStyleBackColor = false;
            this.CreateSQLServerButton.Click += new System.EventHandler(this.CreateSqlServer_Click);
            // 
            // CreateSQLiteButton
            // 
            this.CreateSQLiteButton.BackColor = System.Drawing.Color.Black;
            this.CreateSQLiteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateSQLiteButton.ForeColor = System.Drawing.Color.Aqua;
            this.CreateSQLiteButton.Location = new System.Drawing.Point(415, 170);
            this.CreateSQLiteButton.Name = "CreateSQLiteButton";
            this.CreateSQLiteButton.Size = new System.Drawing.Size(161, 100);
            this.CreateSQLiteButton.TabIndex = 3;
            this.CreateSQLiteButton.Text = "Create SQLite";
            this.CreateSQLiteButton.UseVisualStyleBackColor = false;
            this.CreateSQLiteButton.Click += new System.EventHandler(this.CreateSQLite_Click);
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.Black;
            this.Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Back.ForeColor = System.Drawing.Color.Red;
            this.Back.Location = new System.Drawing.Point(310, 350);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(150, 60);
            this.Back.TabIndex = 5;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // CreateMySQL
            // 
            this.CreateMySQL.BackColor = System.Drawing.Color.Black;
            this.CreateMySQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateMySQL.ForeColor = System.Drawing.Color.Aqua;
            this.CreateMySQL.Location = new System.Drawing.Point(609, 170);
            this.CreateMySQL.Name = "CreateMySQL";
            this.CreateMySQL.Size = new System.Drawing.Size(161, 100);
            this.CreateMySQL.TabIndex = 6;
            this.CreateMySQL.Text = "Create MySQL";
            this.CreateMySQL.UseVisualStyleBackColor = false;
            this.CreateMySQL.Click += new System.EventHandler(this.CreateMySQL_Click);
            // 
            // CreateDBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TeamVesper.UI.Properties.Resources._1;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.CreateMySQL);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.CreateSQLiteButton);
            this.Controls.Add(this.CreateSQLServerButton);
            this.Controls.Add(this.CreateMongoDbButton);
            this.Name = "CreateDBForm";
            this.Text = "CreateDB";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateMongoDbButton;
        private System.Windows.Forms.Button CreateSQLServerButton;
        private System.Windows.Forms.Button CreateSQLiteButton;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button CreateMySQL;
    }
}