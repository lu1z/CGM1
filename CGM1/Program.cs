using System.Windows.Forms;

namespace CGM1
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Matriz m = new Matriz ("[2, 3][0, 1][-1, 4]");
			Matriz r = m.multiplicacao(new Matriz("[1, 2, 3][-2, 0, 4]"));
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
            GUI telinha = new GUI();
			Application.Run(telinha);

            Dezenheiro d = new Dezenheiro(telinha.g);
            d.dezenhaPoligono(m);
		}
	}
}
