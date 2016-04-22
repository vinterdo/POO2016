using System.IO;

namespace Lista5
{
    public abstract class CeasarStreamProxy : CeasarStream
    {
        private readonly CeasarStream _stream;
        private CeasarStream Subject
        {
            get
            {
                OnUse();
                return _stream;
            }
        }

        protected CeasarStreamProxy(Stream str, byte offset) : base(str, offset)
        {
            _stream = new CeasarStream(str, offset);
        }

        
        public override void Flush()
        {
            Subject.Flush();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return Subject.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            Subject.SetLength(value);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return Subject.Read(buffer, offset, count);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            Subject.Write(buffer, offset, count);
        }

        public override bool CanRead => Subject.CanRead;
        public override bool CanSeek => Subject.CanSeek;
        public override bool CanWrite => Subject.CanWrite;
        public override long Length => Subject.Length;
        public override long Position
        {
            get { return Subject.Position; }
            set { Subject.Position = value; }
        }
        
        public abstract void OnUse();
    }
}
