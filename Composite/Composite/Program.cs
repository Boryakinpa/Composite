using System;
using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        Component document = new Document("Животные Африки");
        Component document2 = new Document("AOAOAO");
        Component section = new Section("Млекопитающие");
        Component sectionFood = new Section("Что они едят");
        Component paragraphLeon = new Paragraph("Лев");
        Component paragraphAntil = new Paragraph("Антилопа");
        Component paragraphFood1 = new Paragraph("Зверей");
        Component paragraphFood2 = new Paragraph("Траву");
        document.Add(section);
        section.Add(paragraphLeon);
        section.Add(paragraphAntil);
        section.Add(sectionFood);
        sectionFood.Add(paragraphFood1);
        sectionFood.Add(paragraphFood2);
        document.Display(0);
        document.Add(document2);
    }
}

internal abstract class Component
{
    public string Name { get; private set; }
    public Component(string name)
    {
        Name = name;
    }
    public virtual void Add(Component component) { }
    public virtual void Remove(Component component) { }
    public virtual void Display(int depth)
    {
        Console.WriteLine(Name);
    }

}

internal class Document : Component
{
    private List<Component> components = new List<Component>();
    public Document(string name) : base(name)
    {
    }

    public override void Add(Component component) 
    {
        if(component is Section)
        {
            components.Add(component);
        }
        else { Console.WriteLine("КРИТИКАЛ ОШИБКА"); }
    }
    public override void Remove(Component component)
    {
        components.Remove(component);
    }
    public override void Display(int depth = 0)
    {
        Console.WriteLine(new string('-', depth) + "Документ " + Name);
        Console.WriteLine(new string('-', depth+1) + "Разделы:");
        depth++;
        foreach (Component component in components)
        {
            component.Display(depth);
        }
    }
}

internal class Section : Component
{
    private List<Component> components = new List<Component>();
    public Section(string name) : base(name)
    {
    }
    public override void Add(Component component)
    {
        if (component is Section || component is Paragraph)
        {
            components.Add(component);
        }
        else { Console.WriteLine("КРИТИКАЛ ОШИБКА"); }
    }
    public override void Remove(Component component)
    {
        components.Remove(component);
    }
    public override void Display(int depth = 0)
    {
        Console.WriteLine(new string('-', depth) + "-Раздел " + Name);
        Console.WriteLine(new string('-', depth) + "-Разделы и параграфы:");
        depth++;
        foreach (Component component in components)
        {
            component.Display(depth);  
        }
        Console.WriteLine();
    } 
}

internal class Paragraph : Component
{
    public Paragraph(string name) : base(name)
    {
    }
    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth+1) + Name);
    }
}