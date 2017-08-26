using System;
using System.Drawing;

public class Dezenheiro
{
    int dimencaoPonto = 1;
    Graphics g;
    Brush b;

    public Dezenheiro(Graphics g) {
        this.g = g;
        b = (Brush)Brushes.Black;
	}
    public void dezenhaLinha(int x0, int y0, int x1, int y1) {
        bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
        if (steep)
        {
            int t;
            t = x0; // swap x0 and y0
            x0 = y0;
            y0 = t;
            t = x1; // swap x1 and y1
            x1 = y1;
            y1 = t;
        }
        if (x0 > x1)
        {
            int t;
            t = x0; // swap x0 and x1
            x0 = x1;
            x1 = t;
            t = y0; // swap y0 and y1
            y0 = y1;
            y1 = t;
        }
        int dx = x1 - x0;
        int dy = Math.Abs(y1 - y0);
        int error = dx / 2;
        int ystep = (y0 < y1) ? 1 : -1;
        int y = y0;
        for (int x = x0; x <= x1; x++)
        {
            dezenhaPonto(steep ? y : x, steep ? x : y);
            error = error - dy;
            if (error < 0)
            {
                y += ystep;
                error += dx;
            }
        }
        break;
    }

    public void dezenhaPonto(int x, int y) {
        g.FillRectangle(b, x, y, dimencaoPonto, dimencaoPonto);
    }

    public void dezenhaPoligono(Matriz m) {
        int anterior = 1;
        for (int corrente = 3; corrente < m.matriz.length; corrente = corrente + 2) {
            dezenhaLinha(m.matriz[anterior - 1], m.matriz[anterior], m.matriz[corrente - 1], m.matriz[corrente]);
            anterior = corrente;
        }
        dezenhaLinha(m.matriz[anterior - 1], m.matriz[anterior], m.matriz[0], m.matriz[0]);
    }
}
