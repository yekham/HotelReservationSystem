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
            dtReservation.SelectionChanged += dtReservation_SelectionChanged;

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

        Room selectedRoom;
        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRoom.SelectedValue != null)
            {
                int selectedRoomId = (int)cmbRoom.SelectedValue;
                selectedRoom = _roomService.GetByID(selectedRoomId);
            }
        }

        //public static List<Booking> bookingsList { get; set; } = new List<Booking>();

        private void btnReservation_Click(object sender, EventArgs e)
        {
/*            var selectedRoom = _roomService.GetAll()
                .FirstOrDefault(r => r.RoomTypeID == selectedRoomTypeId && r.HotelId == selectedHotelId);*/

            int numberOfRecords = (int)nmGuest.Value;
            if (numberOfRecords == 0)
            {
                MessageBox.Show("Lütfen en az bir misafir sayýsý girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                var existingRoomBooking = _bookingService.GetAll()
                .FirstOrDefault(b => b.RoomID == selectedRoom.Id &&
                              ((dtGiris.Value >= b.CheckinDate && dtGiris.Value < b.CheckoutDate) ||
                               (dtCikis.Value > b.CheckinDate && dtCikis.Value <= b.CheckoutDate) ||
                               (dtGiris.Value <= b.CheckinDate && dtCikis.Value >= b.CheckoutDate)));

                if (existingRoomBooking != null)
                {
                    MessageBox.Show("Seçilen tarihler arasýnda bu oda için zaten bir rezervasyon var. Lütfen farklý tarihler seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                using (GuestForm guestForm = new GuestForm(numberOfRecords))
                {
                    if (guestForm.ShowDialog() == DialogResult.OK)
                    {
                        foreach (var guest in GuestList.Guests)
                        {
                            var numberOfDays = (dtCikis.Value - dtGiris.Value).Days;
                            var totalPrice = numberOfDays * numberOfRecords * selectedRoom.RoomType.PricePerNight;
                            Booking booking = new Booking()
                            {
                                CheckinDate = dtGiris.Value,
                                CheckoutDate = dtCikis.Value,
                                TotalPrice = totalPrice,
                                RoomID = selectedRoom.Id,
                                Room = selectedRoom,
                                GuestID = guest.Id,
                                CreateAt = DateTime.Now,
                                UpdatedDate = DateTime.Now,
                                Guest = guest,
                            };

                            _bookingService.Create(booking);
                            //MessageBox.Show(booking.Guest.FirstName);
                            //bookingsList.Add(booking);
                            LoadBookings();
                            //MessageBox.Show(guest.FirstName.ToString());


                        }
                        /* 
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
                            //
                        }*/
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                GuestList.Guests.Clear();

            }


        }
        Booking selectedBooking;
        private void dtReservation_SelectionChanged(object sender, EventArgs e)
        {
            if (dtReservation.SelectedRows.Count > 0)
            {
                var bookingId = (Guid)dtReservation.SelectedRows[0].Cells["Id"].Value;
                selectedBooking = _bookingService.GetByID(bookingId);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedBooking != null)
            {
                var deleteResult = MessageBox.Show("Bu rezervasyonu silmek istediðinizden emin misiniz?",
                                                     "Onay",
                                                     MessageBoxButtons.YesNo);
                if (deleteResult == DialogResult.Yes)
                {
                    try
                    {
                        _bookingService.Delete(selectedBooking.Id);
                        //bookingsList.Remove(selectedBooking);

                        LoadBookings();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Silme iþlemi sýrasýnda bir hata oluþtu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediðiniz rezervasyonu seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void LoadBookings()
        {
            var bookings = _bookingService.GetAll();

            dtReservation.DataSource = null;
            dtReservation.DataSource = bookings;

            // Kolon baþlýklarýný düzenleme
            dtReservation.Columns["CheckinDate"].HeaderText = "Giriþ Tarihi";
            dtReservation.Columns["CheckoutDate"].HeaderText = "Çýkýþ Tarihi";
            dtReservation.Columns["TotalPrice"].HeaderText = "Toplam Fiyat";
            dtReservation.Columns["RoomID"].HeaderText = "Oda Numarasý";
            dtReservation.Columns["CreateAt"].HeaderText = "Oluþturma Tarihi";

            // Gereksiz kolonlarý gizleme
            dtReservation.Columns["IsDeleted"].Visible = false;
            dtReservation.Columns["Room"].Visible = false;
            dtReservation.Columns["Guest"].Visible = false;
            dtReservation.Columns["UpdatedDate"].Visible = false;
            dtReservation.Columns["BookingGuests"].Visible = false;
            dtReservation.Columns["GuestID"].Visible = false;
            dtReservation.Columns["Id"].Visible = false;



            // Tarih formatlarýný ayarlama
            dtReservation.Columns["CheckinDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtReservation.Columns["CheckoutDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtReservation.Columns["CreateAt"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";


            // Alternatif satýr renkleri
            dtReservation.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Kolon geniþliklerini ayarlama (isteðe baðlý)
            dtReservation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }


        private void btnResUpdate_Click(object sender, EventArgs e)
        {
            if (selectedBooking != null)
            {
                try
                {
                    selectedBooking.CheckinDate = dtGiris.Value;
                    selectedBooking.CheckoutDate = dtCikis.Value;
                    selectedBooking.RoomID = (int)cmbRoom.SelectedValue;
                    selectedBooking.UpdatedDate = DateTime.Now;

                    _bookingService.Update(selectedBooking);
                    LoadBookings();
                    MessageBox.Show("Rezervasyon baþarýyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme iþlemi sýrasýnda bir hata oluþtu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediðiniz rezervasyonu seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public List<Booking> SearchBookings(DateTime? checkinDate, DateTime? checkoutDate, int? roomNumber)
        {
            var bookings = _bookingService.GetAll();


            if (checkinDate.HasValue)
            {
                bookings = bookings.Where(b => b.CheckinDate.Date == checkinDate.Value.Date);
            }

            if (checkoutDate.HasValue)
            {
                bookings = bookings.Where(b => b.CheckoutDate.Date == checkoutDate.Value.Date);
            }

            if (roomNumber.HasValue)
            {
                bookings = bookings.Where(b => b.RoomID == roomNumber.Value);
            }

            return bookings.ToList();
        }




        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime? checkinDate = dtGiris.Value.Date;
            DateTime? checkoutDate = dtCikis.Value.Date;
            int? roomNumber = (int)cmbRoom.SelectedValue; ;


            var searchingResult = SearchBookings(checkinDate, checkoutDate, roomNumber);

            dtReservation.DataSource = searchingResult;
        }
        private void nmGuest_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
