using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class state_machine : MonoBehaviour
{
    public BaseState Activestate;
    

    public void Initialise()
    {

        ChangeState(new patrol_state());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Activestate != null)
        {
            Activestate.Perform();
        }
    }
    public void ChangeState (BaseState newState)
    {
        if (Activestate != null)
        {
            Activestate.Exit();
        }
        Activestate = newState;

        if (Activestate != null)
        {
            Activestate.StateMachine = this;
            Activestate.enemy = GetComponent<enemy>();
            Activestate.Enter();
        }
    }
}
