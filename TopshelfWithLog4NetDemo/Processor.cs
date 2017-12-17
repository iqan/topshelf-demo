namespace TopshelfWithLog4NetDemo
{
    using System;
    using System.Timers;
    using Topshelf.Logging;

    public class Processor
    {
        readonly Timer _timer;
        readonly LogWriter _log;

        public Processor(double interval, LogWriter log)
        {
            _log = log;
            _timer = new Timer(interval) { AutoReset = true };
            _timer.Elapsed += (sender, eventArgs) => Process();
        }

        private void Process()
        {
            _log.Info("Processing started at " + DateTime.Now);
            _log.Warn("Logging Warning at " + DateTime.Now);
            _log.Error("Logging Error at " + DateTime.Now);
            _log.Info("Processing finished at " + DateTime.Now);
        }

        public void Start() { _timer.Start(); }
        public void Stop() { _timer.Stop(); }
    }
}
