using Brainfuck.Compile;
using Brainfuck.VM;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Brainfuck
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var vm = new VirtualMachine();

                var prog1 = new CompilerProgramProvider(new DefaultProgramCompiler());
                var text = File.ReadAllText("StackTest.bf");
                prog1.LoadProgram(text);

                var s = new MemoryStream();

                vm.Cin = Console.OpenStandardInput();
                vm.Cout = Console.OpenStandardOutput();

                vm.Run(prog1);

                var pos = s.Position;
                s.Seek(0, SeekOrigin.Begin);

                var sr = new StreamReader(s, Encoding.ASCII);

                Console.WriteLine(sr.ReadToEnd());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
#if DEBUG
            finally
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
#endif
        }
    }
}
