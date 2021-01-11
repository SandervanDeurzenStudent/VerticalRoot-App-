﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace VerticalRoot
{
    /// <summary>
    /// Interaction logic for plantdetail.xaml
    /// </summary>
    public partial class plantdetail : Window
    {
        public int index { get; private set; }

        public plantdetail()
        {
            InitializeComponent();

            try
            {
                DB db = new DB();
                db.openConnection();
                int uid = MainWindow.userId;
                int pid = CropList.plantID;
                Login login = new Login();
                
                string mysql = "SELECT * FROM tbl_plantdetails WHERE user_id = @uid AND plant_id = @pid;";

                MySqlCommand command = new MySqlCommand(mysql, db.GetConnection());
                command.Parameters.Add("@uid", MySqlDbType.VarChar).Value = uid;
                command.Parameters.Add("@pid", MySqlDbType.VarChar).Value = pid;
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataTable dtt = new DataTable();
                da.Fill(dtt);
                DataGrid dg = new DataGrid();
                dt_plantdetail.ItemsSource = dtt.AsDataView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {

            foreach (DataRowView row in dt_plantdetail.SelectedItems)
            {
                DB db = new DB();
                string text = row.Row.ItemArray[0].ToString();

                int plantID = Convert.ToInt32(row.Row.ItemArray[0]);

                string Query = "UPDATE tbl_plantdetails SET set_humidity = " + row.Row.ItemArray[4] + ", set_celsius= " + row.Row.ItemArray[5] + ", set_water_use = " + row.Row.ItemArray[6] + ", set_moisture = " + row.Row.ItemArray[7] + " WHERE plant_id = " + plantID;
                // plant_name = " + row.Row.ItemArray[3] + ", 
                MySqlCommand command = new MySqlCommand(Query, db.GetConnection());
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataTable dtt = new DataTable();
                da.Fill(dtt);
                dt_plantdetail.Items.Refresh();
                MessageBox.Show(Query);
            }
        }
    }
}