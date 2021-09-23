using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using GraphQL;
using GraphQL.Types;
using WebApi.Persistencia;
using WebApi.Graph;



namespace WebApi.Graph
{
    public class ProductoQuery:ObjectGraphType
    {
        private readonly TiendaContext _context;

        public ProductoQuery(TiendaContext context)
        {
             this._context=context;

             Field<ListGraphType<ProductoType>>(
               "productos",
                 resolve:context =>{
                    return _context.Producto.ToListAsync();
                 }
                    
             );

            
        }
    }
}