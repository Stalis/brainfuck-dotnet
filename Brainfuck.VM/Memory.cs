namespace Brainfuck.VM
{
    [System.Diagnostics.DebuggerDisplay("Pointer = {Pointer}; CurrentData = {CurrentData}")]
    public class Memory
    {
        public const int MemorySize = 256;

        private uint _pointer = 0;
        private readonly byte[] _data;

        public uint Pointer => _pointer;
        public byte CurrentData
        {
            get => _data[Pointer];
            set => _data[Pointer] = value;
        }

        public Memory()
        {
            _data = new byte[MemorySize];
        }

        public void StepRight()
        {
            if (Pointer >= MemorySize - 1)
                _pointer = 0;
            else
                _pointer++;
        }

        public void StepLeft()
        {
            if (Pointer <= 0)
                _pointer = MemorySize - 1;
            else
                _pointer--;
        }

        public void Inc()
        {
            _data[Pointer] = (byte)(CurrentData + 1);
        }

        public void Dec()
        {
            _data[Pointer] = (byte)(CurrentData - 1);
        }
    }
}
