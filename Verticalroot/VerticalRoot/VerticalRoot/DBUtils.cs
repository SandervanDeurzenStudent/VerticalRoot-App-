﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace VerticalRoot
{
    class DBUtils
    {
        //get all the plants connected to the given user
        public List<int> getAllPlants(int id)
        {
            DB word = new DB();
            string selectedPlant = "SELECT * FROM tbl_datadetails WHERE plant_id = 1;";
            MySqlCommand command = new MySqlCommand(selectedPlant, word.GetConnection());
            List<int> plantLists = new List<int>(5);
            using (MySqlDataReader plantValues = command.ExecuteReader())

                if (plantValues.HasRows)
                {
                    while (plantValues.Read())
                    {
                        int currentPlantCelsius = Convert.ToInt32(plantValues["celsius"]);
                        int currentPlantLdr = Convert.ToInt32(plantValues["ldr"]);
                        int currentPlantHumidty = Convert.ToInt32(plantValues["humidity"]);
                        int currentPlantMoisture = Convert.ToInt32(plantValues["moisture"]);
                        int currentPlantWateruse = Convert.ToInt32(plantValues["water_use"]);
                        plantLists.Add(currentPlantLdr);
                        plantLists.Add(currentPlantHumidty);
                        plantLists.Add(currentPlantCelsius);
                        plantLists.Add(currentPlantWateruse);
                        plantLists.Add(currentPlantMoisture);
                    }
                }
            // return list met al die shit hierboven
            return plantLists;
        }

        //get all the plantsdetails(with gesette waardes) for the user and specific clicked plant.
        public List<int> getAllPlantDetails(int uid, int plant_id)
        {
            string selectPlant = "SELECT * FROM tbl_plantdetails WHERE user_id = 2 AND plant_id = 1;";

            DB word = new DB();
            MySqlCommand command = new MySqlCommand(selectPlant, word.GetConnection());
            List<int> plantLists = new List<int>(5);
            using (MySqlDataReader plantValues = command.ExecuteReader())

                if (plantValues.HasRows)
                {
                    while (plantValues.Read())
                    {
                        int currentPlantLdr = Convert.ToInt32(plantValues["set_ldr"]);
                        int currentPlantHumidty = Convert.ToInt32(plantValues["set_humidity"]);
                        int currentPlantCelsius = Convert.ToInt32(plantValues["set_celsius"]);
                        int currentPlantWateruse = Convert.ToInt32(plantValues["set_water_use"]);
                        int currentPlantMoisture = Convert.ToInt32(plantValues["set_moisture"]);
                        plantLists.Add(currentPlantLdr);
                        plantLists.Add(currentPlantHumidty);
                        plantLists.Add(currentPlantCelsius);
                        plantLists.Add(currentPlantWateruse);
                        plantLists.Add(currentPlantMoisture);
                    }
                }
            return plantLists;
        }

        public void CheckAmount()
        {
            try
            {
                DB db = new DB();
                db.openConnection();
                List<int> currentPlantValues = getAllPlants(1);
                List<int> SetplantValues = getAllPlantDetails(2, 2);

                //checking the  ldr
                if (currentPlantValues[1] == SetplantValues[1])
                {
                    System.Windows.Forms.MessageBox.Show("Tes555555t");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Test");
                }

                //checking the  Humidty
                if (currentPlantValues[2] == SetplantValues[2])
                {
                    System.Windows.Forms.MessageBox.Show("Tes555555t");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Test");
                }

                //checking the  celsius
                if (currentPlantValues[3] == SetplantValues[3])
                {
                    System.Windows.Forms.MessageBox.Show("Tes555555t");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Test");
                }

                //checking the  water_use
                if (currentPlantValues[4] == SetplantValues[4])
                {
                    System.Windows.Forms.MessageBox.Show("Tes555555t");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Test");
                }

                //checking the moisture
                if (currentPlantValues[5] == SetplantValues[5])
                {
                    System.Windows.Forms.MessageBox.Show("Tes555555t");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Test");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
