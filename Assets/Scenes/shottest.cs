using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shottest : MonoBehaviour
{
    public Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
           ani.SetTrigger("Shot");
    }
}
