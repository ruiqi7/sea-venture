using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCompletionManager : MonoBehaviour
{
    [Header("Game Completion")]
    [Tooltip("The game reward.")]
    public GameObject gameReward;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(gameReward, transform.position, transform.rotation, null);
            GameManager.instance.GameCleared();
        }
    }
}
