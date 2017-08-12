using System;
using System.Text.RegularExpressions;

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
	}
}

