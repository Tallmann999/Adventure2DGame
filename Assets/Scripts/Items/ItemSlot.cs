using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot
{
    public ItemDatabase Item;

    public ItemDatabase AddItem(ItemDatabase item)
    {
        return Item = item;
    }
    public int Quantity { get; private set; }

    public int RemoveQuantity()
    {
        return Quantity--;
    }
    public int QuantityAddStack()
    {
        return Quantity++;
    }

    public int QuantityAdd()
    {
        return Quantity = 1;
    }
}