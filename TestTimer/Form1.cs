// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TestTimer
{
    public partial class Form1 : Form
    {
        // Таймеры и переменные таймеров
        Timer timer = new System.Windows.Forms.Timer();
        int tit = 0;

        public Form1()
        {
            InitializeComponent();

            // Определение исполнительной функции и времени
            timer.Interval = 1000;
            timer.Tick += new EventHandler(HourProcedure);

        }

        private void Timer5m_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void InsertJournal(string text)
        {
            
        }

        private static void OnTimedEvent(Object myObject, EventArgs myEventArgs)
        {
            
        }

        private static void Minute5Insert(Object myObject, EventArgs myEventArgs)
        {
        
        }

        private static void Minute2chInsert(Object myObject, EventArgs myEventArgs)
        {
            
        }

        private static void HourProcedure(Object myObject, EventArgs myEventArgs)
        {
            try
            {
                if (DateTime.Now.Hour % 1 == 0 && DateTime.Now.Second == 0)
                {
                    // экземпляр класса типа SqlConnection
                    SqlConnection cn; 
                    
                    // строка соединения с базой данных
                    string ConnStr = @"Data Source=DNSSHERSHNEVKA\SQLSERVERDNS1103;Initial Catalog = DNS; Integrated Security = True; User ID=sa;Password=sqladmin;";

                    #region Область данных по тегам

                    using (cn = new SqlConnection(ConnStr))
                    {
                        var sqlCmd = new SqlCommand("dbo.CreateReports", cn);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@repdattim", null);
                        sqlCmd.Parameters.AddWithValue("@kind", 3);

                        cn.Open();
                        sqlCmd.ExecuteNonQuery();
                        cn.Close();
                    }

                    #endregion

                    cn.Close(); // закрыть источник данных

                }
                if (DateTime.Now.Hour % 2 == 0 && DateTime.Now.Second == 0)
                {
                    // экземпляр класса типа SqlConnection
                    SqlConnection cn; 

                    // строка соединения с базой данных
                    string ConnStr = @"Data Source=DNSSHERSHNEVKA\SQLSERVERDNS1103;Initial Catalog = DNS; Integrated Security = True; User ID=sa;Password=sqladmin;";

                    #region Область данных по тегам

                    using (cn = new SqlConnection(ConnStr))
                    {
                        var sqlCmd = new SqlCommand("dbo.CreateReports2H", cn);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@repdattim", null);
                        sqlCmd.Parameters.AddWithValue("@kind", 3);

                        cn.Open();
                        sqlCmd.ExecuteNonQuery();
                        cn.Close();
                    }

                    #endregion

                    cn.Close(); // закрыть источник данных

                }
            }
            catch (Exception ex)
            {
                
            }
        }

        // Управление таймером
        private void button1_Click(object sender, EventArgs e)
        {
            if (tit == 0)
            {
                //InsertJournal("Запуск процедурного процесса");
                timer.Enabled = true;
                timer.Start();
                tit = 1;
                // Включаем и переходим на выполнение активации хранимых процедур в sql из процедуры HourProcedure
            }
            else
            {

                timer.Stop();
                timer.Enabled = false;
                tit = 0;
                //InsertJournal("Остановка процедурного процесса");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        // Выход
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _ButtonInsertTime_Click(object sender, EventArgs e)
        {
           
        }

        private void _ButtonInsert2ch_Click(object sender, EventArgs e)
        {
  
        }

        // Скрытие формы
        private void _ButtonHide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }

}
