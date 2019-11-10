using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public enum Player {P1, P2};
    public Player player;
    public float speed;
    public Animator anim;
    public GameObject target;
    public Item hold;
    public int score;

    public Item target_item;
    public Seat target_seat;
    public Custom target_Custom;
    private void Act()
    {
        switch (player)
        {
            case Player.P1:
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    if (target_item && !hold)
                    {
                        //Debug.Log("Eat");
                        //anim.SetTrigger("Eat");
                        if (target_seat)
                        {
                            hold = target_seat.Eat();
                            target_item = null;
                        }
                        else
                        {
                            hold = target_item;
                            target_item.gameObject.SetActive(false);
                        }
                    }
                    else if (target_seat)
                    {
                        target_seat.place(hold);
                        target_item = target_seat.item;
                        hold = null;
                        //anim.SetTrigger("Place");
                    }
                    else if (target_Custom)
                    {
                        anim.SetTrigger("Attack");

                    }
                }
                break;
            case Player.P2:
                if (Input.GetKeyDown(KeyCode.Period)) // . key
                {
                    if (target_item && !hold)
                    {
                        //Debug.Log("Eat");
                        //anim.SetTrigger("Eat");
                        if (target_seat)
                        {
                            hold = target_seat.Eat();
                            target_item = null;
                        }
                        else
                        {
                            hold = target_item;
                            target_item.gameObject.SetActive(false);
                        }
                    }
                    else if (target_seat)
                    {
                        target_seat.place(hold);
                        target_item = target_seat.item;
                        hold = null;
                        //anim.SetTrigger("Place");
                    }
                    else if (target_Custom)
                    {
                        anim.SetTrigger("Attack");

                    }
                }
                break;
            default:
                break;
        }
        
    }


    private void Move() // without roatation
    {
        switch (player)
        {
            case Player.P1:
                if (Input.GetKey(KeyCode.W))
                {
                    transform.Translate(new Vector3(0, speed * Time.deltaTime, 0), Space.World);
                    transform.eulerAngles = new Vector3(0, 0, 90);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0), Space.World);
                    transform.eulerAngles = new Vector3(0, 0, -90);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0), Space.World);
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0), Space.World);
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                break;
            case Player.P2:
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.Translate(new Vector3(0, speed * Time.deltaTime, 0), Space.World);
                    transform.eulerAngles = new Vector3(0, 0, 90);
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0), Space.World);
                    transform.eulerAngles = new Vector3(0, 0, -90);
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0), Space.World);
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0), Space.World);
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //target = collision.gameObject.tag;
        //Debug.Log("TriggerEnter");
        if (collision.GetComponent<Item>())
        {
            //Debug.Log("Item Enter");
            target_item = collision.GetComponent<Item>();
        }
        if (collision.GetComponent<Seat>())
        {
            target_seat = collision.GetComponent<Seat>();
            if (target_seat.item)
                target_item = target_seat.item;
        }
        if (collision.GetComponent<Custom>())
        {
            target_Custom = collision.GetComponent<Custom>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Item Exit");
        if (collision.GetComponent<Item>())
        {
            target_item = null;
        }
        if (collision.GetComponent<Seat>())
        {
            target_seat = null;
        }
        if (collision.GetComponent<Custom>())
        {
            target_Custom = null;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Act();
        Move();

    }
}
