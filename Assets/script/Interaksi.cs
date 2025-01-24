using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interaksi : MonoBehaviour
{
    public string promptMassage;

    public void BaseInteract () 
    {
        interact();
    }
    protected virtual void interact() 
    {

    }
}
