using WebApi.Dominio;
using WebApi.Persistencia;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Repositorio
{
    public class OperacionesProducto
    {
        private readonly TiendaContext _context;

        public OperacionesProducto(TiendaContext contex){
            this._context=contex;
        }

        public async Task<List<Producto>>GetProducto()
        {
              return await _context.Producto.ToListAsync();
        }

        public async Task<Producto> GetProductoId(int id)
        {
            var productoUnico= await _context.Producto.FindAsync(id);
            return productoUnico;
        }

        public async Task<Producto>CreateProduct(Producto producto)
        {
              var productoNuevo= new Producto
                {
                   nombreProducto=producto.nombreProducto,
                   descripcionProducto=producto.descripcionProducto
                };
            _context.Producto.Add(productoNuevo);

            var valor= await _context.SaveChangesAsync();

            return   productoNuevo;

        }

         public async Task<Producto>EditProduct(Producto producto, int id)
         {
              var productoEditar=_context.Producto.Find(id);

               productoEditar.nombreProducto= producto.nombreProducto;
               productoEditar.descripcionProducto=producto.descripcionProducto;

             await _context.SaveChangesAsync();

             return productoEditar;

         }

         public async Task<Producto> DeleteProduc(int id)
         {
              var producto= _context.Producto.Find(id);

             _context.Remove(producto);

            var resultado=  await _context.SaveChangesAsync();

            return producto;

         }





    }
}