using System;

class Resume
{
    private String _name;
    private List<Job> _jobs = new List<Job>();

    public Resume(String name)
    {
        _name = name;
    }

    public void AddJob(Job job)
    {
        _jobs.Add(job);
    }

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}