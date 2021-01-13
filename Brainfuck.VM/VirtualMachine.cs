using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Brainfuck.VM
{
    [DebuggerDisplay("PC = {PC}")]
    public class VirtualMachine
    {
        private readonly Stack<int> _addressStack;
        private readonly Stack<byte> _dataStack;
        private readonly Dictionary<int, int> _procTable;
        private readonly Memory _memory;

        private bool _declarationMode = false;

        public Stream Cin { get; set; }
        public Stream Cout { get; set; }

        private int PC { get; set; }

        public VirtualMachine()
        {
            _addressStack = new Stack<int>();
            _dataStack = new Stack<byte>();
            _procTable = new Dictionary<int, int>();
            _memory = new Memory();
        }

        public void Run(IProgramProvider provider)
        {
            while (!provider.IsEOF(PC))
            {
                RunCommand(provider.GetCommand(PC));
            }
        }

        public void RunCommand(byte cmd)
        {
            if (!_declarationMode)
            {
                switch (cmd)
                {
                    case Commands.Nop:
                        break;
                    case Commands.Inc:
                        _memory.Inc();
                        break;
                    case Commands.Dec:
                        _memory.Dec();
                        break;
                    case Commands.SeekLeft:
                        _memory.StepLeft();
                        break;
                    case Commands.SeekRight:
                        _memory.StepRight();
                        break;
                    case Commands.LoopStart:
                        _addressStack.Push(PC);
                        break;
                    case Commands.LoopEnd:
                        if (_memory.CurrentData != 0)
                            PC = _addressStack.Peek();
                        else
                            _addressStack.Pop();
                        break;
                    case Commands.PrintChar:
                        Cout.WriteByte(_memory.CurrentData);
                        break;
                    case Commands.ScanChar:
                        _memory.CurrentData = (byte)Cin.ReadByte();
                        break;
                    case Commands.Push:
                        _dataStack.Push(_memory.CurrentData);
                        break;
                    case Commands.Pop:
                        _memory.CurrentData = _dataStack.Pop();
                        break;
                    case Commands.ProcBegin:
                        _procTable.Add(_memory.CurrentData, PC);
                        _declarationMode = true;
                        break;
                    case Commands.ProcEnd:
                        if (_addressStack.TryPop(out var addr))
                        {
                            PC = addr;
                        }
                        break;
                    case Commands.ProcRun:
                        _addressStack.Push(PC);
                        PC = _procTable[_memory.CurrentData];
                        break;
                    default:
                        throw new InvalidOperationException($"Cannot run this command: 0x{cmd:X2}");
                }
            } else
            {
                if (cmd == Commands.ProcEnd)
                {
                    _declarationMode = false;
                }
            }

            PC++;
        }
    }
}
