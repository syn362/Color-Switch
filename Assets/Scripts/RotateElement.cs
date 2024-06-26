using System;
using UnityEngine;

public class RotateElement : MonoBehaviour
{
    public float speed = 10;

    private void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
