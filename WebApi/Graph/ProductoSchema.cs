using System;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Graph;


namespace WebApi.Graph
{
    public class ProductoSchema:Schema
    {
        public ProductoSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<ProductoQuery>();
            Mutation = resolver.Resolve<ProductoMutation>();
        }
    }
}