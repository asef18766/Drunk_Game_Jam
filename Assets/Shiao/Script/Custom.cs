using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom : MonoBehaviour
{

    public Seat seat;
    public Allenum.wine need;

    private void move()
    { 
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //GeneratorCustom.Instance.seat_cnt--;
        int i = Random.Range(0, 5);
        need = (Allenum.wine)i;
        Debug.Log(need);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

public class Allenum
{
    public enum wine { ice, water, bubble, unicorn, mayor };
}