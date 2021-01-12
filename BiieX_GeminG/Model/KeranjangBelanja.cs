using System;
using System.Collections.Generic;
using System.Text;

namespace BiieX_GeminG.Model
{
    class KeranjangBelanja
    {
        List<Item> itemkeranjangBelanja;
        public List<Diskon> diskonDipakai;
        Payment payment;
        onKeranjangBelanjaChangedListener onKeranjangBelanjaChangedListener;

        public KeranjangBelanja(Payment payment, onKeranjangBelanjaChangedListener onKeranjangBelanjaChangedListener)
        {
            this.payment = payment;
            this.onKeranjangBelanjaChangedListener = onKeranjangBelanjaChangedListener;
            this.itemkeranjangBelanja = new List<Item>();
            this.diskonDipakai = new List<Diskon>();
        }
        public List<Item> getItems()
        {
            return this.itemkeranjangBelanja;
        }

        public List<Diskon> getDiskon()
        {
            return this.diskonDipakai;
        }

        public void addDiskon(Diskon diskon)
        {
            this.diskonDipakai.Clear();
            this.diskonDipakai.Add(diskon);
            this.onKeranjangBelanjaChangedListener.addPromoSucceed();
            calculateSubTotal();
        }

        public void addItem(Item item)
        {
            this.itemkeranjangBelanja.Add(item);
            this.onKeranjangBelanjaChangedListener.addItemSucceed();
            calculateSubTotal();
        }

        public void removeItem(Item item)
        {
            this.itemkeranjangBelanja.Remove(item);
            this.onKeranjangBelanjaChangedListener.removeItemSucceed();
            calculateSubTotal();
        }

        private void calculateSubTotal()
        {
            double subTotal = 0;
            double promo = 0;
            foreach (Item item in itemkeranjangBelanja)
            {
                subTotal += item.price;

            }
            foreach (Diskon diskon in diskonDipakai)
            {
                if (diskon.potongan == 50000)
                {
                    promo = 50000;
                }
                else if (diskon.potongan == 70000)
                {

                    promo = (subTotal * 70 / 100);

                    if (promo > 70000)
                    {
                        promo = 70000;
                    }
                    else
                    {
                        promo = (subTotal * 45 / 100);
                    }

                }
                else if (diskon.potongan == 45000)
                {
                    promo = (subTotal * 45 / 100);

                }

            }

            payment.updateTotal(subTotal, promo);
        }
    }


    interface onKeranjangBelanjaChangedListener
    {
        void removeItemSucceed();
        void addItemSucceed();
        void addPromoSucceed();

    }
}