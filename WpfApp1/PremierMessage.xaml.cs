using Personnes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// https://codes-sources.commentcamarche.net/faq/11277-apercu-du-binding-en-wpf
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged // détecte le changement de propriété
    {

        private string simple = "SIM-P-LE";
        private string prenom0 = "Jacques";
        private string nom0 = "POMME";

        private Personne qqn; // attribut utilisé dans un binding
        public Personne Qqn {
            get { return qqn; }
            set { qqn = value; OnPropertyChanged("Qqn"); }// On appelle la méthode si le qqn change
        }
        private Personne1 qqn1; // attribut utilisé dans un binding
        public Personne1 Qqn1
        {
            get { return qqn1; }
            set { qqn1 = value; OnPropertyChanged("Qqn1"); }// On appelle la méthode si le qqn change
        }
        public string Simple
        {
            get { return simple; }
            set { simple = value;  }
        }

        public string Nom0
        {
            get { return nom0; }
            set { nom0 = value; OnPropertyChanged("Nom0"); }// On appelle la méthode si le qqn change
        }
        public string Prenom0
        {
            get { return prenom0; }
            set { prenom0 = value; OnPropertyChanged("Prenom0"); }// On appelle la méthode si le qqn change
        }

        public event PropertyChangedEventHandler PropertyChanged; // implémentation de INotifyPropertyChanged

        private void OnPropertyChanged(string nomPropriete)
        {
            if (PropertyChanged!=null)
            {
                if (nomPropriete.Equals("Qqn"))
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Qqn.Nom"));
                    PropertyChanged(this, new PropertyChangedEventArgs("Qqn.Prenom"));
                }
                else
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
                }
            }
        }

        public MainWindow()
        {
            qqn = new Personne();
            InitializeComponent();
            this.DataContext = this; // pour que les bindings fonctionnent
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)OUI.IsChecked)
            {
                MessageBox.Show("Oui.");
            }
            else if ((bool)NON.IsChecked)
            {
                Nom0 = "Unknown";
                Qqn.Nom = "inconnu";
                MessageBox.Show("NONNON.");

            }
            else if ((bool)BS.IsChecked)
            {
                Prenom0 = "NotKnown";
                Qqn.Prenom = "pas connu";
                MessageBox.Show("BS.");
            }
        }
    }
}
