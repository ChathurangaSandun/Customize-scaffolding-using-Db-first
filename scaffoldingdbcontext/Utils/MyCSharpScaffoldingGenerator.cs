using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scaffoldingdbcontext.Utils
{
    public class MyCSharpScaffoldingGenerator : CSharpScaffoldingGenerator
    {
        public virtual IBaseClassGenerator BaseClassGenerator { get; }

        public MyCSharpScaffoldingGenerator(IFileService fileService,  ICSharpDbContextGenerator cSharpDbContextGenerator,  ICSharpEntityTypeGenerator cSharpEntityTypeGenerator) 
            : base(fileService, cSharpDbContextGenerator, cSharpEntityTypeGenerator)
        {
            //BaseClassGenerator = baseClassGenerator;
        }

        public override ReverseEngineerFiles WriteCode(IModel model, string outputPath, string @namespace, string contextName, string connectionString, bool useDataAnnotations)
        {
            var baseReverseEngineerFiles =  base.WriteCode(model, outputPath, @namespace, contextName, connectionString, useDataAnnotations);
            var generatedCode = new MyBaseClassGenerator().WriteCode(@namespace);
            var baseClassFileName = "BaseClass" + base.FileExtension;
            var entityTypeFileFullPath = FileService.OutputFile(outputPath, baseClassFileName, generatedCode);
            baseReverseEngineerFiles.EntityTypeFiles.Add(entityTypeFileFullPath);
            return baseReverseEngineerFiles;
        }
    }
}
