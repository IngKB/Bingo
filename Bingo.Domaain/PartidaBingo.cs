using System;
using System.Collections.Generic;
using System.Text;

namespace Bingo.Domain
{
    public class PartidaBingo
    {
        private Carton[] Cartones { get; set; }
        int[,] Numeros = new int[5, 15];
        List<int> NumerosMarcados = new List<int>();

        public PartidaBingo()
        {
            CrearNumerosBingo();

        }

        public void CrearNumerosBingo()
        {
            int cont = 1;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Numeros[i, j] = cont;
                    cont++;
                }
            }
        }

        public string SortearNumero(int numero)
        {
            if(numero > 75 )
            {
                return "El numero sobrepasa el limite";
            }else if (numero <= 0)
            {
                return "El numero esta por debajo del limite inferior";
            }
            else
            {
                if(NumerosMarcados.Find(x => x == numero) == 0)
                {
                    
                    foreach (Carton carton in Cartones)
                    {
                        carton.MarcarNumero(numero);
                    }

                    NumerosMarcados.Add(numero);
                    return "Numero registrado";
                }
                
                return "Numero ya se encuentra registrado";
            }

        }

        public 




    }


}
