using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemDatabase _item;


    // Здесь так же можно сделать интерактивность поднимаемого предмета
    // Тоесть добавить  окно с инвормацией об предмете


    public string GetInteractPromt()
    {
        return string.Format("Поднять {0}", _item.name);
    }

    public void OnInteract()
    {
        Inventory.instance.AddItem(_item);
        Destroy(gameObject);
    }
}
