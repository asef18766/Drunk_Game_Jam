using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Item : MonoBehaviour
{
    public enum item_type { cat, ice, bambo, bear, cash, bomb, fish, weed, trash
    };
    public item_type type;
    public float LifeTime;
    public float timer;
    public SpriteRenderer ren;
    public Sprite sp;
    // Start is called before the first frame update
    void Start()
    {
        ren = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > LifeTime)
        {
            ren.sprite = sp;
        }
    }
}
