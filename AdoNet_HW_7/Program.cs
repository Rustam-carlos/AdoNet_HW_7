using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet_HW_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int e = 100;
            for(int i = 1; i < e; i++)
            {
                int choise = 0;
                Console.WriteLine("\n\n");
                ShowMenu();
                choise = int.Parse(Console.ReadLine());
                if ((choise != 1) & (choise != 2) & (choise != 3))
                    Console.WriteLine("ОШИБКА ВВОДА!!! СОБЕРИСЬ ТРЯПКА!!!");
                else
                {
                    Console.Clear();
                    using (VisitorContext DB = new VisitorContext())
                    {
                        switch (choise)
                        {
                            case 1:
                                var visitors = DB.Visitors;
                                //Visitor Test = new Visitor { Name = "Test", SecondName = "Test", DocNumber = 0, GoneTime = DateTime.Now, Intention = "Test", ComingTime = DateTime.Now };
                                //DB.Visitors.Add(Test);
                                //DB.SaveChanges();
                                Console.WriteLine("Список посетителей:");
                                foreach (Visitor n in visitors)
                                {
                                    Console.WriteLine("{0}.{1}.{2}.{3}.{4}.{5}.{6}", n.ID, n.Name, n.SecondName, n.DocNumber, n.ComingTime, n.Intention, n.GoneTime);
                                }
                                continue;
                            case 2:
                                Visitor Man = new Visitor();
                                //InputVisitor(Man);
                                string name = "", secondname = "", interes = "";
                                int docnum = 0;
                                bool Informer = true;
                                Console.WriteLine("Введите Имя посетителя:");
                                name = Console.ReadLine();
                                while (Informer)
                                {
                                    if (String.IsNullOrEmpty(name) || name == "\n")
                                    {
                                        Console.WriteLine("ОШИБКА ВВОДА!!! СМОТРИ КУДА ЖМАКАЕШЬ!!!");
                                        Console.WriteLine("Введи Имя посетителя, никонец!!!");
                                        name = Console.ReadLine();
                                    }
                                    else { Informer = false; }
                                }
                                /*----------------*/
                                Console.WriteLine("Введите Фамилию посетителя:");
                                secondname = Console.ReadLine();
                                while (Informer)
                                {
                                    if (String.IsNullOrEmpty(secondname) || secondname == "\n")
                                    {
                                        Console.WriteLine("ОШИБКА ВВОДА!!! СМОТРИ КУДА ЖМАКАЕШЬ!!!");
                                        Console.WriteLine("Введи Фамилию посетителя, никонец!!!");
                                        secondname = Console.ReadLine();
                                    }
                                    else { Informer = false; }
                                }
                                /*----------------*/
                                Console.WriteLine("Введите номер уд. личности:");
                                docnum = int.Parse(Console.ReadLine());
                                /*----------------*/
                                Console.WriteLine("Введите цель визита:");
                                interes = Console.ReadLine();
                                while (Informer)
                                {
                                    if (String.IsNullOrEmpty(interes) || interes == "\n")
                                    {
                                        Console.WriteLine("ОШИБКА ВВОДА!!! СМОТРИ КУДА ЖМАКАЕШЬ!!!");
                                        Console.WriteLine("Введи цель визита!!!");
                                        interes = Console.ReadLine();
                                    }
                                    else { Informer = false; }
                                }
                                Man = new Visitor
                                {
                                    Name = name,
                                    SecondName = secondname,
                                    DocNumber = docnum,
                                    ComingTime = DateTime.Now,
                                    Intention = interes,
                                    GoneTime = DateTime.Now
                                };
                                DB.Visitors.Add(Man);
                                DB.SaveChanges();
                                Console.WriteLine("Добавлен");
                                Console.Clear();
                                continue;
                                //break;
                            case 3:
                                Console.WriteLine("Введите порядковый номер посетителя");
                                int id = int.Parse(Console.ReadLine());
                                var getID = (from Visitors in DB.Visitors
                                             where Visitors.ID.Equals(id)
                                             select Visitors).FirstOrDefault();
                                getID.GoneTime = DateTime.Now;
                                DB.SaveChanges();
                                Console.WriteLine("Время выхода посетителя обновлено");
                                //Console.Clear();
                                continue;
                        }
                    }

                }
                Console.Read();
            }
        }

        //private static Visitor InputVisitor(Visitor man)
        //{
        //    string name = "", secondname = "", interes = "";
        //    int docnum = 0;            
        //    bool Informer = true;
        //    Console.WriteLine("Введите Имя посетителя:");
        //    name = Console.ReadLine();
        //    while (Informer)
        //    {
        //        if (String.IsNullOrEmpty(name) || name == "\n")
        //        {
        //            Console.WriteLine("ОШИБКА ВВОДА!!! СМОТРИ КУДА ЖМАКАЕШЬ!!!");
        //            Console.WriteLine("Введи Имя посетителя, никонец!!!");
        //            name = Console.ReadLine();
        //        }
        //        else { Informer = false; }
        //    }
        //    /*----------------*/
        //    Console.WriteLine("Введите Фамилию посетителя:");
        //    secondname = Console.ReadLine();
        //    while (Informer)
        //    {
        //        if (String.IsNullOrEmpty(secondname) || secondname == "\n")
        //        {
        //            Console.WriteLine("ОШИБКА ВВОДА!!! СМОТРИ КУДА ЖМАКАЕШЬ!!!");
        //            Console.WriteLine("Введи Фамилию посетителя, никонец!!!");
        //            secondname = Console.ReadLine();
        //        }
        //        else { Informer = false; }
        //    }
        //    /*----------------*/
        //    Console.WriteLine("Введите номер уд. личности:");
        //    docnum = int.Parse(Console.ReadLine());
        //    /*----------------*/
        //    Console.WriteLine("Введите цель визита:");
        //    interes = Console.ReadLine();
        //    while (Informer)
        //    {
        //        if (String.IsNullOrEmpty(interes) || interes == "\n")
        //        {
        //            Console.WriteLine("ОШИБКА ВВОДА!!! СМОТРИ КУДА ЖМАКАЕШЬ!!!");
        //            Console.WriteLine("Введи цель визита!!!");
        //            interes = Console.ReadLine();
        //        }
        //        else { Informer = false; }
        //    }            
        //    man = new Visitor
        //    {
        //        Name = name,
        //        SecondName = secondname,
        //        DocNumber = docnum,
        //        ComingTime = DateTime.Now,
        //        Intention = interes,
        //        GoneTime = DateTime.Now
        //    };
        //    return man;
        //}

        private static void ShowMenu()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1 - Просмотр всего списка");
            Console.WriteLine("2 - Добавить посетителя");
            Console.WriteLine("3 - Выпустить посетителя");
        }
    }
}
