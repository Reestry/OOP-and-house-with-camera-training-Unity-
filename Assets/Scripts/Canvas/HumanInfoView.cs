// Copyright (c) 2012-2023 FuryLion Group. All Rights Reserved.

using System;
using Canvas;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HumanInfoView : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    [FormerlySerializedAs("_delBtn")]
    [SerializeField]
    private Button _deleteButton;

    [FormerlySerializedAs("_editBtn")]
    [SerializeField]
    private Button _editButton;

    public static event Action<int> Selected;

    public Human HumanData { private set; get; }

    private void Awake()
    {
        _deleteButton.onClick.AddListener(Delete);
        _editButton.onClick.AddListener(Edit);
    }

    public void SetData(Human data)
    {
        HumanData = data;
        _text.text = HumanData.GatherData();
    }

    private void Delete()
    {
        var index = transform.GetSiblingIndex();
        HumanListView.Delete(index);
    }

    private void Edit()
    {
        var index = transform.GetSiblingIndex();

        HumanListView.Edit(index);
    }
}