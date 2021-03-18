using System;
using System.Collections.Generic;

namespace Bingo.Domain
{
    public class Carton
    {
        int[,] Numeros = new int[5, 5];
        List<int> NumerosMarcados = new List<int>();

        public Carton()
        {
            CrearCarton();
        }

        public string MarcarNumero(int numero)
        {
            if (EstaElNumeroEnCarton(numero))
            {
                NumerosMarcados.Add(numero);
                if (VerificarCartonCompleto())
                {
                    return "Carton ganador";
                }
            }
            return null;
        }

        public bool VerificarCartonCompleto()
        {
            return NumerosMarcados.Count == 24;
        }

        public void CrearCarton()
        {
            var rand = new Random();
            var minVal = 1;
            var maxVal = 16;
            for (int i = 0; i<5;i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    if (!(i == 2 && j == 2))
                    {
                        var num = rand.Next(minVal, maxVal);

                        while (EstaElNumeroEnCarton(num))
                        {
                            num = rand.Next(minVal, maxVal);
                        }

                        Numeros[i, j] = num;
                    }
                    else {
                        Numeros[i, j] = 0;
                    }
                }            
                minVal += 15;
                maxVal += 15;
            }  
        }

        private bool EstaElNumeroEnCarton(int num)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                { 
                    if(Numeros[i,j] == num)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
