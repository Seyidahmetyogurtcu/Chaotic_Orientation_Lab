using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float Yinput;
    private float XInput;

    [SerializeField] private LayerMask What_is_ground;

    [SerializeField] private float Radius = 0.1f;
    [SerializeField] private float Speed = 10f;
    [SerializeField] private float JumpIntensity = 30f;
    [SerializeField] private float strafe;

    [SerializeField] private Transform Positioner;

    [HideInInspector]
    public bool GlobalCheck = false;

    private Rigidbody rb;

    [SerializeField] private Vector3 Offset;

    [HideInInspector]
    public static Movement GlobalController;

    [SerializeField] private float Max;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GlobalController = this;
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
        Jumping();
        CounterMovement();
    }

    private void MovementInput()
    {
        Yinput = Input.GetAxis("Vertical");
        XInput = Input.GetAxis("Horizontal");
        strafe = Yinput != 0 && XInput != 0 ? 0.5f : 1;
        rb.AddRelativeForce(((new Vector3(0, 0, 1) * Yinput + (new Vector3(1, 0, 0) * XInput)) * Speed) * strafe);

        if (UIController.singleton.isPauseMenuPanelsOpen==true)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void CounterMovement()
    {
        Vector3 Vel = rb.velocity;
        Vel.y = 0;
        float counterMovementMultiplier = (Speed) / 10f;
        rb.AddForce(-Vel * counterMovementMultiplier, ForceMode.Force);
    }
    private void Jumping()
    {
        bool isGrounded()
        {
            Collider[] colliders = Physics.OverlapSphere(Positioner.position, Radius, What_is_ground);
            if(colliders.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        float JumpMultiplier = Input.GetKeyDown(KeyCode.Space) && isGrounded() ? JumpIntensity : 0;
        rb.AddRelativeForce(new Vector3(0, 1, 0) * JumpMultiplier, ForceMode.Impulse);
        GlobalCheck = isGrounded();
    }
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(Positioner.position, Radius);
    }
}
