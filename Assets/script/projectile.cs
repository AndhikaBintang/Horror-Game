/*using System.Collections;
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
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float destroyTime = 5f; // waktu peluru hancur jika tidak mengenai objek

    void Start()
    {
        Destroy(gameObject, destroyTime); // Menghancurkan peluru setelah waktu tertentu
    }

    void OnCollisionEnter(Collision collision)
    {
        // Abaikan tabrakan dengan objek yang tidak diinginkan
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Spawn Point"))
        {
            return;
        }

        // Hancurkan peluru jika mengenai objek lain
        Destroy(gameObject);
    }
}

