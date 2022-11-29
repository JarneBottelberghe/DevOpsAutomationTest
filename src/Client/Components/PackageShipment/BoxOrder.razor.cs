using Microsoft.AspNetCore.Components;
using Shared.Orders;
using System.Reflection.Metadata;

namespace Client.Components.PackageShipment
{
    public partial class BoxOrder
    {
            private OrderDto.Index? order;
            [Inject]
            public IOrderService OrderService { get; set; }

        /*        [Parameter]
                public string OrderId { get; set; }

                protected async override Task OnInitializedAsync()
                {
                    order = await OrderService.GetOrderDetailAsync(OrderId);
                }
        */

        private string BoxType { get; set; }

        private int Breedte { get; set; } = 1;
        private int Hoogte { get; set; } = 1;
        private int Diepte { get; set; } = 1;

        private int PrijsSubTotaal { get; set; }
        private int PrijsTotaal { get; set; }
        private int PrijsDozen { get; set; }
        private int PrijsPaletten { get; set; }
        private int PrijsVerzending { get; set; }

        private int AantalDozen { get; set; }
        private int AantalPaletten { get; set; }


        private void BerekenPrijs()
        {
            int breedte = Breedte;
            int hoogte = Hoogte;
            int diepte = Diepte;
            int aantal = 50;
            int priceProduct = 30;

            int price = aantal * priceProduct;
            Product product = new(1, 1, 1, priceProduct, aantal);
            Doos doos = new(breedte, hoogte, diepte, 2);

            BerekenPrijsNaSubtotaal(price, doos,product);
        }

        private void BerekenPrijsNaSubtotaal(int subPrice, Doos doos, Product product)
        {
            /*
      * statische data
      *  */ 
            Pallet pallet = new(40,40,20,10);
            int prijs_verzending = 15;
            int totalPrice = 0;

            int hoeveelheidDozen = berekenAantal(product.width, product.height, product.dept, product.Aantal, doos.width, doos.height, doos.dept);
            int hoeveelheidPaletten = berekenAantal(doos.width, doos.height, doos.dept, hoeveelheidDozen, pallet.width, pallet.height, pallet.dept);
            AantalPaletten = hoeveelheidPaletten;
            AantalDozen = hoeveelheidDozen;

            int dozenprijs = (hoeveelheidDozen * doos.prijs);
            int palettenprijs = (hoeveelheidPaletten * pallet.prijs);
            totalPrice += dozenprijs + palettenprijs + (1 * prijs_verzending) + subPrice;
            PrijsVerzending = prijs_verzending;
            PrijsDozen = dozenprijs;
            PrijsPaletten = palettenprijs;
            PrijsSubTotaal = subPrice;
            PrijsTotaal = totalPrice;
        }

        private int berekenAantal(int objWidth, int objHeight, int objDept, int objAantal, int containerWidth, int containerHeight, int containerDept)
        {
            double aantalObj = objAantal;


            double maxObjsW = containerWidth / objWidth;

            double maxObjsD = containerDept / objDept;
            double maxObjsH = containerHeight / objHeight;

            double maxObjsPerCountainer = maxObjsW * maxObjsD * maxObjsH;

            int aantalContainers = 0;
            while (aantalObj > 0)
            {
                aantalObj -= maxObjsPerCountainer;
                aantalContainers++;
            }

            return aantalContainers;
        }

        public class Pallet
        {
            public int width { get; set; }
            public int height { get; set; }
            public int dept { get; set; }
            public int prijs { get; set; }

            public Pallet(int width, int height, int dept, int prijs)
            {
                this.width = width;
                this.height = height;
                this.dept = dept;
                this.prijs = prijs;
            }

           
        }
        public class Doos
        {
            public int width { get; set; }
            public int height { get; set; }
            public int dept { get; set; }
            public int prijs { get; set; }

            public Doos(int width, int height, int dept, int prijs)
            {
                this.width = width;
                this.height = height;
                this.dept = dept;
                this.prijs = prijs;
            }

           
        }
        public class Product
        {
            public int width { get; set; }
            public int height { get; set; }
            public int dept { get; set; }
            public int prijs { get; set; }
            public int Aantal { get; }

            public Product(int width, int height, int dept, int prijs)
            {
                this.width = width;
                this.height = height;
                this.dept = dept;
                this.prijs = prijs;
            }

            public Product(int width, int height, int dept, int prijs, int aantal) : this(width, height, dept, prijs)
            {
                Aantal = aantal;
            }
        }
    }
}