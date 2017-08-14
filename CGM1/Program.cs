using System;

namespace CGM1
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Matriz m = new Matriz ("[2, 3][0, 1][-1, 4]");
			Matriz r = m.multiplicacao(new Matriz("[1, 2, 3][-2, 0, 4]"));
			r = r;
		}
	}
}
