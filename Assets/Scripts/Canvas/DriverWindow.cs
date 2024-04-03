// Copyright (c) 2012-2023 FuryLion Group. All Rights Reserved.

using System;
using UnityEngine;
using UnityEngine.UI;
using Canvas;
using UnityEngine.Serialization;

public class DriverWindow : EmployeeWindow
{
    [FormerlySerializedAs("_carBrandField")]
    [SerializeField]
    internal InputField CarBrandField;

    [FormerlySerializedAs("_carModelField")]
    [SerializeField]
    internal InputField CarModelField;

    private void Awake()
    {
        SaveInfo.onClick.AddListener(OnDeiverButtonClicked);
    }

    public Driver GetDriverData()
    {
        var driver = new Driver();

        DateTime birthdate;
        birthdate = !DateTime.TryParse(BirthdateField.text, out birthdate)
            ? new DateTime(2000, 1, 1)
            : Convert.ToDateTime(BirthdateField.text);

        driver.SetData(LastNameField.text, FirstNameField.text, PatronomycField.text, birthdate,
            string.IsNullOrEmpty(OrganisationField.text) ? "Unknown" : OrganisationField.text,
            int.TryParse(SalaryField.text, out var salary) ? salary : 0,
            int.TryParse(WorkExperienceField.text, out var workExperience) ? workExperience : 0,
            CarBrandField.text, CarModelField.text);
        return driver;
    }

    public override void SetData(Human data)
    {
        var newData = (Driver) data;
        base.SetData(newData);
        CarBrandField.text = newData.CarBrand;
        CarModelField.text = newData.CarModel;
    }

    private void OnDeiverButtonClicked()
    {
        if (HumanListView.IsInEditMode)
        {
            HumanListView.SetData(GetDriverData());
            HumanListView.IsInEditMode = false;
        }
        else
        {
            HumanListView.Add(GetDriverData());
        }

        WindowManager.Close(gameObject);

        ClearData();
    }

    protected override void ClearData()
    {
        CarBrandField.text = string.Empty;
        CarModelField.text = string.Empty;
        base.ClearData();
    }
}