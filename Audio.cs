using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMediatheque_IA
{
    class Audio
    {
        public static MySqlConnection conexion = new MySqlConnection("Datasource = localhost; database = csharp_projects; User Id = root; pwd =");
        //Attributs
        static int num_audio;
        static string intitule;
        static string format;
        static int taille;

        //Propriétés
        public int NumAudio
        {
            get { return num_audio; }
            set { num_audio = value; }
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
        public Audio() { }

        //Constructeur par défaut
        public Audio(int num_audio, string intitule, string format, int taille)
        {
            num_audio = num_audio;
            intitule = intitule;
            format = format;
            taille = taille;
        }

        public static void InserAudio()
        {

            try
            {
                conexion.Open();

                Console.Write("\n\n\t\t\t Enregistrement d'un nouveau Fichier Audio : \n\n");
                Console.WriteLine();

                Console.Write("\n\n\t\t\t Entrer le numéro du fichier: ");
                num_audio = Int32.Parse(Console.ReadLine());
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
            MySqlCommand cmd = new MySqlCommand("INSERT INTO audio values('" + num_audio + "','" + intitule + "','" + format + "'," + taille + ")", conexion);
            Console.WriteLine("\n\n\t\t\t\t\t\t la fichier a été bien enregistré dans votre Base de Données");
            cmd.ExecuteNonQuery();
            conexion.Close();
            Console.ReadLine();
        }


        public void AfficherAudio()
        {
            conexion.Open();
            MySqlCommand listespec = new MySqlCommand("SELECT * From audio", conexion);
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
