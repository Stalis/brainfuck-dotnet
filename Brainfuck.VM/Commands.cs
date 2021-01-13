using System;
using System.Collections.Generic;
using System.Text;

namespace Brainfuck.VM
{
    public static class Commands
    {
        /// <summary>
        /// NOP
        /// </summary>
        public const byte Nop = 0x0;
        /// <summary>
        /// Increment `+`
        /// </summary>
        public const byte Inc = 0x1;
        /// <summary>
        /// Decrement `-`
        /// </summary>
        public const byte Dec = 0x2;
        /// <summary>
        /// Seek left `lbracket`
        /// </summary>
        public const byte SeekLeft = 0x3;
        /// <summary>
        /// Seek right `>`
        /// </summary>
        public const byte SeekRight = 0x4;
        /// <summary>
        /// Loop start `[`
        /// </summary>
        public const byte LoopStart = 0x5;
        /// <summary>
        /// Loop end `]`
        /// </summary>
        public const byte LoopEnd = 0x6;
        /// <summary>
        /// Print char `;`
        /// </summary>
        public const byte PrintChar = 0x7;
        /// <summary>
        /// Scan char `;`
        /// </summary>
        public const byte ScanChar = 0x8;
        /// <summary>
        /// Save to stack `/`
        /// </summary>
        public const byte Push = 0x20;
        /// <summary>
        /// Load from stack `\`
        /// </summary>
        public const byte Pop = 0x21;
        /// <summary>
        /// Begin of procedure '('
        /// </summary>
        public const byte ProcBegin = 0x31;
        /// <summary>
        /// End of procedure ')'
        /// </summary>
        public const byte ProcEnd = 0x32;
        /// <summary>
        /// Run procedure ':'
        /// </summary>
        public const byte ProcRun = 0x33;
    }
}
