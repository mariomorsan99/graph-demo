using System.Collections.Generic;
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
    public class ProductoQuery:ObjectGraphType
    {
        private readonly TiendaContext _context;
        

        public ProductoQuery(TiendaContext context)
        {
             this._context=context;

              OperacionesProducto operaciones= new OperacionesProducto(this._context);

             Field<ListGraphType<ProductoType>>(
               "productos",
                 resolve:context =>{
                    return  operaciones.GetProducto();
                 }
                    
             );

             Field<ProductoType>("producto", arguments : new QueryArguments(
            new QueryArgument<IdGraphType> { Name = "id" }
            ), resolve: context =>
            {
                 var id = context.GetArgument<int>("id");
                 return  operaciones.GetProductoId(id);
                
             });


           


        }
    }
}