using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Custom : MonoBehaviour
{
    public GeneratorCustom pa;
    public Seat seat;
    public float speed = 5;
    public Item.item_type need;
    public SpriteRenderer need_icon;
    public Sprite[] iteams;
    public int score = 0;
    private void move()
    {
        //transform.Translate((seat.transform.position - transform.position) * speed * Time.deltaTime);
        transform.DOMove(seat.transform.position, 1).SetEase(Ease.Linear);
        Invoke("PassStatus", 1);
    }
    /*
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
    */
    public void CEat()
    {
        Invoke("CustomEat", 1);
    }
    // Start is called before the first frame update
    void Start()
    {
        //GeneratorCustom.Instance.seat_cnt--;
        int i = Random.Range(8, 14);
        need = (Item.item_type)i;
        need_icon.sprite = iteams[i];
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
            pa.Score += 100;
        }
        else
        {
            // score -
            pa.Score -= 50;
        }
        Destroy(seat.item.gameObject);
        seat.empty = true;
        seat.item = null;
        seat.onTable.sprite = null;
        Debug.Log("Finish");
        Leave();
    }
    public void Leave()
    { 
        transform.DOMove(transform.position + Vector3.down * 30, 1).SetEase(Ease.Linear);
        pa.seat_cnt++;
    }
}
