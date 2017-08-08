namespace ProblemCaseWinForms {
  partial class Form1 {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
      this.myView1 = new ProblemCase.MyView();
      this.button1 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // elementHost1
      // 
      this.elementHost1.Location = new System.Drawing.Point(12, 12);
      this.elementHost1.Name = "elementHost1";
      this.elementHost1.Size = new System.Drawing.Size(745, 438);
      this.elementHost1.TabIndex = 0;
      this.elementHost1.Text = "elementHost1";
      this.elementHost1.Child = this.myView1;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(21, 23);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 1;
      this.button1.Text = "Export";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(769, 462);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.elementHost1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Integration.ElementHost elementHost1;
    private ProblemCase.MyView myView1;
    private System.Windows.Forms.Button button1;
  }
}

