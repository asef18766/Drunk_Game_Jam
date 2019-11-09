using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat : MonoBehaviour
{
    public enum seat_type { inside, outside };
    public seat_type st;
    public bool empty = true;
    public Custom custom;
    public Item item;
    public SpriteRenderer onTable; // on table item
    public Item[] items;


    public Item Eat()
    {
        if (st == seat_type.outside)
            return null;
        Item r = item;
        item = null;
        onTable.sprite = null;
        return r;
    }
    public void place(Item _item) //place item
    {
        if (!_item)
            return;
        switch (st)
        {
            case seat_type.inside:
                if (item)
                {
                    craft(_item);
                    onTable.sprite = item.ren.sprite;
                }
                else
                {
                    item = _item;
                    onTable.sprite = item.ren.sprite;
                }
                break;
            case seat_type.outside:
                item = _item;
                onTable.sprite = item.ren.sprite;
                break;
            default:
                break;
        }
    }
    void craft(Item _item)
    {
        Item.item_type tp = _item.type;
        switch (item.type)
        {
            case Item.item_type.cat:
                if (tp == Item.item_type.icecream)
                {
                    Destroy(item.gameObject);
                    Destroy(_item.gameObject);
                    item = Instantiate(items[1], transform.position, Quaternion.identity); 
                }
                else if(tp == Item.item_type.bambo)
                {
                    Destroy(item.gameObject);
                    Destroy(_item.gameObject);
                    item = Instantiate(items[3], transform.position, Quaternion.identity);
                    
                }
                else
                {
                    Destroy(item.gameObject);
                    Destroy(_item.gameObject);
                    item = Instantiate(items[5], transform.position, Quaternion.identity);
                }
                break;
            case Item.item_type.icecream:
                if (tp == Item.item_type.bomb)
                {
                    Destroy(item.gameObject);
                    Destroy(_item.gameObject);
                    item = Instantiate(items[0], transform.position, Quaternion.identity);
                }
                else if (tp == Item.item_type.cat)
                {
                    Destroy(item.gameObject);
                    Destroy(_item.gameObject);
                    item = Instantiate(items[1], transform.position, Quaternion.identity);
                }
                else
                {
                    Destroy(item.gameObject);
                    Destroy(_item.gameObject);
                    item = Instantiate(items[5], transform.position, Quaternion.identity);
                }
                break;
            case Item.item_type.bambo:
                if (tp == Item.item_type.cat)
                {
                    Destroy(item.gameObject);
                    Destroy(_item.gameObject);
                    item = Instantiate(items[3], transform.position, Quaternion.identity);
                }
                else
                {
                    Destroy(item.gameObject);
                    Destroy(_item.gameObject);
                    item = Instantiate(items[5], transform.position, Quaternion.identity);
                }
                break;
            case Item.item_type.bear:
                if (tp == Item.item_type.ice)
                {
                    Destroy(item.gameObject);
                    Destroy(_item.gameObject);
                    item = Instantiate(items[2], transform.position, Quaternion.identity);
                }
                else
                {
                    Destroy(item.gameObject);
                    Destroy(_item.gameObject);
                    item = Instantiate(items[5], transform.position, Quaternion.identity);
                }
                break;
            case Item.item_type.cash:
                if (tp == Item.item_type.water)
                {
                    Destroy(item.gameObject);
                    Destroy(_item.gameObject);
                    item = Instantiate(items[4], transform.position, Quaternion.identity);
                }
                else
                {
                    Destroy(item.gameObject);
                    Destroy(_item.gameObject);
                    item = Instantiate(items[5], transform.position, Quaternion.identity);
                }
                break;
            case Item.item_type.bomb:
                if (tp == Item.item_type.icecream)
                {
                    Destroy(item.gameObject);
                    Destroy(_item.gameObject);
                    item = Instantiate(items[0], transform.position, Quaternion.identity);
                }
                else
                {
                    Destroy(item.gameObject);
                    Destroy(_item.gameObject);
                    item = Instantiate(items[5], transform.position, Quaternion.identity);
                }
                break;
           
            case Item.item_type.ice:
                if (tp == Item.item_type.bear)
                {
                    Destroy(item.gameObject);
                    Destroy(_item.gameObject);
                    item = Instantiate(items[2], transform.position, Quaternion.identity);
                }
                else
                {
                    Destroy(item.gameObject);
                    Destroy(_item.gameObject);
                    item = Instantiate(items[5], transform.position, Quaternion.identity);
                }
                break;
            case Item.item_type.water:
                if (tp == Item.item_type.cash)
                {
                    Destroy(item.gameObject);
                    Destroy(_item.gameObject);
                    item = Instantiate(items[4], transform.position, Quaternion.identity);
                }
                else
                {
                    Destroy(item.gameObject);
                    Destroy(_item.gameObject);
                    item = Instantiate(items[5], transform.position, Quaternion.identity);
                }
                break;
           
            default:
                Destroy(item.gameObject);
                Destroy(_item.gameObject);
                item = Instantiate(items[5], transform.position, Quaternion.identity);
                break;
        }
        item.gameObject.SetActive(false);
    }
}
