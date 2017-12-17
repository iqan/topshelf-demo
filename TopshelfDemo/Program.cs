using Topshelf;

namespace TopshelfDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var intervalInSeconds = 1;

            HostFactory.Run(x =>
            {
                x.Service<Processor>(s =>
                {
                    s.ConstructUsing(name => new Processor(intervalInSeconds * 1000));
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("Topshelf Demo Service");
                x.SetDisplayName("Topshelf Demo");
                x.SetServiceName("Topshelf Demo");
            });
        }
    }
}
