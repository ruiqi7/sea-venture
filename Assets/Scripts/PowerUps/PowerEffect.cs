using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerEffect : MonoBehaviour
{
    [Header("GameObject/Component References")]
    [Tooltip("The gun object to attach to the player.")]
    public GameObject gun;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collider = collision.gameObject;
        if (collider.tag == "Player")
        {
            string power = gameObject.name;
            switch(power)
            {
                case "ExtraSpeed":
                    Controller playerController = collider.GetComponent<Controller>();
                    playerController.moveSpeed += 10.0f;       
                    break;
                case "ExtraLife":
                    Health playerHealth = collider.GetComponent<Health>();
                    playerHealth.currentLives += 1;
                    break;
                case "ExtraGun":
                    Vector3 rotationEulerAngles = gun.transform.rotation.eulerAngles;
                    rotationEulerAngles.z -= 5f;
                    Vector3 position = gun.transform.position;
                    position.y -= 0.25f;
                    Instantiate(gun, position, Quaternion.Euler(rotationEulerAngles), collider.transform);
                    
                    rotationEulerAngles = gun.transform.rotation.eulerAngles;
                    rotationEulerAngles.z += 5f;
                    position = gun.transform.position;
                    position.y += 0.25f;
                    Instantiate(gun, position, Quaternion.Euler(rotationEulerAngles), collider.transform);
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }
}
