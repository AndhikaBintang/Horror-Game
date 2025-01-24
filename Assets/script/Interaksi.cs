using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public abstract class Interaksi : MonoBehaviour
{
    public bool useEvents;
    [SerializeField]
    public string promptMassage;

   
    public void BaseInteract () 
    {
        if (useEvents)
            GetComponent<Interaction_Event>().OnInteract.Invoke ();
        interact();
    }
    protected virtual void interact() 
    {

    }
}
