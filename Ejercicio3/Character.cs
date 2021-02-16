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
            this.Nom = Nom;
            this.DanyAtac = DanyAtac;
            Vida = MAX_VIDA;
            Escudo = true;
        }

        public Character(string Nom, int DanyAtac, double ProbabilidadRepresalia)
        {

            this.Nom = Nom;
            this.DanyAtac = DanyAtac;
            Vida = MAX_VIDA;
            this.ProbabilidadRepresalia = ProbabilidadRepresalia;
            Escudo = false;
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

        public double getProbabilitatRepresalia()
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
            
            if(getEscudo())
            {
                updateVida(Atacant.getDany()-1);
                Console.WriteLine();
                Console.Write(getNom() + " rep dany de " + Atacant.getDany());
                Console.WriteLine(", però té un escut i per això la seva vida és " + getVida() + ".\n");
            }
            else
            {
                updateVida(Atacant.getDany());
                Console.WriteLine();
                Console.WriteLine(getNom() + " rep dany de " + Atacant.getDany() + ", la seva vida és " + getVida() + ".\n");
                double numb = rnd.NextDouble();
                if(numb < ProbabilidadRepresalia)
                {
                    Atacant.updateVida(1);
                    Console.WriteLine();
                    Console.WriteLine("Generem el número " + numb + "->" + Atacant.getNom() + "rep una represàlia i la seva vida és " + getVida() + ".\n");
                }
            }
        }

        public void mostrar()
        {
            Console.WriteLine();
            Console.Write("Nom: " + getNom() + " ");
            Console.Write("Vida: "+ getVida() + " ");
            Console.Write("Dany: "+ getDany() + " ");
            if(getEscudo() == true)
            {
                Console.Write("Amb escut");
            }
            else
            {
                Console.Write("Sense escut, amb probabilitat de represàlia "+ getProbabilitatRepresalia() * 100 + "%");
            }
            
           
        }
    }
}
