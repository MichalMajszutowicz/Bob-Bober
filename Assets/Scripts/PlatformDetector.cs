using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
       if(other.gameObject.tag == "Player")
       {
            other.gameObject.transform.SetParent(transform);
       } 
    }

    private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.transform.SetParent(null);
        }
    }
}
