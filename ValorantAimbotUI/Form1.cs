using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using InputInjectorNet;
using ValorantAimbotUI.Properties;

namespace ValorantAimbotUI
{
	// Token: 0x02000002 RID: 2
	public partial class Form1 : Form
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public Form1()
		{
			this.InitializeComponent();
			this.BackColor = Color.FromArgb(7, 107, 255);//// if you want to change the color menu: https://www.rapidtables.com/web/color/RGB_Color.html
            this.Text = "Cracked By Proofex";
			base.ShowIcon = false;
			this.isTriggerbot = this.GetKey<bool>("isTriggerbot");
			this.isAimbot = this.GetKey<bool>("isAimbot");
			this.speed = this.GetKey<decimal>("speed");
			this.fovX = this.GetKey<int>("fovX");
			this.fovY = this.GetKey<int>("fovY");
			this.color = (Form1.ColorType)this.GetKey<int>("color");
			this.mainAimKey = (Form1.AimKey)this.GetKey<int>("mainAimKey");
			this.isAimKey = this.GetKey<bool>("isAimKey");
			this.isHold = this.GetKey<bool>("isHold");
			this.monitor = this.GetKey<int>("monitor");
			this.isTriggerbot = this.GetKey<bool>("isTriggerbot");
			this.offsetY = this.GetKey<int>("offsetY");
			this.msShootTime = this.GetKey<int>("msShootTime");
			Form1.ColorType colorType = this.color;
			if (colorType != Form1.ColorType.Red)
			{
				if (colorType == Form1.ColorType.Purple)
				{
					this.PurpleRadio.Checked = true;
				}
			}
			else
			{
				this.RedRadio.Checked = true;
			}
			this.UpdateUI();
			this.IsHoldToggle.Checked = this.isHold;
			//this.AimbotBtt.Checked = this.isAimbot;
			this.AimKeyToggle.Checked = this.isAimKey;
			this.Speed.Value = this.speed;
			this.TriggerbotBtt.Checked = this.isTriggerbot;
			this.offsetNum.Value = this.offsetY;
			this.FireRateNum.Value = this.msShootTime;
			foreach (string text in Enum.GetNames(typeof(Form1.AimKey)))
			{
				this.contextMenuStrip1.Items.Add(text);
			}
			this.contextMenuStrip1.ItemClicked += delegate(object o, ToolStripItemClickedEventArgs e)
			{
				this.mainAimKey = (Form1.AimKey)Enum.Parse(typeof(Form1.AimKey), e.ClickedItem.ToString());
				this.SetKey("mainAimKey", (int)this.mainAimKey);
				this.UpdateUI();
			};
			this.AutoSize = false;
			base.AutoScaleMode = AutoScaleMode.Font;
			this.Font = new Font("Trebuchet MS", 10f, FontStyle.Regular, GraphicsUnit.Point, 204);
		}

		// Token: 0x06000002 RID: 2
		[DllImport("gdi32.dll")]
		private static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

		// Token: 0x06000003 RID: 3 RVA: 0x00002324 File Offset: 0x00000524
		private float GetScalingFactor()
		{
			IntPtr hdc = Graphics.FromHwnd(IntPtr.Zero).GetHdc();
			int deviceCaps = Form1.GetDeviceCaps(hdc, 10);
			return (float)Form1.GetDeviceCaps(hdc, 117) / (float)deviceCaps;
		}

		// Token: 0x06000004 RID: 4
		[DllImport("user32.dll")]
		private static extern short GetAsyncKeyState(int vKey);

		// Token: 0x06000005 RID: 5
		[DllImport("USER32.dll")]
		private static extern short GetKeyState(int nVirtKey);

		// Token: 0x06000006 RID: 6 RVA: 0x00002354 File Offset: 0x00000554
		private new async void Update()
		{
			for (;;)
			{
				if (!this.isRunning)
				{
					await Task.Delay(10);
				}
				else
				{
					if (this.isAimKey)
					{
						int keyState = (int)Form1.GetKeyState((int)this.mainAimKey);
						if (this.isHold)
						{
							if (keyState >= 0)
							{
								await Task.Delay(1);
								if (this.lastPressDown)
								{
									this.lastPressDown = false;
									this.Move(0, 0, false);
									continue;
								}
								continue;
							}
						}
						else if (keyState != 0)
						{
							await Task.Delay(1);
							if (this.lastPressDown)
							{
								this.lastPressDown = false;
								this.Move(0, 0, false);
								continue;
							}
							continue;
						}
					}
					Color pixel_Color = Color.FromArgb(this.GetColor(this.color));
					if (this.isTriggerbot && !this.isAimbot)
					{
						if (this.PixelSearch(new Rectangle((Form1.xSize - 10) / 2, (Form1.ySize - 10) / 2, 10, 10), pixel_Color, this.colorVariation).Length != 0)
						{
							this.Move(0, 0, true);
						}
					}
					else if (this.isAimbot)
					{
						Point[] array = this.PixelSearch(new Rectangle((Form1.xSize - this.fovX) / 2, (Form1.ySize - this.fovY) / 2, this.fovX, this.fovY), pixel_Color, this.colorVariation);
						if (array.Length != 0)
						{
							try
							{
								bool pressDown = false;
								if (this.isTriggerbot)
								{
									for (int i = 0; i < array.Length; i++)
									{
										if ((new Vector2((float)array[i].X, (float)array[i].Y) - new Vector2((float)(Form1.xSize / 2), (float)(Form1.ySize / 2))).Length() < 10f)
										{
											pressDown = true;
											break;
										}
									}
								}
								Point[] array2 = (from t in array
								orderby t.Y
								select t).ToArray<Point>();
								List<Vector2> list = new List<Vector2>();
								for (int j = 0; j < array2.Length; j++)
								{
									Vector2 current = new Vector2((float)array2[j].X, (float)array2[j].Y);
									if ((from t in list
									where (t - current).Length() < 60f || Math.Abs(t.X - current.X) < 60f
									select t).Count<Vector2>() < 1)
									{
										list.Add(current);
										if (list.Count > 5)
										{
											break;
										}
									}
								}
								Vector2 vector = (from t in list
								select t - new Vector2((float)(Form1.xSize / 2), (float)(Form1.ySize / 2)) into t
								orderby t.Length()
								select t).ElementAt(0) + new Vector2(1f, (float)this.offsetY);
								this.Move((int)(vector.X * (float)this.speed), (int)(vector.Y * (float)this.speed), pressDown);
								this.lastPressDown = pressDown;
								continue;
							}
							catch (Exception ex)
							{
								Console.WriteLine("Main Ex." + ((ex != null) ? ex.ToString() : null));
								continue;
							}
							return;
						}
					}
				}
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x0000238D File Offset: 0x0000058D
		private bool IsInsideCluster(Form1.Cluster cluster, int x, int y, int padding = 0)
		{
			return cluster.x1 - padding < x && x < cluster.x2 + padding && cluster.y1 - padding < y && y < cluster.y2 + padding;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000023C4 File Offset: 0x000005C4
		private Form1.Cluster AddToCluster(Form1.Cluster c, int x, int y)
		{
			if (c.y2 < y)
			{
				c.y2 = y;
			}
			if (c.x2 < x)
			{
				c.x2 = x;
			}
			if (c.y1 > y)
			{
				c.y1 = y;
			}
			if (c.x1 > y)
			{
				c.x1 = x;
			}
			return c;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002416 File Offset: 0x00000616
		private Form1.Cluster MergeClusters(Form1.Cluster c1, Form1.Cluster c2)
		{
			c1 = this.AddToCluster(c1, c2.x2, c2.y2);
			c1 = this.AddToCluster(c1, c2.x1, c2.y1);
			return c1;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002444 File Offset: 0x00000644
		public List<Form1.Cluster> ConvertPointsToCluster(Point[] p)
		{
			List<Form1.Cluster> list = new List<Form1.Cluster>();
			int num = -1;
			int num2 = -1;
			int num3 = -1;
			int num4 = -1;
			p = (from t in p
			orderby t.X
			select t).ToArray<Point>();
			for (int i = 0; i < p.Length - 1; i++)
			{
				Point point = p[i];
				Point point2 = p[i + 1];
				if (num == -1)
				{
					num = point.Y;
					num2 = point.Y;
				}
				else
				{
					if (point.Y > num)
					{
						num = point.Y;
					}
					if (point.Y < num2)
					{
						num2 = point.Y;
					}
				}
				if (num3 == -1)
				{
					num3 = point.X;
				}
				num4 = point.X;
				if (point2.X - point.X > 8)
				{
					list.Add(new Form1.Cluster
					{
						x1 = num3,
						x2 = point.X,
						y1 = num2,
						y2 = num
					});
					num = -1;
					num2 = -1;
					num3 = -1;
					num4 = -1;
				}
			}
			if (num3 != -1 && num4 != -1)
			{
				list.Add(new Form1.Cluster
				{
					x1 = num3,
					x2 = num4,
					y1 = num2,
					y2 = num
				});
			}
			return list;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002597 File Offset: 0x00000797
		private int GetColor(Form1.ColorType color)
		{
			if (color == Form1.ColorType.Red)
			{
				return 11801877;
			}
			if (color != Form1.ColorType.Purple)
			{
				return 0;
			}
			return 11480751;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000025B0 File Offset: 0x000007B0
		private void UpdateDisplayInformation()
		{
			this.zoom = this.GetScalingFactor();
			Screen screen = this.CurrentScreen();
			bool primary = screen.Primary;
			Form1.xSize = (int)((float)screen.Bounds.Width * (primary ? this.zoom : 1f));
			Form1.ySize = (int)((float)screen.Bounds.Height * (primary ? this.zoom : 1f));
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002624 File Offset: 0x00000824
		public new void Move(int xDelta, int yDelta, bool pressDown = false)
		{
			if (pressDown)
			{
				if (DateTime.Now.Subtract(this.lastShot).TotalMilliseconds < (double)this.msShootTime)
				{
					pressDown = false;
				}
				else
				{
					this.lastShot = DateTime.Now;
				}
			}
			InjectedInputMouseInfo input = default(InjectedInputMouseInfo);
			input.DeltaX = xDelta;
			input.DeltaY = yDelta;
			input.MouseOptions = (InjectedInputMouseOptions)8196;
			if (pressDown)
			{
				input.MouseOptions = (InjectedInputMouseOptions)8194;
			}
			InputInjector.InjectMouseInput(input);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000026A1 File Offset: 0x000008A1
		public Screen CurrentScreen()
		{
			return Screen.AllScreens[this.monitor];
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000026B0 File Offset: 0x000008B0
		public unsafe Point[] PixelSearch(Rectangle rect, Color Pixel_Color, int Shade_Variation)
		{
			ArrayList arrayList = new ArrayList();
			Bitmap bitmap = new Bitmap(rect.Width, rect.Height, PixelFormat.Format24bppRgb);
			if (this.monitor >= Screen.AllScreens.Length)
			{
				this.monitor = 0;
				this.UpdateUI();
			}
			int left = Screen.AllScreens[this.monitor].Bounds.Left;
			int top = Screen.AllScreens[this.monitor].Bounds.Top;
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.CopyFromScreen(rect.X + left, rect.Y + top, 0, 0, rect.Size, CopyPixelOperation.SourceCopy);
			}
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
			int[] array = new int[]
			{
				(int)Pixel_Color.B,
				(int)Pixel_Color.G,
				(int)Pixel_Color.R
			};
			for (int i = 0; i < bitmapData.Height; i++)
			{
				byte* ptr = (byte*)((void*)bitmapData.Scan0) + i * bitmapData.Stride;
				for (int j = 0; j < bitmapData.Width; j++)
				{
					if (((int)ptr[j * 3] >= array[0] - Shade_Variation & (int)ptr[j * 3] <= array[0] + Shade_Variation) && ((int)ptr[j * 3 + 1] >= array[1] - Shade_Variation & (int)ptr[j * 3 + 1] <= array[1] + Shade_Variation) && ((int)ptr[j * 3 + 2] >= array[2] - Shade_Variation & (int)ptr[j * 3 + 2] <= array[2] + Shade_Variation))
					{
						arrayList.Add(new Point(j + rect.X, i + rect.Y));
					}
				}
			}
			bitmap.Dispose();
			return (Point[])arrayList.ToArray(typeof(Point));
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000028D8 File Offset: 0x00000AD8
		private void Red_changed(object sender, EventArgs e)
		{
			this.color = Form1.ColorType.Red;
			this.SetKey("color", (int)this.color);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000028F2 File Offset: 0x00000AF2
		private void Purple_changed(object sender, EventArgs e)
		{
			this.color = Form1.ColorType.Purple;
			this.SetKey("color", (int)this.color);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000290C File Offset: 0x00000B0C
		private void Speed_changed(object sender, EventArgs e)
		{
			this.speed = this.Speed.Value;
			this.SetKey("speed", this.speed);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002930 File Offset: 0x00000B30
	

		// Token: 0x06000015 RID: 21 RVA: 0x00002982 File Offset: 0x00000B82
		private void IsAimbot_changed(object sender, EventArgs e)
		{
			//this.isAimbot = this.AimbotBtt.Checked;
			this.SetKey("isAimbot", this.isAimbot);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000029A6 File Offset: 0x00000BA6
		private void IsTriggerbot_changed(object sender, EventArgs e)
		{
			this.isTriggerbot = this.TriggerbotBtt.Checked;
			this.SetKey("isTriggerbot", this.isTriggerbot);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000029CA File Offset: 0x00000BCA
		private void Main_load(object sender, EventArgs e)
		{
			MessageBox.Show("If you paid for this you were ripped off!");
			this.mainThread = new Thread(delegate()
			{
				this.Update();
			});
			this.mainThread.Start();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000029EE File Offset: 0x00000BEE
		private void SetKey(string key, bool o)
		{
			Settings.Default[key] = o;
			Settings.Default.Save();
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002A0B File Offset: 0x00000C0B
		private void SetKey(string key, int o)
		{
			Settings.Default[key] = o;
			Settings.Default.Save();
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002A28 File Offset: 0x00000C28
		private void SetKey(string key, decimal o)
		{
			Settings.Default[key] = o;
			Settings.Default.Save();
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002A45 File Offset: 0x00000C45
		private T GetKey<T>(string key)
		{
			return (T)((object)Settings.Default[key]);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002A57 File Offset: 0x00000C57
		protected override void OnHandleDestroyed(EventArgs e)
		{
			this.mainThread.Abort();
			Settings.Default.Save();
			base.OnHandleDestroyed(e);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002A75 File Offset: 0x00000C75
		private void Start_click(object sender, EventArgs e)
		{
			this.isRunning = !this.isRunning;
			this.UpdateUI();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002A8C File Offset: 0x00000C8C
		private void UpdateUI()
		{
			this.StartBtt.Text = (this.isRunning ? "Stop" : "Start");
			this.UpdateDisplayInformation();
			this.ChangeMonitorBtt.Text = string.Concat(new string[]
			{
				"Monitor [",
				this.monitor.ToString(),
				"] ",
				Form1.xSize.ToString(),
				"x",
				Form1.ySize.ToString()
			});
			this.AimkeyBtt.Text = Enum.GetName(typeof(Form1.AimKey), this.mainAimKey);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002B39 File Offset: 0x00000D39
		private void MonitorChanged(object sender, EventArgs e)
		{
			this.monitor++;
			if (this.monitor >= Screen.AllScreens.Length)
			{
				this.monitor = 0;
			}
			this.SetKey("monitor", this.monitor);
			this.UpdateUI();
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002B76 File Offset: 0x00000D76
		private void IsAimKeyChanged(object sender, EventArgs e)
		{
			this.isAimKey = this.AimKeyToggle.Checked;
			this.SetKey("isAimKey", this.isAimKey);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002B9A File Offset: 0x00000D9A
		private void IsHold_changed(object sender, EventArgs e)
		{
			this.isHold = this.IsHoldToggle.Checked;
			this.SetKey("isHold", this.isHold);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002BC0 File Offset: 0x00000DC0
		private void AimKeyDrop(object sender, EventArgs e)
		{
			if (this.AimkeyBtt.PointToScreen(new Point(this.AimkeyBtt.Left, this.AimkeyBtt.Bottom)).Y + this.contextMenuStrip1.Size.Height > Screen.PrimaryScreen.WorkingArea.Height)
			{
				this.contextMenuStrip1.Show(this.AimkeyBtt, new Point(0, -this.contextMenuStrip1.Size.Height));
				return;
			}
			this.contextMenuStrip1.Show(this.AimkeyBtt, new Point(0, this.AimkeyBtt.Height));
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002C71 File Offset: 0x00000E71
		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002C73 File Offset: 0x00000E73
		private void OffsetY_changed(object sender, EventArgs e)
		{
			this.offsetY = (int)this.offsetNum.Value;
			this.SetKey("offsetY", this.offsetY);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002C9C File Offset: 0x00000E9C
		private void label5_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002C9E File Offset: 0x00000E9E
		private void FireRate_changed(object sender, EventArgs e)
		{
			this.msShootTime = (int)this.FireRateNum.Value;
			this.SetKey("msShootTime", this.msShootTime);
		}

		// Token: 0x04000001 RID: 1
		public static int xSize;

		// Token: 0x04000002 RID: 2
		public static int ySize;

		// Token: 0x04000003 RID: 3
		private int msShootTime = 225;

		// Token: 0x04000004 RID: 4
		private DateTime lastShot = DateTime.Now;

		// Token: 0x04000005 RID: 5
		private int offsetY = 10;

		// Token: 0x04000006 RID: 6
		private bool lastPressDown;

		// Token: 0x04000007 RID: 7
		private bool isTriggerbot;

		// Token: 0x04000008 RID: 8
		private bool isAimbot;

		// Token: 0x04000009 RID: 9
		private decimal speed = 1m;

		// Token: 0x0400000A RID: 10
		private int fovX = 100;

		// Token: 0x0400000B RID: 11
		private int fovY = 100;

		// Token: 0x0400000C RID: 12
		private bool isAimKey;

		// Token: 0x0400000D RID: 13
		private bool isHold = true;

		// Token: 0x0400000E RID: 14
		private int monitor;

		// Token: 0x0400000F RID: 15
		private int colorVariation = 25;

		// Token: 0x04000010 RID: 16
		private Form1.AimKey mainAimKey = Form1.AimKey.Alt;

		// Token: 0x04000011 RID: 17
		private Form1.ColorType color = Form1.ColorType.Purple;

		// Token: 0x04000012 RID: 18
		private float zoom = 1f;

		// Token: 0x04000013 RID: 19
		private const int MOUSEEVENTF_LEFTDOWN = 2;

		// Token: 0x04000014 RID: 20
		private const int MOUSEEVENTF_LEFTUP = 4;

		// Token: 0x04000015 RID: 21
		private const int MOUSEEVENTF_RIGHTDOWN = 8;

		// Token: 0x04000016 RID: 22
		private const int MOUSEEVENTF_RIGHTUP = 16;

		// Token: 0x04000017 RID: 23
		private Thread mainThread;

		// Token: 0x04000018 RID: 24
		private bool isRunning;

		// Token: 0x02000007 RID: 7
		private enum AimKey
		{
			// Token: 0x04000036 RID: 54
			LeftMouse = 1,
			// Token: 0x04000037 RID: 55
			RightMouse,
			// Token: 0x04000038 RID: 56
			X1Mouse = 5,
			// Token: 0x04000039 RID: 57
			X2Button,
			// Token: 0x0400003A RID: 58
			Shift = 160,
			// Token: 0x0400003B RID: 59
			Ctrl = 162,
			// Token: 0x0400003C RID: 60
			Alt = 164,
			// Token: 0x0400003D RID: 61
			Capslock = 20,
			// Token: 0x0400003E RID: 62
			Numpad0 = 96,
			// Token: 0x0400003F RID: 63
			Numlock = 144
		}

		// Token: 0x02000008 RID: 8
		public enum DeviceCap
		{
			// Token: 0x04000041 RID: 65
			VERTRES = 10,
			// Token: 0x04000042 RID: 66
			DESKTOPVERTRES = 117
		}

		// Token: 0x02000009 RID: 9
		public struct Cluster
		{
			// Token: 0x06000055 RID: 85 RVA: 0x00003FAC File Offset: 0x000021AC
			public static Form1.Cluster operator +(Form1.Cluster a, Vector2 b)
			{
				return new Form1.Cluster
				{
					x1 = a.x1 + (int)b.X / 2,
					x2 = a.x2 + (int)b.X / 2,
					y1 = a.y1 + (int)b.Y / 2,
					y2 = a.y2 + (int)b.Y / 2
				};
			}

			// Token: 0x17000010 RID: 16
			// (get) Token: 0x06000056 RID: 86 RVA: 0x0000401E File Offset: 0x0000221E
			public int x
			{
				get
				{
					return (this.x2 + this.x1) / 2;
				}
			}

			// Token: 0x17000011 RID: 17
			// (get) Token: 0x06000057 RID: 87 RVA: 0x0000402F File Offset: 0x0000222F
			public int y
			{
				get
				{
					return (this.y2 + this.y1) / 2;
				}
			}

			// Token: 0x17000012 RID: 18
			// (get) Token: 0x06000058 RID: 88 RVA: 0x00004040 File Offset: 0x00002240
			public int width
			{
				get
				{
					return this.x2 - this.x1;
				}
			}

			// Token: 0x17000013 RID: 19
			// (get) Token: 0x06000059 RID: 89 RVA: 0x0000404F File Offset: 0x0000224F
			public int height
			{
				get
				{
					return this.y2 - this.y1;
				}
			}

			// Token: 0x04000043 RID: 67
			public int x1;

			// Token: 0x04000044 RID: 68
			public int x2;

			// Token: 0x04000045 RID: 69
			public int y1;

			// Token: 0x04000046 RID: 70
			public int y2;
		}

		// Token: 0x0200000A RID: 10
		private enum ColorType
		{
			// Token: 0x04000048 RID: 72
			Red,
			// Token: 0x04000049 RID: 73
			Purple
		}

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
