namespace ErpCasino.BusinessLibrary.BE.UI
{
    public class Descuento
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Monto { get; set; }
        public bool Activo { get; set; }

        public Descuento()
        {
            Id = 0;
            Nombre = "<Ingrese el nombre>";
            Descripcion = "<Ingrese la descripción>";
            Monto = 0.0;
            Activo = false;            
        }
    }
}
