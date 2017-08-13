using System;

namespace CGM1 {
	public class Matriz {
		int x;
		int y;
		int[] matriz;
		public Matriz (int linhas, int colunas) {
			matriz = new int[linhas * colunas];
			x = linhas;
			y = colunas;
		}
		/* Matriz de texto: Cada linha é denotada por um "[" no comeco e um "]" no final com os valores das colunas separados por ",";
		 * Ex : [1, 2, 3]
		 * 		[3, 2, 1]
		 * 		[2, 1, 3]
		 */
		public Matriz(String matrizTexto) {
			matriz = new int[1];
			int i = 0;
			int j = 0;

			String[] linhas = matrizTexto.Split('[');
			String[] colunas;

			foreach (String linha in linhas) {
				if (linha.Length < 1) {
					continue;
				}
				i++;
				colunas = linha.Split(',');
				foreach (String coluna in colunas) {
					String t =coluna.Replace(']', ' ');
					j++;
					int[] temp = new int[j];
					matriz.CopyTo(temp, 0);
					matriz = temp;
					matriz[j - 1] = Int32.Parse(t);
				}
				x = i;
				y = j / i;
			}
		}
		public int pegaPosicao(int i, int j)
		{
			return matriz[(i - 1) * y + j];
		}
		public void guardaPosicao(int i, int j, int p)
		{
			matriz[(i - 1) * y + j] = p;
		}

		public Matriz soma(Matriz m)
		{
			if (x == m.x && y == m.y)
			{
				Matriz retorno = new Matriz(x, y);
				int i = 0;
				foreach (int r in matriz)
				{
					retorno.matriz[i] = matriz[i] + m.matriz[i];
						i++;	
				}
				return retorno;
			}
			else return null;
		}
		public Matriz sutracao(Matriz m)
		{
			if (x == m.x && y == m.y)
			{
				Matriz retorno = new Matriz(x, y);
				int i = 0;
				foreach (int r in matriz)
				{
					retorno.matriz[i] = matriz[i] - m.matriz[i];
					i++;
				}
				return retorno;
			}
			else return null;
		}
		public Matriz ecalar(int e)
		{
			Matriz retorno = new Matriz(x, y);
			int i = 0;
			foreach (int r in matriz)
			{
				retorno.matriz[i] = matriz[i] * e;
				i++;
			}
			return retorno;
		}

		public Matriz multiplicacao(Matriz m)
		{
			if (y != m.x)
				return null;
			Matriz retorno = new Matriz(x, m.y);
			for (int i = 0; i < this.y; i++)
			{
				for (int j = 0; j < m.x; j++)
				{
					retorno.guardaPosicao(i, j, this.pegaPosicao(i, j) * m.pegaPosicao(j, i));
				}
				
			}

			return retorno;
		}
	}
}