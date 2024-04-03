// Copyright (c) 2012-2023 FuryLion Group. All Rights Reserved.

using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Canvas
{
    public class HumanWindow : Window
    {
        [FormerlySerializedAs("_lastNameField")]
        [SerializeField]
        internal InputField LastNameField;

        [FormerlySerializedAs("_firstNameField")]
        [SerializeField]
        internal InputField FirstNameField;

        [FormerlySerializedAs("_patronomycField")]
        [SerializeField]
        internal InputField PatronomycField;

        [FormerlySerializedAs("_birthdateField")]
        [SerializeField]
        internal InputField BirthdateField;
        
        public virtual void SetData(Human data)
        {
            LastNameField.text = data.LastName;
            FirstNameField.text = data.FirstName;
            PatronomycField.text = data.Patronymic;
            BirthdateField.text = data.Birthdate.ToString();
        }

        internal Human GetHumanData()
        {
            var human = new Human();

            human.SetData(LastNameField.text, FirstNameField.text, PatronomycField.text, DateTime.Parse(BirthdateField.text));

            return human;
        }

        protected virtual void ClearData()
        {
            FirstNameField.text = string.Empty;
            LastNameField.text = string.Empty;
            PatronomycField.text = string.Empty;
            BirthdateField.text = string.Empty;
        }
    }
}