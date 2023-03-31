using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlotsUi : MonoBehaviour
{


    [SerializeField] private Button _button;
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _quantityText;

    private ItemSlot _currentSlot;
    private Outline _outLine;
    public  bool _isEquipped;

    public int Index;

    private void Awake()
    {
        _outLine = GetComponent<Outline>();
    }


    private void OnEnable()
    {
        _outLine.enabled = _isEquipped;
    }

    public void SetItemSlotInformation(ItemSlot slot)
    {
        _currentSlot = slot; // установка иконки

       _icon.gameObject.SetActive(true); // включение иконки

        _icon.sprite = slot.Item.Icon; // установка спрайта в иконку

        _quantityText.text = slot.Quantity >1? slot.Quantity.ToString() : string.Empty; // Если  колличевстыво больше 1 то это напишет, если слот пустой тогда будет вместо цифр пусто

        if (_outLine != null)
        {
            _outLine.enabled = _isEquipped;
        }
    }

    public void ClearItemSlotInformation()
    {
        _currentSlot = null;
        _icon.gameObject.SetActive(false);
        _quantityText.text = string.Empty;
    }

    public void OnClickButton()
    {

    }


}
