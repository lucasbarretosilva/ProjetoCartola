using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Form1 : Form
    {
        private const string ConnectionString = @"Data Source=LUCAS\SQLEXPRESS;Initial Catalog=Connection;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            SqlConnection con = new SqlConnection(@"Data Source=lucas\sqlexpress;Initial Catalog=Connection;Integrated Security=True");
            con.Open();
            
            SqlCommand cmd = new SqlCommand("insert into UserTable values (@Id,@NOmeJogador,@NomeTime,@Pontuacao)", con);
            //cmd.Connection = con;
            try
            {
                cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@NomeJogador", textBox2.Text);
                cmd.Parameters.AddWithValue("@NomeTime", textBox3.Text);

                cmd.Parameters.AddWithValue("@Pontuacao", float.Parse(textBox4.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cadastrado com sucesso");

            }
            catch (Exception ex) { 
            
              MessageBox.Show(ex.Message);
            
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox2.Focus();





        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LUCAS\SQLEXPRESS;Initial Catalog=Connection;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Usertable set NomeJogador=@NomeJogador, Pontuacao=@Pontuacao, NomeTime=@NomeTime where Id = @Id ", con);
            //cmd.Connection = con;
            try
            {
                cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@NomeJogador", textBox2.Text);
                cmd.Parameters.AddWithValue("@NomeTime", textBox3.Text);
                cmd.Parameters.AddWithValue("@Pontuacao", float.Parse(textBox4.Text));
                
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dados atualizados com sucesso");

            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
            
            con.Close();

            



        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LUCAS\SQLEXPRESS;Initial Catalog=Connection;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete UserTable where Id=@Id ", con);
            //cmd.Connection = con;
            try
            {
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Deletado com sucesso! ");
            }
            catch (Exception ex) {

                MessageBox.Show("Digite o nome de um jogador cadastrado", "Dados Incorretos");
            }
            finally
            {
                con.Close();
            }
            

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LUCAS\SQLEXPRESS;Initial Catalog=Connection;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from UserTable order by NomeJogador asc", con);

            cmd.ExecuteNonQuery();
            cmd.Parameters.AddWithValue("@NomeJogador",textBox2.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'connectionDataSet.UserTab'. Você pode movê-la ou removê-la conforme necessário.
           

        }
    }
}
