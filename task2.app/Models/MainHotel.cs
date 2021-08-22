using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace task2.app.Models
{
    public class MainHotel
    {
        public Hotel hotel { get; set;}
        public List<HotelRate> hotelRates { get; set;}

        public DataTable AsDataTable(){
            DataTable dataTable = new DataTable();
            dataTable.TableName = "mytable";

            dataTable.Columns.Add(new DataColumn("ARRIVAL_DATE"));
            dataTable.Columns.Add(new DataColumn("DEPARTURE_DATE"));
            dataTable.Columns.Add(new DataColumn("PRICE", System.Type.GetType("System.Double")));
            dataTable.Columns.Add(new DataColumn("CURRENCY"));
            dataTable.Columns.Add(new DataColumn("RATENAME"));
            dataTable.Columns.Add(new DataColumn("ADULTS", System.Type.GetType("System.Int32")));
            dataTable.Columns.Add(new DataColumn("BREAKFAST_INCLUDED", System.Type.GetType("System.Int32")));
            foreach (var rate in hotelRates)
            {
                object[] values = new object[]
                    {
                        rate.targetDay.Date.ToString("dd.MM.yy"), 
                        rate.targetDay.AddDays(rate.los).Date.ToString("dd.MM.yy"), 
                        rate.price.numericFloat, 
                        rate.price.currency, 
                        rate.rateName,
                        rate.adults,
                        rate.rateTags.FirstOrDefault().shape ? 1 : 0
                    };
                
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}