using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace helinyeni
{
    public partial class Form5 : Form
    {
        private SqlConnection con = new SqlConnection(@"Server=LAPTOP-U8BQCNOH\SQLEXPRESS;Database=Library;Integrated Security=True;");

        private TextBox txtCustomerName; // Müşteri adı için TextBox
        private DateTimePicker dateTimePickerDate; // Rezervasyon tarihi için DateTimePicker
        private TextBox txtNotes; // Notlar için TextBox
        private Button btnSaveReservation; // Rezervasyonu kaydet butonu

        public Form5()
        {
            InitializeComponent();
            CreateControls(); // Kontrolleri yarat ve ekle
        }

        private void CreateControls()
        {
            // Müşteri adı TextBox
            txtCustomerName = new TextBox
            {
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(200, 20)
            };
            this.Controls.Add(txtCustomerName);

            // Rezervasyon tarihi DateTimePicker
            dateTimePickerDate = new DateTimePicker
            {
                Location = new System.Drawing.Point(10, 40),
                Size = new System.Drawing.Size(200, 20)
            };
            this.Controls.Add(dateTimePickerDate);

            // Notlar TextBox
            txtNotes = new TextBox
            {
                Location = new System.Drawing.Point(10, 70),
                Size = new System.Drawing.Size(200, 20)
            };
            this.Controls.Add(txtNotes);

            // Rezervasyonu kaydet butonu
            btnSaveReservation = new Button
            {
                Text = "Rezervasyon Kaydet",
                Location = new System.Drawing.Point(10, 100),
                Size = new System.Drawing.Size(200, 30)
            };
            btnSaveReservation.Click += new EventHandler(button1_Click); // Olay işleyicisini bağla
            this.Controls.Add(btnSaveReservation);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Rezervasyonlar (MusteriAdi, RezervasyonTarihi, Notlar) VALUES (@MusteriAdi, @RezervasyonTarihi, @Notlar)", con);
                cmd.Parameters.AddWithValue("@MusteriAdi", txtCustomerName.Text);
                cmd.Parameters.AddWithValue("@RezervasyonTarihi", dateTimePickerDate.Value.Date);
                cmd.Parameters.AddWithValue("@Notlar", txtNotes.Text);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Rezervasyon başarıyla eklendi!");
                }
                else
                {
                    MessageBox.Show("Rezervasyon eklenemedi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // Form yüklenirken yapılması gereken işlemler
        }
    }
}

