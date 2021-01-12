using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        MenuController menuController;
        OnMenuChangedListener listener;
        public Menu()
        {

            InitializeComponent();
            menuController = new MenuController();
            listMenu.ItemsSource = menuController.getItems();

            generateContentMenu();
        }

        public void SetOnItemSelectedListener(OnMenuChangedListener listener)
        {
            this.listener = listener;
        }
        private void listMenuOnDoubleClicked(object sender, MouseButtonEventArgs e)
        {
            ListBox listbox = sender as ListBox;
            Item item = listbox.SelectedItem as Item;
            this.listener.OnMenuSelected(item);


        }

        private void generateContentMenu()
        {
            Item Menu1 = new Item("MOUSE LOGITECH GPRO", 1250000);
            Item Menu2 = new Item("MOUSE LOGITECH G102", 250000);
            Item Menu3 = new Item("KEYBOARD DUCKY ONE TKL", 150000);
            Item Menu4 = new Item("KEYBOAR STEELSERIES APEX", 1150000);
            Item Menu5 = new Item("HEADSET HYPER X CLOUD 2", 1350000);
            Item Menu6 = new Item("HEADSET STEELSERIES SIBERIA", 600000);
            Item Menu7 = new Item("WEBCAM LOGITECH C920 PRO", 1950000);

            menuController.addItem(Menu1);
            menuController.addItem(Menu2);
            menuController.addItem(Menu3);
            menuController.addItem(Menu4);
            menuController.addItem(Menu5);
            menuController.addItem(Menu6);
            menuController.addItem(Menu7);

            listMenu.Items.Refresh();

        }

        private void listMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    public interface OnMenuChangedListener
    {
        void OnMenuSelected(Item item);
    }
}