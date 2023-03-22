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
        Consumable
    }

    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private int _weight;
    [SerializeField] private ItemType _itemType;
    [SerializeField] private Sprite _icon;
    [SerializeField] private GameObject _dropPrefab;
    [SerializeField] private bool _canStachItem;
    [SerializeField] private int _maxStackAmount;
}
