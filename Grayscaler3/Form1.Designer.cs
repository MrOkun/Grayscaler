
namespace Grayscaler3
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
            this.Original_Image = new System.Windows.Forms.PictureBox();
            this.Modified_Image = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Image_Selector = new System.Windows.Forms.ComboBox();
            this.Method_Selector = new System.Windows.Forms.ComboBox();
            this.Load_Image = new System.Windows.Forms.Button();
            this.Save_Button = new System.Windows.Forms.Button();
            this.Iteration_box = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Original_Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Modified_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // Original_Image
            // 
            this.Original_Image.Location = new System.Drawing.Point(12, 34);
            this.Original_Image.Name = "Original_Image";
            this.Original_Image.Size = new System.Drawing.Size(165, 165);
            this.Original_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Original_Image.TabIndex = 1;
            this.Original_Image.TabStop = false;
            // 
            // Modified_Image
            // 
            this.Modified_Image.Location = new System.Drawing.Point(187, 34);
            this.Modified_Image.Name = "Modified_Image";
            this.Modified_Image.Size = new System.Drawing.Size(165, 165);
            this.Modified_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Modified_Image.TabIndex = 2;
            this.Modified_Image.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Original :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(184, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Modified :";
            // 
            // Image_Selector
            // 
            this.Image_Selector.FormattingEnabled = true;
            this.Image_Selector.Location = new System.Drawing.Point(12, 205);
            this.Image_Selector.Name = "Image_Selector";
            this.Image_Selector.Size = new System.Drawing.Size(165, 21);
            this.Image_Selector.TabIndex = 5;
            this.Image_Selector.SelectedIndexChanged += new System.EventHandler(this.Image_Selector_Changed);
            // 
            // Method_Selector
            // 
            this.Method_Selector.FormattingEnabled = true;
            this.Method_Selector.Items.AddRange(new object[] {
            "All Channels (Original)",
            "By Red channel (Rude)",
            "By Green channel (Rude)",
            "By Blue channel (Rude)",
            "Average (All channels average )",
            "Luminance (Photoshop)",
            "Desaturation (Min&Max Channels averge)",
            "Pasteurization (Colored)",
            "Pasteurization (B&W)"});
            this.Method_Selector.Location = new System.Drawing.Point(187, 205);
            this.Method_Selector.Name = "Method_Selector";
            this.Method_Selector.Size = new System.Drawing.Size(165, 21);
            this.Method_Selector.TabIndex = 6;
            this.Method_Selector.SelectedIndexChanged += new System.EventHandler(this.Method_Selector_Changed);
            // 
            // Load_Image
            // 
            this.Load_Image.Location = new System.Drawing.Point(12, 232);
            this.Load_Image.Name = "Load_Image";
            this.Load_Image.Size = new System.Drawing.Size(165, 32);
            this.Load_Image.TabIndex = 7;
            this.Load_Image.Text = "Load Image";
            this.Load_Image.UseVisualStyleBackColor = true;
            this.Load_Image.Click += new System.EventHandler(this.Load_Image_Click);
            // 
            // Save_Button
            // 
            this.Save_Button.Location = new System.Drawing.Point(12, 270);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(165, 32);
            this.Save_Button.TabIndex = 8;
            this.Save_Button.Text = "Save Image";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // Iteration_box
            // 
            this.Iteration_box.FormattingEnabled = true;
            this.Iteration_box.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.Iteration_box.Location = new System.Drawing.Point(295, 281);
            this.Iteration_box.Name = "Iteration_box";
            this.Iteration_box.Size = new System.Drawing.Size(57, 21);
            this.Iteration_box.TabIndex = 9;
            this.Iteration_box.SelectedIndexChanged += new System.EventHandler(this.Iteration_box_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(364, 311);
            this.Controls.Add(this.Iteration_box);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.Load_Image);
            this.Controls.Add(this.Method_Selector);
            this.Controls.Add(this.Image_Selector);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Modified_Image);
            this.Controls.Add(this.Original_Image);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Grayscaler";
            this.SizeChanged += new System.EventHandler(this.Form_Sized);
            ((System.ComponentModel.ISupportInitialize)(this.Original_Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Modified_Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Original_Image;
        private System.Windows.Forms.PictureBox Modified_Image;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Image_Selector;
        private System.Windows.Forms.ComboBox Method_Selector;
        private System.Windows.Forms.Button Load_Image;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.ComboBox Iteration_box;
    }
}

