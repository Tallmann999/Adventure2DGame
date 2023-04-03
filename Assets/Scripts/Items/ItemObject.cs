using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemDatabase _item;


    // ����� ��� �� ����� ������� ��������������� ������������ ��������
    // ������ ��������  ���� � ����������� �� ��������


    public string GetInteractPromt()
    {
        return string.Format("������� {0}", _item.name);
    }

    public void OnInteract()
    {
        Inventory.instance.AddItem(_item);
        Destroy(gameObject);
    }
}
