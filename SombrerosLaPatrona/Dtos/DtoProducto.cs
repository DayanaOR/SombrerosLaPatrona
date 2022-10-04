using System.Data;

namespace SombrerosLaPatrona.Dtos
{
    public class DtoProducto
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public int ValorUnitario { get; set; }
        public int ValorDetal { get; set; }
        public string? Talla { get; set; }
        public string? Img { get; set; }
        public DtoProducto() { }

        public DtoProducto(DataRow row)
        {
            Id = int.Parse(row["Id"]?.ToString() ?? "0");
            Titulo = row["Nombre"]?.ToString();
            Descripcion = row["Descripcion"].ToString();
            ValorUnitario = int.Parse(row["Valor_unitario"]?.ToString() ?? "0");
            ValorDetal = int.Parse(row["Valor_por_mayor"]?.ToString() ?? "0");
            Talla = row["Talla"].ToString();
        }
    }

   
}
