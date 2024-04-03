// Copyright (c) 2012-2023 FuryLion Group. All Rights Reserved.

using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Canvas
{
    public class EmployeeWindow : HumanWindow
    {
        [FormerlySerializedAs("_organisationField")]
        [SerializeField]
        internal InputField OrganisationField;

        [FormerlySerializedAs("_salaryField")]
        [SerializeField]
        internal InputField SalaryField;

        [FormerlySerializedAs("_workExperienceField")]
        [FormerlySerializedAs("_workLenhthField")]
        [SerializeField]
        internal InputField WorkExperienceField;

        [FormerlySerializedAs("_saveInfo")]
        [SerializeField]
        internal Button SaveInfo;

        public Employee GetEmployeeData()
        {
            var employee = new Employee();

            DateTime birthdate;
            birthdate = !DateTime.TryParse(BirthdateField.text, out birthdate)
                ? new DateTime(2000, 1, 1)
                : Convert.ToDateTime(BirthdateField.text);

            employee.SetData(LastNameField.text, FirstNameField.text, PatronomycField.text, birthdate,
                string.IsNullOrEmpty(OrganisationField.text) ? "Unknown" : OrganisationField.text,
                int.TryParse(SalaryField.text, out var salary) ? salary : 0,
                int.TryParse(WorkExperienceField.text, out var workExperience) ? workExperience : 0);
            return employee;
        }

        public override void SetData(Human data)
        {
            var newData = (Employee) data;
            base.SetData(newData);
            OrganisationField.text = newData.Organisation;
            SalaryField.text = newData.Salary.ToString();
            WorkExperienceField.text = newData.WorkExperience.ToString();
        }

        private void Awake()
        {
            SaveInfo.onClick.AddListener(OnEmployeeButtonClicked);
        }

        private void OnEmployeeButtonClicked()
        {
            if (HumanListView.IsInEditMode)
            {
                HumanListView.SetData(GetEmployeeData());
                HumanListView.IsInEditMode = false;
            }
            else
            {
                HumanListView.Add(GetEmployeeData());
            }

            WindowManager.Close(gameObject);

            ClearData();
        }

        protected override void ClearData()
        {
            OrganisationField.text = string.Empty;
            SalaryField.text = string.Empty;
            WorkExperienceField.text = string.Empty;
            base.ClearData();
        }
    }
}