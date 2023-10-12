namespace ValorantAimbotUI
{
	// Token: 0x02000003 RID: 3
	public partial class Overlay : global::System.Windows.Forms.Form
	{
		// Token: 0x06000032 RID: 50 RVA: 0x00003CCD File Offset: 0x00001ECD
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00003CEC File Offset: 0x00001EEC
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(800, 450);
			base.Name = "Overlay";
			this.Text = "Overlay";
			base.Load += new global::System.EventHandler(this.Load_Main);
		}

		// Token: 0x04000031 RID: 49
		private global::System.ComponentModel.IContainer components;
	}
}
