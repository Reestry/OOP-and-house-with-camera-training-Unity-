// Copyright (c) 2012-2023 FuryLion Group. All Rights Reserved.

using System;

namespace Canvas
{
    public class Student : Human
    {
        internal string Faculty { get; private set; }
        internal string Course { get; private set; }
        internal string Group { get; private set; }

        internal void SetData(string lastName, string firstName, string patronomyc, 
            DateTime birthdate, string faculty, string course, string group)
        {
            SetData(lastName, firstName, patronomyc, birthdate);
            Faculty = faculty;
            Course = course;
            Group = group;
        }

        internal override string GatherData()
        {
            return $"{base.GatherData()} Факультет: {Faculty}, Номер курса: {Course}, Группа: {Group}\n";
        }
    }
}