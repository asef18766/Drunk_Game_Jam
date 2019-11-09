using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Item : MonoBehaviour
{
    public enum item_type { cat, icecream, bambo, bear, cash, bomb, weed, ice, water, bubble, unicorn, mayor, trash };
    public item_type type;
    public float LifeTime;
    public float speed = 50f;
    public float timer;
    public SpriteRenderer ren;
    public Sprite trash;
    public Rigidbody2D rb;
    private void move()
    {
        //transform.Translate(Vector2.right * speed * Time.deltaTime)
        rb.AddForce(Vector2.right * speed * Time.deltaTime);
    }
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        move();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ren = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > LifeTime)
        {
            ren.sprite = trash;
        }
    }

}
