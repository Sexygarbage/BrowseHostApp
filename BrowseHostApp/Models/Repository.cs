using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrowseHostApp.Models
{
    public class Repository
    {

        private static Repository repo = new Repository();

        public static Repository Current
        {
            get
            {
                return repo;
            }
        }

        private List<Register> data = new List<Register>
        {
            /*new Reservation {
                ReservationId = 1, ClientName = "Петр", Location = "Отель"},
            new Reservation {
                ReservationId = 2, ClientName = "Вася", Location = "Библиотека"},
            new Reservation {
                ReservationId = 3, ClientName = "Игорь", Location = "Столовая"},*/
        };

        public Register Add(Register item)
        {
            item.registerId = data.Count + 1;
            data.Add(item);
            return item;
        }
    }
}