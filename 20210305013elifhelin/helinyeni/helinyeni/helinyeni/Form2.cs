using System;
using System.Windows.Forms;

namespace helinyeni
{
    public partial class Form2 : Form
    {
        private Button btnAddBooks;
        private Button btnAddStudent;
        private Button btnMakeReservation;

        public Form2()
        {
            InitializeComponent();

            // Butonlar doğru şekilde tanımlanmalı, burada örnek bir tanımlama
            btnAddBooks = new Button()
            {
                Text = "Add Books",
                Size = new System.Drawing.Size(100, 50),
                Location = new System.Drawing.Point(10, 10)
            };
            btnAddStudent = new Button()
            {
                Text = "Add Student",
                Size = new System.Drawing.Size(100, 50),
                Location = new System.Drawing.Point(120, 10)
            };
            btnMakeReservation = new Button()
            {
                Text = "Make Reservation",
                Size = new System.Drawing.Size(100, 50),
                Location = new System.Drawing.Point(230, 10)
            };

            this.Controls.Add(btnAddBooks);
            this.Controls.Add(btnAddStudent);
            this.Controls.Add(btnMakeReservation);

            // Butonların olay işleyicilerini burada ilişkilendir
            this.btnAddBooks.Click += new System.EventHandler(this.btnAddBooks_Click);
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            this.btnMakeReservation.Click += new System.EventHandler(this.btnMakeReservation_Click);
        }

        // Form3 (Kitap ekleme formunu) aç
        private void btnAddBooks_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(); // Form3 oluştur ve göster
            form3.Show();
            this.Hide(); // Mevcut formu gizle
        }

        // Form4 (Öğrenci ekleme formunu) aç
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(); // Form4 oluştur ve göster
            form4.Show();
            this.Hide(); // Mevcut formu gizle
        }

        // Form5 (Rezervasyon formunu) aç
        private void btnMakeReservation_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(); // Form5 oluştur ve göster
            form5.Show();
            this.Hide(); // Mevcut formu gizle
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}



