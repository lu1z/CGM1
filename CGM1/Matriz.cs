using System;

namespace CGM1 {
	public class Matriz {
		public int x;
		public int y;
		public double[] matriz;

		public Matriz (int linhas, int colunas) {
			matriz = new double[linhas * colunas];
			x = linhas;
			y = colunas;
		}
		/* Matriz de texto: Cada linha é denotada por um "[" no comeco e um "]" no final com os valores das colunas separados por ",";
		 * Ex : [1, 2, 3]
		 * 		[3, 2, 1]
		 * 		[2, 1, 3]
		 */
		public Matriz(String matrizTexto) {
			matriz = new double[1];
			int i = 0;
			int j = 0;

			String[] linhas = matrizTexto.Split('[');
			String[] colunas;

			foreach (String linha in linhas) {
				if (linha.Length < 1) {
					continue;
				}
				i++;
				colunas = linha.Split(';');
				foreach (String coluna in colunas) {
					String t = coluna.Replace(']', ' ');
					j++;
					double[] temp = new double[j];
					matriz.CopyTo(temp, 0);
					matriz = temp;
					matriz[j - 1] = Double.Parse(t);
				}
				x = i;
				y = j / i;
			}
		}
		public double pegaPosicao(int i, int j)
		{
			return matriz[i * y + j];
		}
		public void guardaPosicao(int i, int j, double p)
		{
			matriz[i * y + j] = matriz[i * y + j] + p;
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
			else
				return null;
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
		public Matriz ecalar(double e)
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

		public Matriz multiplicacao(Matriz multiplicando)
		{
			if (this.y != multiplicando.x)
				return null;
			Matriz retorno = new Matriz(this.x, multiplicando.y);
			for (int i = 0; i < this.x; i++)
			{
				for (int j = 0; j < multiplicando.y; j++)
				{
					for (int z = 0; z < this.y; z++)
						retorno.guardaPosicao(i, j, this.pegaPosicao(i, z) * multiplicando.pegaPosicao(z, j));
				}
				
			}

			return retorno;
		}
		public Matriz rotacao(int grau) {

			return this.multiplicacao(new Matriz("[" + Math.Cos(grau) + "; " + -Math.Sin(grau)+ "][" + Math.Sin(grau) + "; " + Math.Cos(grau) + "]"));

		}
	}
}