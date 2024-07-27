namespace HotelReservation.UI.Forms
{
    partial class GuestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnGuest = new Button();
            txtMail = new TextBox();
            txtTel = new TextBox();
            txtAdress = new TextBox();
            txtSur = new TextBox();
            txtName = new TextBox();
            dtBirth = new DateTimePicker();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnGuest
            // 
            btnGuest.Location = new Point(258, 895);
            btnGuest.Name = "btnGuest";
            btnGuest.Size = new Size(238, 88);
            btnGuest.TabIndex = 20;
            btnGuest.Text = "Misafiri Kaydet";
            btnGuest.UseVisualStyleBackColor = true;
            btnGuest.Click += btnGuest_Click;
            // 
            // txtMail
            // 
            txtMail.Location = new Point(33, 803);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(463, 39);
            txtMail.TabIndex = 15;
            // 
            // txtTel
            // 
            txtTel.Location = new Point(33, 655);
            txtTel.Name = "txtTel";
            txtTel.Size = new Size(463, 39);
            txtTel.TabIndex = 16;
            // 
            // txtAdress
            // 
            txtAdress.Location = new Point(33, 495);
            txtAdress.Name = "txtAdress";
            txtAdress.Size = new Size(463, 39);
            txtAdress.TabIndex = 17;
            // 
            // txtSur
            // 
            txtSur.Location = new Point(33, 211);
            txtSur.Name = "txtSur";
            txtSur.Size = new Size(463, 39);
            txtSur.TabIndex = 18;
            // 
            // txtName
            // 
            txtName.Location = new Point(33, 84);
            txtName.Name = "txtName";
            txtName.Size = new Size(463, 39);
            txtName.TabIndex = 19;
            // 
            // dtBirth
            // 
            dtBirth.Location = new Point(33, 354);
            dtBirth.Name = "dtBirth";
            dtBirth.Size = new Size(463, 39);
            dtBirth.TabIndex = 14;
            // 
            // label10
            // 
            label10.Location = new Point(33, 300);
            label10.Name = "label10";
            label10.Size = new Size(463, 38);
            label10.TabIndex = 8;
            label10.Text = "Doğum Tarihi:";
            // 
            // label9
            // 
            label9.Location = new Point(33, 740);
            label9.Name = "label9";
            label9.Size = new Size(463, 38);
            label9.TabIndex = 9;
            label9.Text = "Mail Adresi:";
            // 
            // label8
            // 
            label8.Location = new Point(33, 592);
            label8.Name = "label8";
            label8.Size = new Size(463, 38);
            label8.TabIndex = 10;
            label8.Text = "Telefon Numarası:";
            // 
            // label7
            // 
            label7.Location = new Point(33, 432);
            label7.Name = "label7";
            label7.Size = new Size(463, 38);
            label7.TabIndex = 11;
            label7.Text = "Adres:";
            // 
            // label6
            // 
            label6.Location = new Point(33, 160);
            label6.Name = "label6";
            label6.Size = new Size(463, 38);
            label6.TabIndex = 12;
            label6.Text = "Soyisim:";
            // 
            // label1
            // 
            label1.Location = new Point(33, 33);
            label1.Name = "label1";
            label1.Size = new Size(463, 38);
            label1.TabIndex = 13;
            label1.Text = "İsim:";
            // 
            // BookingForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 1050);
            Controls.Add(btnGuest);
            Controls.Add(txtMail);
            Controls.Add(txtTel);
            Controls.Add(txtAdress);
            Controls.Add(txtSur);
            Controls.Add(txtName);
            Controls.Add(dtBirth);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            Margin = new Padding(4, 4, 4, 4);
            Name = "BookingForm";
            Text = "BookingForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGuest;
        private TextBox txtMail;
        private TextBox txtTel;
        private TextBox txtAdress;
        private TextBox txtSur;
        private TextBox txtName;
        private DateTimePicker dtBirth;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label1;
    }
}