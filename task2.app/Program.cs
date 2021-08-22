using System;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using task2.app.Models;
using task2.app.Services;

namespace task2.app
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "task 2 - hotelrates.json";
            var mainHotel = new JsonMapper(fileName).Deserialize<MainHotel>(new MainHotel());

            DataTable mainHotelTable = mainHotel.AsDataTable();

            var reportService = new DocumentService("HotelRateReport");
            reportService.LoadFromDataTable(mainHotelTable);
            reportService.Dispose();
        }
    }
}
