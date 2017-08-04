using System;
using System.Timers;


namespace MultiChannelIntegration
{
    class Program
    {
        private static Logger Logger = Logger.Instance;
        const double interval60Minutes = 60 * 60 * 1000; // milliseconds to one hour

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            JetScheduler JetScheduler = new JetScheduler();

            Timer Timer = new Timer(5000);
            Timer.Elapsed += new ElapsedEventHandler(JetScheduler.CheckForOrdersTimerElapsed);
            Timer.Interval = 5000;
            Timer.AutoReset = true;
            Timer.Enabled = true;

            Timer LogTimer = new Timer(2000);
            LogTimer.Elapsed += new ElapsedEventHandler(DumpLogTimerElapsed);
            LogTimer.Interval = 5000;
            LogTimer.AutoReset = true;
            LogTimer.Enabled = true;

            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
        }


        static void DumpLogTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Logger.DumpLog();
        }


        static void OnProcessExit(object sender, EventArgs e)
        {
            Logger.DumpLog();
            Console.WriteLine("Goodbye");
        }
    }
}
