using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMediatheque_IA
{
    class Program
    {
        public static MySqlConnection conexion = new MySqlConnection("Datasource = localhost; database = mediatheque; User Id = root; pwd =");


        static void Main(string[] args)
        {

            int a = 0;
            while (a != 4)
            {
                System.Console.WriteLine("\n\n\t\t t\tGESTION D'UNE MEDIATEQUE \n\n");
                Console.WriteLine("\t\t\t 1-AJOUTER UN FICHIER \n\n");
                Console.WriteLine("\t\t\t 2-LISTE DES FICHIERS \n\n");
                Console.WriteLine("\t\t\t 4-QUITTER \n\n");
                Console.Write("\t\t\t FAITES VOTRE CHOIX : ");
                a = Int16.Parse(Console.ReadLine());
                if (a == 1)
                {
                    InserAudio();
                }
                if (a == 2)
                {
                    AfficherAudio();
                }
                if (a == 3)
                {
                    NbreInscSup100();
                }

                Console.ForegroundColor = ConsoleColor.DarkYellow;


                Console.ReadKey();
            }

            //Classe Livre



        }


        
    }
}
