using Brainfuck.VM;
using System.Collections.Generic;
using System.Linq;

namespace Brainfuck.Compile
{
    public class CompilerProgramProvider : IProgramProvider
    {
        private readonly IProgramCompiler _compiler;
        private List<byte> _program;

        public CompilerProgramProvider(IProgramCompiler compiler)
        {
            _compiler = compiler;
        }

        public void LoadProgram(string text)
        {
            _program = Optimize(_compiler.Compile(text));
        }

        private List<byte> Optimize(List<byte> prog) =>
            prog.Where(v => v != 0).ToList();

        public byte GetCommand(int address)
            => _program[address];

        public bool IsEOF(int address)
            => _program.Count <= address;

        public static CompilerProgramProvider HelloWorld
        {
            get
            {
                var res = new CompilerProgramProvider(new DefaultProgramCompiler());
                res.LoadProgram(@"++++++++++[>+++++++>++++++++++>+++<<<-]>++.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.------.--------.>+.");
                return res;
            }
        }
    }
}
