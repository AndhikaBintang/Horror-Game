using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float destroyTime = 5f; // waktu peluru hancur jika tidak mengenai objek

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
