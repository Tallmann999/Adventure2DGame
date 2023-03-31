using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{


    //[SerializeField] private List<ItemSlotsUi> _uiSlots;
    //[SerializeField] private List<ItemSlot> _slots;

    [SerializeField] private ItemSlotsUi[] _uiSlots;
    [SerializeField] private ItemSlot[] _slots;











    [SerializeField] private List<ItemSlotsUi> _uiSlotsBody;
    [SerializeField] private List<ItemSlot> _slotsBody;
    


    [SerializeField] private GameObject _inventoryWindow;
    [SerializeField] private Transform _dropPrefabsPosition;

    private ItemSlot _selectedItem;
    private int _selectedItemIndex;

    [SerializeField] private TextMeshProUGUI _selectedItemName;
    [SerializeField] private TextMeshProUGUI _selectedItemDescription;
    [SerializeField] private TextMeshProUGUI _selectedItemStatsName;
    [SerializeField] private TextMeshProUGUI _selectedItemStatsValue;

    [SerializeField] private GameObject _useButton;
    [SerializeField] private GameObject _dropButton;
    [SerializeField] private GameObject _equpButton;
    [SerializeField] private GameObject _unEqupButton;

    private int _currentEquipIndex;
    private Weapon[] _currentWeaponsEquipIndex; // возможно сдесь нужно заменить на массив Оружия Где каждое оружие это число индекса
    private PlayerController _controller;

    public UnityEvent onOpenInventory;
    public UnityEvent onCloseInventory;

    public static Inventory instance; // Сингелтон  

    private void Awake()
    {
        instance = this;
        _controller = GetComponent<PlayerController>();
    }

    private void Start()
    {
        _inventoryWindow.SetActive(false);

        // в Панели персонажа для каждого слона установить свойство этго слота(В слот где голова , можно поместить только вещи с типом одеваемого Голова
        //
        //  и так для каждого типа)
        _slots = new ItemSlot[_uiSlots.Length];

        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i] = new ItemSlot();
            _uiSlots[i].Index = i;
            _uiSlots[i].ClearItemSlotInformation();
        }




        //_slots = new List<ItemSlot>(20);

        //for (int i = 0; i < _slots.Count; i++)
        //{
        //    _slots[i] = new ItemSlot();
        //    _uiSlots[i].Index = i;
        //    _uiSlots[i].ClearItemSlotInformation();
        //}
        Debug.Log(_slots.Length);
        Debug.Log(_uiSlots.Length);
    }
}

public class ItemSlot
{
    public ItemDatabases Item;
    public int Quantity;
}
