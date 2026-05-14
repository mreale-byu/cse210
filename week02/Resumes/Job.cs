using System;

class Job
{
    private String _company;
    private String _jobTitle;
    private int _startYear;
    private int _endYear;

    public Job(String company, String jobTitle, int startYear, int endYear)
    {
        _company = company;
        _jobTitle = jobTitle;
        _startYear = startYear;
        _endYear = endYear;
    }

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }

}