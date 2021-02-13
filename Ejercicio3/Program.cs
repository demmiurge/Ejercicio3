using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    class Program
    {
        private Random rnd = new Random();
        private List<Character> llistat = new List<Character>();
        public void Main()
        {

        }

        private void addPersonatge()
        {
            Console.WriteLine("Com es diu el teu personatge?");
            string Nom = Console.ReadLine();
            while(isPersonatge(Nom))
            {
                Console.WriteLine("Aquest nom esta ocupat. Escull un altre nom.");
                Nom = Console.ReadLine();
            }

            Console.WriteLine("Quant dany de atac te el teu personatge?");
            int DanyAtac;
            string StringDanyAtac;
            bool Escudo;
            StringDanyAtac = Console.ReadLine();
            while(!Int32.TryParse(StringDanyAtac, out DanyAtac))
            {
                Console.WriteLine("Aquest numero no és enter, escull un enter.");
                StringDanyAtac = Console.ReadLine();
            }
            while(DanyAtac < 1 || DanyAtac > 5)
            {
                Console.WriteLine("El numero no pot ser mes gran que 5 i mes petit que 1, escull un altre numero.");
                StringDanyAtac = Console.ReadLine();
            }
            Console.WriteLine("Vols escut o represàlia? E/e = escut, R/r = represàlia.");
            char resposta = Console.ReadKey().KeyChar;
            while(!( resposta == 'E' || resposta == 'e'|| resposta == 'R'|| resposta == 'r'))
            {
                Console.WriteLine("Aquesta resposta és incorrecta. E/e = escut, R/r = represàlia.");
                resposta = Console.ReadKey().KeyChar;
            }
            if(resposta == 'e' || resposta == 'E')
            {
                Escudo = true;

            }
            else if(resposta == 'r' || resposta == 'R')
            {
                Escudo = false;
                Console.WriteLine("Quin percentatge de represàlia vols?");
                double Probabilitat;
                string StringProbabilitat = Console.ReadLine();
                while(!Double.TryParse(StringProbabilitat, out Probabilitat))
                {
                    Console.WriteLine("Aquest numero no es un double. Escull un double.");
                    StringProbabilitat = Console.ReadLine();
                }
                while(Probabilitat < 1 || Probabilitat > 100)
                {
                    Console.WriteLine("Aquest numero no esta entre 1 i 100, escull un altre.");
                    StringProbabilitat = Console.ReadLine();
                }
                Probabilitat /= 100;
                llistat.Add(new Character(Nom, DanyAtac, Probabilitat));
            }
            else
            {
                llistat.Add(new Character(Nom, DanyAtac)); //Escudo
            }

        }

        private bool isPersonatge(string Nom)
        {
            for(int i = 0; i < llistat.Count(); i++)
            {
                if (llistat[i].getNom() == Nom) return true;
                
            }
            return false;
        }
        private void mostrarllistat ()
        {
            for (int i = 0; i < llistat.Count(); i++)
            {
                llistat[i].mostrar();
            }              
        }
        private Character getAtacant()
            //?????
        {
            int maxDau=0, dau, posicio;
            
            List<int> llistaPosicions = new List<int>();



            for (int i = 0; i < llistat.Count(); i++)
            {
             dau = rnd.Next(1, 7);
             if (dau>maxDau)
             {
                    maxDau = dau;
                    llistaPosicions.Clear();
                    llistaPosicions.Add(i);
                    
                }
             else if (dau == maxDau)
             {
                    llistaPosicions.Add(i);
             }
                
                    
             
            }

            return
            
            
        }


        private Character getVictima(Character Atacant)
        {
            int vidaMin=5, posicio=0;
            
            
            for (int i = 0; i < llistat.Count(); i++)
            {

                if (llistat[i].getVida()<vidaMin && Atacant.getNom()!= llistat[i].getNom())
                {
                    vidaMin = llistat[i].getVida();
                    posicio = i;
                }


                

            }
            return llistat[posicio];

        }
    }
}
