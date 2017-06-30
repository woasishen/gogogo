using System;

namespace Gogogo.Instances
{
    public class LogInstance
    {
        public const string ERR_START = "Err:";
        public const string WARN_START = "Warn:";

        public static LogInstance Instance { get; } = new LogInstance();

        public Action<string> ErrorMsgAction;
        public Action<string> WarnMsgAction;
        public Action<string> NormalMsgAction;
        public Action<string> AllMsgAction;

        public void LogError(string msg)
        {
            ErrorMsgAction?.Invoke(ERR_START + msg);
            AllMsgAction?.Invoke(ERR_START + msg);
        }
        public void LoWarn(string msg)
        {
            WarnMsgAction?.Invoke(WARN_START + msg);
            AllMsgAction?.Invoke(WARN_START + msg);
        }

        public void LogMsg(string msg)
        {
            NormalMsgAction?.Invoke(msg);
            AllMsgAction?.Invoke(msg);
        }
    }
}
