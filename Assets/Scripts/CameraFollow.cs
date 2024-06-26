using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;

    void LateUpdate()
    {
        if (Player.position.y > transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, Player.position.y, transform.position.z);
            transform.position = newPos;
        }
      
    }
}