using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public string TargetTag = "Player";
    public float DamageValue = 5f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TargetTag))
        {
            Rigidbody2D rb = collision.rigidbody;
            if (rb != null)
            {
                PlayerController pc = rb.GetComponent<PlayerController>();
                if (pc != null )
                {
                    Debug.Log("Hit");
                    pc.takeDamage(DamageValue);
                }
            }
        }
    }
}
