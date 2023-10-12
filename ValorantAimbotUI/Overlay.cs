using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValorantAimbotUI
{
	// Token: 0x02000003 RID: 3
	public partial class Overlay : Form
	{
		// Token: 0x0600002B RID: 43
		[DllImport("user32.dll")]
		private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

		// Token: 0x0600002C RID: 44
		[DllImport("user32.dll", SetLastError = true)]
		private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

		// Token: 0x0600002D RID: 45 RVA: 0x00003BAC File Offset: 0x00001DAC
		private void Load_Main(object sender, EventArgs e)
		{
			Console.WriteLine("LOADED:::");
			base.TransparencyKey = Color.Wheat;
			base.TopMost = true;
			base.FormBorderStyle = FormBorderStyle.None;
			int windowLong = Overlay.GetWindowLong(base.Handle, -20);
			Overlay.SetWindowLong(base.Handle, -20, windowLong | 524288 | 32);
			base.Size = new Size(Form1.xSize, Form1.ySize);
			base.Top = 0;
			base.Left = 0;
			Overlay.g = base.CreateGraphics();
			Overlay.Clear();
			this.Update();
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00003C3C File Offset: 0x00001E3C
		private new async void Update()
		{
			await Task.Delay(10);
			Overlay.Clear();
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00003C6D File Offset: 0x00001E6D
		public static void Clear()
		{
			if (Overlay.g != null)
			{
				Overlay.g.Clear(Color.Wheat);
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003C85 File Offset: 0x00001E85
		public static void DrawRec(int x1, int y1, int w, int h)
		{
			if (Overlay.g != null)
			{
				x1 = (int)((double)x1 * 0.8);
				y1 = (int)((double)y1 * 0.8);
				Overlay.g.DrawRectangle(Overlay.myPen, x1, y1, w, h);
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00003CBF File Offset: 0x00001EBF
		public Overlay()
		{
			this.InitializeComponent();
		}

		// Token: 0x0400002E RID: 46
		private static Graphics g;

		// Token: 0x0400002F RID: 47
		private static Pen myPen = new Pen(Color.Blue);

		// Token: 0x04000030 RID: 48
		private const double offsetMulti = 0.8;
	}
}
