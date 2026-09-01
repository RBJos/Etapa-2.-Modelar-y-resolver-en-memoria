using System;
using System.Collections.Generic;
using System.Linq;
using Dominio;
namespace UIConsola;

public class Program
{
    public static void Main(string[] args)
    {
        List<Producto> catalogoProductos = new List<Producto>();
        catalogoProductos.Add(new Producto(1, 1001, "Producto 1", 10.5m, 1));
        catalogoProductos.Add(new Producto(2, 1002, "Producto 2", 20.0m, 1));
        catalogoProductos.Add(new Producto(3, 1003, "Producto 3", 15.0m, 1));

        var solicitud = new SolicitudCompra
        {
            folio = 1,
            solicitante = "Juan Pérez",
            fecha = DateOnly.FromDateTime(DateTime.Now),
            observaciones = "Solicitud de compra de productos"
        };

        try
        {
            var detalle1 = new SolicitudCompraDetalle (1, solicitud.id, catalogoProductos[0].id, 2, catalogoProductos[0].precioReferencia, catalogoProductos[0].precioReferencia * 2);
            solicitud.AgregarDetalle(detalle1);
            var detalle2 = new SolicitudCompraDetalle (2, solicitud.id, catalogoProductos[1].id, 1, catalogoProductos[1].precioReferencia, catalogoProductos[1].precioReferencia * 1);
            solicitud.AgregarDetalle(detalle2);
            //Intento de agregar un producto duplicado
            //var detalle3 = new SolicitudCompraDetalle (3, solicitud.id, catalogoProductos[1].id, 1, catalogoProductos[1].precioReferencia, catalogoProductos[1].precioReferencia * 1);
            //solicitud.AgregarDetalle(detalle3);
            //Intento de agregar un producto con precio negativo
            var detalle4 = new SolicitudCompraDetalle (4, solicitud.id, catalogoProductos[2].id, 1, catalogoProductos[2].precioReferencia * -1, catalogoProductos[2].precioReferencia * 1);
            solicitud.AgregarDetalle(detalle4);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Error: No se puede agregar un producto duplicado a la solicitud.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: No se puede agregar un producto con precio negativo a la solicitud.");
        }
        finally
        {
            Console.WriteLine("Continua trabajando");
        }

        Console.WriteLine($"Solicitud de Compra.\n\nFolio: {solicitud.folio}, Solicitante: {solicitud.solicitante}, Fecha: {solicitud.fecha}, Estado: {solicitud.estado}, Observaciones: {solicitud.observaciones}, Total: {solicitud.total}\n");

        Console.WriteLine("Productos en la solicitud:");

        Console.WriteLine("ID\tProducto\tCantidad\tPrecio\tSubtotal");
        foreach (var detalle in solicitud.detalles)
        {
            Console.WriteLine($"{detalle.id}\t{catalogoProductos.First(p => p.id == detalle.producto).descripcion}\t{detalle.cantidad}\t\t{detalle.precio}\t{detalle.subtotal}");
        }

    }
}

