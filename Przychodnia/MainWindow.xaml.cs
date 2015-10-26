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
using MySql.Data.MySqlClient;
using System.Data;

namespace Przychodnia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var newWindow = new OknoLogowania();
            newWindow.ShowDialog();
        }

        private void btnDodajPacjenta_Click(object sender, RoutedEventArgs e)
        {
            string MessageDodajPacjenta = "Czy chcesz dodać pacjenta o następujących danych: \n" +
                "Imie: " + txtImie.Text + "\n" +
                "Nazwisko: " + txtNazwisko.Text + "\n" +
                "Adres: " + txtAdres.Text + "\n" +
                "Email: " + txtEmail.Text + "?";

            string MessageDodajTytul = "Dodać pacjenta?";

            MessageBoxButton btnMessageDodaj = MessageBoxButton.OKCancel;
            MessageBoxImage imgMessageDodaj = MessageBoxImage.Question;

            MessageBoxResult MessageDodajResult = MessageBox.Show(MessageDodajPacjenta, MessageDodajTytul, btnMessageDodaj, imgMessageDodaj);

            if (MessageDodajResult == MessageBoxResult.OK)
            {
                AkcjePacjentow.DodajPacjenta(new Pacjent(AkcjePacjentow.IlePacjentow(), txtImie.Text, txtNazwisko.Text, txtAdres.Text, txtEmail.Text));
                string MyConnectionString = "Server=localhost;Database=mydb1;Uid=root;";
                MySqlConnection con = new MySqlConnection(MyConnectionString);
                MySqlCommand cmd;
                con.Open();
                try
                {
                    cmd = con.CreateCommand();
                    cmd.CommandText = "insert into pacjent (imie, nazwisko, adres, email) values (@imie, @nazwisko, @adres, @email);";
                    cmd.Parameters.AddWithValue("@imie", AkcjePacjentow.ListaPacjentow[AkcjePacjentow.IlePacjentow() - 1].Imie);
                    cmd.Parameters.AddWithValue("@nazwisko", AkcjePacjentow.ListaPacjentow[AkcjePacjentow.IlePacjentow() - 1].Nazwisko);
                    cmd.Parameters.AddWithValue("@adres", AkcjePacjentow.ListaPacjentow[AkcjePacjentow.IlePacjentow() - 1].Adres);
                    cmd.Parameters.AddWithValue("@email", AkcjePacjentow.ListaPacjentow[AkcjePacjentow.IlePacjentow() - 1].Email);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw;
                }

                con.Close();
            }
        }

        private void btnSzukajPacjenta_Click(object sender, RoutedEventArgs e)
        {
            lbl1.Content = "Szukanie...";
            string[] columnNames = { "pacjent", "imie", "nazwisko", "adres", "email" };
            
            TworzenieZapytan.WykonajSelecta(TworzenieZapytan.StworzSelecta(columnNames , new WhereParams("imie", txtImie.Text), new WhereParams("nazwisko", txtNazwisko.Text), new WhereParams("adres", txtAdres.Text), new WhereParams("email", txtEmail.Text)), AkcjePacjentow.OgarnijDanePacjentow);
           
            
            //NIEWAŻNE, można wyjebać
            string temp = "";
            if (AkcjePacjentow.IlePacjentow() > 0) { temp = AkcjePacjentow.ListaPacjentow[0].Imie + AkcjePacjentow.ListaPacjentow[0].Nazwisko; }
            lbl1.Content = temp;


            dataGrid.ItemsSource = null; //czyści grida
            dataGrid.ItemsSource = AkcjePacjentow.ListaPacjentow; //wrzuca pacjentów do czystego grida
            
        }

        private void btnWyloguj_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new OknoLogowania();
            newWindow.ShowDialog();
        }
    }
}
