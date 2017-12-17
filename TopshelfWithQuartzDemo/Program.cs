namespace TopshelfWithQuartzDemo
{
    using System;
    using Quartz;
    using Topshelf;
    using Topshelf.Quartz;

    class Program
    {
        static void Main(string[] args)
        {
            var intervalInSeconds = 1;

            HostFactory.Run(x =>
            {
                x.Service<Processor>(s =>
                {
                    s.ConstructUsing(name => new Processor());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());

                    s.ScheduleQuartzJob(q =>
                        q.WithJob(() =>
                            JobBuilder.Create<Processor>().Build())
                        .AddTrigger(() =>
                            TriggerBuilder.Create()
                                .WithSimpleSchedule(builder => builder
                                    .WithIntervalInSeconds(intervalInSeconds)
                                    .RepeatForever())
                                .Build())
                        );
                });
                x.RunAsLocalSystem();

                x.SetDescription("Topshelf Demo Service");
                x.SetDisplayName("Topshelf Demo");
                x.SetServiceName("Topshelf Demo");
            });
        }
    }
}
