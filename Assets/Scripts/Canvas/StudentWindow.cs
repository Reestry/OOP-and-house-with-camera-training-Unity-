// Copyright (c) 2012-2023 FuryLion Group. All Rights Reserved.

using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Canvas
{
    public class StudentWindow : HumanWindow
    {
        [FormerlySerializedAs("_facultyField")]
        [SerializeField]
        internal InputField FacultyField;

        [FormerlySerializedAs("_courseField")]
        [SerializeField]
        internal InputField CourseField;

        [FormerlySerializedAs("_groupField")]
        [SerializeField]
        internal InputField GroupField;

        [FormerlySerializedAs("_saveInfo")]
        [SerializeField]
        internal Button SaveInfo;

        private void Awake()
        {
            SaveInfo.onClick.AddListener(OnStudentButtonClicked);
        }

        public Student GetStudentData()
        {
            var student = new Student();

            DateTime birthdate;
            birthdate = !DateTime.TryParse(BirthdateField.text, out birthdate)
                ? new DateTime(2000, 1, 1)
                : Convert.ToDateTime(BirthdateField.text);

            student.SetData(LastNameField.text, FirstNameField.text, PatronomycField.text, birthdate,
                FacultyField.text, CourseField.text, GroupField.text);
            return student;
        }

        public override void SetData(Human data)
        {
            var newData = (Student) data;
            base.SetData(newData);
            FacultyField.text = newData.Faculty;
            CourseField.text = newData.Course;
            GroupField.text = newData.Group;
        }

        private void OnStudentButtonClicked()
        {
            if (HumanListView.IsInEditMode)
            {
                HumanListView.SetData(GetStudentData());
                HumanListView.IsInEditMode = false;
            }
            else
            {
                HumanListView.Add(GetStudentData());
            }

            WindowManager.Close(gameObject);

            ClearData();
        }

        protected override void ClearData()
        {
            FacultyField.text = string.Empty;
            CourseField.text = string.Empty;
            GroupField.text = string.Empty;
            base.ClearData();
        }
    }
}