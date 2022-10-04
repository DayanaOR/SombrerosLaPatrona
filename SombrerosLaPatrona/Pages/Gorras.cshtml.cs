using System.Data;
using SombrerosLaPatrona.DataBaseAccess;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SombrerosLaPatrona.Dtos;

namespace SombrerosLaPatrona.Pages
{
    public class GorrasModel : PageModel
    {
        private DataBase dataBase { get; set; }
        public List<DtoProducto> Gorras { set; get; }
        public GorrasModel()
        {
            Gorras = new List<DtoProducto>();
            dataBase = new DataBase();
        }
        public void OnGet()
        {
            DataSet? dataSet3 = dataBase.EjecutarQuery($"SELECT * FROM PRODUCTOS WHERE ID_TIPO_PRODUCTO = 6");

            if (dataSet3 != null && dataSet3.Tables.Count > 0 && dataSet3.Tables[0].Rows.Count > 0)
            {
                Gorras = new List<DtoProducto>();
                for (int i = 0; i < dataSet3.Tables[0].Rows.Count; i++)
                {
                    Gorras.Add(new DtoProducto(dataSet3.Tables[0].Rows[i]));
                }
            }
        }
    }
}
