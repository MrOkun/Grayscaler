
namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.preImage = new System.Windows.Forms.PictureBox();
            this.postImage = new System.Windows.Forms.PictureBox();
            this.AllButton = new System.Windows.Forms.Button();
            this.selectBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LoadBox = new System.Windows.Forms.ComboBox();
            this.Load = new System.Windows.Forms.Button();
            this.ImageName = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.preImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.postImage)).BeginInit();
            this.SuspendLayout();
            // 
            // preImage
            // 
            this.preImage.Image = global::WindowsFormsApp2.Properties.Resources.img;
            this.preImage.Location = new System.Drawing.Point(15, 25);
            this.preImage.Name = "preImage";
            this.preImage.Size = new System.Drawing.Size(150, 150);
            this.preImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.preImage.TabIndex = 0;
            this.preImage.TabStop = false;
            // 
            // postImage
            // 
            this.postImage.Image = global::WindowsFormsApp2.Properties.Resources.img;
            this.postImage.Location = new System.Drawing.Point(171, 25);
            this.postImage.Name = "postImage";
            this.postImage.Size = new System.Drawing.Size(150, 150);
            this.postImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.postImage.TabIndex = 0;
            this.postImage.TabStop = false;
            // 
            // AllButton
            // 
            this.AllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AllButton.Location = new System.Drawing.Point(12, 194);
            this.AllButton.Name = "AllButton";
            this.AllButton.Size = new System.Drawing.Size(150, 22);
            this.AllButton.TabIndex = 1;
            this.AllButton.Text = "All";
            this.AllButton.UseVisualStyleBackColor = true;
            this.AllButton.Click += new System.EventHandler(this.AllButton_Click);
            // 
            // selectBox
            // 
            this.selectBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.selectBox.FormattingEnabled = true;
            this.selectBox.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue",
            "Average",
            "Average (Human eye correcting)",
            "Desaturation"});
            this.selectBox.Location = new System.Drawing.Point(168, 195);
            this.selectBox.Name = "selectBox";
            this.selectBox.Size = new System.Drawing.Size(150, 21);
            this.selectBox.TabIndex = 2;
            this.selectBox.SelectedIndexChanged += new System.EventHandler(this.selectBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Original Image :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(165, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Modified Image :";
            // 
            // LoadBox
            // 
            this.LoadBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.LoadBox.FormattingEnabled = true;
            this.LoadBox.Location = new System.Drawing.Point(168, 222);
            this.LoadBox.Name = "LoadBox";
            this.LoadBox.Size = new System.Drawing.Size(150, 21);
            this.LoadBox.TabIndex = 4;
            this.LoadBox.SelectedIndexChanged += new System.EventHandler(this.LoadBox_Change);
            // 
            // Load
            // 
            this.Load.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Load.Location = new System.Drawing.Point(12, 220);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(150, 23);
            this.Load.TabIndex = 5;
            this.Load.Text = "Load Image";
            this.Load.UseVisualStyleBackColor = true;
            this.Load.Click += new System.EventHandler(this.Load_Click);
            // 
            // ImageName
            // 
            this.ImageName.AutoSize = true;
            this.ImageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ImageName.Location = new System.Drawing.Point(12, 178);
            this.ImageName.Name = "ImageName";
            this.ImageName.Size = new System.Drawing.Size(89, 13);
            this.ImageName.TabIndex = 6;
            this.ImageName.Text = "Image Name : ";
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveButton.Location = new System.Drawing.Point(12, 249);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(150, 21);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.Text = "Save Mod Image";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(238)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(338, 291);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ImageName);
            this.Controls.Add(this.Load);
            this.Controls.Add(this.LoadBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectBox);
            this.Controls.Add(this.AllButton);
            this.Controls.Add(this.postImage);
            this.Controls.Add(this.preImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Grayscaler";
            ((System.ComponentModel.ISupportInitialize)(this.preImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.postImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox preImage;
        private System.Windows.Forms.PictureBox postImage;
        private System.Windows.Forms.Button AllButton;
        private System.Windows.Forms.ComboBox selectBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox LoadBox;
        private System.Windows.Forms.Button Load;
        private System.Windows.Forms.Label ImageName;
        private System.Windows.Forms.Button SaveButton;
    }
}

