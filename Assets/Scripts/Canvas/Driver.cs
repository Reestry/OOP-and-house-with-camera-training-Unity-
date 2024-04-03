// Copyright (c) 2012-2023 FuryLion Group. All Rights Reserved.

using System;

namespace Canvas
{
    public sealed class Driver : Employee
    {
        internal string CarBrand;

        internal string CarModel;

        internal void SetData(string lastName, string firstName, string patronomyc,
            DateTime birthdate, string organisation, int salary, int workExperience, string carBrand, string carModel)
        {
            SetData(lastName, firstName, patronomyc, birthdate, organisation, salary, workExperience);
            CarBrand = carBrand;
            CarModel = carModel;
        }

        internal override string GatherData()
        {
            return $" {base.GatherData()} Марка автомобиля:: {CarBrand}, Модель: {CarModel}\n";
        }
    }
}