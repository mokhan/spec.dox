using System;
using System.Collections.Generic;
using System.Reflection;

namespace Spec.Dox
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                dispay(args);
                new Console().Execute(args);
            }
            catch (ReflectionTypeLoadException e)
            {
                System.Console.Out.WriteLine(e);
                foreach (var error in e.LoaderExceptions)
                {
                    System.Console.Out.WriteLine(error);
                }
            }
            catch (Exception e)
            {
                System.Console.Out.WriteLine(e);
                System.Console.Out.WriteLine("spec.dox.exe [full path to assembly to inspect] [full name of attribute decorating each test]");
                System.Console.Out.WriteLine("e.g...");
                System.Console.Out.WriteLine("spec.dox.exe c:/development/test.dll TestAttribute");
            }
        }

        static void dispay(IEnumerable<string> args)
        {
            System.Console.Out.WriteLine("Received:");
            foreach (var arg in args) System.Console.Out.WriteLine(arg);
            System.Console.Out.WriteLine();
        }
    }
}