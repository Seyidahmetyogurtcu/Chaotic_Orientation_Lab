 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientation : MonoBehaviour
{
    public static Orientation GlobalOrientation;

    private float MouseY = 0;

    [HideInInspector] public float Zview, Xview;

    [SerializeField] private Vector3 RelativeYposition;

    // Start is called before the first frame update
    void Start()
    {
        GlobalOrientation = this;
    }

    // Update is called once per frame
    void Update()
    {
        reOrient();
    }
    private void FixedUpdate()
    {
        ChangeGravity();
    }

    private void reOrient()
    {
        //TODO: check y_axis
        Quaternion Target = Quaternion.Euler(transform.localRotation.x, CameraTracking.GlobalCamera.transform.localEulerAngles.y, transform.localRotation.z);
        transform.localRotation =  Quaternion.Euler(Xview, transform.localRotation.y, Zview) * Target;
    }

    private void ChangeGravity()
    {
        RelativeYposition = -transform.up;
        Physics.gravity = RelativeYposition * 9.81f;
    }

    //what is this part doing?
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 8 && !Movement.GlobalController.GlobalCheck)
        {
            Zview = collision.gameObject.transform.localEulerAngles.z;
            Xview = collision.gameObject.transform.localEulerAngles.x; 
        }
    }
}
