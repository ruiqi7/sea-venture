using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClamController : MonoBehaviour
{
    [Header("GameObject/Component References")]
    [Tooltip("The clam object to set active.")]
    public GameObject clamObject;

    [Header("Damage Settings")]
    [Tooltip("Whether or not the object can apply damage")]
    public bool dealDamage;
    [Tooltip("Whether or not to apply damage when triggers collide")]
    public bool dealDamageOnTriggerEnter;

    void OnEnable()
    {
        StartCoroutine(Activate());
    }

    IEnumerator Activate()
    {
        int delay = Random.Range(2, 8);
        yield return new WaitForSeconds(delay);
        clamObject.SetActive(true);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (dealDamage)
            {
                if (dealDamageOnTriggerEnter) 
                {
                    DealDamage(collision.gameObject);
                }
            } 
            else 
            {
                clamObject.GetComponent<ClamController>().dealDamageOnTriggerEnter = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (gameObject.activeInHierarchy & collision.gameObject.tag == "Player")
        {
            if (!dealDamage)
            {
                clamObject.GetComponent<ClamController>().dealDamageOnTriggerEnter = false;
            }
        }
    }

    private void DealDamage(GameObject collisionGameObject)
    {
        Health collidedHealth = collisionGameObject.GetComponent<Health>();
        if (collidedHealth != null)
        {
            collidedHealth.TakeDamage(1);
        }
    }
}
