namespace Product_Form
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnProductForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProductForm
            // 
            this.btnProductForm.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnProductForm.Font = new System.Drawing.Font("Stencil", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductForm.Location = new System.Drawing.Point(558, 483);
            this.btnProductForm.Margin = new System.Windows.Forms.Padding(4);
            this.btnProductForm.Name = "btnProductForm";
            this.btnProductForm.Size = new System.Drawing.Size(316, 113);
            this.btnProductForm.TabIndex = 0;
            this.btnProductForm.Text = "Product Form";
            this.btnProductForm.UseVisualStyleBackColor = false;
            this.btnProductForm.Click += new System.EventHandler(this.btnProductForm_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1425, 682);
            this.Controls.Add(this.btnProductForm);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProductForm;
    }
}

