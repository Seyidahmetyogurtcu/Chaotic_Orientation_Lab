using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdobjects : MonoBehaviour
{
    [SerializeField] private float Distance = 10;

    [SerializeField] LayerMask targetObject;

    private RaycastHit info;

    [SerializeField]private Transform pos;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CastObject();
    }
    private void CastObject()
    {
        info.distance = Distance;
        Ray rayFromCam = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        //TODO: check here
        if (Physics.Raycast(rayFromCam, out info, info.distance, targetObject.value) && Input.GetMouseButton(0))
        {
            info.collider.gameObject.transform.position = pos.position;
            info.collider.gameObject.transform.rotation = pos.rotation;
        }
        else if (Physics.Raycast(rayFromCam, out info, info.distance, targetObject.value) && Input.GetMouseButtonUp(0))
        {
            info.collider.gameObject.transform.position = info.collider.gameObject.transform.position;
        }

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(Camera.main.transform.position, info.point);
    }
}
