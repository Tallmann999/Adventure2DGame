using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item",menuName = "New Item")]
public class ItemDatabase : ScriptableObject
{
    enum ItemType
    {
        Resourse,
        Equipable,
        Consumable,
        WorkBench
    }

    enum EquoipableType
    {
        None,
        Head,
        Body,
        Backpack,
        Arms,
        Weapon,
        Legs,
    }

    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private float _weight;
    [SerializeField] private ItemType _itemType;
    [SerializeField] private EquoipableType _equoipableType;
    public  Sprite Icon;
    [SerializeField] private GameObject _dropPrefab;
    public bool CanStackItem;
    [SerializeField] private int _maxStackAmount;
}
