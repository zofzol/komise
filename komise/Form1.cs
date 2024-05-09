using Microsoft.Data.SqlClient;
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
        public void WriteData(int id, string imie, string nazwisko)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO [dbo].[Table] ( indeks, imie, nazwisko) VALUES (@indeks,@imie, @nazwisko)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@indeks", id);
                command.Parameters.AddWithValue("@imie", imie);
               command.Parameters.AddWithValue("@nazwisko", nazwisko);

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
            WriteData(ind,imie,nazwisko);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ind = Int32.Parse(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            imie = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            nazwisko = textBox3.Text;
        }
    }
}
