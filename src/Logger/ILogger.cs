using System;

namespace LE {
    public interface ILogger {
        void WriteException(Exception e);
    }
}