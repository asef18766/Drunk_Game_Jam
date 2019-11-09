using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Custom : MonoBehaviour
{

    public Seat seat;
    public float speed = 5;
    public Item.item_type need;
    public Seat target;

    private void move()
    {
        //transform.Translate((seat.transform.position - transform.position) * speed * Time.deltaTime);
        transform.DOMove(seat.transform.position, 1).SetEase(Ease.Linear);
        Invoke("PassStatus", 1);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Seat>())
        {
            target = collision.GetComponent<Seat>();
            if(target.item.type == need)
            {
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //GeneratorCustom.Instance.seat_cnt--;
        int i = Random.Range(7, 12);
        need = (Item.item_type)i;
        Debug.Log(need);
        move();
    }

    public void PassStatus()
    {
        seat.custom = this;
    }
}
