using System.Text;
using System.Xml;

XmlTextWriter writer = null;

try
{
    writer = new XmlTextWriter("Cars.xml", Encoding.Unicode);
    writer.Formatting = Formatting.Indented;

    writer.WriteStartDocument();
    writer.WriteStartElement("Cars");
    writer.WriteAttributeString("NewCarAttribute", "Attr");

    writer.WriteStartElement("Car");
    writer.WriteAttributeString("Image", "test.jpeg");
    writer.WriteAttributeString("Test", "testInfo");

    writer.WriteElementString("Manufacturer", "BMW");
    writer.WriteElementString("Model", "X5");
    writer.WriteElementString("Year", "2018");
    writer.WriteElementString("Color", "Black");
    writer.WriteElementString("Speed", "220");

    writer.WriteEndElement();

    writer.WriteStartElement("Car");
    writer.WriteAttributeString("Image", "test.jpeg");

    writer.WriteElementString("Manufacturer", "Mersedes");
    writer.WriteElementString("Model", "E");
    writer.WriteElementString("Year", "2020");
    writer.WriteElementString("Color", "White");
    writer.WriteElementString("Speed", "235");

    writer.WriteEndElement();

    writer.WriteEndElement();
    writer.WriteEndDocument();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    if (writer != null)
    {
        writer.Dispose();
        writer.Close();
    }
}

XmlDocument document = new XmlDocument();
document.Load("Cars.xml");

XmlNode root = document.DocumentElement;

root.RemoveChild(root.FirstChild);

XmlNode bike = document.CreateElement("Motobike");

XmlNode elem1 = document.CreateElement("Manufacturer");
XmlNode elem2 = document.CreateElement("Model");
XmlNode elem3 = document.CreateElement("Year");
XmlNode elem4 = document.CreateElement("Color");
XmlNode elem5 = document.CreateElement("Speed");

XmlNode text1 = document.CreateTextNode("BMW");
XmlNode text2 = document.CreateTextNode("C12");
XmlNode text3 = document.CreateTextNode("2003");
XmlNode text4 = document.CreateTextNode("Green");
XmlNode text5 = document.CreateTextNode("179");

elem1.AppendChild(text1);
elem2.AppendChild(text2);
elem3.AppendChild(text3);
elem4.AppendChild(text4);
elem5.AppendChild(text5);

bike.AppendChild(elem1);
bike.AppendChild(elem2);
bike.AppendChild(elem3);
bike.AppendChild(elem4);
bike.AppendChild(elem5);

root.AppendChild(bike);

document.Save("Cars.xml");

Output(document.DocumentElement);

Console.WriteLine("----------------------------------------------------------------------------------------------------");

XmlTextReader reader = new XmlTextReader("Cars.xml");
reader.WhitespaceHandling = WhitespaceHandling.None;

using (StreamWriter stream = new StreamWriter("new.txt", true))
{
    stream.WriteLine("Hi!");
}

while(reader.Read())
{
    Console.WriteLine($"Type: {reader.NodeType}\t Name: {reader.Name}\t Value: {reader.Value}");

    if(reader.AttributeCount > 0)
        while(reader.MoveToNextAttribute())
            Console.WriteLine($"Type: {reader.NodeType}\t Name: {reader.Name}\t Value: {reader.Value}");
}

void Output(XmlNode node)
{
    Console.WriteLine($"Type: {node.NodeType}\t Name: {node.Name}\t Value: {node.Value}");

    if(node.Attributes != null)
        foreach(XmlAttribute attr in node.Attributes)
            Console.WriteLine($"Type: {attr.NodeType}\t Name: {attr.Name}\t Value: {attr.Value}");

    if (node.HasChildNodes)
        foreach(XmlNode childNode in node.ChildNodes)
            Output(childNode);
}