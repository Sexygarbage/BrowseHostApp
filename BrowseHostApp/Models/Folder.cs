using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BrowseHostApp.Models
{
    public class Folder
    {
        public List<Folder> File;
        public string Name;

        public Folder() { }

        public Folder(string name)
        {
            Name = name;
        }


        public IEnumerable<string> GetFiles(string folder = @"c:\", string filter="", bool recursive=true)
        {
            string[] found = null;
            try
            {
                found = Directory.GetFiles(folder, filter);
            }
            catch { }
            if (found != null)
                foreach (var x in found)
                    yield return x;
            if (recursive)
            {
                found = null;
                try
                {
                    found = Directory.GetDirectories(folder);
                }
                catch { }
                if (found != null)
                    foreach (var x in found)
                        foreach (var y in GetFiles(x, filter, recursive))
                            yield return y;
            }
        }
    }

    abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Operation();

        public abstract void Add(Component component);

        public abstract void Remove(Component component);

        public abstract Component GetChild(int index);
    }

    class Leaf : Component
    {
        public Leaf(string name)
            : base(name)
        {
        }

        public override void Operation()
        {
            Console.WriteLine(name);
        }

        public override void Add(Component component)
        {
            throw new InvalidOperationException();
        }

        public override void Remove(Component component)
        {
            throw new InvalidOperationException();
        }

        public override Component GetChild(int index)
        {
            throw new InvalidOperationException();
        }


    }



    class Composite : Component
    {
        ArrayList nodes = new ArrayList();

        public Composite(string name)
            : base(name)
        {
        }

        public override void Operation()
        {
            Console.WriteLine(name);

            foreach (Component component in nodes)
                component.Operation();
        }

        public override void Add(Component component)
        {
            nodes.Add(component);
        }

        public override void Remove(Component component)
        {
            nodes.Remove(component);
        }

        public override Component GetChild(int index)
        {
            return nodes[index] as Component;
        }

    }

    public class Register
    {
        public int registerId { get; set; }
        public string registerName { get; set; }
        public string registerAccess { get; set; }
        public List<Register> registerChildren { get; set; }

        public Register(int ID, string Name, List<Register> Children)
        {
            this.registerId = ID;
            this.registerName = Name;
            this.registerChildren = Children;
        }
        public Register() { }
    }
    

}