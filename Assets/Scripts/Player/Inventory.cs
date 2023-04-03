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

    private float _maxWeight = 40;
    private float _currentWeight = 0;

    private ItemSlot _selectedItem;
    private int _selectedItemIndex;

    [SerializeField] private TextMeshProUGUI _selectedItemName;
    [SerializeField] private TextMeshProUGUI _selectedItemDescription;
    [SerializeField] private TextMeshProUGUI _selectedItemStatsName;
    [SerializeField] private TextMeshProUGUI _selectedItemStatsValue;
    [SerializeField] private TextMeshProUGUI _currentweightValueView;
    [SerializeField] private TextMeshProUGUI _maxtweightValueView;

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
        //_weightValueView.text = _maxWeight.ToString();
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

        ClearSelectedItemWindow();
    }

    private void Update()
    {
        _currentweightValueView.text = _currentWeight.ToString();
        _maxtweightValueView.text = _maxWeight.ToString();

        OnInventoryButton();
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
    public void OnInventoryButton()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        if (_inventoryWindow.activeInHierarchy)
        {
            _inventoryWindow.SetActive(false);
            onCloseInventory.Invoke();
            _controller.ToogleCursor(false);
        }
        else
        {
            _inventoryWindow.SetActive(true);
            onOpenInventory.Invoke();
            _controller.ToogleCursor(true);

            ClearSelectedItemWindow();
        }
    }

    public bool IsOpen()
    {
        return _inventoryWindow.activeInHierarchy;
    }

    public void EquipetAddSlots(ItemDatabase item)
    {
        if (item.EquoipableTypes == ItemDatabase.EquoipableType.Body)
        {

        }
    }

    public void AddItem(ItemDatabase item) // функция которая добавляет предмет и проверяет его на колличество заполнения  в слоте
    {
        if (item.CanStackItem)
        {
            ItemSlot slotToStack = GetItemStack(item);

            if (slotToStack != null)
            {
                slotToStack.QuantityAddStack();
                _currentWeight += item.Weight;
                UpdateUi();
                return;
            }
        }
        
        ItemSlot emptySlot = GetEmptySlot();

        if (emptySlot != null) // если мы находим не пустой слот
        {
            emptySlot.AddItem(item);
            emptySlot.QuantityAdd();
            _currentWeight += item.Weight;
            UpdateUi();
            return;
        }

        ThrowItem(item);//если у нас нет ни одного доступного слота, элемент не может складываться, а затем просто выбрасывается.

    }

    public void ThrowItem(ItemDatabase item)
    {
        Instantiate(item.DropPrefab, _dropPrefabsPosition.position,Quaternion.Euler(Vector3.one * Random.value));
    }

    public void RemoveItem(ItemDatabase item) // если мы крафтим то удалим те предметы из инвенторя котрые нужны для крафта
    {

    }

    private void UpdateUi()
    {
        // нужно попробовать через foreach
        for (int i = 0; i < _slots.Count; i++)
        {
            if (_slots[i].Item != null)
            {
                _uiSlots[i].SetItemSlotInformation(_slots[i]);
            }
            else
            {
                _uiSlots[i].ClearItemSlotInformation();
            }
        }
    }

    public ItemSlot GetItemStack(ItemDatabase item)
    {
        for (int i = 0; i < _slots.Count; i++)
        {
            if (_slots[i].Item == item && _slots[i].Quantity < item.MaxStackAmount)
            {
                return _slots[i];
            }
        }

        return null;
    }

    public ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < _slots.Count; i++)
        {
            if (_slots[i].Item == null)
            {
                return _slots[i];
            }
        }

        return null;
    }

    public void SelectedItem(int index)
    {
        if (_slots[index].Item ==null)
        {
            return;
        }

       _selectedItem = _slots[index];
       _selectedItemIndex = index;
       _selectedItemName.text = _selectedItem.Item.Name;
       _selectedItemDescription.text = _selectedItem.Item.Description;
        
        _useButton.SetActive(_selectedItem.Item.ItemTypes == ItemDatabase.ItemType.Consumable); 
        // кнопка  Use будет работать << включена >>  если  выделенный предмет будет относиться к типу потребляемый

                                                                                               // или предмет не одет сейчас на персонажа
        _equpButton.SetActive(_selectedItem.Item.ItemTypes == ItemDatabase.ItemType.Equipable && !_uiSlots[index]._isEquipped);

        _unEqupButton.SetActive(_selectedItem.Item.ItemTypes == ItemDatabase.ItemType.Equipable && _uiSlots[index]._isEquipped);

        _dropButton.SetActive(true);


    }

    private void ClearSelectedItemWindow()
    {
        _selectedItem = null;
        _selectedItemName.text = string.Empty;
        _selectedItemDescription.text = string.Empty;
        _selectedItemStatsName.text = string.Empty;
        _selectedItemStatsValue.text = string.Empty;

        _useButton.SetActive(false);
        _equpButton.SetActive(false);
        _unEqupButton.SetActive(false);
        _dropButton.SetActive(false);
    }

    private void RemoveSelectedItem() // удаляем выделенные предметы из инвентаря
    {
        _selectedItem.RemoveQuantity();

        if (_selectedItem.Quantity == 0)
        {
            if (_uiSlots[_selectedItemIndex]._isEquipped ==true)
            {
                UnEquip(_selectedItemIndex);
            }

            _selectedItem.Item = null;
            ClearSelectedItemWindow();
        }

        UpdateUi();
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
        ThrowItem(_selectedItem.Item);
        RemoveSelectedItem();
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
