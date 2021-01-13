using System;
using System.Collections.Generic;
using System.Text;

namespace Brainfuck.VM
{
    public enum CommandEnum : byte
    {
        /// <summary>
        /// NOP
        /// </summary>
        Nop = 0x0,
        /// <summary>
        /// Increment `+`
        /// </summary>
        Inc = 0x1,
        /// <summary>
        /// Decrement `-`
        /// </summary>
        Dec = 0x2,
        /// <summary>
        /// Seek left `lbracket`
        /// </summary>
        SeekLeft = 0x3,
        /// <summary>
        /// Seek right `>`
        /// </summary>
        SeekRight = 0x4,
        /// <summary>
        /// Loop start `[`
        /// </summary>
        LoopStart = 0x5,
        /// <summary>
        /// Loop end `]`
        /// </summary>
        LoopEnd = 0x6,
        /// <summary>
        /// Print char `,`
        /// </summary>
        PrintChar = 0x7,
        /// <summary>
        /// Scan char `,`
        /// </summary>
        ScanChar = 0x8,
        /// <summary>
        /// Save to stack `/`
        /// </summary>
        Push = 0x20,
        /// <summary>
        /// Load from stack `\`
        /// </summary>
        Pop = 0x21,
        /// <summary>
        /// Begin of procedure '('
        /// </summary>
        ProcBegin = 0x31,
        /// <summary>
        /// End of procedure ')'
        /// </summary>
        ProcEnd = 0x32,
        /// <summary>
        /// Run procedure ':'
        /// </summary>
        ProcRun = 0x33,
    }
}
