using System.Windows.Forms;

namespace CGM1
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new GUI());
		}
	}
}
