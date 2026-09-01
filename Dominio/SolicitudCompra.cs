namespace Dominio
{
    public class SolicitudCompra
    {
		private int _id;
		public int id {	get { return _id; } }

		private int _folio;
		public int folio { get { return _folio; } set { _folio = value; } }

		private string _solicitante = string.Empty;
		public string solicitante { get { return _solicitante; } set { _solicitante = value; } }

		private DateOnly _fecha;
		public DateOnly fecha {	get { return _fecha; } set { _fecha = value; } }

		private string _estado = estadoSolicitud.borrador.ToString();
		public string estado { get { return _estado; } set { _estado = value; } }


		public enum estadoSolicitud
        {
            borrador,
            envaida,
            cancelada,
        }

		private string _observaciones = string.Empty;
		public string observaciones	{ get { return _observaciones; } set { _observaciones = value; } }

		private decimal _total;
		public decimal total { 
			get { return _total = detalles.Sum(d => d.subtotal); }
		}

		public List<SolicitudCompraDetalle> detalles { get; private set; } = new();


		public void AgregarDetalle(SolicitudCompraDetalle detalle)
        {
			bool existeProducto = detalles.Any(d => d.producto == detalle.producto);
			if (!existeProducto)
			{
                detalles.Add(detalle);
			}
			else
			{
                throw new InvalidOperationException($"El producto con ID {detalle.producto} ya existe en la solicitud.");
            }
            
        }
    }
}
