using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofDisable : MonoBehaviour
{
   [SerializeField]private  GameObject _roofChild;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _roofChild.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _roofChild.SetActive(true);
        }
    }
}
