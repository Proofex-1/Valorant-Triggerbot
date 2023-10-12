namespace ValorantAimbotUI
{
	// Token: 0x02000002 RID: 2
	public partial class Form1 : global::System.Windows.Forms.Form
	{
		// Token: 0x06000027 RID: 39 RVA: 0x00002CC7 File Offset: 0x00000EC7
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002CE8 File Offset: 0x00000EE8
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.TriggerbotBtt = new System.Windows.Forms.CheckBox();
            this.Speed = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.RedRadio = new System.Windows.Forms.RadioButton();
            this.PurpleRadio = new System.Windows.Forms.RadioButton();
            this.ChangeMonitorBtt = new System.Windows.Forms.Button();
            this.AimKeyToggle = new System.Windows.Forms.CheckBox();
            this.IsHoldToggle = new System.Windows.Forms.CheckBox();
            this.AimkeyBtt = new System.Windows.Forms.Button();
            this.StartBtt = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.offsetNum = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FireRateNum = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FireRateNum)).BeginInit();
            this.SuspendLayout();
            // 
            // TriggerbotBtt
            // 
            this.TriggerbotBtt.AutoSize = true;
            this.TriggerbotBtt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TriggerbotBtt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TriggerbotBtt.Location = new System.Drawing.Point(9, 2);
            this.TriggerbotBtt.Margin = new System.Windows.Forms.Padding(2);
            this.TriggerbotBtt.Name = "TriggerbotBtt";
            this.TriggerbotBtt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TriggerbotBtt.Size = new System.Drawing.Size(71, 17);
            this.TriggerbotBtt.TabIndex = 1;
            this.TriggerbotBtt.Text = "Triggerbot";
            this.TriggerbotBtt.UseVisualStyleBackColor = true;
            this.TriggerbotBtt.CheckedChanged += new System.EventHandler(this.IsTriggerbot_changed);
            // 
            // Speed
            // 
            this.Speed.DecimalPlaces = 2;
            this.Speed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Speed.Location = new System.Drawing.Point(10, 79);
            this.Speed.Margin = new System.Windows.Forms.Padding(2);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(90, 20);
            this.Speed.TabIndex = 3;
            this.Speed.ValueChanged += new System.EventHandler(this.Speed_changed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(104, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Speed";
            // 
            // RedRadio
            // 
            this.RedRadio.AutoSize = true;
            this.RedRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RedRadio.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RedRadio.Location = new System.Drawing.Point(153, 32);
            this.RedRadio.Margin = new System.Windows.Forms.Padding(2);
            this.RedRadio.Name = "RedRadio";
            this.RedRadio.Size = new System.Drawing.Size(44, 17);
            this.RedRadio.TabIndex = 9;
            this.RedRadio.TabStop = true;
            this.RedRadio.Text = "Red";
            this.RedRadio.UseVisualStyleBackColor = true;
            this.RedRadio.CheckedChanged += new System.EventHandler(this.Red_changed);
            // 
            // PurpleRadio
            // 
            this.PurpleRadio.AutoSize = true;
            this.PurpleRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PurpleRadio.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PurpleRadio.Location = new System.Drawing.Point(152, 56);
            this.PurpleRadio.Margin = new System.Windows.Forms.Padding(2);
            this.PurpleRadio.Name = "PurpleRadio";
            this.PurpleRadio.Size = new System.Drawing.Size(54, 17);
            this.PurpleRadio.TabIndex = 10;
            this.PurpleRadio.TabStop = true;
            this.PurpleRadio.Text = "Purple";
            this.PurpleRadio.UseVisualStyleBackColor = true;
            this.PurpleRadio.CheckedChanged += new System.EventHandler(this.Purple_changed);
            // 
            // ChangeMonitorBtt
            // 
            this.ChangeMonitorBtt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(107)))), ((int)(((byte)(255)))));
            this.ChangeMonitorBtt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeMonitorBtt.ForeColor = System.Drawing.SystemColors.Window;
            this.ChangeMonitorBtt.Location = new System.Drawing.Point(9, 145);
            this.ChangeMonitorBtt.Margin = new System.Windows.Forms.Padding(2);
            this.ChangeMonitorBtt.Name = "ChangeMonitorBtt";
            this.ChangeMonitorBtt.Size = new System.Drawing.Size(139, 22);
            this.ChangeMonitorBtt.TabIndex = 11;
            this.ChangeMonitorBtt.Text = "Change Monitor";
            this.ChangeMonitorBtt.UseVisualStyleBackColor = false;
            this.ChangeMonitorBtt.Click += new System.EventHandler(this.MonitorChanged);
            // 
            // AimKeyToggle
            // 
            this.AimKeyToggle.AutoSize = true;
            this.AimKeyToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AimKeyToggle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AimKeyToggle.Location = new System.Drawing.Point(153, 79);
            this.AimKeyToggle.Margin = new System.Windows.Forms.Padding(2);
            this.AimKeyToggle.Name = "AimKeyToggle";
            this.AimKeyToggle.Size = new System.Drawing.Size(58, 17);
            this.AimKeyToggle.TabIndex = 12;
            this.AimKeyToggle.Text = "On Key";
            this.AimKeyToggle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AimKeyToggle.UseVisualStyleBackColor = true;
            this.AimKeyToggle.Click += new System.EventHandler(this.IsAimKeyChanged);
            // 
            // IsHoldToggle
            // 
            this.IsHoldToggle.AutoSize = true;
            this.IsHoldToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IsHoldToggle.ForeColor = System.Drawing.Color.Snow;
            this.IsHoldToggle.Location = new System.Drawing.Point(153, 101);
            this.IsHoldToggle.Margin = new System.Windows.Forms.Padding(2);
            this.IsHoldToggle.Name = "IsHoldToggle";
            this.IsHoldToggle.Size = new System.Drawing.Size(45, 17);
            this.IsHoldToggle.TabIndex = 13;
            this.IsHoldToggle.Text = "Hold";
            this.IsHoldToggle.UseVisualStyleBackColor = true;
            this.IsHoldToggle.CheckedChanged += new System.EventHandler(this.IsHold_changed);
            // 
            // AimkeyBtt
            // 
            this.AimkeyBtt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(107)))), ((int)(((byte)(255)))));
            this.AimkeyBtt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AimkeyBtt.ForeColor = System.Drawing.SystemColors.Window;
            this.AimkeyBtt.Location = new System.Drawing.Point(152, 145);
            this.AimkeyBtt.Margin = new System.Windows.Forms.Padding(2);
            this.AimkeyBtt.Name = "AimkeyBtt";
            this.AimkeyBtt.Size = new System.Drawing.Size(81, 22);
            this.AimkeyBtt.TabIndex = 14;
            this.AimkeyBtt.Text = "button1";
            this.AimkeyBtt.UseVisualStyleBackColor = false;
            this.AimkeyBtt.Click += new System.EventHandler(this.AimKeyDrop);
            // 
            // StartBtt
            // 
            this.StartBtt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(107)))), ((int)(((byte)(255)))));
            this.StartBtt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartBtt.ForeColor = System.Drawing.SystemColors.Window;
            this.StartBtt.Location = new System.Drawing.Point(9, 171);
            this.StartBtt.Margin = new System.Windows.Forms.Padding(2);
            this.StartBtt.Name = "StartBtt";
            this.StartBtt.Size = new System.Drawing.Size(224, 24);
            this.StartBtt.TabIndex = 15;
            this.StartBtt.Text = "button1";
            this.StartBtt.UseVisualStyleBackColor = false;
            this.StartBtt.Click += new System.EventHandler(this.Start_click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // offsetNum
            // 
            this.offsetNum.Location = new System.Drawing.Point(9, 100);
            this.offsetNum.Margin = new System.Windows.Forms.Padding(2);
            this.offsetNum.Name = "offsetNum";
            this.offsetNum.Size = new System.Drawing.Size(90, 20);
            this.offsetNum.TabIndex = 16;
            this.offsetNum.ValueChanged += new System.EventHandler(this.OffsetY_changed);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(104, 102);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Offset";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(104, 124);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Fire Rate";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // FireRateNum
            // 
            this.FireRateNum.Location = new System.Drawing.Point(9, 122);
            this.FireRateNum.Margin = new System.Windows.Forms.Padding(2);
            this.FireRateNum.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.FireRateNum.Name = "FireRateNum";
            this.FireRateNum.Size = new System.Drawing.Size(90, 20);
            this.FireRateNum.TabIndex = 18;
            this.FireRateNum.ValueChanged += new System.EventHandler(this.FireRate_changed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(183, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Key:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(128, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Enemy Outline:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 206);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FireRateNum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.offsetNum);
            this.Controls.Add(this.StartBtt);
            this.Controls.Add(this.AimkeyBtt);
            this.Controls.Add(this.IsHoldToggle);
            this.Controls.Add(this.AimKeyToggle);
            this.Controls.Add(this.ChangeMonitorBtt);
            this.Controls.Add(this.PurpleRadio);
            this.Controls.Add(this.RedRadio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Speed);
            this.Controls.Add(this.TriggerbotBtt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_load);
            ((System.ComponentModel.ISupportInitialize)(this.Speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FireRateNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		// Token: 0x04000019 RID: 25
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.CheckBox TriggerbotBtt;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.NumericUpDown Speed;

		// Token: 0x0400001D RID: 29
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000022 RID: 34
		private global::System.Windows.Forms.RadioButton RedRadio;

		// Token: 0x04000023 RID: 35
		private global::System.Windows.Forms.RadioButton PurpleRadio;

		// Token: 0x04000024 RID: 36
		private global::System.Windows.Forms.Button ChangeMonitorBtt;

		// Token: 0x04000025 RID: 37
		private global::System.Windows.Forms.CheckBox AimKeyToggle;

		// Token: 0x04000026 RID: 38
		private global::System.Windows.Forms.CheckBox IsHoldToggle;

		// Token: 0x04000027 RID: 39
		private global::System.Windows.Forms.Button AimkeyBtt;

		// Token: 0x04000028 RID: 40
		private global::System.Windows.Forms.Button StartBtt;

		// Token: 0x04000029 RID: 41
		private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

		// Token: 0x0400002A RID: 42
		private global::System.Windows.Forms.NumericUpDown offsetNum;

		// Token: 0x0400002B RID: 43
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400002C RID: 44
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400002D RID: 45
		private global::System.Windows.Forms.NumericUpDown FireRateNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
