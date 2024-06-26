using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateZonePlatform : MonoBehaviour
{
     private bool Used = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !Used)
        {
            GeneratorPlatforms.generator.Generate();
            Used = true;
            Destroy(gameObject);
        }
    }
}
