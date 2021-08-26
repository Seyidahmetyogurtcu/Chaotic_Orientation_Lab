using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour

{
    [SerializeField] private GameObject springBottom;
    [SerializeField] private GameObject[] portals;
    
    [Header("Functionalities")]
    [SerializeField] private bool doesTriggerDoors;
    [SerializeField] private bool doesTriggerAnimation;
    [SerializeField] private bool doesTriggerPortals;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject == springBottom)
        {
            OnPortalTrigger(true);
            Debug.Log("isActive");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == springBottom)
        {
            OnPortalTrigger(false);
        }
    }
    private void OnPortalTrigger(bool isActive)
    {
        if (doesTriggerPortals && portals != null)
        {
            foreach (GameObject port in portals)
            {
                port.transform.Find("portalCollider").GetComponent<MeshCollider>().enabled = isActive;
                port.transform.Find("Portal_OBJ").GetComponent<MeshRenderer>().enabled = isActive;
            }
        }
    }
}
