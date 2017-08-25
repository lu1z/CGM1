using System;
using System.Windows.Forms;

namespace CGM1 {
	public partial class GUI : Form {
		public TextBox t1;
		public TextBox t2;
		public TextBox t3;

		public Button b1;
		public Button b2;
		public Button b3;

		public GUI() {
            InitializeComponent();
		}

		private void closeButton_Click(object sender, EventArgs e) {
				Close();
		}

		private void InitializeComponent() {
            this.SuspendLayout();
            this.Text = "GCM1";

			t1 = new TextBox();
			t1.Location  = new System.Drawing.Point(12,12);
			t1.Size = new System.Drawing.Size(260, 0);

			b1 = new Button();
			b1.Location = new System.Drawing.Point(12,44);
			b1.Text = "+";
			b1.Click += new System.EventHandler(b1_Click);

			b2 = new Button();
			b2.Location = new System.Drawing.Point(104,44);
			b2.Text = "*";
			b2.Click += new System.EventHandler(b1_Click);

			b3 = new Button();
			b3.Location = new System.Drawing.Point(196,44);
			b3.Text = "-";
			b3.Click += new System.EventHandler(b1_Click);

			t2 = new TextBox();
			t2.Location  = new System.Drawing.Point(12,76);
			t2.Size = new System.Drawing.Size(260, 0);

			t3 = new TextBox();
			t3.Location  = new System.Drawing.Point(12,108);
			t3.Size = new System.Drawing.Size(260, 0);
			t3.ReadOnly = true;

			this.Controls.Add(t1);
            this.Controls.Add(t2);
            this.Controls.Add(t3);
            this.Controls.Add(b1);
            this.Controls.Add(b2);
            this.Controls.Add(b3);

            Brush aBrush = (Brush)Brushes.Black;
            Graphics g = this.CreateGraphics();

            int x, y = 10;
            g.FillRectangle(aBrush, x, y, 1, 1);

			this.ResumeLayout(false);
		}

		public void b1_Click(Object Sender, EventArgs e) {
			
		}
	}
}
