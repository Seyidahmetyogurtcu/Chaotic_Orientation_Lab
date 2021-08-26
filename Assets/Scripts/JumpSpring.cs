using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSpring : MonoBehaviour
{

    private Vector3 storedVel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            storedVel = collision.gameObject.GetComponent<Rigidbody>().velocity;
            storedVel.y =  collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude + 5;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(storedVel * 100);
        }
    }
}
