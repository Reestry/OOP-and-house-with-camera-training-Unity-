using System;
using System.Collections.Generic;
using Canvas;
using UnityEngine;

public class HumanListView : MonoBehaviour
{
    [SerializeField]
    private GameObject _content;

    [SerializeField]
    private HumanInfoView _panelPrefab;

    public static bool IsInEditMode;

    private static HumanListView _instance;
    private readonly List<HumanInfoView> _panels = new();

    public static int LastSelectedIndex;

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);
        else
            _instance = this;

        HumanInfoView.Selected += InfoPanelOnSelect;
    }

    private void InfoPanelOnSelect(int index)
    {
    }

    public static void Add(Human data)
    {
        var newPanel = Instantiate(_instance._panelPrefab, _instance._content.transform, false);
        newPanel.SetData(data);
        _instance._panels.Add(newPanel);
    }

    public static void SetData(Human data)
    {
        _instance._panels[LastSelectedIndex].SetData(data);
    }

    public static void Edit(int index)
    {
        IsInEditMode = true;
        
        switch (_instance._panels[index].HumanData)
        {
        case Student studentData:
            WindowManager.OpenWindow<StudentWindow>().SetData(studentData);
            break;
        case Driver driverData:
            WindowManager.OpenWindow<DriverWindow>().SetData(driverData);
            break;
        case Employee employeeData:
            WindowManager.OpenWindow<EmployeeWindow>().SetData(employeeData);
            break;
        default:
            throw new ArgumentOutOfRangeException();
        }

        LastSelectedIndex = index;
    }

    public static void Delete(int index)
    {
        Destroy(_instance._panels[index].gameObject);
        _instance._panels.RemoveAt(index);
    }

    private void OnDestroy()
    {
        HumanInfoView.Selected -= InfoPanelOnSelect;
    }
}