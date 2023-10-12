using System;
using System.Windows.Forms;

namespace ValorantAimbotUI
{
	// Token: 0x02000004 RID: 4
	internal static class Program
	{
		// Token: 0x06000035 RID: 53 RVA: 0x00003D6E File Offset: 0x00001F6E
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
