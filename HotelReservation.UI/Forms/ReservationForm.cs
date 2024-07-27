using HotelReservation.Business.Services;
using HotelReservation.DataAccess.Context;
using HotelReservation.DataAccess.Repositories;
using HotelReservation.Entities.Models;
using HotelReservation.UI.Forms;
using System.Windows.Forms;

namespace HotelReservation.UI
{
    public partial class ReservationForm : Form
    {
        private readonly BookingService _bookingService;
        private readonly GuestService _guestService;
        private readonly BookingGuestService _bookingGuestService;
        private readonly HotelService _hotelService;
        private readonly RoomService _roomService;
        private readonly RoomTypeService _roomTypeService;

        public ReservationForm()
        {
            InitializeComponent();
            var dbContext = new ApplicationDbContext();

            var bookingRepository = new BookingRepository(dbContext);
            _bookingService = new BookingService(bookingRepository);

            var guestRepository = new GuestRepository(dbContext);
            _guestService = new GuestService(guestRepository);

            var bookingGuestRepository = new BookingGuestRepository(dbContext);
            _bookingGuestService = new BookingGuestService(bookingGuestRepository);

            var hotelRepository = new HotelRepository(dbContext);
            _hotelService = new HotelService(hotelRepository);

            var roomRepository = new RoomRepository(dbContext);
            _roomService = new RoomService(roomRepository);

            var roomTypeRepository = new RoomTypeRepository(dbContext);
            _roomTypeService = new RoomTypeService(roomTypeRepository);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadHotels();

        }


        private void LoadHotels()
        {
            cmbHotels.ValueMember = "Id";
            cmbHotels.DisplayMember = "Name";
            cmbHotels.DataSource = _hotelService.GetAll();
            //SelectedIndexChanged event'i tetiklenir ve cagirilir.
            cmbHotels.SelectedIndexChanged += cmbHotels_SelectedIndexChanged;
        }

        Hotel selectedHotel;
        private void cmbHotels_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHotelRoomType();
        }
        Guid selectedHotelId;
        private void LoadHotelRoomType()
        {
            selectedHotelId = (Guid)cmbHotels.SelectedValue;

            //secili otelin odalarina erisilir.
            var rooms = _roomService.GetAll()
                .Where(r => r.Hotel.Id == selectedHotelId)
                .ToList();
            //odalarin type'ina erisilir Include methodu ile
            var roomTypes = rooms
                .Select(r => r.RoomType)
                .Where(rt => rt != null)
                .Distinct()
                .ToList();

            cmbRoomType.ValueMember = "Id";
            cmbRoomType.DisplayMember = "Name";
            cmbRoomType.DataSource = roomTypes;
            cmbRoomType.SelectedIndexChanged += cmbRoomType_SelectedIndexChanged;


        }
        Guid selectedRoomTypeId;
        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {

            selectedRoomTypeId = (Guid)cmbRoomType.SelectedValue;
            //MessageBox.Show(selectedRoomTypeId.ToString());
            LoadRoom();

        }

        private void LoadRoom()
        {
            var rooms = _roomService.GetAll()
                   .Where(r => r.RoomType.Id == selectedRoomTypeId && r.Hotel.Id == selectedHotelId)
                   .ToList();

            cmbRoom.ValueMember = "Id";
            cmbRoom.DisplayMember = "Id";
            cmbRoom.DataSource = rooms;
        }
        int selectedRoom;

        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedRoom = (int)cmbRoom.SelectedValue;
            //MessageBox.Show(selectedRoom.ToString());
        }

        public static List<Booking> bookingsList { get; set; } = new List<Booking>();

        private void btnReservation_Click(object sender, EventArgs e)
        {
            var selectedRoom = _roomService.GetAll()
                .FirstOrDefault(r => r.RoomTypeID == selectedRoomTypeId && r.HotelId == selectedHotelId);

            int numberOfRecords = (int)nmGuest.Value;
            using (GuestForm guestForm = new GuestForm(numberOfRecords))
            {
                if (guestForm.ShowDialog() == DialogResult.OK)
                {
                    foreach (var guest in GuestList.Guests)
                    {
                        Booking booking = new Booking()
                        {
                            CheckinDate = dtGiris.Value,
                            CheckoutDate = dtCikis.Value,
                            TotalPrice = selectedRoom.RoomType.PricePerNight,
                            RoomID = selectedRoom.Id,
                            Room = selectedRoom,
                            GuestID = guest.Id,
                            CreateAt = DateTime.Now,
                            UpdatedDate = DateTime.Now,
                            Guest = guest,
                        };

                        _bookingService.Create(booking);
                        //MessageBox.Show(booking.Guest.FirstName);
                        bookingsList.Add(booking);
                        var bookings = _bookingService.GetAll();
                        dtReservation.DataSource = bookings;
                        //MessageBox.Show(guest.FirstName.ToString());


                    }
                    foreach (var booking in bookingsList)
                    {
                        BookingGuest bookingGuest = new BookingGuest()
                        {
                            BookingID = booking.Id,
                            Booking = booking,
                            GuestID = booking.Guest.Id,
                            Guest = booking.Guest
                        };
                        _bookingGuestService.Create(bookingGuest);
                        //MessageBox.Show(bookingGuest.Guest.FirstName);
                    }

                }
            }
        }
        private void nmGuest_ValueChanged(object sender, EventArgs e)
        {

        }


    }
}
