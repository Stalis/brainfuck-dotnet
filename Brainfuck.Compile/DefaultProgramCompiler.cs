using Brainfuck.VM;
using System.Collections.Generic;
using System.Linq;

namespace Brainfuck.Compile
{
    public class DefaultProgramCompiler : IProgramCompiler
    {
        public List<byte> Compile(string text)
        {
            return text.Select(DecodeChar).Optimize().ToList();
        }

        public byte DecodeChar(char ch)
        {
            switch (ch)
            {
                case '+':
                    return Commands.Inc;
                case '-':
                    return Commands.Dec;
                case '<':
                    return Commands.SeekLeft;
                case '>':
                    return Commands.SeekRight;
                case '[':
                    return Commands.LoopStart;
                case ']':
                    return Commands.LoopEnd;
                case '.':
                    return Commands.PrintChar;
                case ',':
                    return Commands.ScanChar;
                case '(':
                    return Commands.ProcBegin;
                case ')':
                    return Commands.ProcEnd;
                case ':':
                    return Commands.ProcRun;
                case '/':
                    return Commands.Push;
                case '\\':
                    return Commands.Pop;
                default:
                    return Commands.Nop;
            }
        }

    }

    internal static class Ext
    {
        public static IEnumerable<byte> Optimize(this IEnumerable<byte> program)
            => program.Where(v => v != Commands.Nop).ToList();
    }
}
