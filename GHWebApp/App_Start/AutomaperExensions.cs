using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace GHWebApp
{
    public static class AutoMapperExtensions
    {
        public static void Bidirectional<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            Mapper.CreateMap<TDestination, TSource>();
        }
    }
}