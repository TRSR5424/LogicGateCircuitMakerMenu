namespace LogicGateCircuitMakerMenu
{
    partial class Form2
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
            openLocal = new Button();
            createNewCircuit = new Button();
            datbaseOpenComboBox = new ComboBox();
            dateCreatedRadio = new RadioButton();
            alphabetizeDownRadio = new RadioButton();
            lastUpdatedUpRadio = new RadioButton();
            alphabetizeUpRadio = new RadioButton();
            lastUpdatedDownRadio = new RadioButton();
            SuspendLayout();
            // 
            // openLocal
            // 
            openLocal.Location = new Point(40, 47);
            openLocal.Name = "openLocal";
            openLocal.Size = new Size(275, 29);
            openLocal.TabIndex = 0;
            openLocal.Text = "Open Locally";
            openLocal.UseVisualStyleBackColor = true;
            openLocal.Click += openLocal_Click;
            // 
            // createNewCircuit
            // 
            createNewCircuit.Location = new Point(40, 12);
            createNewCircuit.Name = "createNewCircuit";
            createNewCircuit.Size = new Size(275, 29);
            createNewCircuit.TabIndex = 2;
            createNewCircuit.Text = "Create New Circuit";
            createNewCircuit.UseVisualStyleBackColor = true;
            createNewCircuit.Click += createNewCircuit_Click;
            // 
            // datbaseOpenComboBox
            // 
            datbaseOpenComboBox.FormattingEnabled = true;
            datbaseOpenComboBox.Location = new Point(40, 82);
            datbaseOpenComboBox.Name = "datbaseOpenComboBox";
            datbaseOpenComboBox.Size = new Size(275, 28);
            datbaseOpenComboBox.TabIndex = 3;
            datbaseOpenComboBox.Text = "Open From Database";
            datbaseOpenComboBox.SelectedIndexChanged += databaseOpenComboBox_SelectedIndexChanged;
            // 
            // dateCreatedRadio
            // 
            dateCreatedRadio.AutoSize = true;
            dateCreatedRadio.Checked = true;
            dateCreatedRadio.Location = new Point(11, 176);
            dateCreatedRadio.Name = "dateCreatedRadio";
            dateCreatedRadio.Size = new Size(181, 24);
            dateCreatedRadio.TabIndex = 5;
            dateCreatedRadio.TabStop = true;
            dateCreatedRadio.Text = "Date Created (Default)";
            dateCreatedRadio.UseVisualStyleBackColor = true;
            dateCreatedRadio.CheckedChanged += dateCreatedRadio_CheckedChanged;
            // 
            // alphabetizeDownRadio
            // 
            alphabetizeDownRadio.AutoSize = true;
            alphabetizeDownRadio.Location = new Point(199, 116);
            alphabetizeDownRadio.Name = "alphabetizeDownRadio";
            alphabetizeDownRadio.Size = new Size(153, 24);
            alphabetizeDownRadio.TabIndex = 6;
            alphabetizeDownRadio.Text = "Alphabetize Down";
            alphabetizeDownRadio.UseVisualStyleBackColor = true;
            alphabetizeDownRadio.CheckedChanged += alphabetizeDownRadio_CheckedChanged;
            // 
            // lastUpdatedUpRadio
            // 
            lastUpdatedUpRadio.AutoSize = true;
            lastUpdatedUpRadio.Location = new Point(12, 146);
            lastUpdatedUpRadio.Name = "lastUpdatedUpRadio";
            lastUpdatedUpRadio.Size = new Size(141, 24);
            lastUpdatedUpRadio.TabIndex = 7;
            lastUpdatedUpRadio.TabStop = true;
            lastUpdatedUpRadio.Text = "Last Updated Up";
            lastUpdatedUpRadio.UseVisualStyleBackColor = true;
            lastUpdatedUpRadio.CheckedChanged += lastUpdatedUpRadio_CheckedChanged;
            // 
            // alphabetizeUpRadio
            // 
            alphabetizeUpRadio.AutoSize = true;
            alphabetizeUpRadio.Location = new Point(199, 146);
            alphabetizeUpRadio.Name = "alphabetizeUpRadio";
            alphabetizeUpRadio.Size = new Size(133, 24);
            alphabetizeUpRadio.TabIndex = 8;
            alphabetizeUpRadio.Text = "Alphabetize Up";
            alphabetizeUpRadio.UseVisualStyleBackColor = true;
            alphabetizeUpRadio.CheckedChanged += alphabetizeUpRadio_CheckedChanged;
            // 
            // lastUpdatedDownRadio
            // 
            lastUpdatedDownRadio.AutoSize = true;
            lastUpdatedDownRadio.Location = new Point(11, 116);
            lastUpdatedDownRadio.Name = "lastUpdatedDownRadio";
            lastUpdatedDownRadio.Size = new Size(161, 24);
            lastUpdatedDownRadio.TabIndex = 9;
            lastUpdatedDownRadio.TabStop = true;
            lastUpdatedDownRadio.Text = "Last Updated Down";
            lastUpdatedDownRadio.UseVisualStyleBackColor = true;
            lastUpdatedDownRadio.CheckedChanged += lastUpdatedDownRadio_CheckedChanged;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(364, 208);
            Controls.Add(lastUpdatedDownRadio);
            Controls.Add(alphabetizeUpRadio);
            Controls.Add(lastUpdatedUpRadio);
            Controls.Add(alphabetizeDownRadio);
            Controls.Add(dateCreatedRadio);
            Controls.Add(datbaseOpenComboBox);
            Controls.Add(createNewCircuit);
            Controls.Add(openLocal);
            Name = "Form2";
            Text = "Logic Gate Circuit Maker";
            Shown += Form2_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button openLocal;
        private Button openFromDatabase;
        private Button createNewCircuit;
        private ComboBox datbaseOpenComboBox;
        private RadioButton dateCreatedRadio;
        private RadioButton alphabetizeDownRadio;
        private RadioButton lastUpdatedUpRadio;
        private RadioButton alphabetizeUpRadio;
        private RadioButton lastUpdatedDownRadio;
    }
}