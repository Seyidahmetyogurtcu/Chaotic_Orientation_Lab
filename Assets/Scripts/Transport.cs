using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour
{
    [SerializeField] private string targetPortTag;

    private new GameObject collider;

    private bool DidTransport;

    [SerializeField] private Vector3 storedMovementData;

    [SerializeField] private Renderer R;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transp_();
    }

    private void Transp_()
    {
        if (DidTransport)
        {
            Vector3 portalToPlayer = collider.transform.position - transform.position;
            float SmoothTransition = Vector3.Dot(transform.up, portalToPlayer);
            if(SmoothTransition < 0)
            {
                float rotationDiff = Quaternion.Angle(transform.rotation, GameObject.FindWithTag(targetPortTag).transform.rotation);
                rotationDiff += 180;
                collider.gameObject.transform.Rotate(Vector3.up, rotationDiff);

                Vector3 PosOffset = Quaternion.Euler(0, rotationDiff, 0) * portalToPlayer;
                collider.transform.position = GameObject.FindWithTag(targetPortTag).transform.position + PosOffset;
                DidTransport = false;
            }
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        storedMovementData = collision.gameObject.GetComponent<Rigidbody>().velocity;
        collider = collision.gameObject;
        DidTransport = true;
        Debug.Log("Operates");
    }
    private void OnTriggerExit(Collider collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().velocity += storedMovementData;
        
        Debug.Log("Operates");
    }
}
