﻿namespace Entities
{
    public class Job
    {
        public string JobId { get; set; }

        public string JobTitle { get; set; }

        public int? MinSalary { get; set; }

        public int? MaxSalary { get; set; }

        public override string ToString()
        {
            return $"{JobTitle} ({JobId})";
        }
    }
}
