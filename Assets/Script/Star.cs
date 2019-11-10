using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public float speed;
    private Transform self;

    // Start is called before the first frame update
    void Start()
    {
        self = transform;
    }

    // Update is called once per frame
    void Update()
    {
        self.Translate(Vector3.right * (speed * Time.deltaTime));
    }
}
