using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    class Program
    {
        private static Random rnd = new Random();
        private static List<Character> llistat; 
        public static void Main()
        {
            
            //Character Personaje = new Character("Jeff", 5);
            llistat = new List<Character>();
            mostrarllistat();
            Character Atacante;
            Character Victima;
            bool respuesta = true;
            while (respuesta == true)
            {
                Console.WriteLine();
                Console.WriteLine("Benvinguts! Vols jugar, crear un personatge o sotrir? J/j = jugar, P/p = personatge nou, S/s = sotrir.");
                char resposta = Console.ReadKey().KeyChar;

                if (!(resposta == 'P' || resposta == 'p' || resposta == 'J' || resposta == 'j'))
                {
                    Console.WriteLine();
                    Console.WriteLine("Has de introduir una lletra valida.");
                    resposta = Console.ReadKey().KeyChar;
                }

                if (resposta == 'P' || resposta == 'p')
                {
                    Console.WriteLine();
                    addPersonatge();
                }
                else if (resposta == 'J' || resposta == 'j')
                {
                    if (llistat.Count < 2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Cal que el llistat tingui com a mínim 2 personatges.");
                        addPersonatge();
                    }
                    else
                    {
                        Atacante = getAtacant();
                        Victima = getVictima(Atacante);
                        Victima.esAtacat(Atacante);

                    }
                    mostrarllistat();
                }
                else if (resposta == 'S' || resposta == 's')
                {
                    respuesta = false;
                }
            }


        }

        private static void addPersonatge()
        {
            Console.WriteLine("Com es diu el teu personatge?");
            string Nom = Console.ReadLine();
            while(isPersonatge(Nom))
            {
                Console.WriteLine("Aquest nom esta ocupat. Escull un altre nom.");
                Nom = Console.ReadLine();
            }
            Console.WriteLine();
            Console.WriteLine("Quant dany de atac te el teu personatge?");
            int DanyAtac;
            string StringDanyAtac;
            bool Escudo = false;
            StringDanyAtac = Console.ReadLine();
            while(!Int32.TryParse(StringDanyAtac, out DanyAtac))
            {
                Console.WriteLine();
                Console.WriteLine("Aquest numero no és enter, escull un enter.");
                StringDanyAtac = Console.ReadLine();
            }
            while(DanyAtac < 1 || DanyAtac > 5)
            {
                Console.WriteLine();
                Console.WriteLine("El numero no pot ser mes gran que 5 i mes petit que 1, escull un altre numero.");
                StringDanyAtac = Console.ReadLine();
            }
            Console.WriteLine();
            Console.WriteLine("Vols escut o represàlia? E/e = escut, R/r = represàlia.");
            char resposta = Console.ReadKey().KeyChar;
            while(!( resposta == 'E' || resposta == 'e'|| resposta == 'R'|| resposta == 'r'))
            {
                Console.WriteLine();
                Console.WriteLine("Aquesta resposta és incorrecta. E/e = escut, R/r = represàlia.");
                resposta = Console.ReadKey().KeyChar;
            }
            if(resposta == 'e' || resposta == 'E')
            {
                Escudo = true;
                llistat.Add(new Character(Nom, DanyAtac));
            }
            else if(resposta == 'r' || resposta == 'R')
            {
                Escudo = false;
                Console.WriteLine();
                Console.WriteLine("Quin es el teu percentatge de represàlia?");
                double Probabilitat;
                string StringProbabilitat = Console.ReadLine();
                while(!Double.TryParse(StringProbabilitat, out Probabilitat))
                {
                    Console.WriteLine();
                    Console.WriteLine("Aquest numero no es un double. Escull un double.");
                    StringProbabilitat = Console.ReadLine();
                }
                while(Probabilitat < 1 || Probabilitat > 100)
                {
                    Console.WriteLine();
                    Console.WriteLine("Aquest numero no esta entre 1 i 100, escull un altre.");
                    StringProbabilitat = Console.ReadLine();
                }
                Probabilitat /= 100;
                llistat.Add(new Character(Nom, DanyAtac, Probabilitat));
            }
            

        }

        private static bool isPersonatge(string Nom)
        {
            for(int i = 0; i < llistat.Count(); i++)
            {
                if (llistat[i].getNom() == Nom) return true;
                
            }
            return false;
        }
        private static void mostrarllistat ()
        {
            for (int i = 0; i < llistat.Count(); i++)
            {
                llistat[i].mostrar();
            }              
        }
        private static Character getAtacant()
            //?????
        {
            int maxDau = 0, dau;
            
            List<int> llistaPosicions = new List<int>();



            for (int i = 0; i < llistat.Count(); i++)
            {
                dau = rnd.Next(1, 7);
                if (dau>maxDau)
                {
                    llistaPosicions.Clear();
                    maxDau = dau;
                    llistaPosicions.Add(i);
                    
                }
                else if (dau == maxDau)
                {
                    llistaPosicions.Add(i);
                }
                    
             
            }
            while(llistaPosicions.Count > 1)
            {
                for (int i = 0; i < llistat.Count(); i++)
                {
                    dau = rnd.Next(1, 7);
                    if (dau > maxDau)
                    {
                        llistaPosicions.Clear();
                        maxDau = dau;
                        llistaPosicions.Add(i);

                    }
                    else if (dau == maxDau)
                    {
                        llistaPosicions.Add(i);
                    }


                }
            }

            return llistat[llistaPosicions[0]];
            
            
        }


        private static Character getVictima(Character Atacant)
        {
            int vidaMin=5, posicio=0;
            
            
            for (int i = 0; i < llistat.Count(); i++)
            {

                if (llistat[i].getVida() < vidaMin && Atacant.getNom() != llistat[i].getNom())
                {
                    vidaMin = llistat[i].getVida();
                    posicio = i;
                }


                

            }
            return llistat[posicio];

        }
    }
}
