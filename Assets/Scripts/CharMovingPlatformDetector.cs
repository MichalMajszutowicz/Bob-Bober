using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovingPlatformDetector : MonoBehaviour
{
    GameObject player;

     void OnTriggerEnter(Collider other) {
        Debug.Log(other + " is inside OnTriggerEnter");
        if(other.gameObject.layer == LayerMask.NameToLayer("MovPlatform")) {
            Debug.Log("The player is on the platform");
            transform.parent = other.transform;
            //isBobPlatformed = true;
        }
     }

     void OnTriggerExit(Collider other)
     {
        if(other.gameObject.layer == LayerMask.NameToLayer("MovPlatform"))
        {
            player = GameObject.Find("Bob");
            player.transform.SetParent(null);
        }
     }

    
}
