using NCrontab;

const string SCHEDULE = "*/5 * * * *";

var schedule = CrontabSchedule.Parse(SCHEDULE);
var now = DateTime.Now;

foreach (var nextRun in schedule.GetNextOccurrences(now, DateTime.MaxValue))
{
    var waitDuration = nextRun - now;

    // Wait until next run
    Console.WriteLine($"[-] {DateTime.Now} | Waiting until {DateTime.Now.Add(waitDuration)} ({waitDuration})");
    await Task.Delay(waitDuration);

    // Do work
    Console.WriteLine($"[+] {DateTime.Now} | Running job...");
    await Task.Delay(500);
    Console.WriteLine($"[+] {DateTime.Now} | Done!");

    now = DateTime.Now;
}