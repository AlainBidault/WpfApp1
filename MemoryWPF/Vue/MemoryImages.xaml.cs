using Cartes;
using Jeu;
using Joueurs;
using Paquets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MemoryWPF.Vue.Images
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MemoryBehind : Window
    {
        private MemoryVueModel<CarteImage> MemoryVue;
        private MemoryImage jeu;
        private bool cacher = false;
        private bool paireGagnee= false;
        private bool finJeu = false;
        private bool AttentePremiere = true;
        private bool AttenteDeuxieme = false;
        private int premiereCarte;
        private int deuxiemeCarte;

        public MemoryBehind()
        {
            InitializeComponent();
            jeu = new MemoryImage(6);
            jeu.Joueurs.Add(new JoueurMemory<CarteImage>("Roger", new PaquetImage(0)));               
            MemoryVue = new MemoryVueModel<CarteImage>(new ObservableCollection<CarteImage>(jeu.GetCartes()));
            MemoryVue.Indications = "bon jeu "+jeu.Joueurs[0].Nom+", choisissez deux cartes";
            this.DataContext = MemoryVue;
            /*
            "<Image Width=\"100\" Margin=\"350,350,0,0\" Source=\"./photos/dos.jpeg\"/>";
            "<Image Width=\"100\" Margin=\"350,350,0,0\" Source=\"./photos/" + url + "\"/>";
            */

        }

        public void TurnCard(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //Console.WriteLine("début !");
            if (tablecartes.SelectedItem != null)
            {
                int ix = tablecartes.SelectedIndex;
                if (paireGagnee)
                {
                    EnregistrerCartesGagnees();
                }
                if (ClicValide(ix))
                {                    
                    if (cacher)
                    {
                        cacher = false;
                        jeu.Paquet.Cartes[premiereCarte].Tourne();
                        jeu.Paquet.Cartes[deuxiemeCarte].Tourne();
                    }

                    CarteImage carte = ((CarteImage)tablecartes.SelectedItem);
                    carte.Tourne();
                    tablecartes.Items.Refresh();
                    if (AttentePremiere)
                    {                        
                        AttentePremiere = false;
                        premiereCarte = ix;
                        AttenteDeuxieme = true;
                        MemoryVue.Indications = jeu.Joueurs[0].Nom + ", choisissez une 2e carte";

                    }
                    else if (AttenteDeuxieme)
                    {
                        deuxiemeCarte = ix;
                        AttentePremiere = true;
                        AttenteDeuxieme = false;
                        //Vérifier paire
                        if (carte.EstCompatible(jeu.Paquet.Cartes[premiereCarte])) {
                            //Console.WriteLine("GAGNE");
                            paireGagnee = true;
                            finJeu = jeu.FinDuJeu();
                            if (finJeu)
                            {
                                MessageBox.Show("GAGNE !!");
                                EnregistrerCartesGagnees();
                                tablecartes.Items.Refresh();
                                MemoryVue.Indications = "GAGNE !!";                                
                            }
                            else
                            {
                                MemoryVue.Indications = "Bravo " + jeu.Joueurs[0].Nom + ", choisissez deux autres cartes";
                            }
                        }
                        else
                        {
                            //Console.WriteLine("PERDU");                                                        
                            MemoryVue.Indications = jeu.Joueurs[0].Nom + ", choisissez deux autres cartes";
                        }
                        cacher = true;
                    }
                    

                }
            }
            //Console.WriteLine("fin !");
        }

        private void EnregistrerCartesGagnees()
        {
            ((JoueurMemory<CarteImage>)jeu.Joueurs[0]).AddCarteGagnee(jeu.Paquet.Cartes[premiereCarte]);
            jeu.Paquet.Cartes[premiereCarte].Gagnee = true;
            ((JoueurMemory<CarteImage>)jeu.Joueurs[0]).AddCarteGagnee(jeu.Paquet.Cartes[deuxiemeCarte]);
            jeu.Paquet.Cartes[deuxiemeCarte].Gagnee = true;
            paireGagnee = false;
        }

        private bool ClicValide(int n)
        {
            return (n >= 0) && (n < jeu.Paquet.Count())
                        && !jeu.Paquet.Get(n).Gagnee
                        && !jeu.Paquet.Get(n).Visible
                        && !finJeu;
        }
    }
}
