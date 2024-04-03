// Copyright (c) 2012-2023 FuryLion Group. All Rights Reserved.

using System;

namespace Canvas
{
    public class Human
    {
        internal string LastName { get; private set; }
        internal string FirstName { get; private set; }
        internal string Patronymic { get; private set; }
        internal DateTime Birthdate { get; private set; }
        

        internal void SetData(string lastName, string firstName, string patronomyc, DateTime birthdate)
        {
            LastName = lastName;
            FirstName = firstName;
            Patronymic = patronomyc;
            Birthdate = birthdate;
        }

        internal virtual string GatherData()
        {
            return $"Фамилия: {LastName} Имя: {FirstName} Отчество: {Patronymic}, Дата рождения: {Birthdate.ToShortDateString()}\n";
        }
    }
}