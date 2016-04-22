using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista5
{
    public class CeasarLoggerProxy : CeasarStreamProxy
    {
        public CeasarLoggerProxy(Stream str, byte offset) : base(str, offset)
        {
        }

        public override void OnUse()
        {
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            Console.WriteLine(DateTime.Now.ToShortTimeString() +
                              " called CeasarLoggerProxy.Write with params :  buffer : " + buffer.ToString() +
                              " offset : " + offset + " count : " + count);
            return base.Read(buffer, offset, count);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            Console.WriteLine(DateTime.Now.ToShortTimeString() +
                              " called CeasarLoggerProxy.Read with params :  buffer : " + buffer.ToString() +
                              " offset : " + offset + " count : " + count);
            base.Write(buffer, offset, count);
        }

    }
}
