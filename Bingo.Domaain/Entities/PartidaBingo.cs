using Bingo.Domain.Entities;
using Bingo.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bingo.Domain
{
    public class PartidaBingo
    {
        private List<Carton> Cartones { get; set; }
        private Casilla[] Casillas;

        public PartidaBingo()
        {
            Cartones = new List<Carton>();
            CrearNumerosBingo();
        }

        public void CrearNumerosBingo()
        {
            Casillas = new Casilla[75];
            for (int i = 0; i < 75; i++)
            {
                Casillas[i] = new Casilla();
            }
            int cont = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                   Casillas[cont].Numero = cont; 
                   cont++;
                }
            }
        }

        public void AgregarCartones(List<Carton> cartons)
        {
            foreach (Carton carton in cartons)
            {
                Cartones.Add(carton);
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

                foreach (Casilla casilla in Casillas)
                {
                    if(casilla.Numero == numero && casilla.Marcado==false)
                    {
                        foreach (Carton carton in Cartones)
                        {
                            carton.MarcarNumero(numero);
                        }
                        casilla.Marcado = true;
                        return "Numero registrado";
                    }
                }
                return "Numero ya se encuentra registrado";
            }

        }


    }


}
