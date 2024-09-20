﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace XmlIntroduction
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XmlDocument documento = new XmlDocument();
            documento.Load("C:\\Users\\Dougl\\OneDrive\\Documentos\\IFSP\\Sistemas Distribuídos\\SDSI6-IFSP\\TP02\\voos.xml");
            XmlNodeReader nos = new XmlNodeReader(documento);
            int endentar = -1;

            while (nos.Read())
            {
                switch (nos.NodeType)
                {
                    case XmlNodeType.Element:
                        endentar++;
                        Tabular(endentar);
                        if (nos.Name != "operando")
                            TextBox1.Text += "<" + nos.Name + ">" + "\r\n";
                        else
                        {
                            nos.Read();
                            if (nos.Value == "T")
                                TextBox1.Text += "Vôo operando\r\n";
                            else
                                TextBox1.Text += "Vôo NÃO operando\r\n";
                            endentar--;
                            // nos.Read();
                            nos.Read();
                        }
                        if (nos.IsEmptyElement)
                            endentar--;
                        break;

                    case XmlNodeType.Comment:
                        Tabular(endentar);
                        TextBox1.Text += "Comentário: " + nos.Value + "\r\n";
                        break;

                    case XmlNodeType.Text:
                        endentar++;
                        Tabular(endentar);
                        TextBox1.Text += (nos.Value + "\r\n");
                        endentar--;
                        break;

                    case XmlNodeType.XmlDeclaration:
                        TextBox1.Text += "<?" + nos.Name + " " + nos.Value + " ?>" + "\r\n";
                        break;

                    case XmlNodeType.EndElement:
                        Tabular(endentar);
                        TextBox1.Text += "</" + nos.Name + ">" + "\r\n";
                        endentar--;
                        break;
                }
            }

            Response.Clear();
            Response.Charset = "utf-8";

            // Caminho onde o arquivo será salvo, no meu caso será:
            // C:\inetpub\wwwroot\exemplos\exemplo3.xml
            string strFilePath = "C:\\Users\\Dougl\\OneDrive\\Documentos\\IFSP\\Sistemas Distribuídos\\SDSI6-IFSP\\TP02\\teste.xml";

            // Esta linha indica que o arquivo XML será salvo, diferente dos outros exemplos
            XmlTextWriter xtw = new XmlTextWriter(strFilePath, Encoding.UTF8);

            // A linha abaixo vai identar o código, se não usar isso tudo ficará em uma linha
            xtw.Formatting = Formatting.Indented;

            // Escreve a declaração do documento <?xml version="1.0" encoding="utf-8"?>
            xtw.WriteStartDocument();
            xtw.WriteStartElement("blog");

            xtw.WriteStartElement("artigos");
            xtw.WriteAttributeString("linguagem", "asp.net");
            xtw.WriteStartElement("artigo");
            xtw.WriteElementString("titulo", "DataSet para XML em ASP.NET / C#");
            xtw.WriteElementString("url", "http://cbsa.com.br/post/dataset-para-xmlem-aspnet-c.aspx");
            xtw.WriteEndElement();

            xtw.WriteStartElement("artigo");
            xtw.WriteElementString("titulo", "XML para DataSet em ASP.NET / C#");
            xtw.WriteElementString("url", "http://cbsa.com.br/post/xml-para-datasetem-aspnet-c.aspx");
            xtw.WriteEndElement();

            xtw.WriteStartElement("artigo");
            xtw.WriteElementString("titulo", "Ler arquivo XML usando XmlTextReader e XmlDocument em C# - ASP.NET");
            xtw.WriteElementString("url", "http://cbsa.com.br/post/ler-arquivo-xmlusando-xmltextreader-e-xmldocument-em-c---aspnet.aspx");
            xtw.WriteEndElement();

            xtw.WriteEndElement();

            xtw.WriteStartElement("artigos");
            xtw.WriteAttributeString("linguagem", "C#");
            xtw.WriteStartElement("artigo");
            xtw.WriteElementString("titulo", "Calcular idade em C#");
            xtw.WriteElementString("url", "http://cbsa.com.br/post/calcular-idadeem-c.aspx");
            xtw.WriteEndElement();
            xtw.WriteEndElement();

            xtw.WriteEndElement();
            xtw.WriteEndDocument();

            // Libera o XmlTextWriter
            xtw.Flush();

            // Fecha o XmlTextWriter
            xtw.Close();


        }

        private void Tabular(int valor)
        {
            for (int i = 0; i < valor; i++)
                TextBox1.Text += '\t';
        }
    }
}