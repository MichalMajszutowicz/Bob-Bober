using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovingPlatformDetector : MonoBehaviour
{
    GameObject player;
    bool isBobPlatformed = false;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "MovingPlatform")
       {
            Debug.Log("test");
            player = GameObject.Find("Bob");
            player.transform.parent = hit.gameObject.transform;
            isBobPlatformed = true;
       } 
    }

    void Update()
    {
        if(isBobPlatformed)
        {
            player = GameObject.Find("Bob");
            if(Input.GetButtonDown("Jump"))
            {
                player.transform.SetParent(null);
                isBobPlatformed = false;
            }
        }
    }
    
}
