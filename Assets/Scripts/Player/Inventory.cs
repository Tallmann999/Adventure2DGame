using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{


    [SerializeField] private List<ItemSlotsUi> _uiSlots = new List<ItemSlotsUi>();
    [SerializeField] private List<ItemSlot> _slots = new List<ItemSlot>();
    //[SerializeField] private ItemSlotsUi[] _uiSlots;
    //[SerializeField] private ItemSlot[] _slots;

    [SerializeField] private List<ItemSlotsUi> _uiSlotsBody = new List<ItemSlotsUi>();
    [SerializeField] private List<ItemSlot> _slotsBody = new List<ItemSlot>();



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

        //_slots = new ItemSlot[_uiSlots.Length];
        //for (int i = 0; i < _slots.Length; i++)
        //{
        //    _slots[i] = new ItemSlot();
        //    _uiSlots[i].Index = i;
        //    _uiSlots[i].ClearItemSlotInformation();
        //}
        //Debug.Log(_slots.Length);
        //Debug.Log(_uiSlots.Length);

        InitialisionSlots(_slots, _uiSlots, _uiSlots.Count);
        InitialisionSlots(_slotsBody, _uiSlotsBody, _uiSlotsBody.Count);

        Debug.Log(_slots.Count);
        Debug.Log(_uiSlots.Count);
        Debug.Log("__________________________");
        Debug.Log(_slotsBody.Count);
        Debug.Log(_uiSlotsBody.Count);
    }

    private void InitialisionSlots(List<ItemSlot> slots, List<ItemSlotsUi> uiSlots, int uiCount)
    {
        for (int i = 0; i < uiCount; i++)
        {
            slots.Add(new ItemSlot());

            //uiSlots[i].Index = i;
            uiSlots[i].IndexSet(i);

            uiSlots[i].ClearItemSlotInformation();
        }
    }

    public void Toggle()
    {

    }

    public bool IsOpen()
    {
        return _inventoryWindow.activeInHierarchy;
    }

    public void AddItem(ItemDatabase item)
    {
        if (item.CanStackItem)
        {

        }
    }

    public void ThrowItem(ItemDatabase item)
    {

    }
    public void RemoveItem(ItemDatabase item) // если мы крафтим то удалим те предметы из инвенторя котрые нужны для крафта
    {

    }

    public void UpdateUi()
    {

    }

    public ItemSlot GetItemEquipedType(ItemDatabase item)
    {
        return null;
    }

    public ItemSlot GetItemStack(ItemDatabase item)
    {
        return null;
    }

    public ItemSlot GetEmptySlot()
    {
        return null;
    }

    public void SelectedItem(int index)
    {

    }

    private void ClearSelectedItemWindow()
    {

    }
    private void RemoveSelectedItem() // удаляем выделенные предметы из инвентаря
    {

    }

    public void OnUseButton()
    {

    }
    public void OnEquipButton()
    {

    }

    private void UnEquip(int index)
    {

    }

    public void OnUnEquipButton()
    {

    }

    public void OnDropButton()
    {

    }
    
    public bool HasItem(ItemDatabase item,int quantity) //  проверка хватает ли предметов для крафта
    {
        return false;
    }


}

//public class ItemSlot
//{
//    public ItemDatabases Item;
//    public int Quantity;
//}
