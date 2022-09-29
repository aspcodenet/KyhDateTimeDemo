using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KyhDateTimeDemo
{
    //public enum PlayerPosition
    //{
    //    Forward,
    //    Defence,
    //    Goalie
    //}
    //public class HockeyPlayer
    //{
    //    public string Namn{ get; set; }
    //    public int Age { get; set; }

    //    public PlayerPosition Position { get; set; } 
    //}

    public class App
    {
        //public void a()
        //{
        //    var hockeyPlayer = new HockeyPlayer();
        //    hockeyPlayer.Namn = "Aaaaaa";
        //    hockeyPlayer.Position = PlayerPosition.Forward;

        //    if (hockeyPlayer.Position == PlayerPosition.Forward)
        //    {

        //    }
        //}

        //Skapa aktuell dag+tid
        //Skapa vilken dag+tid som helst
        //Se vilken veckodag
        //Se skillnad mellan datum
        //Lägga till dagar/månader/år till datum
        //Skriva ut
        //Läsa in
        //Vi bygger en "faktureringsrutin". Fakturadag = Current date 
        //                          Förfallodag = CurrentDate + 30 dagar
        //                          Men om förfallodagen är på en lördag -> fredag (29 dagar)
        //                          Eller om söndag -> måndag (31 dagar)

        public string GetSwedishWeekdayName(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday: 
                    return "Måndag";
                case DayOfWeek.Tuesday:
                    return "Tisdag";
                case DayOfWeek.Wednesday:
                    return "Onsdag";
                case DayOfWeek.Thursday:
                    return "Torsdag";
                case DayOfWeek.Friday:
                    return "Fredag";
                case DayOfWeek.Saturday:
                    return "Lördag";
                default:
                    return "Söndag";
            }

        }

        public void DagCounter()
        {
            Console.WriteLine("Ange ditt födelseår:");
            var year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ange ditt födelsemånad(1-12):");
            var month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ange din dag(1-31):");
            var day = Convert.ToInt32(Console.ReadLine());  // 2022-08-01

            var yourBirthDay = new DateTime(year, month, day);

            Console.WriteLine($"Du är född på en {yourBirthDay.DayOfWeek}");  // Gör om till svenska
            var nameInSwedish = GetSwedishWeekdayName(yourBirthDay.DayOfWeek);
            Console.WriteLine($"På svenska är det {nameInSwedish}");  


            if (yourBirthDay.DayOfWeek == DayOfWeek.Saturday || yourBirthDay.DayOfWeek == DayOfWeek.Sunday)
            {
                Console.WriteLine("Ok du är född på en helg, det förklarar varför du är så lat");
            }

            var aktuellDag = DateTime.Now;
            var diff = aktuellDag - yourBirthDay;
            Console.WriteLine($"Du är {Convert.ToInt32(diff.TotalDays)} gammal. ");   



        }

        public void Run()
        {
            var aktuellDag = DateTime.Now;
            var s = aktuellDag.ToString("dddd", new CultureInfo("es-ES"));
            var s2 = aktuellDag.ToString("dddd", new CultureInfo("sv-SE"));



            CalculateDaysToChristmasVacation();
            Invoice();
            aktuellDag = DateTime.Now;
            var snyggtDatum = aktuellDag.ToString("yyyy-MM-dd HH:mm:ss");    // 2022-09-01      // 29 2022
            Console.WriteLine(snyggtDatum);

            DagCounter();
        }

        public void CalculateDaysToChristmasVacation()
        {
            var vacationStarts = new DateTime(2022,12,21);
            Console.Write("Ange datum i format 2022-10-01");
            var inmatning = Console.ReadLine();

            // ENDAST HAPPY CASE    2022-02-30
            var datum = DateTime.ParseExact(inmatning,"yyyy-MM-dd",CultureInfo.CurrentCulture);

//            var ok = DateTime.TryParseExact(inmatning, "yyyy-MM-dd", CultureInfo.CurrentCulture, DateTimeStyles.None, out datum);

            var diff = vacationStarts - datum;
            Console.WriteLine($"håll ut det är {diff.TotalDays} dagar kvar till jullovet");

            // idag
            //Mata in ett datum 2022-10-18
            // håll ut det är 105 dagar kvar tll jullovet
        }



        public void Invoice()
        {
            var invoiceDate = DateTime.Now;
            Console.WriteLine($"Fakturadag: {invoiceDate.ToString("yyyy-MM-dd")}");

            //förfallodag
            var dueDate = invoiceDate.AddDays(30);
            if (dueDate.DayOfWeek == DayOfWeek.Saturday)
                dueDate = dueDate.AddDays(-1); // friday -> 29 
            else if (dueDate.DayOfWeek == DayOfWeek.Sunday)
                dueDate = dueDate.AddDays(1); // Mpndag -> 31
                                              // 
            Console.WriteLine($"Förfallodag: {dueDate.ToString("yyyy-MM-dd")}");
        }
    }
}
