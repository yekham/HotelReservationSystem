using HotelReservation.Business.Services;
using HotelReservation.DataAccess.Context;
using HotelReservation.DataAccess.Repositories;
using HotelReservation.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelReservation.UI.Forms
{
    public partial class GuestForm : Form
    {
        private readonly BookingService _bookingService;
        private readonly GuestService _guestService;
        private readonly BookingGuestService _bookingGuestService;
        private int _numberOfRecords;
        public GuestForm(int numberOfRecords)
        {
            InitializeComponent();
            var dbContext = new ApplicationDbContext();


            var bookingRepository = new BookingRepository(dbContext);
            _bookingService = new BookingService(bookingRepository);

            var guestRepository = new GuestRepository(dbContext);
            _guestService = new GuestService(guestRepository);

            var bookingGuestRepository = new BookingGuestRepository(dbContext);
            _bookingGuestService = new BookingGuestService(bookingGuestRepository);
            _numberOfRecords = numberOfRecords;
            GuestList.Guests.Clear();

        }

        private void btnGuest_Click(object sender, EventArgs e)
        {

            if (GuestList.Guests.Count < _numberOfRecords)
            {
                Guest guest = new Guest()
                {
                    FirstName = txtName.Text,
                    LastName = txtSur.Text,
                    DateOfBirth = dtBirth.Value,
                    Address = txtAdress.Text,
                    Phone = txtTel.Text,
                    Email = txtMail.Text,
                };
                //_guestService.Create(guest);

                GuestList.Guests.Add(guest);
                txtName.Text = "";
                txtSur.Text = "";
                txtMail.Text = "";
                txtTel.Text = "";
                txtAdress.Text = "";
/*
                BookingGuest bookingGuest = new BookingGuest()
                {
                    Guest = guest,
                    GuestID = guest.Id,
                };
                //_bookingGuestService.Create(bookingGuest);
                GuestList.BookingGuest.Add(bookingGuest);*/

                if (GuestList.Guests.Count == _numberOfRecords)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Lutfen kisi sayisi seciniz.");
            }
        }
    }
    public static class GuestList
    {
        public static List<Guest> Guests { get; set; } = new List<Guest>();
        //public static List<BookingGuest> BookingGuest { get; set; } = new List<BookingGuest>();
    }

}
