// Copyright (c) 2012-2023 FuryLion Group. All Rights Reserved.

using System;

namespace Canvas
{
    public class Employee : Human
    {
        internal string Organisation;
        
        internal int Salary;

        internal int WorkExperience;

        internal void SetData(string lastName, string firstName, string patronomyc, 
            DateTime birthdate, string organisation, int salary, int workExperience)
        {
            SetData(lastName, firstName, patronomyc, birthdate);
            Organisation = organisation;
            Salary = salary;
            WorkExperience = workExperience;
        }
        
        internal override string GatherData()
        {
            return $"{base.GatherData()} Организация: {Organisation}, " +
                   $"Зарплата: {Salary}, Длительность работы: {WorkExperience}\n";
        }
    }
}