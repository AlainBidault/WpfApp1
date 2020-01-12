using BD.dao;
using BD.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BD
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Connexion.ConnecterUtilisateur("AlainB","toto");
            Connexion.GetInstance();
            //Des petits essais sur la DAO, affichés en "sortie"
            Pilote pilote = PiloteDAO.Read(1);
            Console.WriteLine(pilote);
            pilote.NomPil = "Edgar";
            PiloteDAO.Update(pilote);
            pilote = PiloteDAO.Read0(1);
            Console.WriteLine(pilote);
            //PiloteDAO.Create(pilote); // pour tester INSERT
            //Console.WriteLine(pilote);
            //PiloteDAO.Delete(pilote.NumPil); // pour tester DELETE
            Connexion.close();
        }
    }
}
