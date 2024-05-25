using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace helinyeni
{
    public partial class Form4 : Form
    {
        private SqlConnection con = new SqlConnection(@"Server=LAPTOP-U8BQCNOH\SQLEXPRESS;Database=Library;Integrated Security=True;");
        private TextBox txtFirstName; // Ad TextBox'ı
        private TextBox txtLastName; // Soyad TextBox'ı
        private DateTimePicker dateTimePickerBirthDate; // Doğum Tarihi DateTimePicker kontrolü

        public Form4()
        {
            InitializeComponent();
            CreateControls(); // Kontrolleri oluştur
        }

        private void CreateControls()
        {
            // Ad TextBox
            txtFirstName = new TextBox
            {
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(200, 20)
            };
            this.Controls.Add(txtFirstName);

            // Soyad TextBox
            txtLastName = new TextBox
            {
                Location = new System.Drawing.Point(10, 40),
                Size = new System.Drawing.Size(200, 20)
            };
            this.Controls.Add(txtLastName);

            // Doğum Tarihi DateTimePicker kontrolü
            dateTimePickerBirthDate = new DateTimePicker
            {
                Location = new System.Drawing.Point(10, 70),
                Size = new System.Drawing.Size(200, 20)
            };
            this.Controls.Add(dateTimePickerBirthDate);

            // Ekleme Butonu
            Button btnAddStudent = new Button
            {
                Text = "Öğrenci Ekle",
                Location = new System.Drawing.Point(10, 100),
                Size = new System.Drawing.Size(200, 30)
            };
            btnAddStudent.Click += new EventHandler(button1_Click);
            this.Controls.Add(btnAddStudent);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Ogrenciler (Adi, Soyadi, DogumTarihi) VALUES (@Adi, @Soyadi, @DogumTarihi)", con);
                cmd.Parameters.AddWithValue("@Adi", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@Soyadi", txtLastName.Text);
                cmd.Parameters.AddWithValue("@DogumTarihi", dateTimePickerBirthDate.Value);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Öğrenci başarıyla eklendi!");
                }
                else
                {
                    MessageBox.Show("Öğrenci eklenemedi.");
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

        private void Form4_Load(object sender, EventArgs e)
        {
            // Form yüklenirken yapılacak özel işlemler buraya yazılabilir.
        }
    }
}


