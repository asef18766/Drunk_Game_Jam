using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMove : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = transform.localScale * 1.05f;
        transform.Translate(Vector2.right * speed * Time.deltaTime);

    }
}
