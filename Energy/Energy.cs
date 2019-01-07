using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Energy
{
    public class Energy
    {
        public static string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+Properties.Settings.Default.+"energy.mdb"; // строка подключения

        public static DataTable dt = new DataTable(); // основа для загрузки

        public static string QS; // значение BD стринг

        public static int QI; // значение BD инт

        public static void LoadComboBox(ComboBox bx, string text) // Загрузка объектов в ComboBox
        {
            OleDbDataAdapter dataAdapter = new  OleDbDataAdapter(text, ConnectionString);
            DataSet ds3 = new DataSet();
            dataAdapter.Fill(ds3);
            bx.DataSource = ds3.Tables[0];
            bx.DisplayMember = "naim";
            bx.ValueMember = "ID";
        }

        public static void LoadTable(string query) // загрузка таблиц
        {
            OleDbConnection con = new OleDbConnection(ConnectionString);
            con.Open();
            OleDbCommand command = new OleDbCommand(query, con);
            OleDbDataReader reader = command.ExecuteReader();
            dt.Reset();
            dt.Load(reader);
            con.Close();
        }

        public static void SearchDataGridView(DataGridView dg, string text) //Метод поиска
        {
            try
            {
                CurrencyManager cManager = dg.BindingContext[dg.DataSource, dg.DataMember] as CurrencyManager;
                cManager.SuspendBinding();
                cManager.ResumeBinding();
                for (int i = 0; i < dg.RowCount; i++)
                {
                    dg.Rows[i].Selected = false;
                }
                if (text == "")
                    for (int i = 0; i < dg.RowCount; i++)
                    {
                        dg.Rows[i].Selected = false;
                        dg.Rows[i].Visible = true;
                    }
                else
                {
                    for (int i = 0; i < dg.RowCount; i++)
                    {
                        dg.Rows[i].Selected = false;
                        for (int j = 0; j < dg.ColumnCount; j++)
                            if (dg.Rows[i].Cells[j].Value != null)

                                if (dg.Rows[i].Cells[j].Value.ToString().ToLower().Contains(text.ToLower()) || dg.Rows[i].Cells[j].Value.ToString().ToUpper().Contains(text.ToUpper()))
                                {
                                    dg.Rows[i].Selected = true;
                                    dg.Rows[i].Visible = true;
                                    break;
                                }
                                else
                                {
                                    dg.Rows[i].Selected = false;
                                    dg.Rows[i].Visible = false;
                                }
                    }
                }
            }
            catch
            {
                MessageBox.Show("При поиске произошла ошибка, для исправления выберите другую строку");
            }
        }

        public static void Query(string query) // основа для запросов к бд
        {
            OleDbConnection con = new  OleDbConnection(ConnectionString);
            con.Open();
            OleDbCommand cmd = new  OleDbCommand();
            cmd.CommandText = String.Format(query);
            cmd.Connection = con;
            cmd.ExecuteScalar();
        }

        public static void QueryString(string query) // метод выбора стринг
        {
            OleDbConnection con = new  OleDbConnection(ConnectionString);
            con.Open();
            OleDbCommand cmd = new  OleDbCommand();
            cmd.CommandText = String.Format(query);
            cmd.Connection = con;
            QS = (string)cmd.ExecuteScalar();
        }
       
        public static void QueryInt(string query) // метод выбора инт
        {
            OleDbConnection con = new  OleDbConnection(ConnectionString);
            con.Open();
            OleDbCommand cmd = new  OleDbCommand();
            cmd.CommandText = String.Format(query);
            cmd.Connection = con;
            QI = (int)cmd.ExecuteScalar();
        }
    }
}
