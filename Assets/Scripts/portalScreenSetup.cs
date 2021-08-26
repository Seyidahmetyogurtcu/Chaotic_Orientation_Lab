using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalScreenSetup : MonoBehaviour
{
    public Camera cmA;
    public Camera cmB;

    public Material mB;
    public Material mA;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cmA.targetTexture != null && cmB != null)
        {
            cmA.targetTexture.Release();
            cmB.targetTexture.Release();
        }
        cmA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cmB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        mA.mainTexture = cmA.targetTexture;
        mB.mainTexture = cmB.targetTexture;
    }
}
