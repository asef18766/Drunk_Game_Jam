using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public enum Player {P1, P2};
    public Player player;
    public float speed;
    public Animator anim;
    private enum target { none, item, table};
    private void Act()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            anim.SetTrigger("Attack");
        }
    }
    private void Move()
    {
        switch (player)
        {
            case Player.P1:
                if (Input.GetKey(KeyCode.W))
                {
                    transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
                }
                if (Input.GetKey(KeyCode.S))
                {
                    transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
                }
                if (Input.GetKey(KeyCode.A))
                {
                    transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
                }
                if (Input.GetKey(KeyCode.D))
                {
                    transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                }
                break;
            case Player.P2:
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                }
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
         if(other.tag == "Material")
        {
            Debug.Log("HI");
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
