using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    bool isAttacking = false;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            isAttacking = true;
        }
    }

     public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy") && isAttacking)
        {
            Debug.Log("atakuje");

            Destroy(other.gameObject,0.5f);
            isAttacking = false;
        }
    }
}
