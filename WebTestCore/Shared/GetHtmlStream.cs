using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebTestCore.Shared
{
    public class GetHtmlStream : Stream
    {
        private readonly Stream outputStream;

        public GetHtmlStream(Stream stream)
        {
            outputStream = stream;
        }
        public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            var html = Encoding.UTF8.GetString(buffer, offset, count);

            //а тут мы выводим на консоль наш сгенеренный html, лучше выводить здесь, а не в вызывающем классе - тут асинхронка, и вызывающий класс
            //выполняется прежде, чем отсюда инфа поступит в консоль
            Console.WriteLine(html);
            Console.WriteLine("-----------------------------------------------------------------------------------------------");

            buffer = Encoding.UTF8.GetBytes(html);
            await outputStream.WriteAsync(buffer, 0, buffer.Length, cancellationToken);
        }
        public override bool CanRead { get { return false; } }

        public override bool CanSeek { get { return false; } }

        public override bool CanWrite { get { return true; } }

        public override long Length => throw new NotImplementedException();

        public override long Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Flush()
        {
            outputStream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
    }
}
