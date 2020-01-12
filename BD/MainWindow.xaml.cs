using BD.dao;
using BD.Modele;
using BD.Modele.ExempleDAO;
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
            //Des petits essais sur la DAO classique, affichés en "sortie"
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
            // Des essais avec linq et Entity Framework
            var ctx = new ModelPilote();
            PILOTE pilote2 = ctx.PILOTE.Find(1);
            Console.WriteLine(pilote2);
            pilote2.nompil = "Bernard";
            ctx.PILOTE.Add(pilote2);
            ctx.SaveChanges();
            Console.WriteLine(pilote2);

        }
    }
}
