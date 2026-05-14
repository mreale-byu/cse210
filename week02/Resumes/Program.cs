using System;

class Program
{
    static void Main(string[] args)
    {
        Resume resume = new Resume("Mauricio Reale");
        Job job1 = new Job("Proton Sistemas", "Software Engineer", 2020, 2025);
        Job job2 = new Job("Tem Market", "CTO", 2025, 2026);

        resume.AddJob(job1);
        resume.AddJob(job2);

        resume.Display();
    }
}