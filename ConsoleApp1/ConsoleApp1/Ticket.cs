using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApp1
{
    public class Ticket
    {
        private static int serialnrs=0;
        static string currency; //atrybut klasowy
        private int serialnr;
        private Event ev;
        private static ArrayList tckts = new ArrayList();
        private Ticket()
        {
            currency = "PLN";
            serialnr = ++serialnrs;

        }

        public static Ticket createTicket(Event e)
        {
            Ticket t = new Ticket();
            tckts.Add(t);
            return t;
        }
    }
}
