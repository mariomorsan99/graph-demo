using Microsoft.EntityFrameworkCore;
using System.Linq;
using GraphQL;
using GraphQL.Types;
using WebApi.Persistencia;
using WebApi.Graph;
using WebApi.Dominio;
using WebApi.Repositorio;

namespace WebApi.Graph
{
    public class ProductoMutation:ObjectGraphType
    {
        private readonly TiendaContext _context;

        public ProductoMutation(TiendaContext context)
        {
             this._context=context;

             OperacionesProducto operaciones= new OperacionesProducto(this._context);

          Field<ProductoType>(
            "createProducto",
                arguments: new QueryArguments(
                    new QueryArgument<ProductoInputType > 
                           { Name = "producto" }

            ), resolve: context =>
            {
                 var producto = context.GetArgument<Producto>("producto");

                  var productoNuevo= operaciones.CreateProduct(producto);

                  return productoNuevo;
                
             });

           Field<ProductoType>(
            "deleteProducto",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType > 
                           { Name = "id" }

            ), resolve: context =>
            {
                 var id = context.GetArgument<int>("id");

               /* var producto= _context.Producto.Find(id);

                 _context.Remove(producto);

                 var resultado=  _context.SaveChangesAsync();*/

                 var producto= operaciones.DeleteProduc(id);

                  return producto;
                
             });

             Field<ProductoType>(
            "editProducto",
                arguments: new QueryArguments(
                    new QueryArgument<ProductoInputType > 
                           { Name = "producto" },
                    new QueryArgument
                         <NonNullGraphType<IntGraphType>>
                           { Name = "id" }

            ), resolve: context =>
            {
                var id = context.GetArgument<int>("id");
                var producto = context.GetArgument<Producto>("producto");
                var productoEditar= operaciones.EditProduct(producto,id);

                  return productoEditar;
                
             });



           


        }
        
    }
}