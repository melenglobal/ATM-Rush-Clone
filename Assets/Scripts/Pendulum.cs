using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    Quaternion _start, _end;

    [SerializeField, Range(0.0f, 200f)]
    private float _angle = 90f;

    [SerializeField, Range(0.0f, 5f)]
    private float _speed= 2.0f;

    [SerializeField, Range(0.0f, 10f)]
    private float _startTime = 90f;

    private void Start()
    {
        _start = PendulumRotatin(_angle);
        _end = PendulumRotatin(-_angle);
    }

    private void Update()
    {
       
    }

    private void FixedUpdate()
    {
        _startTime += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(_start, _end,
            (Mathf.Sin(_startTime * _speed + Mathf.PI / 2.0f ) +1.0f) /2.0f);
    }

    private void ResetTimer()
    {
        _startTime = 0.0f;
    }

    Quaternion PendulumRotatin(float angle)
    {
        var pendulumRotation = transform.rotation;
        var angleX = pendulumRotation.eulerAngles.z + angle;

        if (angleX > 180)
            angleX -= 360;

        else if (angleX < -100)
            angleX += 360;
        pendulumRotation.eulerAngles = new Vector3(angleX,
            pendulumRotation.eulerAngles.y,pendulumRotation.eulerAngles.z);

        return pendulumRotation;

    }

}
