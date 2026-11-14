namespace SistemaServicioTecnico.Entidades
{
    public class Refaccion
    {
        public int IdRefaccion { get; set; }
        public int IdCategoriaRefaccion { get; set; }
        public string SKU { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal CostoReferencia { get; set; }
        public decimal PrecioVenta { get; set; }
        public int StockMinimo { get; set; }
        public int Existencia { get; set; }
        public bool Activo { get; set; }
    }
}
