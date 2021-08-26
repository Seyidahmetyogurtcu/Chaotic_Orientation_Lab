using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    private float MouseX;
    private float MouseY;

    [SerializeField] 
    private Vector3 Offset;

    [HideInInspector]
    public float Max = 60f;

    [HideInInspector]
    public float ClampedX;

    [SerializeField] Transform CameraPoint;

    private GameObject Player;

    [HideInInspector]
    public static CameraTracking GlobalCamera;

    private Quaternion TargetRot;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        GlobalCamera = this;
    }

    // Update is called once per frame
    void Update()
    {
        CameraTrack();
    }
    private void CameraTrack()
    {

        transform.position = CameraPoint.position;
        MouseY += Input.GetAxis("Mouse X") * 60 * Time.deltaTime;
        MouseX -= Input.GetAxis("Mouse Y") * 60 * Time.deltaTime;

        ClampedX = Mathf.Clamp(MouseX, -Max, Max);

        TargetRot = Quaternion.Euler(MouseX, MouseY, Player.transform.eulerAngles.z);
        transform.rotation = TargetRot;
    }
}
