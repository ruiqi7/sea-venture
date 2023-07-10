using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWallCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            Destroy(this.gameObject);
        }
    }
}
