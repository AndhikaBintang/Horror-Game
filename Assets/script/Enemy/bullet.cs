using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Transform hitTrasform=collision.transform;
        if(hitTrasform.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
            hitTrasform.GetComponent<Player_Heatlh_UI>().TakeDamage(10);
        }
        Destroy(gameObject);
    }
}
