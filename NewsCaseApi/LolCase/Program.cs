using LolCase.Champions;
using LolCase.HeroType;
using LolCase.Loot;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LolCase
{
    class Program
    {
        static void Main(string[] args)
        {
            var champions = GetChampions();
            foreach (var item in champions)
            {
                Console.WriteLine("{0}-{1}", item.Id, item.Name);
            }
            Console.WriteLine("Lütfen Şampiyon Seçiminizi rakamlar ile  Yapınız!");
            int cNumber = 0;
            bool check = true;
            do
            {
                Tuple<bool, int> nCheck = CheckNumber(1, 9);
                check = nCheck.Item1;
                cNumber = nCheck.Item2;
                var champion = champions.FirstOrDefault(x => x.Id == cNumber);
                if (champion == null)
                {
                    Console.WriteLine("Şeçim ekranında beklenmeyen hata!");
                    Console.ReadKey();
                    check = true;
                    Console.WriteLine("Lütfen Tekrar Seçim Yapınız!");
                }
                else
                    SelectChampions(champion);

            } while (check);

            Console.ReadKey();

        }

        public static List<Champion> GetChampions()
        {
            var champions = new List<Champion>();
            var ashe = new Champion()
            {
                Id = 1,
                Name = "Ashe",
                Type = TypeEnum.Adc
            };
            champions.Add(ashe);
            var jinx = new Champion()
            {
                Id = 2,
                Name = "Jinx",
                Type = TypeEnum.Adc
            };
            champions.Add(jinx);
            var lucion = new Champion()
            {
                Id = 3,
                Name = "Lucian",
                Type = TypeEnum.Adc
            };
            champions.Add(lucion);
            var annie = new Champion()
            {
                Id = 4,
                Name = "Annie",
                Type = TypeEnum.Magician
            };
            champions.Add(annie);
            //Main karakterim
            var brand = new Champion()
            {
                Id = 5,
                Name = "Brand",
                Type = TypeEnum.Magician
            };
            champions.Add(brand);
            var veigar = new Champion()
            {
                Id = 6,
                Name = "Veigar",
                Type = TypeEnum.Magician
            };
            champions.Add(veigar);
            //Main karakterim
            var tresh = new Champion()
            {
                Id = 7,
                Name = "Tresh",
                Type = TypeEnum.Support
            };
            champions.Add(tresh);
            var alistar = new Champion()
            {
                Id = 8,
                Name = "Alistar",
                Type = TypeEnum.Support
            };
            champions.Add(alistar);
            var braum = new Champion()
            {
                Id = 9,
                Name = "Braum",
                Type = TypeEnum.Support
            };
            champions.Add(braum);

            return champions;
        }
        public static List<Item> GetItems()
        {
            var items = new List<Item>();
            var mana = new Item()
            {
                Id = 1,
                AdcValue = 10,
                MagicianValue = 50,
                Name = "Mavi Büyü",
                SupportValue = 0,
                Type = ItemType.Hp
            };
            items.Add(mana);
            var healt = new Item()
            {
                Id = 2,
                AdcValue = 5,
                MagicianValue = 30,
                Name = "Yeşil Büyü",
                SupportValue = 0,
                Type = ItemType.Hp
            };
            items.Add(healt);
            var sword = new Item()
            {
                Id = 3,
                AdcValue = 20,
                MagicianValue = 0,
                Name = "Kılıç",
                SupportValue = 10,
                Type = ItemType.Xp
            };
            items.Add(sword);
            var gun = new Item()
            {
                Id = 4,
                AdcValue = 50,
                MagicianValue = 0,
                Name = "Silah",
                SupportValue = 20,
                Type = ItemType.Xp
            };
            items.Add(gun);
            return items;
        }
        public static Tuple<bool, int> CheckNumber(int min, int max)
        {
            int CNumber = 0;
            bool NCheck = true;
            var readCNumber = int.TryParse(Console.ReadLine(), out CNumber);
            if (!readCNumber)
                Console.WriteLine("Lütfen sadece rakam girişi yapınız!");
            else
            {
                if (CNumber < min || CNumber > max)
                    Console.WriteLine("Lütfen {0 }ile {1} arası giriş yapınız!", min, max);
                else
                    NCheck = false;
            }
            return Tuple.Create(NCheck, CNumber);
        }
        public static void SelectChampions(Champion champion)
        {
            int cNumber = 0;
            bool check = true;
            var items = GetItems();
            switch (champion.Type)
            {
                case TypeEnum.Adc:
                    Adc adc = new Adc();
                    adc.Name = champion.Name;
                    adc.Type = TypeEnum.Adc;
                    do
                    {
                        foreach (var item in items)
                        {
                            Console.WriteLine("{0}-{1}", item.Id, item.Name);
                        }
                        Console.WriteLine("Lütfen Şampiyon Ekipmanlarını Seçiniz!");
                        do
                        {
                            Tuple<bool, int> adcCheck = CheckNumber(1, 9);
                            check = adcCheck.Item1;
                            cNumber = adcCheck.Item2;

                        } while (check);
                        check = true;
                        var selectedItem = items.FirstOrDefault(x => x.Id == cNumber);
                        if (selectedItem == null)
                            Environment.Exit(0);

                        adc.AddItem(selectedItem);
                        Console.WriteLine("Şampiyon Ekipmanı seçimine devam edilsin mi! Y:Evet N:Hayır");
                        string result = string.Empty;
                        do
                        {
                            result = Console.ReadLine();
                            if (result != "N" && result != "Y")
                                Console.WriteLine("Yanlış seçim yaptınız!Şampiyon Ekipmanı seçimine devam edilsin mi! Y:Evet N:Hayır");
                            else
                                check = false;
                        } while (check);
                        check = true;
                        if (result == "N")
                        {
                            if (adc.CheckItem())
                            {
                                check = false;
                                adc.WriteProperties();
                            }
                            else
                                Console.WriteLine("Şampiyon Ekipmanı tamamlanmamıştır ekipman eklemeye devam ediniz.");
                        }
                    }
                    while (check);
                    break;
                case TypeEnum.Support:
                    Support support = new Support();
                    support.Name = champion.Name;
                    support.Type = TypeEnum.Support;
                    do
                    {
                        foreach (var item in items)
                        {
                            Console.WriteLine("{0}-{1}", item.Id, item.Name);
                        }
                        Console.WriteLine("Lütfen Şampiyon Ekipmanlarını Seçiniz!");
                        do
                        {
                            Tuple<bool, int> supCheck = CheckNumber(1, 9);
                            check = supCheck.Item1;
                            cNumber = supCheck.Item2;

                        } while (check);
                        check = true;
                        var selectedItem = items.FirstOrDefault(x => x.Id == cNumber);
                        if (selectedItem == null)
                            Environment.Exit(0);

                        support.AddItem(selectedItem);
                        Console.WriteLine("Şampiyon Ekipmanı seçimine devam edilsin mi! Y:Evet N:Hayır");
                        string result = string.Empty;
                        do
                        {
                            result = Console.ReadLine();
                            if (result != "N" && result != "Y")
                                Console.WriteLine("Yanlış seçim yaptınız!Şampiyon Ekipmanı seçimine devam edilsin mi! Y:Evet N:Hayır");
                            else
                                check = false;
                        } while (check);
                        check = true;
                        if (result == "N")
                        {
                            if (support.CheckItem())
                            {
                                check = false;
                                support.WriteProperties();
                            }
                            else
                                Console.WriteLine("Şampiyon Ekipmanı tamamlanmamıştır ekipman eklemeye devam ediniz.");
                        }
                    }
                    while (check);
                    break;
                case TypeEnum.Magician:
                    Magician magician = new Magician();
                    magician.Name = champion.Name;
                    magician.Type = TypeEnum.Magician;
                    do
                    {
                        foreach (var item in items)
                        {
                            Console.WriteLine("{0}-{1}", item.Id, item.Name);
                        }
                        Console.WriteLine("Lütfen Şampiyon Ekipmanlarını Seçiniz!");
                        do
                        {
                            Tuple<bool, int> magCheck = CheckNumber(1, 9);
                            check = magCheck.Item1;
                            cNumber = magCheck.Item2;

                        } while (check);
                        check = true;
                        var selectedItem = items.FirstOrDefault(x => x.Id == cNumber);
                        if (selectedItem == null)
                            Environment.Exit(0);

                        magician.AddItem(selectedItem);
                        Console.WriteLine("Şampiyon Ekipmanı seçimine devam edilsin mi! Y:Evet N:Hayır");
                        string result = string.Empty;
                        do
                        {
                            result = Console.ReadLine();
                            if (result != "N" && result != "Y")
                                Console.WriteLine("Yanlış seçim yaptınız!Şampiyon Ekipmanı seçimine devam edilsin mi! Y:Evet N:Hayır");
                            else
                                check = false;
                        } while (check);
                        check = true;
                        if (result == "N")
                        {
                            if (magician.CheckItem())
                            {
                                check = false;
                                magician.WriteProperties();
                            }
                            else
                                Console.WriteLine("Şampiyon Ekipmanı tamamlanmamıştır ekipman eklemeye devam ediniz.");
                        }
                    }
                    while (check);
                    break;
            }
        }
    }
}
