﻿namespace HotelReservation.UI
{
    partial class ReservationForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbRoomType = new ComboBox();
            dtGiris = new DateTimePicker();
            dtCikis = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            nmGuest = new NumericUpDown();
            label4 = new Label();
            label5 = new Label();
            btnReservation = new Button();
            label11 = new Label();
            cmbHotels = new ComboBox();
            dtReservation = new DataGridView();
            btnDelete = new Button();
            btnResUpdate = new Button();
            label1 = new Label();
            cmbRoom = new ComboBox();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)nmGuest).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtReservation).BeginInit();
            SuspendLayout();
            // 
            // cmbRoomType
            // 
            cmbRoomType.FormattingEnabled = true;
            cmbRoomType.Location = new Point(573, 214);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(530, 40);
            cmbRoomType.TabIndex = 1;
            cmbRoomType.SelectedIndexChanged += cmbRoomType_SelectedIndexChanged;
            // 
            // dtGiris
            // 
            dtGiris.Location = new Point(573, 454);
            dtGiris.Name = "dtGiris";
            dtGiris.Size = new Size(530, 39);
            dtGiris.TabIndex = 2;
            // 
            // dtCikis
            // 
            dtCikis.Location = new Point(573, 567);
            dtCikis.Name = "dtCikis";
            dtCikis.Size = new Size(530, 39);
            dtCikis.TabIndex = 3;
            // 
            // label2
            // 
            label2.Location = new Point(573, 404);
            label2.Name = "label2";
            label2.Size = new Size(463, 38);
            label2.TabIndex = 0;
            label2.Text = "Giriş Tarihi:";
            // 
            // label3
            // 
            label3.Location = new Point(573, 513);
            label3.Name = "label3";
            label3.Size = new Size(463, 38);
            label3.TabIndex = 0;
            label3.Text = "Cıkış Tarihi:";
            // 
            // nmGuest
            // 
            nmGuest.Location = new Point(573, 724);
            nmGuest.Name = "nmGuest";
            nmGuest.Size = new Size(180, 39);
            nmGuest.TabIndex = 4;
            nmGuest.ValueChanged += nmGuest_ValueChanged;
            // 
            // label4
            // 
            label4.Location = new Point(573, 670);
            label4.Name = "label4";
            label4.Size = new Size(463, 38);
            label4.TabIndex = 0;
            label4.Text = "Misafir Sayısı:";
            // 
            // label5
            // 
            label5.Location = new Point(573, 159);
            label5.Name = "label5";
            label5.Size = new Size(463, 38);
            label5.TabIndex = 0;
            label5.Text = "Oda Tipi Seçiniz:";
            // 
            // btnReservation
            // 
            btnReservation.Location = new Point(140, 791);
            btnReservation.Name = "btnReservation";
            btnReservation.Size = new Size(244, 83);
            btnReservation.TabIndex = 6;
            btnReservation.Text = "Rezervasyon Oluştur";
            btnReservation.UseVisualStyleBackColor = true;
            btnReservation.Click += btnReservation_Click;
            // 
            // label11
            // 
            label11.Location = new Point(573, 57);
            label11.Name = "label11";
            label11.Size = new Size(463, 38);
            label11.TabIndex = 0;
            label11.Text = "Otel Seçiniz:";
            // 
            // cmbHotels
            // 
            cmbHotels.FormattingEnabled = true;
            cmbHotels.Location = new Point(573, 107);
            cmbHotels.Name = "cmbHotels";
            cmbHotels.Size = new Size(530, 40);
            cmbHotels.TabIndex = 1;
            cmbHotels.SelectedIndexChanged += cmbHotels_SelectedIndexChanged;
            // 
            // dtReservation
            // 
            dtReservation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtReservation.Location = new Point(33, 880);
            dtReservation.Name = "dtReservation";
            dtReservation.RowHeadersWidth = 62;
            dtReservation.Size = new Size(1556, 325);
            dtReservation.TabIndex = 7;
            dtReservation.SelectionChanged += dtReservation_SelectionChanged;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(539, 791);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(244, 83);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Rezervasyon Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnResUpdate
            // 
            btnResUpdate.Location = new Point(961, 791);
            btnResUpdate.Name = "btnResUpdate";
            btnResUpdate.Size = new Size(244, 83);
            btnResUpdate.TabIndex = 6;
            btnResUpdate.Text = "Rezervasyon Güncelle";
            btnResUpdate.UseVisualStyleBackColor = true;
            btnResUpdate.Click += btnResUpdate_Click;
            // 
            // label1
            // 
            label1.Location = new Point(573, 266);
            label1.Name = "label1";
            label1.Size = new Size(463, 38);
            label1.TabIndex = 0;
            label1.Text = "Oda Seçiniz:";
            // 
            // cmbRoom
            // 
            cmbRoom.FormattingEnabled = true;
            cmbRoom.Location = new Point(573, 328);
            cmbRoom.Name = "cmbRoom";
            cmbRoom.Size = new Size(530, 40);
            cmbRoom.TabIndex = 8;
            cmbRoom.SelectedIndexChanged += cmbRoom_SelectedIndexChanged;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(1328, 791);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(205, 83);
            btnSearch.TabIndex = 9;
            btnSearch.Text = "Rezervasyon Ara";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // ReservationForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1702, 1217);
            Controls.Add(btnSearch);
            Controls.Add(cmbRoom);
            Controls.Add(dtReservation);
            Controls.Add(btnResUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnReservation);
            Controls.Add(nmGuest);
            Controls.Add(dtCikis);
            Controls.Add(dtGiris);
            Controls.Add(cmbHotels);
            Controls.Add(cmbRoomType);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label11);
            Controls.Add(label1);
            Controls.Add(label5);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "ReservationForm";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)nmGuest).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtReservation).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ComboBox cmbRoomType;
        private DateTimePicker dtGiris;
        private DateTimePicker dtCikis;
        private Label label2;
        private Label label3;
        private NumericUpDown nmGuest;
        private Label label4;
        private Label label5;
        private Button btnReservation;
        private Label label11;
        private ComboBox cmbHotels;
        private DataGridView dtReservation;
        private Button btnDelete;
        private Button btnResUpdate;
        private Label label1;
        private ComboBox cmbRoom;
        private Button btnSearch;
    }
}
