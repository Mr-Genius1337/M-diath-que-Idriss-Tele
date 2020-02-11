using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMediatheque_IA
{
    class Livre
    {
        public static MySqlConnection conexion = new MySqlConnection("Datasource = localhost; database = csharp_projects; User Id = root; pwd =");

        //Attributs
        static string code;
        static string nom;
        static string auteur;
        static string edition;
        static int nbr_pages;

        //Propriétés

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Auteur
        {
            get { return auteur; }
            set { auteur = value; }
        }

        public string Edition
        {
            get { return edition; }
            set { edition = value; }
        }

        public int Nbr_pages
        {
            get { return nbr_pages; }
            set { nbr_pages = value; }
        }

        //Constructeur d'initialisation
        public Livre() { }

        //Constructeur par défaut
        public Livre(int code, string nom, string auteur, string edition, int nbr_pages)
        {
            code = code;
            nom = nom;
            auteur = auteur;
            edition = edition;
            nbr_pages = nbr_pages;

        }

        public static void InserLivre()
        {

            try
            {
                conexion.Open();

                Console.Write("\n\n\t\t\t Enregistrement d'un nouveau livre : \n\n");
                Console.WriteLine();

                Console.Write("\n\n\t\t\t Entrer le code du : ");
                code = Console.ReadLine();
                Console.WriteLine();

                Console.Write("\n\n\t\t\t Entrer le nom du livre : ");
                nom = Console.ReadLine();
                Console.WriteLine();

                Console.Write("\n\n\t\t\t Entrer l'auteur du livre : ");
                auteur = Console.ReadLine();
                Console.WriteLine();

                Console.Write("\n\n\t\t\t Entrer l'édition : ");
                edition = Console.ReadLine();

                Console.Write("\n\n\t\t\t Entrer le nombre de page : ");
                nbr_pages = Int32.Parse(Console.ReadLine());

            }

            catch
            {
                System.Console.WriteLine("Une erreur c'est produit lors de la connexion au serveur veuiller à ce votre serveur soit en exécution merci");

            }
            MySqlCommand cmd = new MySqlCommand("INSERT INTO livre values('" + code + "','" + nom + "','" + auteur + "'," + edition + "," + nbr_pages + ")", conexion);
            Console.WriteLine("\n\n\t\t\t\t\t\t la livre a été bien enregistré dans votre Base de Données");
            cmd.ExecuteNonQuery();
            conexion.Close();
            Console.ReadLine();
        }


        public static void AfficherLivre()
        {
            conexion.Open();
            MySqlCommand listespec = new MySqlCommand("SELECT * From livre", conexion);
            MySqlDataReader dr = listespec.ExecuteReader();
            while (dr.Read())
            {
                System.Console.WriteLine("\t\t\t" + dr["code"] + " \t" + dr["nom"] + " \t" + dr["auteur"] + " \t" + dr["edition"] + " \t" + dr["nbre_pages"]);
            }
            dr.Close();
            conexion.Close();
            Console.ReadLine();
        }




    }
}
