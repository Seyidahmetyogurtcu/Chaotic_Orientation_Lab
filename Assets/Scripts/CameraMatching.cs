using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMatching : MonoBehaviour
{
    [SerializeField] private Transform PlayersCam;
    [SerializeField] private Transform Portal;
    [SerializeField] private Transform OtherPortal;


    [SerializeField] private new MeshRenderer renderer;

    private Transform Handler;

    private float StartDepth;
    private float Depth;
    // Start is called before the first frame update
    void Start()
    {
        Handler = GetComponentInParent<Transform>();
        StartDepth = Handler.localPosition.z;
    }


    void LateUpdate()
    {
        Vector3 FixedPos = new Vector3(Handler.position.x, PlayersCam.position.y, PlayersCam.position.z);
        Handler.position = FixedPos;
        Handler.localPosition = new Vector3(Handler.localPosition.x, Mathf.Clamp(Handler.localPosition.y, -2, 2), Mathf.Clamp(Handler.localPosition.z, -2, 2));
        transform.rotation = PlayersCam.rotation;
    }
}
