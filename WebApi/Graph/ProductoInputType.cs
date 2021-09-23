using System.Security.Cryptography.X509Certificates;
using WebApi.Dominio;
using GraphQL.Types;


namespace WebApi.Graph
{
    public class ProductoInputType:InputObjectGraphType<Producto>
    { 
        public ProductoInputType(){
           Name = "Producto";  
           Field(x=>x.nombreProducto);
           Field(x=>x.descripcionProducto);
        }
        
    }
}