namespace Prog2
{
    partial class LetterForm
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
            this.components = new System.ComponentModel.Container();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.fixedCostTxt = new System.Windows.Forms.TextBox();
            this.destAddCbo = new System.Windows.Forms.ComboBox();
            this.originAddCbo = new System.Windows.Forms.ComboBox();
            this.costLbl = new System.Windows.Forms.Label();
            this.destLbl = new System.Windows.Forms.Label();
            this.originLbl = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(191, 124);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 15;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            this.cancelBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cancelBtn_MouseDown);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(74, 124);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 14;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // fixedCostTxt
            // 
            this.fixedCostTxt.Location = new System.Drawing.Point(145, 90);
            this.fixedCostTxt.Name = "fixedCostTxt";
            this.fixedCostTxt.Size = new System.Drawing.Size(121, 20);
            this.fixedCostTxt.TabIndex = 13;
            this.fixedCostTxt.Validating += new System.ComponentModel.CancelEventHandler(this.fixedCostTxt_Validating);
            this.fixedCostTxt.Validated += new System.EventHandler(this.AllFields_Validated);
            // 
            // destAddCbo
            // 
            this.destAddCbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destAddCbo.FormattingEnabled = true;
            this.destAddCbo.Location = new System.Drawing.Point(145, 63);
            this.destAddCbo.Name = "destAddCbo";
            this.destAddCbo.Size = new System.Drawing.Size(121, 21);
            this.destAddCbo.TabIndex = 12;
            this.destAddCbo.Validating += new System.ComponentModel.CancelEventHandler(this.addressCbo_Validating);
            this.destAddCbo.Validated += new System.EventHandler(this.AllFields_Validated);
            // 
            // originAddCbo
            // 
            this.originAddCbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.originAddCbo.FormattingEnabled = true;
            this.originAddCbo.Location = new System.Drawing.Point(145, 27);
            this.originAddCbo.Name = "originAddCbo";
            this.originAddCbo.Size = new System.Drawing.Size(121, 21);
            this.originAddCbo.TabIndex = 11;
            this.originAddCbo.Validating += new System.ComponentModel.CancelEventHandler(this.addressCbo_Validating);
            this.originAddCbo.Validated += new System.EventHandler(this.AllFields_Validated);
            // 
            // costLbl
            // 
            this.costLbl.AutoSize = true;
            this.costLbl.Location = new System.Drawing.Point(80, 93);
            this.costLbl.Name = "costLbl";
            this.costLbl.Size = new System.Drawing.Size(59, 13);
            this.costLbl.TabIndex = 10;
            this.costLbl.Text = "Fixed Cost:";
            // 
            // destLbl
            // 
            this.destLbl.AutoSize = true;
            this.destLbl.Location = new System.Drawing.Point(35, 66);
            this.destLbl.Name = "destLbl";
            this.destLbl.Size = new System.Drawing.Size(104, 13);
            this.destLbl.TabIndex = 9;
            this.destLbl.Text = "Destination Address:";
            // 
            // originLbl
            // 
            this.originLbl.AutoSize = true;
            this.originLbl.Location = new System.Drawing.Point(61, 30);
            this.originLbl.Name = "originLbl";
            this.originLbl.Size = new System.Drawing.Size(78, 13);
            this.originLbl.TabIndex = 8;
            this.originLbl.Text = "Origin Address:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // LetterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 183);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.fixedCostTxt);
            this.Controls.Add(this.destAddCbo);
            this.Controls.Add(this.originAddCbo);
            this.Controls.Add(this.costLbl);
            this.Controls.Add(this.destLbl);
            this.Controls.Add(this.originLbl);
            this.Name = "LetterForm";
            this.Text = "Letter";
            this.Load += new System.EventHandler(this.LetterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.TextBox fixedCostTxt;
        private System.Windows.Forms.ComboBox destAddCbo;
        private System.Windows.Forms.ComboBox originAddCbo;
        private System.Windows.Forms.Label costLbl;
        private System.Windows.Forms.Label destLbl;
        private System.Windows.Forms.Label originLbl;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}