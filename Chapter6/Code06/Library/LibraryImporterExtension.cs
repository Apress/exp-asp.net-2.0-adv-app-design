using System;
using System.Collections.Generic;
using System.Text;

using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Xml.Serialization.Advanced;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Diagnostics;

[assembly: AssemblyKeyFile(@"c:\work\extremeaspnet\aaad.snk")]

namespace Library
{
    class LibraryImporterExtension : SchemaImporterExtension
    {
        public override string ImportSchemaType(string name,
            string ns,
            XmlSchemaObject context,
            XmlSchemas schemas,
            XmlSchemaImporter importer,
            CodeCompileUnit compileUnit,
            CodeNamespace mainNamespace,
            CodeGenerationOptions options,
            CodeDomProvider codeProvider)
        {
            System.Diagnostics.EventLog.CreateEventSource("Library", "Application");
            System.Diagnostics.EventLog.WriteEntry("Library", "Fired:" + name);            
            if (name.Equals("BookCollection"))
            {
                compileUnit.ReferencedAssemblies.Add("Library.dll");
                mainNamespace.Imports.Add(new CodeNamespaceImport("Library"));
                return "Library.BookCollection";
            }
            else
                return null;
        }    
    }
}
