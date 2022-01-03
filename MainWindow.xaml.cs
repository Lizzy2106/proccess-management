using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace w5Q8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LancerProcessus_Click(object sender, RoutedEventArgs e)
        {
            // Nom du processus récupéré de la TextBox

            // Créer un processus
            Process process = new Process();
            // Donner le nom à travers StartInfo
            //process.StartInfo.FileName = name;
            // Démarrer processus 
            ChargerProcessus();
        }

        private void ArreterProcessus_Click(object sender, RoutedEventArgs e)
        {
            // Sélectionner le processus de la listView
            Processus processus = listView1.SelectedItem();
            // Le Link est le processus
            Process process = processus.Link;
            // L'arrêter avec Kill
            process.Kill();
            ChargerProcessus();
        }

        private void Quitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ChargerProcessus()
        {
            listView1.Items.Clear();

            // Récupérer tous les processus 
            foreach (Process p in Process.GetProcesses())
            {   // Ajouter un nouveau processus dans la liste avec Link le processus lui-même + tous les données qu'on souhaite afficher
                Processus processus = new Processus(p);
                listView1.Items.Add(processus);
            }
        }

        private void WIndowsGestionProcessus_Loaded(object sender, RoutedEventArgs e)
        {
            ChargerProcessus();
        }

    }

    public class Processus
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public string Priority { get; set; }

        public string VirtualMemory { get; set; }

        public Process Link { get; set; }

        public Processus(Process link)
        {
            Name = link.ProcessName;
            Id = Convert.ToString(link.Id);
            Priority = Convert.ToString(link.BasePriority);
            VirtualMemory = Convert.ToString(link.VirtualMemorySize64);
            Link = link;
        }
    }
}
