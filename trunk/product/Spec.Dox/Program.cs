using Spec.Dox.Infrastructure.Container;

namespace Spec.Dox {
    public class Program {
        private static void Main(string[] args) {
            try {
                Resolve.AnImplementationOf<IConsole>().Execute(args);
            }
            catch {
                System.Console.Out.WriteLine(
                    "spec.dox.exe [full path to assembly to inspect] [full name of attribute decorating each test]");
                System.Console.Out.WriteLine("e.g...");
                System.Console.Out.WriteLine("spec.dox.exe 'c:/development/test.dll' TestAttribute");
            }
        }
    }
}