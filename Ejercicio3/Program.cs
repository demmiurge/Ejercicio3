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
    }
}
