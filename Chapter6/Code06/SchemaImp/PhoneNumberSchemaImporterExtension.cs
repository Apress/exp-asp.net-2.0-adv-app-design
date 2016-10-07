#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;
using System.CodeDom;
using System.CodeDom.Compiler;
using NumberLib;
using System.Xml.Serialization.Advanced;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Diagnostics;
#endregion



namespace SchemaImp
{
    public class PhoneNumberSchemaImporterExtension : SchemaImporterExtension
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
            if (name.Equals("PhoneNumber") && ns.Equals("http://phoneNumber/"))
            {
                compileUnit.ReferencedAssemblies.Add("SchemaImp.dll");
                mainNamespace.Imports.Add(new CodeNamespaceImport("NumberLib"));
                return "NumberLib.PhoneNumber";
            }            
            else
                return null;
        }         
    }
}

