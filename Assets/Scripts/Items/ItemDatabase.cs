using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemDatabase : ScriptableObject
{
    enum ItemType
    {
        Resourse,
        Equipable,
        Consumable
    }

    enum EquipType
    {
        None,
        Head,
        Arms,
        Body,
        Belt,
        Legs
    }

    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private float _weight;
    [SerializeField] private ItemType _itemType;
    [SerializeField] private EquipType _equipType;
    [SerializeField] private Sprite _icon;
    [SerializeField] private GameObject _dropPrefab;
    [SerializeField] private bool _canStachItem;
    [SerializeField] private int _maxStackAmount;
}
