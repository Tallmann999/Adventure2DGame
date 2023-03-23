using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenObject : MonoBehaviour
{
    [SerializeField] private GameObject _doorClose;
    [SerializeField] private GameObject _doorOpen;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _doorClose.SetActive(false);
            _doorOpen.SetActive(true);
        }
    }
}
