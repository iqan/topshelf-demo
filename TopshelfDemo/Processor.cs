namespace TopshelfDemo
{
    using System;
    using System.Timers;

    public class Processor
    {
        readonly Timer _timer;
        public Processor(double interval)
        {
            _timer = new Timer(interval) { AutoReset = true };
            _timer.Elapsed += (sender, eventArgs) => Process();
        }

        private static void Process()
        {
            Console.WriteLine("It is {0} and all is well", DateTime.Now);
        }

        public void Start() { _timer.Start(); }
        public void Stop() { _timer.Stop(); }
    }
}
