// Copyright (c) 2012-2023 FuryLion Group. All Rights Reserved.

using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    public Toggle _toggle;

    private int _duration = 2;
    private float _rotationAngle = 23f;
    private float _rotationSpeed = 10f;
    private float _smoothTime = 5f;

    private void Start()
    {
        transform.DORotate(new Vector3(0, transform.rotation.eulerAngles.y - _rotationAngle, 0), _duration,
                RotateMode.FastBeyond360)
            .SetEase(Ease.Linear).SetUpdate(UpdateType.Normal)
            .SetLoops(-1, LoopType.Incremental);
    }

    private void Update()
    {
        if (_toggle.isOn)
        {
            transform.DORotate(new Vector3(0, transform.rotation.eulerAngles.y - _rotationAngle, 0), _duration,
                    RotateMode.FastBeyond360)
                .SetEase(Ease.Linear).SetUpdate(UpdateType.Normal)
                .SetLoops(-1, LoopType.Incremental);
        }
        else
        {
            transform.DOPause();
            var inputAxis = Input.GetAxis("Horizontal");
            var eulerY = transform.rotation.eulerAngles.y - _rotationSpeed * inputAxis;
            var targetRotation = Quaternion.Euler(0, eulerY, 0);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _smoothTime * Time.deltaTime);
        }
    }
}