using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMediatheque_IA
{
    class Video
    {
        public static MySqlConnection conexion = new MySqlConnection("Datasource = localhost; database = csharp_projects; User Id = root; pwd =");

        //Attributs
        public static int num;
        public static string intitule;
        public static string format;
        public static int taille;

        //Propriétés
        public int Num
        {
            get { return num; }
            set { num = value; }
        }

        public string Intitule
        {
            get { return intitule; }
            set { intitule = value; }
        }

        public string Format
        {
            get { return format; }
            set { format = value; }
        }

        public int Taille
        {
            get { return taille; }
            set { taille = value; }
        }

        //Constructeur d'initialisation
        public Video() { }

        //Constructeur par défaut
        public Video(int num, string intitule, string format, int taille)
        {
            num = num;
            intitule = intitule;
            format = format;
            taille = taille;
        }

        public static void InserVideo()
        {

            try
            {
                conexion.Open();

                Console.Write("\n\n\t\t\t Enregistrement d'un nouveau Fichier Audio : \n\n");
                Console.WriteLine();

                Console.Write("\n\n\t\t\t Entrer le numéro du fichier: ");
                num = Int32.Parse(Console.ReadLine());
                Console.WriteLine();

                Console.Write("\n\n\t\t\t Entrer le nom du fichier : ");
                intitule = Console.ReadLine();
                Console.WriteLine();

                Console.Write("\n\n\t\t\t Entrer le format du fichier : ");
                format = Console.ReadLine();
                Console.WriteLine();

                Console.Write("\n\n\t\t\t Entrer la taille : ");
                taille = Int32.Parse(Console.ReadLine());

            }

            catch
            {
                System.Console.WriteLine("Une erreur c'est produit lors de la connexion au serveur veuiller à ce votre serveur soit en exécution merci");

            }
            MySqlCommand cmd = new MySqlCommand("INSERT INTO video values('" + num + "','" + intitule + "','" + format + "'," + taille + ")", conexion);
            Console.WriteLine("\n\n\t\t\t\t\t\t la fichier a été bien enregistré dans votre Base de Données");
            cmd.ExecuteNonQuery();
            conexion.Close();
            Console.ReadLine();
        }


        public static void AfficherVideo()
        {
            conexion.Open();
            MySqlCommand listespec = new MySqlCommand("SELECT * From video", conexion);
            MySqlDataReader dr = listespec.ExecuteReader();
            while (dr.Read())
            {
                System.Console.WriteLine("\t\t\t" + dr["num"] + " \t" + dr["intitule"] + " \t" + dr["format"] + " \t" + dr["taille"]);
            }
            dr.Close();
            conexion.Close();
            Console.ReadLine();
        }
    }
}
