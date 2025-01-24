using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera Cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private playerUI playerUI;
    private InputManager inputManager;
    // Start is called before the first frame update
    void Start()
    {
        Cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<playerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(Cam.transform.position, Cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction*distance);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo,distance,mask)) 
        {
            if(hitInfo.collider.GetComponent<Interaksi>() != null) 
            {
                Interaksi interaksi = hitInfo.collider.GetComponent<Interaksi>();
                playerUI.UpdateText(interaksi.promptMassage);
                if (inputManager.Onfoot.interact.triggered)
                {
                    interaksi.BaseInteract();
                }
            }
        }
    }
}
