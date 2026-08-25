namespace Dominio
{
    public class Producto
    {
		private int _id;
		public int id { get { return _id; } }
		
		private int _codigo;
		public int codigo {	get { return  _codigo;; } set {  _codigo = value; } }

		private string _descripcion = string.Empty;
		public string descripcion { get { return _descripcion; } set { _descripcion = value; }	}

		private decimal _precioReferencia;
		public decimal precioReferencia	{ get { return _precioReferencia; }	set { _precioReferencia = value; } }

		private int _activo;
		public int activo {	get { return _activo; }	set { _activo = value; }}


		public Producto(int id, int codigo, string descripcion, decimal precioReferencia, int activo)
        {
            _id = id;
            _codigo = codigo;
            _descripcion = descripcion;
            if (precioReferencia < 0)
            {
                throw new ArgumentException("El precio debe ser un valor positivo.","precioReferencia");
            }
            _precioReferencia = precioReferencia;
            _activo = activo;
        }	



    }
}
