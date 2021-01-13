using Brainfuck.VM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brainfuck.Compile
{
    public interface IProgramCompiler
    {
        List<byte> Compile(string text);
    }
}
