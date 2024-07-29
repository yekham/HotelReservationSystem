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
                MessageBox.Show("L�tfen en az bir misafir say�s� girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Se�ilen tarihler aras�nda bu oda i�in zaten bir rezervasyon var. L�tfen farkl� tarihler se�in.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var deleteResult = MessageBox.Show("Bu rezervasyonu silmek istedi�inizden emin misiniz?",
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
                        MessageBox.Show("Silme i�lemi s�ras�nda bir hata olu�tu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("L�tfen silmek istedi�iniz rezervasyonu se�in.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void LoadBookings()
        {
            var bookings = _bookingService.GetAll();

            dtReservation.DataSource = null;
            dtReservation.DataSource = bookings;

            // Kolon ba�l�klar�n� d�zenleme
            dtReservation.Columns["CheckinDate"].HeaderText = "Giri� Tarihi";
            dtReservation.Columns["CheckoutDate"].HeaderText = "��k�� Tarihi";
            dtReservation.Columns["TotalPrice"].HeaderText = "Toplam Fiyat";
            dtReservation.Columns["RoomID"].HeaderText = "Oda Numaras�";
            dtReservation.Columns["CreateAt"].HeaderText = "Olu�turma Tarihi";

            // Gereksiz kolonlar� gizleme
            dtReservation.Columns["IsDeleted"].Visible = false;
            dtReservation.Columns["Room"].Visible = false;
            dtReservation.Columns["Guest"].Visible = false;
            dtReservation.Columns["UpdatedDate"].Visible = false;
            dtReservation.Columns["BookingGuests"].Visible = false;
            dtReservation.Columns["GuestID"].Visible = false;
            dtReservation.Columns["Id"].Visible = false;



            // Tarih formatlar�n� ayarlama
            dtReservation.Columns["CheckinDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtReservation.Columns["CheckoutDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtReservation.Columns["CreateAt"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";


            // Alternatif sat�r renkleri
            dtReservation.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Kolon geni�liklerini ayarlama (iste�e ba�l�)
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
                    MessageBox.Show("Rezervasyon ba�ar�yla g�ncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("G�ncelleme i�lemi s�ras�nda bir hata olu�tu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("L�tfen g�ncellemek istedi�iniz rezervasyonu se�in.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
