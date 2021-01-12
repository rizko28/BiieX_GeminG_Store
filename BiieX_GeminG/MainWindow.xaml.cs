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
using BiieX_GeminG.Controller;
using BiieX_GeminG.Model;
using BiieX_GeminG;

namespace BiieX_GeminG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,
        OnMenuChangedListener,
        onKeranjangBelanjaChangedListener,
        OnPromoChangedListener,
        OnPaymentChangedListener
    {
        MainWindowController controller;
        Payment payment;
        public MainWindow()
        {
            InitializeComponent();
            payment = new Payment(this);
            KeranjangBelanja keranjangBelanja = new KeranjangBelanja(payment, this);
            controller = new MainWindowController(keranjangBelanja, payment);

            listKeranjangBelanja.ItemsSource = controller.getItems();
            listPromo.ItemsSource = controller.getDiskon();

            initializeView();

        }

        public void onPriceUpdated(double subTotal, double total, double promo)
        {
            labelSubTotal.Content = "Rp " + subTotal;
            labelPromo.Content = "Rp " + (total - subTotal);
            labelTotal.Content = "Rp " + total;
        }


        public void addItemSucceed()
        {
            listKeranjangBelanja.Items.Refresh();
        }

        public void OnMenuSelected(Item item)
        {
            controller.addItem(item);
        }

        public void removeItemSucceed()
        {
            listKeranjangBelanja.Items.Refresh();
        }

        public void addPromoSucceed()
        {
            listPromo.Items.Refresh();
        }



        private void onDaftarMenuClicked(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.SetOnItemSelectedListener(this);
            menu.Show();
        }

        private void onlistKeranjangBelanjaDoubleClicked(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Kamu ingin menghapus item ini?",
                   "Konfirmasi", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                ListBox listBox = sender as ListBox;
                Item item = listBox.SelectedItem as Item;
                controller.removeItem(item);
            }
        }

        private void onBtnGantiPromoClicked(object sender, RoutedEventArgs e)
        {
            Promo promo = new Promo();
            promo.SetOnPromoSelectedListener(this);
            promo.Show();
        }

        public void OnPromoSelected(Diskon diskon)
        {
            controller.addDiskon(diskon);
        }

        private void initializeView()
        {
            labelSubTotal.Content = 0;
            labelPromo.Content = 0;
            labelTotal.Content = 0;
        }

        private void listKeranjangBelanja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}