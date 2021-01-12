using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BiieX_GeminG.Controller;
using BiieX_GeminG.Model;

namespace BiieX_GeminG
{
    /// <summary>
    /// Interaction logic for Promo.xaml
    /// </summary>
    public partial class Promo : Window
    {
        PromoController promoController;
        OnPromoChangedListener promoListener;
        public Promo()
        {
            InitializeComponent();
            promoController = new PromoController();
            listBoxDaftarPromo.ItemsSource = promoController.getDiskon();

            generateContentPromo();
        }

        public void SetOnPromoSelectedListener(OnPromoChangedListener promoListener)
        {
            this.promoListener = promoListener;
        }

        private void generateContentPromo()
        {
            Diskon diskon1 = new Diskon("Promo Awal tahun\nDiskon 45 % ", 45000);
            Diskon diskon2 = new Diskon("Promo Tahun Baru\nDiskon 70 % ", 70000);
            Diskon diskon3 = new Diskon("Promo Natal\nPotongan 50000", 50000);

            promoController.addPromo(diskon1);
            promoController.addPromo(diskon2);
            promoController.addPromo(diskon3);

            listBoxDaftarPromo.Items.Refresh();
        }

        public void onlistBoxDaftarPromoClicked(object sender, MouseButtonEventArgs e)
        {
            ListBox listbox = sender as ListBox;
            Diskon diskon = listbox.SelectedItem as Diskon;
            this.promoListener.OnPromoSelected(diskon);
        }
    }
    public interface OnPromoChangedListener
    {
        void OnPromoSelected(Diskon diskon);
    }
}