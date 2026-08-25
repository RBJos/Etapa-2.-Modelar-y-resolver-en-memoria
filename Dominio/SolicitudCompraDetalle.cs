namespace Dominio
{
    public class SolicitudCompraDetalle
    {
		private int _id;
		public int id { get { return _id; } set { _id = value; } }

		private int _solicitud;
		public int solicitud { get { return _solicitud; } set { _solicitud = value; } }

		private int _producto;
		public int producto { get { return _producto; } set { _producto = value; } }

		private int _cantidad;
		public int cantidad { get { return _cantidad; } set { _cantidad = value; } }

		private decimal _precio;
		public decimal precio { get { return _precio; } set { _precio = value; } }

		private decimal _subtotal;
		public decimal subtotal { get { return _subtotal; } set { _subtotal = value; } }
	
		public SolicitudCompraDetalle(int id, int solicitud, int producto, int cantidad, decimal precio, decimal subtotal)
		{
			_id = id;
			_solicitud = solicitud;
			_producto = producto;
			_cantidad = cantidad;
			if(precio < 0)
            {
                throw new ArgumentException("El precio debe ser un valor positivo.", "precio");
            }
            _precio = precio;
			_subtotal = subtotal;
		}
	}
}
