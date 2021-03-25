
namespace ExternalTool
{
    partial class opener
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
            this.pathBox = new System.Windows.Forms.TextBox();
            this.rememberPathCheck = new System.Windows.Forms.CheckBox();
            this.acceptButton = new System.Windows.Forms.Button();
            this.folderPickerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pathBox
            // 
            this.pathBox.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathBox.Location = new System.Drawing.Point(12, 25);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(480, 30);
            this.pathBox.TabIndex = 0;
            this.pathBox.Text = "D:\\Repos\\Bank-Shot-Group-Game\\BankShot\\Content";
            // 
            // rememberPathCheck
            // 
            this.rememberPathCheck.AutoSize = true;
            this.rememberPathCheck.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rememberPathCheck.Location = new System.Drawing.Point(12, 61);
            this.rememberPathCheck.Name = "rememberPathCheck";
            this.rememberPathCheck.Size = new System.Drawing.Size(173, 27);
            this.rememberPathCheck.TabIndex = 2;
            this.rememberPathCheck.Text = "Remember this path";
            this.rememberPathCheck.UseVisualStyleBackColor = true;
            // 
            // acceptButton
            // 
            this.acceptButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptButton.Location = new System.Drawing.Point(269, 61);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(80, 36);
            this.acceptButton.TabIndex = 3;
            this.acceptButton.Text = "Open";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // folderPickerButton
            // 
            this.folderPickerButton.Image = global::ExternalTool.Properties.Resources.folder_icon_small_40;
            this.folderPickerButton.Location = new System.Drawing.Point(452, 61);
            this.folderPickerButton.Name = "folderPickerButton";
            this.folderPickerButton.Size = new System.Drawing.Size(40, 40);
            this.folderPickerButton.TabIndex = 1;
            this.folderPickerButton.UseVisualStyleBackColor = true;
            this.folderPickerButton.Click += new System.EventHandler(this.folderPickerButton_Click);
            // 
            // opener
            // 
            this.AcceptButton = this.acceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 113);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.rememberPathCheck);
            this.Controls.Add(this.folderPickerButton);
            this.Controls.Add(this.pathBox);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "opener";
            this.Text = "Game File Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Button folderPickerButton;
        private System.Windows.Forms.CheckBox rememberPathCheck;
        private System.Windows.Forms.Button acceptButton;
    }
}

