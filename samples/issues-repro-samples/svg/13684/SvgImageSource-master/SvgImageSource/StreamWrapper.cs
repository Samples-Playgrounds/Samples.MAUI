using System;
using System.IO;

namespace Xamarin.Forms.Svg
{
    public class StreamWrapper : Stream
    {
        Stream _wrapped;
        IDisposable _additionalDisposable;

        public StreamWrapper(Stream wrapped, IDisposable additionalDisposable = default)
        {
            if (wrapped == null)
                throw new ArgumentNullException("wrapped");

            _wrapped = wrapped;
            _additionalDisposable = additionalDisposable;
        }

        public override bool CanRead
        {
            get { return _wrapped.CanRead; }
        }

        public override bool CanSeek
        {
            get { return _wrapped.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return _wrapped.CanWrite; }
        }

        public override long Length
        {
            get { return _wrapped.Length; }
        }

        public override long Position
        {
            get { return _wrapped.Position; }
            set { _wrapped.Position = value; }
        }

        public override void Flush()
        {
            _wrapped.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _wrapped.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _wrapped.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _wrapped.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _wrapped.Write(buffer, offset, count);
        }

        protected override void Dispose(bool disposing)
        {
            _wrapped.Dispose();

            _additionalDisposable?.Dispose();
            _additionalDisposable = null;

            base.Dispose(disposing);
        }
    }
}
