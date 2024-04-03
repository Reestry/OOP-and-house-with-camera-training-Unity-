// Copyright (c) 2012-2023 FuryLion Group. All Rights Reserved.

using Canvas;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Window
{
    [SerializeField]
    private Button _btnAddStud;

    [SerializeField]
    private Button _btnAddEmpl;

    [SerializeField]
    private Button _btnAddDriv;

    private void Awake()
    {
        _btnAddStud.onClick.AddListener(OnStudentButtonClicked);
        _btnAddEmpl.onClick.AddListener(OnEmployeeButtonClicked);
        _btnAddDriv.onClick.AddListener(OnDriverButtonClicked);
    }

    private void OnStudentButtonClicked()
    {
        WindowManager.OpenWindow<StudentWindow>();
    }
    
    private void OnEmployeeButtonClicked()
    {
        WindowManager.OpenWindow<EmployeeWindow>();
    }
    
    private void OnDriverButtonClicked()
    {
        WindowManager.OpenWindow<DriverWindow>();
    }
}
