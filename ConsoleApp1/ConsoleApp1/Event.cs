using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace ConsoleApp1
{
    class Event
    {
        private String name;
        static int currcd=0;
        private int code;
        private ArrayList tckt = new ArrayList();
        private Address location;  //atrybut złożony
        static ArrayList eventslist = new ArrayList(); //ekstensja
        private int agelimit; //atrybut opcjonalny
        private int eventMargin;
        private double price;
        private double userPrice;  //atrybut pochodny

        Event(String n, Address loc, double prc, int evM, int al=0)
        {
            name = n;
            code = ++currcd;
            agelimit = al;      ///atrybut opcjonalny
            eventMargin = evM;  ///atrybut do m.pochodnej
            location = loc;     ////atrybut do a. złożonego
            price = prc;    //atrybut do m.pochodnej
            setUserPrice(); //metoda pochodna

            
        }
        private void setUserPrice() //atrybut pochodny
        {
            userPrice += eventMargin * price;
        }
        private void setAgeLimit(int limit) // opcjonalny atrybut
        {
            agelimit = limit;
        }
        public void addEvent(Event ev)  //ekstensja
        {
            eventslist.Add(ev);
        }
        public void removeEvent(Event ev)   //ekstensja
        {
            if (eventslist.Contains(ev))
            {
                eventslist.Remove(ev);
            }
        }
        public Address getAddress() //złożone
        {
            return this.location;
        }
        public void setAddress(Address s)//złożone
        {
            location = s;
        }
        
        public Ticket addTicket()   //metoda przeciążona
        {
            return Ticket.createTicket(this);
        }

        public ArrayList addTicket(int number)   //metoda przeciążona
        {
            ArrayList purchasedTickets = new ArrayList();
          for(int i =0; i<number; i++)
            {
               purchasedTickets.Add(Ticket.createTicket(this));
            }
            return purchasedTickets;
        }

        public static ArrayList listEventsinCity(Address.City c) //metoda klasowa
        {
          
            ArrayList res = new ArrayList();
            foreach(Event e in eventslist)
            {
                if (e.getAddress().getCity().Equals(c))
                    res.Add(c);
            }
            return res;
          

        }

    }



    public class Address
    {
        ArrayList adrs = new ArrayList();
       private City cty; //atrybut powtarzalny
        private int nmbr;
        Street strt;

        Address(City c,Street s, int nr)
        {
            setCity(c); 
            strt = s;
            nmbr = nr;
            adrs.Add(this);
        }

        public City getCity()
        {
            return this.cty;
        }
        public void setCity(City c)
        {
            cty = c;
        }

         
        public class City
        {
            static ArrayList cts = new ArrayList();
            String name;
            ArrayList strts = new ArrayList();

            City(String n)
            {
              name = n;
                cts.Add(this);
            }

            private City Get(string name) {
                foreach (City c in cts) {
                    if (c.name.Equals(name))
                        return c;
            
                }
                return null;
            }
            private City Set(String name)
            {
                City c = new City(name);
                return c;
            }

        }
        class Street
               {
                String name;
                String pstlcode;

                void setStreet(String name)
                {
                    name = name;
                }
            }

      
    }
}
