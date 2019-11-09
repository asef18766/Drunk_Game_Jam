using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Custom : MonoBehaviour
{

    public Seat seat;
    public float speed = 5;
    public Item.item_type need;
    public int score = 0;

    private void move()
    {
        //transform.Translate((seat.transform.position - transform.position) * speed * Time.deltaTime);
        transform.DOMove((seat.transform.position - Vector3.left), 1).SetEase(Ease.Linear);
        Invoke("PassStatus", 1);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (seat.item == null)
            return;
        else
        {
            Debug.Log("Eating");
            Invoke("CustomEat", 1);
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
    public void CustomEat()
    {
        if (seat.item == null)
            return;
        if (seat.item.type == need)
        {
            // score +
            score += 100;
        }
        else
        {
            // score -
            score -= 50;
        }
        Destroy(seat.item.gameObject);
        seat.item = null;
        seat.onTable.sprite = null;
        Debug.Log("Finish");
        Leave();
    }
    public void Leave()
    { 
        transform.DOMove(transform.position + Vector3.down * 30, 1).SetEase(Ease.Linear);
    }
}
