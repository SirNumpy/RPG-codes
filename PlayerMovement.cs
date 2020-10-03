using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{
    ThirdPersonCharacter ThirdPerson;
    CameraRaycaster CameraRaycaster;
    Vector3 currentHitPosition;
    [SerializeField]float MoveRadiusStop = 0.2f;
    Vector3 finalPosition;
    void Start()
    {
        ThirdPerson = GetComponent<ThirdPersonCharacter>();
        CameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        Vector3 currentHitPosition = transform.position;



    }

    
    void FixedUpdate()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            switch (CameraRaycaster.layer)
            {
                case Layer.walkable:
                    currentHitPosition = CameraRaycaster.hit.point;
                    break;
                case Layer.enemy:
                    print("cannot move");
                    break;
                default:
                    print("not suppose to be here");
                    return;
            }
          
        }
        finalPosition = currentHitPosition - transform.position;
        if (finalPosition.magnitude >= MoveRadiusStop)
        {
            ThirdPerson.Move(finalPosition, false, false);
        }
        else
        {
            ThirdPerson.Move(Vector3.zero, false, false);
        }
       
    }
}
