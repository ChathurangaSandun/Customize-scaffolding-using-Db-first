using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scaffoldingdbcontext.Utils
{
    public interface IBaseClassGenerator
    {
        string WriteCode(string @namespace);
    }
}
