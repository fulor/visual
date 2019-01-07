using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Energy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (metroTabControl1.SelectedIndex)
            {
                case 0:
                    Table1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 13.5f, FontStyle.Regular | FontStyle.Regular);
                    Energy.LoadTable(@"SELECT ЗаявкиПредприятие.Код, ЗаявкиПредприятие.ДатаЗаявки as Дата, ЗаявкиПредприятие.ПричинаЗаявки as Причина, [Фамиилия]+' '+[Имя] AS Добавил, ЗаявкиПредприятие.Статус as Статус FROM ЗаявкиПредприятие, Сотрудники;");
                    Table1.DataSource = Energy.dt;
                    Table1.Columns[0].Visible = false;
                    break;
                //case 1:
                //    Energy.LoadTable(@"");
                //    break;
                //case 2:
                //    Energy.LoadTable(@"");
                //    break;
                //case 3:
                //    Energy.LoadTable(@"");
                //    break;
                //case 4:
                //    Energy.LoadTable(@"");
                //    break;
                //case 5:
                //    Energy.LoadTable(@"");
                //    break;
                //case 6:
                //    Energy.LoadTable(@"");
                //    break;
                //case 7:
                //    Energy.LoadTable(@"");
                //    break;
            }
        }

        private void metroTabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
