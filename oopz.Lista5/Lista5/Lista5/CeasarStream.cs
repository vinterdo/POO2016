using System.IO;

namespace Lista5
{
    public class CeasarStream : Stream
    {
        private readonly byte _shift;
        private readonly Stream _str;

        public CeasarStream(Stream str, byte shift)
        {
            _str = str;
            _shift = shift;
        }

        public override int Read(byte[] array, int offset, int count)
        {
            var retValue = _str.Read(array, offset, count);

            for (var a = 0; a < array.Length; a++)
            {
                array[a] = (byte)(array[a] - _shift);
            }

            return retValue;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            byte[] changedBytes = new byte[buffer.Length];

            int index = 0;
            foreach (byte b in buffer)
            {
                changedBytes[index] = (byte)(b + _shift);
                index++;
            }

            _str.Write(changedBytes, offset, count);
        }

        public override void Close()
        {
            _str.Close();
            _str.Dispose();
        }

        public override void SetLength(long value) => _str.SetLength(value);

        public override long Seek(long offset, SeekOrigin origin) => _str.Seek(offset, origin);

        public override long Position
        {
            get { return _str.Position; }
            set { _str.Position = value; }
        }

        public override long Length => _str.Length;

        public override bool CanWrite => _str.CanWrite;

        public override void Flush() => _str.Flush();

        public override bool CanSeek => _str.CanSeek;

        public override bool CanRead => _str.CanRead;
    }
}
