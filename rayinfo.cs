using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayinfo : MonoBehaviour
{
    CameraRaycaster obj;
    void Start()
    {
        obj = GetComponent<CameraRaycaster>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            print(obj.layer);
        }
    }
}
