﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Ploeh.Albedo
{
    public class AssemblyElementMaterializer<T> : IReflectionElementMaterializer<T>
    {
        public IEnumerable<IReflectionElement> Materialize(IEnumerable<T> source)
        {
            return source
                .OfType<Assembly>()
                .Select(a => new AssemblyElement(a))
                .Concat(source.OfType<AssemblyElement>())
                .Cast<IReflectionElement>();
        }
    }
}
