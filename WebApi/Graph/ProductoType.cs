using GraphQL.Types;
using WebApi.Dominio;

namespace WebApi.Graph
{
    public class ProductoType: ObjectGraphType<Producto>
    {
            
         public ProductoType(){
           Name = "Producto";   
           Field(x=>x.Id);
           Field(x=>x.nombreProducto);
           Field(x=>x.descripcionProducto);
        }
    }
}