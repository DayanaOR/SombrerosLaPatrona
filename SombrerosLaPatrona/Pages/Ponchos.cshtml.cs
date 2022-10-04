using System.Data;
using SombrerosLaPatrona.DataBaseAccess;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SombrerosLaPatrona.Dtos;

namespace SombrerosLaPatrona.Pages
{
    public class PonchosModel : PageModel
    {
        private DataBase dataBase { get; set; }
        public List<DtoProducto> Ponchos { get; set; }
        public PonchosModel()
        {
            Ponchos = new List<DtoProducto>();
            dataBase = new DataBase();
        }
        public void OnGet()
        {
            DataSet? dataSet1 = dataBase.EjecutarQuery($"SELECT* FROM PRODUCTOS WHERE ID_TIPO_PRODUCTO = 3");

            if (dataSet1 != null && dataSet1.Tables.Count > 0 && dataSet1.Tables[0].Rows.Count > 0)
            {
                Ponchos = new List<DtoProducto>();
                for (int i = 0; i < dataSet1.Tables[0].Rows.Count; i++)
                {
                    Ponchos.Add(new DtoProducto(dataSet1.Tables[0].Rows[i]));
                }

            }
            
        }
    }
}
