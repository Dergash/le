using System;

namespace LE {
    public interface ILogger {
        void WriteDebug(String msg);
        void WriteException(Exception e);
    }
}
