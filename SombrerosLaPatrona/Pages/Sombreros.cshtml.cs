using System.Data;
using SombrerosLaPatrona.DataBaseAccess;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SombrerosLaPatrona.Dtos;

namespace SombrerosLaPatrona.Pages
{
    public class SombrerosModel : PageModel
    {
        private DataBase dataBase { get; set; }
        public List<DtoProducto> Sombreros { get; set; }
        public SombrerosModel()
        {
            Sombreros = new List<DtoProducto>();
            dataBase = new DataBase();
        }
        public void OnGet()
        {
            DataSet? dataSet = dataBase.EjecutarQuery($"SELECT * FROM PRODUCTOS WHERE ID_TIPO_PRODUCTO = 5");

            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                Sombreros = new List<DtoProducto>();
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    Sombreros.Add(new DtoProducto(dataSet.Tables[0].Rows[i]));
                }
            }
        }
    }

}
