using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scaffoldingdbcontext.Utils
{
    public class MyDbContextGenerator : CSharpDbContextGenerator
    {

        private IndentedStringBuilder _sb;

        public MyDbContextGenerator( IScaffoldingProviderCodeGenerator providerCodeGenerator, IAnnotationCodeGenerator annotationCodeGenerator,  ICSharpUtilities cSharpUtilities) 
            : base(providerCodeGenerator, annotationCodeGenerator, cSharpUtilities)
        {
        }

        public override string WriteCode(IModel model, string @namespace, string contextName, string connectionString, bool useDataAnnotations)
        {
            string code = base.WriteCode(model, @namespace, contextName, connectionString, useDataAnnotations);
            _sb = new IndentedStringBuilder();
            _sb.AppendLine(code);
            _sb.AppendLine();
            _sb.AppendLine($"public partial class BaseClass");
            _sb.AppendLine("{");
            using (_sb.Indent())
            {
                _sb.Append("public long Id { get; set; }");
            }

            _sb.AppendLine();
            _sb.AppendLine("}");
            return _sb.ToString();
        }
    }
}
