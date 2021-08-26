using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticCamera : MonoBehaviour
{
    private float X;
    private float Y;

    [SerializeField] private float speed = 20;
    [SerializeField] private float Max = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        View();
    }

    private void View()
    {
        X -= Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
        Y += Input.GetAxis("Mouse X") * speed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(Mathf.Clamp(X, -Max, Max), Mathf.Clamp(Y, -Max, Max), 0);
    }
}
