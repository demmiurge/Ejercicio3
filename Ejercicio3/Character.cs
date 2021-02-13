using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    class Character
    {
        private int MAX_VIDA = 5;
        private string Nom;
        private int Vida;
        private int DanyAtac;
        private bool Escudo;
        private double ProbabilidadRepresalia;
        public Character(string Nom, int DanyAtac)
        {
            Console.WriteLine("Name your character: ");
            Nom = Console.ReadLine();
            Console.WriteLine("What damage will your character deliver?");
            DanyAtac = Convert.ToInt32(Console.ReadLine());
            Escudo = false;
        }

        public Character(string Nom, int DanyAtac, double ProbabilidadRepresalia)
        {
            Console.WriteLine("Name your character: ");
            Nom = Console.ReadLine();
            Console.WriteLine("What damage will your character deliver?");
            DanyAtac = Convert.ToInt32(Console.ReadLine());
            //random probabilidad
            Escudo = true;
        }

        public string getNom()
        {
            return Nom;
        }

        public int getVida()
        {
            return Vida;
        }

        public int getDany()
        {
            return DanyAtac;
        }

        public bool getEscudo()
        {
            if(Escudo == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double getProbabilidad()
        {
            return ProbabilidadRepresalia;
        }

        public void updateVida(int dany)
        {
            Vida -= dany;
            
        }

        public void esAtacat(Character Atacant)
        {
            Random rnd = new Random();
            if(Escudo == true)
            {
                updateVida(Atacant.getDany()-1);
            }
            else
            {
                Vida -= DanyAtac;
                double numb = rnd.NextDouble();
                if(numb < ProbabilidadRepresalia)
                {
                    Atacant.updateVida(1);
                }
            }
        }

        public void mostrar()
        {
            Console.Write("Nom: " + getNom() + " ");
            Console.Write("Vida: "+ getVida() + " ");
            Console.Write("Dany: "+ getDany() + " ");
            if(getEscudo() == true)
            {
                Console.Write("Amb escut");
            }
            else
            {
                Console.Write("Sense escut, amb probabilitat de represàlia "+ getProbabilidad() * 100 + "%");
            }
            
           
        }
    }
}
