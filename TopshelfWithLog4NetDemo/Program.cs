namespace TopshelfWithLog4NetDemo
{
    using Topshelf;
    using Topshelf.Logging;

    class Program
    {
        static readonly LogWriter _log = HostLogger.Get<Processor>();

        static void Main(string[] args)
        {
            var intervalInSeconds = 1;

            HostFactory.Run(x =>
            {
                x.Service<Processor>(s =>
                {
                    s.ConstructUsing(name => new Processor(intervalInSeconds * 1000, _log));
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
                x.UseLog4Net();

                x.SetDescription("Topshelf Demo Service");
                x.SetDisplayName("Topshelf Demo");
                x.SetServiceName("Topshelf Demo");
            });
        }
    }
}
