using System.Data;
using SombrerosLaPatrona.DataBaseAccess;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SombrerosLaPatrona.Dtos;

namespace SombrerosLaPatrona.Pages

{
    public class MochilasModel : PageModel
    { 
        private DataBase dataBase { get; set; } 
        public List<DtoProducto> Mochilas { set; get; }         
        public MochilasModel()
        {
            Mochilas = new List<DtoProducto>();
            dataBase = new DataBase(); 
        }
        public void OnGet()
        {
            DataSet dataSet2 = dataBase.EjecutarQuery($"SELECT * FROM PRODUCTOS WHERE ID_TIPO_PRODUCTO = 4");

            if (dataSet2 != null && dataSet2.Tables.Count > 0 && dataSet2.Tables[0].Rows.Count > 0)
            {
                Mochilas = new List<DtoProducto>();
                for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
                {
                    Mochilas.Add(new DtoProducto(dataSet2.Tables[0].Rows[i]));
                }

            }

        }
    }
}
