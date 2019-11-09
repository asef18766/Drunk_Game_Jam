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
    private Item[] items;

    void Start()
    {

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
                }
                else
                {
                    item = _item;
                    onTable.sprite = item.ren.sprite;
                }
                break;
            case seat_type.outside:
                item = _item;
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
                if (tp == Item.item_type.icecream) {
                    item = Instantiate() 
                }
                break;
            case Item.item_type.icecream:
                break;
            case Item.item_type.bambo:
                break;
            case Item.item_type.bear:
                break;
            case Item.item_type.cash:
                break;
            case Item.item_type.bomb:
                break;
            case Item.item_type.weed:
                break;
            case Item.item_type.trash:
                break;
            case Item.item_type.ice:
                break;
            case Item.item_type.water:
                break;
            case Item.item_type.bubble:
                break;
            case Item.item_type.unicorn:
                break;
            case Item.item_type.mayor:
                break;
            default:
                break;
        }
    }
}
