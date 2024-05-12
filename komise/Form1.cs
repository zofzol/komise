using Microsoft.Data.SqlClient;
using System.Reflection.Metadata;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace komise
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void Form1_Load(object sender, EventArgs e)
        {

        }

        int ind = 0;
        string imie = "";
        string nazwisko = "";
        int semestr = 0;
        int rok = 0;
        string kierunek = "";
        int stopien = 0;
        string przedmiot = "";
        int punkty = 0;
        string prowadzacy = "";
        string uzasadnienie = "";
        string data = "";
        string decyzja = "";
        string sklad = "";
        string data2 = "";


        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=model;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public void ReadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users";
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int userId = reader.GetInt32(0); // Assuming Id is the first column
                        string userName = reader.GetString(1); // Assuming Name is the second column
                        Console.WriteLine($"User Id: {userId}, Name: {userName}");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        public void WriteData(int id, string imie, string nazwisko, int semestr, int rok, string kierunek, int stopien, string przedmiot, int punkty, string prowadzacy, string uzasadnienie, string data, string decyzja, string sklad, string data2)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO [dbo].[Table] ( indeks, imie, nazwisko, semestr, rok, kierunek, stopien, przedmiot, punkty, prowadzacy, uzasadnienie, data, decyzja, sklad, data2) VALUES (@indeks,@imie, @nazwisko, @semestr, @rok, @kierunek, @stopien, @przedmiot, @punkty, @prowadzacy, @uzasadnienie, @data, @decyzja, @sklad, @data2)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@indeks", id);
                command.Parameters.AddWithValue("@imie", imie);
                command.Parameters.AddWithValue("@nazwisko", nazwisko);
                command.Parameters.AddWithValue("@semestr", semestr);
                command.Parameters.AddWithValue("@rok", rok);
                command.Parameters.AddWithValue("@kierunek", kierunek);
                command.Parameters.AddWithValue("@stopien", stopien);
                command.Parameters.AddWithValue("@przedmiot", przedmiot);
                command.Parameters.AddWithValue("@punkty", punkty);
                command.Parameters.AddWithValue("@prowadzacy", prowadzacy);
                command.Parameters.AddWithValue("@uzasadnienie", uzasadnienie);
                command.Parameters.AddWithValue("@data", data);
                command.Parameters.AddWithValue("@decyzja", decyzja);
                command.Parameters.AddWithValue("@sklad", sklad);
                command.Parameters.AddWithValue("@data2", data2);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} row(s) inserted.");
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WriteData(ind, imie, nazwisko, semestr, rok, kierunek, stopien, przedmiot, punkty, prowadzacy, uzasadnienie, data, decyzja, sklad, data2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ind = int.Parse(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            imie = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            nazwisko = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            semestr = int.Parse(textBox4.Text);

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            rok = int.Parse(textBox5.Text);

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            kierunek = textBox6.Text;

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            stopien = int.Parse(textBox7.Text);

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            przedmiot = textBox8.Text;

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            punkty = int.Parse(textBox9.Text);

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            prowadzacy = textBox10.Text;

        }

        private void label11_Click(object sender, EventArgs e)
        {
            uzasadnienie = textBox11.Text;

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            data = textBox12.Text;

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            decyzja = textBox13.Text;

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            sklad = textBox14.Text;

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            data2 = textBox11.Text;

        }
    }
}