using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour {

    public float DamageValue = 2f;
    public string TargetTag = "Player";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(TargetTag))
        {
            Rigidbody2D rb = collision.rigidbody;
            if (rb != null)
            {
                PlayerController pc = rb.GetComponent<PlayerController>();
                if(pc != null && pc.currentSpeed > pc.maxSpeed/2)
                {
                    pc.takeDamage(DamageValue);
                }
            }
        }
    }
}
