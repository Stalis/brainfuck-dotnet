using System;
using System.Collections.Generic;
using System.Text;

namespace Brainfuck.VM
{
    public interface IProgramProvider
    {
        byte GetCommand(int address);
        bool IsEOF(int address);
    }
}
