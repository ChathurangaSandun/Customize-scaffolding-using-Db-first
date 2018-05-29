using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;

namespace scaffoldingdbcontext.Utils
{
    public class MyBaseClassGenerator : IBaseClassGenerator
    {        
        private IndentedStringBuilder _sb;

        public string WriteCode(string @namespace)
        {
            _sb = new IndentedStringBuilder();

            _sb.AppendLine("using System;");

            _sb.AppendLine();
            _sb.AppendLine($"namespace {@namespace}");
            _sb.AppendLine("{");

            using (_sb.Indent())
            {
                GenerateClass();
            }

            _sb.AppendLine("}");

            return _sb.ToString();
        }

        private void GenerateClass()
        {  
            _sb.AppendLine($"public partial class BaseClass");

            _sb.AppendLine("{");

            using (_sb.Indent())
            {
                _sb.Append("public long Id { get; set; }");
            }

            _sb.AppendLine("}");
        }
    }
}
