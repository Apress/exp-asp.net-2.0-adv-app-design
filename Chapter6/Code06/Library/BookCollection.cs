using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Web;
using System.Xml.Serialization.Advanced;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Library
{
    
    [XmlRoot("books", 
     Namespace ="http://www.intertechtraining.com/Library/BookCollection", 
     IsNullable = true)]
    [XmlSchemaProvider("BookCollectionXsd")]
    public class BookCollection : IEnumerable, IXmlSerializable
    {
        public static XmlQualifiedName BookCollectionXsd(XmlSchemaSet xss)
        {
            string xsdPath = HttpContext.Current.Server.MapPath("BookCollection.xsd");
            XmlSchema xs = XmlSchema.Read(new XmlTextReader(xsdPath), null);

            xss.XmlResolver = new XmlUrlResolver();
            xss.Add(xs);
            return new XmlQualifiedName("BookCollection_Type", ns);
        }

        public Hashtable ht = new Hashtable();
        private static string ns = 
            "http://www.intertechtraining.com/Library/BookCollection";

        public int Add(BookDetails book)
        {
            ht.Add(book.BookID, book);
            return ht.Count - 1;
        }        
        
        public int Count
        {
            get { return ht.Count; }
        }
        public void Remove(int BookID)
        {
            ht.Remove(BookID);
        }
        public void Remove(BookDetails book)
        {
            ht.Remove(book.BookID);
        }
        public IEnumerator GetEnumerator()
        {
            return ht.GetEnumerator();
        }

       

        private void pen()
        {
            XmlSchema xs = XmlSchema.Read(new StringReader(
            "<xs:schema id='BookCollectionSchema' targetNamespace='" + ns +
            "' elementFormDefault='qualified' xmlns='" + ns + "' xmlns:mstns='" +
            ns + "' xmlns:xs='http://www.w3.org/2001/XMLSchema'><xs:complexType " +
            "name='BookCollection_Type'>" +
"<xs:sequence minOccurs='0' maxOccurs='unbounded'>" +
"<xs:element name='book'>" +
"<xs:complexType>" +
"<xs:sequence>" +
"<xs:element name='bookID' type='xs:string' minOccurs='0' /> " +
"<xs:element name='binding' type='xs:string' minOccurs='0' /> " +
"<xs:element name='isbn' type='xs:string' minOccurs='0' /> " +
"<xs:element name='listPrice' type='xs:string' minOccurs='0' /> " +
"<xs:element name='lowestPrice' type='xs:string' minOccurs='0' /> " +
"<xs:element name='pageCount' type='xs:string' minOccurs='0' /> " +
"<xs:element name='publicationDate' type='xs:string' minOccurs='0' /> " +
"<xs:element name='publisher' type='xs:string' minOccurs='0' /> " +
"<xs:element name='review' type='xs:string' minOccurs='0' /> " +
"<xs:element name='scanDate' type='xs:string' minOccurs='0' /> " +
"<xs:element name='title' type='xs:string' minOccurs='0' /> " +
"<xs:element name='weight' type='xs:string' minOccurs='0' /> " +
"<xs:element name='authors' minOccurs='0' maxOccurs='unbounded'>" +
"<xs:complexType>" +
"<xs:sequence>" +
"<xs:element name='author' nillable='true' minOccurs='0' maxOccurs='unbounded'>" +
"<xs:complexType>" +
"<xs:simpleContent>" +
"<xs:extension base='xs:string' /> " +
"</xs:simpleContent>" +
"</xs:complexType>" +
"</xs:element>" +
"</xs:sequence>" +
"</xs:complexType>" +
"</xs:element>" +
"<xs:element name='subjects' minOccurs='0' maxOccurs='unbounded'>" +
"<xs:complexType>" +
"<xs:sequence>" +
"<xs:element name='subject' nillable='true' minOccurs='0' maxOccurs='unbounded'>" +
"<xs:complexType>" +
"<xs:simpleContent>" +
"<xs:extension base='xs:string' /> " +
"</xs:simpleContent>" +
"</xs:complexType>" +
"</xs:element>" +
"</xs:sequence>" +
"</xs:complexType>" +
"</xs:element>" +
"<xs:element name='image' nillable='true' minOccurs='0' maxOccurs='unbounded'>" +
"<xs:complexType>" +
"<xs:simpleContent>" +
"<xs:extension base='xs:string'>" +
"<xs:attribute name='size' form='unqualified' type='xs:string' /> " +
"</xs:extension>" +
"</xs:simpleContent>" +
"</xs:complexType>" +
"</xs:element>" +
"</xs:sequence>" +
"</xs:complexType>" +
"</xs:element>" +
"</xs:sequence>" +

            "</xs:complexType>" +
            "<xs:element name='books' type='mstns:BookCollection_Type'></xs:element></xs:schema>"),
            null);
        }
        #region IXmlSerializable Members

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            BookCollection bc = new BookCollection();
            BookDetails book;
            BinaryFormatter bf = new BinaryFormatter();
            string val;

            reader.Read();
            reader.ReadStartElement("books");
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                book = new BookDetails();
                reader.ReadStartElement("book", ns);

                book.BookID = 
                    Convert.ToInt32(reader.ReadElementContentAsInt("bookID", ns));
                book.Binding = 
                    reader.ReadElementString("binding", ns);
                book.ISBN = 
                    reader.ReadElementString("isbn", ns);
                book.ListPrice = 
                    reader.ReadElementContentAsDouble("listPrice", ns);
                book.LowestPrice = 
                    reader.ReadElementContentAsDouble("lowestPrice", ns);
                book.PageCount = 
                    reader.ReadElementContentAsInt("pageCount", ns);
                val = 
                    reader.ReadElementContentAsString("publicationDate", ns);
                book.PublicationDate = 
                    DateTime.Parse(val);
                book.Publisher = 
                    reader.ReadElementString("publisher", ns);
                book.Review = 
                    reader.ReadElementString("review", ns);
                val = 
                    reader.ReadElementContentAsString("scanDate", ns);
                book.ScanDate = 
                    DateTime.Parse(val);                
                book.Title = 
                    reader.ReadElementString("title", ns);
                book.Weight = 
                    reader.ReadElementContentAsDouble("weight", ns);
                reader.ReadStartElement("authors");
                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    book.Authors.Add
                        (reader.ReadElementContentAsString("author", ns));
                    reader.MoveToContent();
                }
                reader.Read();
                reader.ReadStartElement("subjects");
                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    book.Subjects.Add
                        (reader.ReadElementContentAsString("subject", ns));
                    reader.MoveToContent();
                }
                reader.Read();
                
                int size = Convert.ToInt32(reader.GetAttribute("size"));
                byte[] bytes = new byte[size];
                reader.ReadElementContentAsBase64(bytes, 0, size);
                book.BookImage = new Bitmap(new MemoryStream(bytes));               
                reader.Read();                
                reader.MoveToContent();
                bc.Add(book);
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            BinaryFormatter b = new BinaryFormatter();
            MemoryStream ms;
            BookDetails book;
            ASCIIEncoding ascEnc = new ASCIIEncoding();

            writer.WriteStartElement("books", ns);
            foreach (int i in ht.Keys)
            {
                writer.WriteStartElement("book", ns);
                book = (BookDetails)ht[i];

                writer.WriteElementString
                    ("bookID", ns, book.BookID.ToString());
                writer.WriteElementString
                    ("binding", ns, book.Binding);
                writer.WriteElementString
                    ("isbn", ns, book.ISBN);
                writer.WriteElementString
                    ("listPrice", ns, book.ListPrice.ToString());
                writer.WriteElementString
                    ("lowestPrice", ns, book.LowestPrice.ToString());
                writer.WriteElementString
                    ("pageCount", ns, book.PageCount.ToString());
                writer.WriteElementString
                    ("publicationDate", ns, book.PublicationDate.ToString());
                writer.WriteElementString
                    ("publisher", ns, book.Publisher);
                writer.WriteElementString
                    ("review", ns, book.Review);
                writer.WriteElementString
                    ("scanDate", ns, book.ScanDate.ToString());
                writer.WriteElementString
                    ("title", ns, book.Title);
                writer.WriteElementString
                    ("weight", ns, book.Weight.ToString());
                writer.WriteStartElement
                    ("authors", ns);
                foreach (string s in book.Authors)
                    writer.WriteElementString("author", ns, s);
                writer.WriteEndElement();
                writer.WriteStartElement("subjects", ns);
                foreach (string s in book.Subjects)
                    writer.WriteElementString("subject", ns, s);
                writer.WriteEndElement();

                writer.WriteStartElement("image", ns);
                ms = new MemoryStream();
                book.BookImage.Save(ms, ImageFormat.Jpeg);
                int size = Convert.ToInt32(ms.Length);
                writer.WriteAttributeString("size", "", size.ToString());
                               
                ms.Position = 0;
                writer.WriteBase64(ms.ToArray(), 0, size);
                writer.WriteEndElement();

                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        public void WriteXml_old(System.Xml.XmlWriter writer)
        {
            BinaryFormatter b = new BinaryFormatter();
            MemoryStream ms;
            BookDetails book;

            writer.WriteStartElement("books", ns);
            foreach (int i in ht.Keys)
            {
                book = (BookDetails)ht[i];
                ms = new MemoryStream();
                b.Serialize(ms, ht[i]);
                ms.Position = 0;                                
                writer.WriteElementString("book", ns, ms.ToArray().ToString());
            }
            writer.WriteEndElement();
        }

        #endregion
    }
}
