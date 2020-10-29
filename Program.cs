using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;

namespace Hamnen
{
    class Program
    {
        static void Main(string[] args)
        {
            

            int dag = 1;
            double ledigaPlatser = 64;
            double maxhastighet = 0;
            int antalHastighet = 0;
            int vikt = 0;
            int antalRowBoat = 0;
            int antalMotor = 0;
            int antalSail = 0;
            int antalCargo = 0;

            List<Boat> skapadeBåtar = new List<Boat>();
            List<Boat> båtarIHamnen = new List<Boat>();
            List<Boat> BåtarUtanPlats = new List<Boat>();

            Random r = new Random();
            int båtarDagligen = 5;
            
            while (true)
            {

                Console.WriteLine($"Dag nummer {dag}\n");

                for (int i = 0; i < båtarDagligen; i++)
            {
                int randomNum = r.Next(1, 5);
                if (randomNum == 1)
                {
                    Rowboat rowboats = new Rowboat();
                    skapadeBåtar.Add(rowboats);
                }
                else if (randomNum == 2)
                {
                    Motorboat motorboats = new Motorboat();
                    skapadeBåtar.Add(motorboats);
                }
                else if (randomNum == 3)
                {
                    Sailboat sailboats = new Sailboat();
                    skapadeBåtar.Add(sailboats);
                }
                else if (randomNum == 4)
                {
                    CargoShip cargoships = new CargoShip();
                    skapadeBåtar.Add(cargoships);
                }
                
            }
            // Visa vilka har skapats
                Console.WriteLine("Båtar som kommer idag:\n");
                foreach (var item in skapadeBåtar)
                {
                    Console.WriteLine($"{item.BoatType} med id: {item.IdentityNumber}");
                }
                Console.WriteLine();

            // lägg dem i en ny lista om det finns plats 
                foreach (var item in skapadeBåtar)
                {
                    if (ledigaPlatser > 0 && ledigaPlatser >= item.Tarplatser)
                    {
                        båtarIHamnen.Add(item);
                        ledigaPlatser -= item.Tarplatser;
                    }
                    else
                        BåtarUtanPlats.Add(item);

                }
                Console.WriteLine($"Lediga platser för tillfället: {ledigaPlatser}\n");

                skapadeBåtar.Clear();




                
                Boat[] båtarArray = new Boat[64];

                for (int i = 0; i < båtarIHamnen.Count; i++)
                {

                    båtarArray[i] = båtarIHamnen[i];
                }

                
                int platsnummer = 1;

                Console.WriteLine("Plats\tBåttyp\t\tNr\tVikt\tMaxhast\t\tÖvrigt\n");

                foreach (Boat item in båtarArray)
                {

                    Console.WriteLine($"{platsnummer}.\t{item.BoatType}\t{item.IdentityNumber}\t{item.Weight}\t{item.MaxSpeed} km/h\t\t{item.UniqueProperty} ");
                    if (item == null)
                    {
                        Console.WriteLine(platsnummer + ". Tomt");
                        platsnummer++;

                    }

                    else if (item is Rowboat)
                    {
                        platsnummer++;
                        antalRowBoat++;
                        //if (item.DagarIHamnen == 0)
                        //{
                        //    Console.WriteLine($"Den här båten lämnar hamnen: {item.IdentityNumber}");
                        //    båtarIHamnen.Remove(item);
                        //    ledigaPlatser += 0.5;
                            
                        //}


                    }
                    else if (item is Motorboat)
                    {
                        platsnummer++;
                        antalMotor++;
                        //if (item.DagarIHamnen == 0)
                        //{
                        //    Console.WriteLine($"Den här båten lämnar hamnen: {item.IdentityNumber}");
                        //    hamnplatser.Remove(item);
                        //    ledigaPlatser += 1.0;
                        //}
                    }
                    else if (item is Sailboat)
                    {
                        platsnummer += 2;
                        antalSail++;
                        //if (item.DagarIHamnen == 0)
                        //{
                        //    Console.WriteLine($"Den här båten lämnar hamnen: {item.IdentityNumber}");
                        //    hamnplatser.Remove(item);
                        //    ledigaPlatser += 2.0;
                        //}
                    }
                    else if (item is CargoShip)
                    {
                        platsnummer += 4;
                        antalCargo++;
                        //if (item.DagarIHamnen == 0)
                        //{
                        //    Console.WriteLine($"Den här båten lämnar hamnen: {item.IdentityNumber}");
                        //    hamnplatser.Remove(item);
                        //    ledigaPlatser += 4.0;

                        //}
                    }
                    

                    if (item.DagarIHamnen != 0)
                    {
                        vikt += item.Weight;
                        maxhastighet += item.MaxSpeed;
                        item.DagarIHamnen--;
                    }

                    //else
                    //{
                    //    Console.WriteLine($"Den här båten lämnar hamnen: {item.IdentityNumber}");
                    //    båtarIHamnen.RemoveAll(r => r.DagarIHamnen == 0);
                    //    //  båtarIHamnen.Remove(item);
                    //    //  ledigaPlatser += 0.5;
                        
                    //}



                }

                Console.WriteLine();
                Console.WriteLine($"Antal roddbåtar: {antalRowBoat}\nAntal motorbåtar: {antalMotor}\nAntal segelbåtar: {antalSail}\nAntal lastfartyg: {antalCargo}");
                
                
                
                
                foreach (var item in båtarArray)
                {
                    if (item.Weight != 0)
                        antalHastighet++;

                }
                double maxMedeltal = maxhastighet / antalHastighet;
                Console.WriteLine("Medeltal av båtarnas maxhastighet: " + maxMedeltal + " km/h");
                Console.WriteLine("Vikten är: " + vikt + " kg\n");

                // Visa vilka båtar fick inte plats
                Console.WriteLine("Båtar som inte fick plats:");
                foreach (var item in BåtarUtanPlats)
                {
                    Console.WriteLine($"{item.BoatType} med id: {item.IdentityNumber}");
                }

                dag++;
                Console.WriteLine();
                Console.WriteLine("Nästa dag, klicka enter");

                if (Console.ReadKey().Key == ConsoleKey.Enter)
                    Console.Clear();


            }

        }
        
        
    }
}
