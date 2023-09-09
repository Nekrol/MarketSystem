using ProductSystem.Models;

namespace ProductSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            int options;
            int vendors;
            while (true)
            {
                Console.WriteLine("Введите таблицу с которой будете работать");
                Console.WriteLine("1.Таблица продуктов\n2.Таблица поставщиков");
                options = int.Parse(Console.ReadLine());
                if (options == 1)
                {
                    Console.WriteLine("Выберите пункт меню:\n1. Вывести все товары\n2. Вывести определенный товар\n3. Создать новый товар\n4.Удалить товар\n5. Редактировать товар");
                    Console.Write("Введите ваше число: ");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            foreach (var product1 in Query.GetAllProducts())
                            {
                                Console.WriteLine($"Id {product1.Id}| Название {product1.Name} | Цена {product1.Price} | Количество {product1.Amount} | Описание {product1.Description}");
                            }
                            break;
                        case 2:
                            Console.Write("Введите id: ");
                            int id = int.Parse(Console.ReadLine());
                            Models.Product product = Query.ChoiceProduct(id);
                            Console.WriteLine($"Название {product.Name} | Цена {product.Price} | Количество {product.Amount} | Описание {product.Description}");
                            break;
                        case 3:
                            var product2 = new Product();
                            product2.Id = Query.GetHighId() + 1;

                            Console.Write("Введите название товара: ");
                            product2.Name = Console.ReadLine();

                            Console.Write("Введите цену товара: ");
                            product2.Price = int.Parse(Console.ReadLine());

                            Console.Write("Введите количество товара: ");
                            product2.Amount = int.Parse(Console.ReadLine());

                            Console.Write("Введите id поставщика товара: ");
                            product2.VendorId = int.Parse(Console.ReadLine());

                            Console.Write("Введите описание товара: ");
                            product2.Description= Console.ReadLine();

                            Query.CreateProduct(product2);
                            break;
                        case 4:
                            Console.Write("Введите id: ");
                            int id2 = int.Parse(Console.ReadLine());

                            Query.DeleteProduct(id2);
                            break;
                        case 5:
                            Console.Write("Введите изменяемого товара id: ");
                            int id3 = int.Parse(Console.ReadLine());
                            var product3 = Query.ChoiceProduct(id3);

                            Console.Write("Введите измененое название товара: ");
                            product3.Name = Console.ReadLine();

                            Console.Write("Введите измененую цену товара: ");
                            product3.Price = int.Parse(Console.ReadLine());

                            Console.Write("Введите измененое количество товара: ");
                            product3.Amount = int.Parse(Console.ReadLine());

                            Console.Write("Введите измененое id поставщика товара: ");
                            product3.VendorId = int.Parse(Console.ReadLine());

                            Console.Write("Введите измененое описание товара: ");
                            product3.Description = Console.ReadLine();

                            Query.EditProduct(product3, id3);

                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Выберите пункт меню:\n1. Вывести всех поставщиков\n2. Вывести определенного поставщика\n3. Добавить нового поставщика\n4.Удалить поставщика");
                    Console.Write("Введите ваше число: ");
                    vendors = int.Parse(Console.ReadLine());
                    switch (vendors)
                    {
                        case 1:
                            foreach(var vendor1 in Query.GetAllVendors())
                            {
                                Console.WriteLine($"Id {vendor1.Id}| Название {vendor1.Name} | Адрес {vendor1.Address}");
                            }
                            break;
                        case 2:
                            Console.Write("Введите id: ");
                            int id = int.Parse(Console.ReadLine());
                            Models.Vendor vendor2 = Query.ChoiceVendor(id);
                            Console.WriteLine($"Id {vendor2.Id}| Название {vendor2.Name} | Адрес {vendor2.Address}");
                            break;

                        case 3:
                            var vendor = new Vendor();
                            vendor.Id = Query.GetHighIdVendor() + 1;

                            Console.Write("Введите название фирмы поставщика: ");
                            vendor.Name = Console.ReadLine();

                            Console.Write("Введите адрес поставщика: ");
                            vendor.Address = Console.ReadLine();

                            Query.CreateVendor(vendor);
                            break;
                        case 4:
                            Console.WriteLine("Введите id");
                            int id2 = int.Parse(Console.ReadLine());

                            Query.DeleteVendor(id2);
                            break;

                    }
                }

            }
        }
    }
}