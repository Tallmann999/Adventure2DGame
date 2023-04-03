using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemDatabase _item;

    public string GetInteractPromt()
    {
        return string.Format("Поднять {0}", _item.name);
    }

    public void OnInteract()
    {
        Destroy(gameObject);
    }
}
