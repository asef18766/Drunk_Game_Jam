﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBoom : MonoBehaviour
{
    public GameObject Boom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Boom!");
        Instantiate(Boom, gameObject.transform.position, Quaternion.identity);
        gameObject.SetActive(false);
 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}