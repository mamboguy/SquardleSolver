namespace SquardleSolver;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        comboBox_SquardleType = new ComboBox();
        label1 = new Label();
        squardleGridPanel = new Panel();
        label2 = new Label();
        squardleGridPanel.SuspendLayout();
        SuspendLayout();
        // 
        // comboBox_SquardleType
        // 
        comboBox_SquardleType.FormattingEnabled = true;
        comboBox_SquardleType.Location = new Point(12, 30);
        comboBox_SquardleType.Name = "comboBox_SquardleType";
        comboBox_SquardleType.Size = new Size(121, 23);
        comboBox_SquardleType.TabIndex = 0;
        comboBox_SquardleType.SelectedIndexChanged += comboBox_SquardleType_SelectedIndexChanged;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 9);
        label1.Name = "label1";
        label1.Size = new Size(31, 15);
        label1.TabIndex = 1;
        label1.Text = "Type";
        // 
        // squardleGridPanel
        // 
        squardleGridPanel.Controls.Add(label2);
        squardleGridPanel.Location = new Point(12, 68);
        squardleGridPanel.Name = "squardleGridPanel";
        squardleGridPanel.Size = new Size(420, 420);
        squardleGridPanel.TabIndex = 2;
        // 
        // label2
        // 
        label2.Anchor = AnchorStyles.None;
        label2.AutoSize = true;
        label2.Location = new Point(51, 104);
        label2.Name = "label2";
        label2.Size = new Size(38, 15);
        label2.TabIndex = 0;
        label2.Text = "label2";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 502);
        Controls.Add(squardleGridPanel);
        Controls.Add(label1);
        Controls.Add(comboBox_SquardleType);
        Name = "Form1";
        Text = "Form1";
        Load += Form1_Load;
        squardleGridPanel.ResumeLayout(false);
        squardleGridPanel.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ComboBox comboBox_SquardleType;
    private Label label1;
    private Panel squardleGridPanel;
    private Label label2;
}