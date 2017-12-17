namespace TopshelfWithQuartzDemo
{
    using Quartz;
    using System;

    public class Processor : IJob
    {
        public void Start() { Console.WriteLine("Topshelf.Quartz: Starting ", DateTime.Now); }
        public void Stop() { Console.WriteLine("Topshelf.Quartz: Stopping ", DateTime.Now); }

        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Topshelf.Quartz: It is {0} and all is well", DateTime.Now);
        }
    }
}
