using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace WebApplication16
{
    public static class NestedEndpoints
    {
        // start it all off
        public static void Path(
            this IEndpointRouteBuilder app, 
            string route,
            Action<NestedEndpointConventionBuilder> endpoints)
        {
            var nestedEndpointConventionBuilder = 
                new NestedEndpointConventionBuilder(app, route, endpoints);
        }
    }
    
    public class NestedEndpointConventionBuilder 
    {
        private readonly IEndpointRouteBuilder _app;
        private readonly string _baseRoute;

        public NestedEndpointConventionBuilder(IEndpointRouteBuilder app, string baseRoute, 
            Action<NestedEndpointConventionBuilder> call)
        {
            _app = app;
            _baseRoute = baseRoute;
            
            // invoke as we go down the chain, it's fine
            call(this);
        }

        public NestedEndpointConventionBuilder Path(string route, Action<NestedEndpointConventionBuilder> call)
        {
            return new NestedEndpointConventionBuilder(_app, Combine(route), call);
        }
        
        public IEndpointConventionBuilder MapGet(Delegate requestDelegate)
        {
            return _app.MapGet(_baseRoute, requestDelegate);
        }
        
        public IEndpointConventionBuilder MapGet(RequestDelegate requestDelegate)
        {
            return _app.MapGet(_baseRoute, requestDelegate);
        }
        
        public IEndpointConventionBuilder MapGet(string pattern, RequestDelegate requestDelegate)
        {
            var route = Combine(pattern);
            return _app.MapGet(route, requestDelegate);
        }
        
        public IEndpointConventionBuilder MapGet(string pattern, Delegate requestDelegate)
        {
            var route = Combine(pattern);
            return _app.MapGet(route, requestDelegate);
        }
        
        public IEndpointConventionBuilder MapPost(Delegate requestDelegate)
        {
            return _app.MapPost(_baseRoute, requestDelegate);
        }
        
        public IEndpointConventionBuilder MapPost(RequestDelegate requestDelegate)
        {
            return _app.MapPost(_baseRoute, requestDelegate);
        }
        
        public IEndpointConventionBuilder MapPost(string pattern, RequestDelegate requestDelegate)
        {
            var route = Combine(pattern);
            return _app.MapPost(route, requestDelegate);
        }
        
        public IEndpointConventionBuilder MapPost(string pattern, Delegate requestDelegate)
        {
            var route = Combine(pattern);
            return _app.MapPost(route, requestDelegate);
        }
        
        public IEndpointConventionBuilder MapPut(Delegate requestDelegate)
        {
            return _app.MapPut(_baseRoute, requestDelegate);
        }
        
        public IEndpointConventionBuilder MapPut(RequestDelegate requestDelegate)
        {
            return _app.MapPut(_baseRoute, requestDelegate);
        }
        
        public IEndpointConventionBuilder MapPut(string pattern, RequestDelegate requestDelegate)
        {
            var route = Combine(pattern);
            return _app.MapPut(route, requestDelegate);
        }
        
        public IEndpointConventionBuilder MapPut(string pattern, Delegate requestDelegate)
        {
            var route = Combine(pattern);
            return _app.MapPut(route, requestDelegate);
        }
        
        public IEndpointConventionBuilder MapDelete(Delegate requestDelegate)
        {
            return _app.MapDelete(_baseRoute, requestDelegate);
        }
        
        public IEndpointConventionBuilder MapDelete(RequestDelegate requestDelegate)
        {
            return _app.MapDelete(_baseRoute, requestDelegate);
        }
        
        public IEndpointConventionBuilder MapDelete(string pattern, RequestDelegate requestDelegate)
        {
            var route = Combine(pattern);
            return _app.MapDelete(route, requestDelegate);
        }
        
        public IEndpointConventionBuilder MapDelete(string pattern, Delegate requestDelegate)
        {
            var route = Combine(pattern);
            return _app.MapDelete(route, requestDelegate);
        }

        private string Combine(string pattern)
        {
            return $"{_baseRoute.TrimEnd('/')}/{pattern.TrimStart('/')}";
        }
    }
}