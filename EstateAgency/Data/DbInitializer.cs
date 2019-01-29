using EstateAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateAgency.Data
{
    public static class DbInitializer
    {
        public static void Initialize(EstateAgencyContext context)
        {
            context.Database.EnsureCreated();

            if (context.Clients.Any())
            {
                return;
            }

            var clients = new Client[]
            {
                new Firm {CompanyName = "OwnerCompany1", UNP=111111111, Adress="Adress1", Phone="+3752911111111", ClientStatus=ClientStatus.Owner },
                new Firm {CompanyName = "OwnerCompany2", UNP=111111112, Adress="Adress2", Phone="+3752911111112", ClientStatus=ClientStatus.Owner },
                new Firm {CompanyName = "OwnerCompany3", UNP=111111113, Adress="Adress3", Phone="+3752911111113", ClientStatus=ClientStatus.Owner },
                new Firm {CompanyName = "OwnerCompany4", UNP=111111114, Adress="Adress4", Phone="+3752911111114", ClientStatus=ClientStatus.Owner },
                new Firm {CompanyName = "OwnerCompany5", UNP=111111115, Adress="Adress5", Phone="+3752911111115", ClientStatus=ClientStatus.Owner },
                new Firm {CompanyName = "OwnerCompany6", UNP=111111116, Adress="Adress6", Phone="+3752911111116", ClientStatus=ClientStatus.Owner },
                new Firm {CompanyName = "OwnerCompany7", UNP=111111117, Adress="Adress7", Phone="+3752911111117", ClientStatus=ClientStatus.Owner },
                new Firm {CompanyName = "OwnerCompany8", UNP=111111118, Adress="Adress8", Phone="+3752911111118", ClientStatus=ClientStatus.Owner },
                new Firm {CompanyName = "OwnerCompany9", UNP=111111119, Adress="Adress9", Phone="+3752911111119", ClientStatus=ClientStatus.Owner },
                new Firm {CompanyName = "OwnerCompany10", UNP=111111120, Adress="Adress10", Phone="+3752911111120", ClientStatus=ClientStatus.Owner },
                new Firm {CompanyName = "RentCompany11", UNP=111111121, Adress="Adress11", Phone="+3752911111121", ClientStatus=ClientStatus.Tenant },
                new Firm {CompanyName = "RentCompany12", UNP=111111122, Adress="Adress12", Phone="+3752911111122", ClientStatus=ClientStatus.Tenant },
                new Firm {CompanyName = "RentCompany13", UNP=111111123, Adress="Adress13", Phone="+3752911111123", ClientStatus=ClientStatus.Tenant },
                new Firm {CompanyName = "RentCompany14", UNP=111111124, Adress="Adress14", Phone="+3752911111124", ClientStatus=ClientStatus.Tenant },
                new Firm {CompanyName = "RentCompany15", UNP=111111125, Adress="Adress15", Phone="+3752911111125", ClientStatus=ClientStatus.Tenant },
                new Firm {CompanyName = "RentCompany16", UNP=111111126, Adress="Adress16", Phone="+3752911111126", ClientStatus=ClientStatus.Tenant },
                new Firm {CompanyName = "RentCompany17", UNP=111111127, Adress="Adress17", Phone="+3752911111127", ClientStatus=ClientStatus.Tenant },
                new Firm {CompanyName = "RentCompany18", UNP=111111128, Adress="Adress18", Phone="+3752911111128", ClientStatus=ClientStatus.Tenant },
                new Firm {CompanyName = "RentCompany19", UNP=111111129, Adress="Adress19", Phone="+3752911111129", ClientStatus=ClientStatus.Tenant },
                new Firm {CompanyName = "RentCompany20", UNP=111111130, Adress="Adress20", Phone="+3752911111130", ClientStatus=ClientStatus.Tenant },
                new Firm {CompanyName = "BuyerCompany21", UNP=111111131, Adress="Adress21", Phone="+3752911111131", ClientStatus=ClientStatus.Buyer },
                new Firm {CompanyName = "BuyerCompany22", UNP=111111132, Adress="Adress22", Phone="+3752911111132", ClientStatus=ClientStatus.Buyer },
                new Firm {CompanyName = "BuyerCompany23", UNP=111111133, Adress="Adress23", Phone="+3752911111133", ClientStatus=ClientStatus.Buyer },
                new Firm {CompanyName = "BuyerCompany24", UNP=111111134, Adress="Adress24", Phone="+3752911111134", ClientStatus=ClientStatus.Buyer },
                new Firm {CompanyName = "BuyerCompany25", UNP=111111135, Adress="Adress25", Phone="+3752911111135", ClientStatus=ClientStatus.Buyer },
                new Firm {CompanyName = "BuyerCompany26", UNP=111111136, Adress="Adress26", Phone="+3752911111136", ClientStatus=ClientStatus.Buyer },
                new Firm {CompanyName = "BuyerCompany27", UNP=111111137, Adress="Adress27", Phone="+3752911111137", ClientStatus=ClientStatus.Buyer },
                new Firm {CompanyName = "BuyerCompany28", UNP=111111138, Adress="Adress28", Phone="+3752911111138", ClientStatus=ClientStatus.Buyer },
                new Firm {CompanyName = "BuyerCompany29", UNP=111111139, Adress="Adress29", Phone="+3752911111139", ClientStatus=ClientStatus.Buyer },
                new Person {FirstName = "NameOwnerPerson1", Surname="SurnameOwnerPerson1", Adress="Adress30", Phone="+3752911111140", ClientStatus=ClientStatus.Owner },
                new Person {FirstName = "NameOwnerPerson2", Surname="SurnameOwnerPerson2", Adress="Adress31", Phone="+3752911111141", ClientStatus=ClientStatus.Owner },
                new Person {FirstName = "NameOwnerPerson3", Surname="SurnameOwnerPerson3", Adress="Adress32", Phone="+3752911111142", ClientStatus=ClientStatus.Owner },
                new Person {FirstName = "NameOwnerPerson4", Surname="SurnameOwnerPerson4", Adress="Adress33", Phone="+3752911111143", ClientStatus=ClientStatus.Owner },
                new Person {FirstName = "NameOwnerPerson5", Surname="SurnameOwnerPerson5", Adress="Adress34", Phone="+3752911111144", ClientStatus=ClientStatus.Owner },
                new Person {FirstName = "NameBuyerPerson1", Surname="SurnameBuyerPerson1", Adress="Adress35", Phone="+3752911111145", ClientStatus=ClientStatus.Buyer },
                new Person {FirstName = "NameBuyerPerson2", Surname="SurnameBuyerPerson2", Adress="Adress36", Phone="+3752911111146", ClientStatus=ClientStatus.Buyer },
                new Person {FirstName = "NameBuyerPerson3", Surname="SurnameBuyerPerson3", Adress="Adress37", Phone="+3752911111147", ClientStatus=ClientStatus.Buyer },
                new Person {FirstName = "NameBuyerPerson4", Surname="SurnameBuyerPerson4", Adress="Adress38", Phone="+3752911111148", ClientStatus=ClientStatus.Buyer },
                new Person {FirstName = "NameBuyerPerson5", Surname="SurnameBuyerPerson5", Adress="Adress39", Phone="+3752911111149", ClientStatus=ClientStatus.Buyer }

            };
            foreach (Client c in clients)
            {
                context.Clients.Add(c);
            }
            context.SaveChanges();

            var estates = new Estate[]
            {
                new SaleEstate { Name="изолированное помещение1", Type="склад", InventoryNumber="600/D-111111", Year=1950, Wall="бетон", Area=500, Adress="Adress39",
                ShortDescription="ShortDescription1", LongDescription="LongDescription1", ImageURL="1", ImageThumbURL="1", SalePrice=100000, ClientID=1, SaleStatus=false },
                new SaleEstate { Name="изолированное помещение2", Type="склад", InventoryNumber="600/D-111112", Year=1953, Wall="бетон", Area=900, Adress="Adress40",
                ShortDescription="ShortDescription1", LongDescription="LongDescription1", ImageURL="1", ImageThumbURL="1", SalePrice=105000, ClientID=1, SaleStatus=false },
                new SaleEstate { Name="изолированное помещение3", Type="склад", InventoryNumber="600/D-111113", Year=1955, Wall="бетон", Area=100, Adress="Adress41",
                ShortDescription="ShortDescription1", LongDescription="LongDescription1", ImageURL="1", ImageThumbURL="1", SalePrice=200000, ClientID=1, SaleStatus=false },
                new SaleEstate { Name="изолированное помещение4", Type="склад", InventoryNumber="600/D-111114", Year=1957, Wall="бетон", Area=50, Adress="Adress42",
                ShortDescription="ShortDescription1", LongDescription="LongDescription1", ImageURL="1", ImageThumbURL="1", SalePrice=205000, ClientID=1, SaleStatus=false },
                new SaleEstate { Name="изолированное помещение5", Type="склад", InventoryNumber="600/D-111115", Year=1959, Wall="бетон", Area=400, Adress="Adress43",
                ShortDescription="ShortDescription1", LongDescription="LongDescription1", ImageURL="1", ImageThumbURL="1", SalePrice=300000, ClientID=11, SaleStatus=false },
                new SaleEstate { Name="изолированное помещение6", Type="офис", InventoryNumber="600/D-111116", Year=1961, Wall="бетон", Area=900, Adress="Adress44",
                ShortDescription="ShortDescription1", LongDescription="LongDescription1", ImageURL="1", ImageThumbURL="1", SalePrice=305000, ClientID=11, SaleStatus=false },
                new SaleEstate { Name="изолированное помещение7", Type="офис", InventoryNumber="600/D-111117", Year=1963, Wall="бетон", Area=150, Adress="Adress45",
                ShortDescription="ShortDescription1", LongDescription="LongDescription1", ImageURL="1", ImageThumbURL="1", SalePrice=400000, ClientID=12, SaleStatus=false },
                new SaleEstate { Name="изолированное помещение8", Type="офис", InventoryNumber="600/D-111118", Year=1965, Wall="бетон", Area=1000, Adress="Adress46",
                ShortDescription="ShortDescription1", LongDescription="LongDescription1", ImageURL="1", ImageThumbURL="1", SalePrice=405000, ClientID=13, SaleStatus=false },
                new SaleEstate { Name="изолированное помещение9", Type="офис", InventoryNumber="600/D-111119", Year=1967, Wall="бетон", Area=50, Adress="Adress47",
                ShortDescription="ShortDescription1", LongDescription="LongDescription1", ImageURL="1", ImageThumbURL="1", SalePrice=500000, ClientID=14, SaleStatus=false },
                new RentEstate { Name="изолированное помещение10", Type="офис", InventoryNumber="600/D-111120", Year=1969, Wall="бетон", Area=700, Adress="Adress48",
                ShortDescription="ShortDescription1", LongDescription="LongDescription1", ImageURL="1", ImageThumbURL="1", PerSquareMeterRentPrice=6, ClientID=18, SaleStatus=false },
                new SaleEstate { Name="изолированное помещение11", Type="офис", InventoryNumber="600/D-111121", Year=1970, Wall="бетон", Area=100, Adress="Adress49",
                ShortDescription="ShortDescription1", LongDescription="LongDescription1", ImageURL="1", ImageThumbURL="1", SalePrice=600000, ClientID=22, SaleStatus=false },
                new RentEstate { Name="изолированное помещение12", Type="офис", InventoryNumber="600/D-111122", Year=1972, Wall="бетон", Area=200, Adress="Adress50",
                ShortDescription="ShortDescription1", LongDescription="LongDescription1", ImageURL="1", ImageThumbURL="1", PerSquareMeterRentPrice=7, ClientID=23, SaleStatus=false },
                new SaleEstate { Name="изолированное помещение13", Type="офис", InventoryNumber="600/D-111123", Year=1974, Wall="бетон", Area=350, Adress="Adress51",
                ShortDescription="ShortDescription1", LongDescription="LongDescription1", ImageURL="1", ImageThumbURL="1", SalePrice=700000, ClientID=24, SaleStatus=false },
                new RentEstate { Name="изолированное помещение14", Type="офис", InventoryNumber="600/D-111124", Year=1986, Wall="бетон", Area=500, Adress="Adress52",
                ShortDescription="ShortDescription1", LongDescription="LongDescription1", ImageURL="1", ImageThumbURL="1", PerSquareMeterRentPrice=10, ClientID=25, SaleStatus=false },
                new SaleEstate { Name="изолированное помещение15", Type="офис", InventoryNumber="600/D-111125", Year=1988, Wall="бетон", Area=650, Adress="Adress53",
                ShortDescription="ShortDescription1", LongDescription="LongDescription1", ImageURL="1", ImageThumbURL="1", SalePrice=800000, ClientID=26, SaleStatus=false },
                new RentEstate { Name="капитальное строение1", Type="магазин", InventoryNumber="600/C-111126", Year=1991, Wall="бетон", Area=400, Adress="Adress54",
                ShortDescription="ShortDescription1", LongDescription="LongDescription1", ImageURL="1", ImageThumbURL="1", PerSquareMeterRentPrice=8, ClientID=27, SaleStatus=false },
                new SaleEstate { Name="капитальное строение2", Type="магазин", InventoryNumber="600/C-111127", Year=1993, Wall="бетон", Area=1000, Adress="Adress55",
                ShortDescription="ShortDescription1", LongDescription="LongDescription1", ImageURL="1", ImageThumbURL="1", SalePrice=900000, ClientID=28, SaleStatus=false },
                new RentEstate { Name="капитальное строение3", Type="производство", InventoryNumber="600/C-111128", Year=1999, Wall="бетон", Area=1030, Adress="Adress56",
                ShortDescription="ShortDescription1", LongDescription="LongDescription1", ImageURL="1", ImageThumbURL="1", PerSquareMeterRentPrice=5, ClientID=38, SaleStatus=false },
                new SaleEstate { Name="капитальное строение4", Type="производство", InventoryNumber="600/C-111129", Year=2001, Wall="бетон", Area=800, Adress="Adress57",
                ShortDescription="ShortDescription1", LongDescription="LongDescription1", ImageURL="1", ImageThumbURL="1", SalePrice=1000000, ClientID=38, SaleStatus=false },
                new RentEstate { Name="капитальное строение5", Type="офис", InventoryNumber="600/C-111130", Year=2010, Wall="бетон", Area=5000, Adress="Adress58",
                ShortDescription="ShortDescription1", LongDescription="LongDescription1", ImageURL="1", ImageThumbURL="1", PerSquareMeterRentPrice=14, ClientID=24, SaleStatus=false }
            };
            foreach (Estate e in estates)
            {
                context.Estates.Add(e);
            }
            context.SaveChanges();

            var treaties = new Treaty[]
            {
                new Lease { Number=1, Area=400, SignDate=DateTime.Parse("2016-09-01"), EndDate=DateTime.Parse("2019-09-01"), TotalRentPrice=6 },
                new Lease { Number=2, Area=300, SignDate=DateTime.Parse("2015-06-08"), EndDate=DateTime.Parse("2020-06-08"), TotalRentPrice=6 },
                new Lease { Number=3, Area=200, SignDate=DateTime.Parse("2018-01-01"), EndDate=DateTime.Parse("2021-01-01"), TotalRentPrice=7 },
                new Lease { Number=4, Area=500, SignDate=DateTime.Parse("2017-03-01"), EndDate=DateTime.Parse("2018-12-01"), TotalRentPrice=10 },
                new Lease { Number=5, Area=400, SignDate=DateTime.Parse("2016-02-01"), EndDate=DateTime.Parse("2019-02-01"), TotalRentPrice=8 },
                new Lease { Number=6, Area=1030, SignDate=DateTime.Parse("2017-06-01"), EndDate=DateTime.Parse("2020-06-01"), TotalRentPrice=5 },
                new Lease { Number=7, Area=1000, SignDate=DateTime.Parse("2017-10-01"), EndDate=DateTime.Parse("2019-01-01"), TotalRentPrice=13 },
                new Lease { Number=8, Area=700, SignDate=DateTime.Parse("2018-01-01"), EndDate=DateTime.Parse("2021-01-01"), TotalRentPrice=14 },
                new Lease { Number=9, Area=900, SignDate=DateTime.Parse("2016-11-01"), EndDate=DateTime.Parse("2019-11-01"), TotalRentPrice=13 },

                new SaleTreaty { Number = 10, SignDate=DateTime.Parse("2016-09-01"), TotalSalePrice=100000 },
                new SaleTreaty { Number = 11, SignDate=DateTime.Parse("2015-07-12"), TotalSalePrice=100000 },
                new SaleTreaty { Number = 12, SignDate=DateTime.Parse("2016-06-21"), TotalSalePrice=100000 },
                new SaleTreaty { Number = 13, SignDate=DateTime.Parse("2017-05-31"), TotalSalePrice=100000 },
                new SaleTreaty { Number = 14, SignDate=DateTime.Parse("2017-11-22"), TotalSalePrice=100000 },
                new SaleTreaty { Number = 15, SignDate=DateTime.Parse("2017-01-10"), TotalSalePrice=100000 }
            };

            foreach (Treaty t in treaties)
            {
                context.Treaties.Add(t);
            }
            context.SaveChanges();

            var rentEstate_leases = new RentEstate_Lease[]
            {
                new RentEstate_Lease {
                    EstateID = estates.Single(e=>e.InventoryNumber=="600/D-111120").ID,
                    LeaseID = treaties.Single(l => l.Number==1).ID
                },
                new RentEstate_Lease {
                    EstateID = estates.Single(e=>e.InventoryNumber=="600/D-111120").ID,
                    LeaseID = treaties.Single(l => l.Number==2).ID
                },
                new RentEstate_Lease {
                    EstateID = estates.Single(e=>e.InventoryNumber=="600/D-111122").ID,
                    LeaseID = treaties.Single(l => l.Number==3).ID
                },
                new RentEstate_Lease {
                    EstateID = estates.Single(e=>e.InventoryNumber=="600/D-111124").ID,
                    LeaseID = treaties.Single(l => l.Number==4).ID
                },
                new RentEstate_Lease {
                    EstateID = estates.Single(e=>e.InventoryNumber=="600/C-111126").ID,
                    LeaseID = treaties.Single(l => l.Number==5).ID
                },
                new RentEstate_Lease {
                    EstateID = estates.Single(e=>e.InventoryNumber=="600/C-111128").ID,
                    LeaseID = treaties.Single(l => l.Number==6).ID
                },
                new RentEstate_Lease {
                    EstateID = estates.Single(e=>e.InventoryNumber=="600/C-111130").ID,
                    LeaseID = treaties.Single(l => l.Number==7).ID
                },
                new RentEstate_Lease {
                    EstateID = estates.Single(e=>e.InventoryNumber=="600/C-111130").ID,
                    LeaseID = treaties.Single(l => l.Number==8).ID
                },
                new RentEstate_Lease {
                    EstateID = estates.Single(e=>e.InventoryNumber=="600/C-111130").ID,
                    LeaseID = treaties.Single(l => l.Number==9).ID
                }


            };

            foreach (RentEstate_Lease rel in rentEstate_leases)
            {
                context.RentEstate_Leases.Add(rel);
            }
            context.SaveChanges();

            var clientTreaties = new Client_Treaty[]
            {
                new Client_Treaty {
                    ClientID = clients.Single(c => c.ID == 20).ID,
                    TreatyID = treaties.Single(l => l.Number==1).ID
                },
                new Client_Treaty {
                    ClientID = clients.Single(c => c.ID == 21).ID,
                    TreatyID = treaties.Single(l => l.Number==2).ID
                },
                new Client_Treaty {
                    ClientID = clients.Single(c => c.ID == 37).ID,
                    TreatyID = treaties.Single(l => l.Number==3).ID
                },
                new Client_Treaty {
                    ClientID = clients.Single(c => c.ID == 36).ID,
                    TreatyID = treaties.Single(l => l.Number==4).ID
                },
                new Client_Treaty {
                    ClientID = clients.Single(c => c.ID == 29).ID,
                    TreatyID = treaties.Single(l => l.Number==5).ID
                },
                new Client_Treaty {
                    ClientID = clients.Single(c => c.ID == 30).ID,
                    TreatyID = treaties.Single(l => l.Number==6).ID
                },
                new Client_Treaty {
                    ClientID = clients.Single(c => c.ID == 32).ID,
                    TreatyID = treaties.Single(l => l.Number==7).ID
                },
                new Client_Treaty {
                    ClientID = clients.Single(c => c.ID == 33).ID,
                    TreatyID = treaties.Single(l => l.Number==8).ID
                },
                new Client_Treaty {
                    ClientID = clients.Single(c => c.ID == 34).ID,
                    TreatyID = treaties.Single(l => l.Number==9).ID
                }
            };

            foreach (Client_Treaty ct in clientTreaties)
            {
                context.Client_Treaties.Add(ct);
            }
            context.SaveChanges();
        }
    }
}
