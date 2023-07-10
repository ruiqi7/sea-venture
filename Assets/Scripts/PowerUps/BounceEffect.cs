using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceEffect : MonoBehaviour
{    
    [Header("Settings")]
    [Tooltip("The speed at which the object bounces.")]
    public float speed;

    private Vector3 position;
    private float y;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        position.y = y + Mathf.PingPong(Time.time * speed, 0.2f);
        transform.position = position;
    }
}
