using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPursuit : MonoBehaviour
{
    public Transform player;
    public Vector3 ofset;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = player.position + ofset;
    }
}
