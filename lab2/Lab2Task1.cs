using System.Xml.Linq;

namespace lab2;

public static class Lab2Task1
{
    public static void RunTask1()
    {
        TestXml();
        TestDoc();
        TestTxt();
    }

    private static void TestXml()
    {
        var xmlExists = HandleDocument("document.xml");
        xmlExists.Open();
        xmlExists.Change("to", "Alla");
        xmlExists.Save();


        var xmlDontExist = HandleDocument("document_new.xml");
        xmlDontExist.Create();

        xmlDontExist.Change("to", "Ksenia");
        xmlDontExist.Save();
        xmlDontExist.Change("from", "Laura");
        xmlDontExist.Save();

        xmlDontExist.Open();
        xmlDontExist.Change("to", "Boris");
        xmlDontExist.Save();
    }

    private static void TestTxt()
    {
        var txtExists = HandleDocument("document.txt");
        txtExists.Open();
        txtExists.Change("letter", "message");
        txtExists.Save();


        var txtDontExist = HandleDocument("document_new.txt");
        txtDontExist.Create();

        txtDontExist.Change("Laura", "Ksenia");
        txtDontExist.Save();
        txtDontExist.Change("Linda", "Laura");
        txtDontExist.Save();

        txtDontExist.Open();
        txtDontExist.Change("Laura", "Boris");
        txtDontExist.Save();
    }

    private static void TestDoc()
    {
        var docExists = HandleDocument("document.doc");
        docExists.Open();
        docExists.Change("letter", "message");
        docExists.Save();


        var docDontExist = HandleDocument("document_new.doc");
        docDontExist.Create();

        docDontExist.Change("Laura", "Ksenia");
        docDontExist.Save();
        docDontExist.Change("Linda", "Laura");
        docDontExist.Save();

        docDontExist.Open();
        docDontExist.Change("Laura", "Boris");
        docDontExist.Save();
    }

    private static AbstractHandler HandleDocument(string fileName)
    {
        AbstractHandler handler;
        if (fileName.EndsWith(".xml"))
        {
            handler = new XmlHandler(fileName);
        }
        else if (fileName.EndsWith(".txt"))
        {
            handler = new TxtHandler(fileName);
        }
        else if (fileName.EndsWith(".doc"))
        {
            handler = new DocHandler(fileName);
        }
        else
        {
            throw new ArgumentException("Unsupported file format");
        }

        return handler;
    }
}

public abstract class AbstractHandler
{
    protected readonly string FilePath;
    protected bool IsFileExists;
    protected bool IsFileOpened;

    protected AbstractHandler(string filePath)
    {
        var projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent?.Parent?.FullName;
        var filePathFromRoot = Path.Combine(projectDirectory, filePath);
        Console.WriteLine(filePath);

        if (File.Exists(filePath))
        {
            FilePath = filePath;
            IsFileExists = true;
        }
        else if (File.Exists(filePathFromRoot))
        {
            FilePath = filePathFromRoot;
            IsFileExists = true;
        }
        else
        {
            FilePath = filePathFromRoot;
            IsFileExists = false;
        }

        IsFileOpened = false;
    }

    protected void FileShouldExist(bool should)
    {
        if (IsFileExists != should)
        {
            var isShould = should ? "should" : "should not";
            throw new ArgumentException($"File {isShould} exists");
        }
    }

    protected void FileShouldBeOpened(bool should)
    {
        if (IsFileOpened != should)
        {
            var isShould = should ? "should" : "should not";
            throw new ArgumentException($"File {should} be opened");
        }
    }

    public abstract void Open();
    public abstract void Create();
    public abstract void Change(string param1, string param2);
    public abstract void Save();
}

public class XmlHandler : AbstractHandler
{
    private XDocument _xml;

    public XmlHandler(string filePath) : base(filePath)
    {
    }

    public override void Open()
    {
        FileShouldExist(true);
        _xml = XDocument.Load(FilePath);
        Console.WriteLine("Successfully opened the XML file.");
        IsFileOpened = true;
    }

    public override void Create()
    {
        FileShouldExist(false);
        _xml = new XDocument(
            new XElement("note",
                new XElement("to", "Alex"),
                new XElement("from", "Boris")
            )
        );
        Console.WriteLine("Successfully created the XML file.");
        IsFileOpened = true;
    }

    public override void Change(string element, string value)
    {
        FileShouldBeOpened(true);
        foreach (XElement el in _xml.Root.Elements(element))
        {
            el.Value = value;
        }

        Console.WriteLine("Successfully changed the XML file.");
    }

    public override void Save()
    {
        FileShouldBeOpened(true);
        _xml.Save(FilePath);
        IsFileExists = true;
        Console.WriteLine("Successfully saved the XML file.");
    }
}

public class TxtHandler : AbstractHandler
{
    private string _content;

    public TxtHandler(string filePath) : base(filePath)
    {
    }

    public override void Open()
    {
        FileShouldExist(true);
        _content = File.ReadAllText(FilePath);
        Console.WriteLine("Successfully opened the TXT file.");
        IsFileOpened = true;
    }

    public override void Create()
    {
        FileShouldExist(false);
        _content = "that is the letter from Laura to Linda";
        Console.WriteLine("Successfully created the TXT file.");
        IsFileOpened = true;
    }

    public override void Change(string line, string newValue)
    {
        FileShouldBeOpened(true);
        _content = _content.Replace(line, newValue);
        Console.WriteLine("Successfully changed the TXT file.");
    }

    public override void Save()
    {
        FileShouldBeOpened(true);
        File.WriteAllText(FilePath, _content);
        IsFileExists = true;
        Console.WriteLine("Successfully saved the TXT file.");
    }
}

public class DocHandler : TxtHandler // 🤫
{
    public DocHandler(string filePath) : base(filePath)
    {
    }
}