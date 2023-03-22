using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageble : MonoBehaviour
{
    public int _damage;
    public int _damageRate;

    private List<IDamagable> _thingsDamage = new List<IDamagable>();


    private void Start()
    {
        StartCoroutine(DealDamage());
    }

    private void Update()
    {
        StopCoroutine(DealDamage());
    }

    IEnumerator DealDamage()
    {
        while (true)
        {
            for (int i = 0; i < _thingsDamage.Count; i++)
            {
                _thingsDamage[i].TakePhysicalDamage(_damage);
            }

            yield return new WaitForSeconds(_damageRate);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IDamagable>() != null)
        {
            _thingsDamage.Add(collision.gameObject.GetComponent<IDamagable>());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IDamagable>() != null)
        {
            _thingsDamage.Remove(collision.gameObject.GetComponent<IDamagable>());
        }
    }
   
}



