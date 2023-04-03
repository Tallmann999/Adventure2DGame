using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemDatabase : ScriptableObject
{
    public enum ItemType
    {
        Resourse,
        Equipable,
        Consumable,
        WorkBench
    }

    public  enum EquoipableType
    {
        None,
        Head,
        Body,
        Backpack,
        Arms,
        Weapon,
        Legs,
    }

    [SerializeField]private string _name;
    [SerializeField] private string _description;
    [SerializeField] private float _weight;
    [SerializeField] private ItemType _itemTypes;
    [SerializeField] private EquoipableType _equoipableTypes;
    [SerializeField] private Sprite _icon;
    [SerializeField] private GameObject _dropPrefab;
    [SerializeField] private bool _canStackItem;
    [SerializeField] private int _maxStackAmount;

    public string Name => _name;
    public string Description => _description;
    public float Weight => _weight;
    public ItemType ItemTypes => _itemTypes;
    public EquoipableType EquoipableTypes => _equoipableTypes;
    public Sprite Icon => _icon;
    public GameObject DropPrefab => _dropPrefab;
    public bool CanStackItem => _canStackItem;
    public int MaxStackAmount => _maxStackAmount;

}
