using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace helinyeni
{
    public partial class Form3 : Form
    {
        private SqlConnection con = new SqlConnection(@"Server=LAPTOP-U8BQCNOH\SQLEXPRESS;Database=Library;Integrated Security=True;");

        private TextBox txtISBN;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private Button btnAddBook;

        public Form3()
        {
            InitializeComponent();
            CreateControls();
        }

        private void CreateControls()
        {
            // ISBN TextBox
            txtISBN = new TextBox
            {
                Location = new Point(10, 10),
                Size = new Size(200, 20)
            };
            this.Controls.Add(txtISBN);

            // Title TextBox
            txtTitle = new TextBox
            {
                Location = new Point(10, 40),
                Size = new Size(200, 20)
            };
            this.Controls.Add(txtTitle);

            // Author TextBox
            txtAuthor = new TextBox
            {
                Location = new Point(10, 70),
                Size = new Size(200, 20)
            };
            this.Controls.Add(txtAuthor);

            // Add Book Button
            btnAddBook = new Button
            {
                Text = "Add Book",
                Location = new Point(10, 100),
                Size = new Size(200, 30)
            };
            btnAddBook.Click += new EventHandler(button1_Click);
            this.Controls.Add(btnAddBook);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Kitaplar (ISBN, Baslik, Yazar) VALUES (@ISBN, @Baslik, @Yazar)", con);
                cmd.Parameters.AddWithValue("@ISBN", txtISBN.Text);
                cmd.Parameters.AddWithValue("@Baslik", txtTitle.Text);
                cmd.Parameters.AddWithValue("@Yazar", txtAuthor.Text);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Veri başarıyla eklendi!");
                }
                else
                {
                    MessageBox.Show("Veri eklenemedi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }
    }
}

