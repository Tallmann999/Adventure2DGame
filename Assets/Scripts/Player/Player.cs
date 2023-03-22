using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    [SerializeField] private Needs _health;
    [SerializeField] private Needs _hunger;
    [SerializeField] private Needs _thristy;
    [SerializeField] private Needs _radiation;

    [SerializeField] private float _hungerHealthDecay;
    [SerializeField] private float _thirstHealthDecay;
    [SerializeField] private float _radiationHealthDecay;
    

    //[SerializeField] private Transform _shootPoint;
    //[SerializeField] private List<Weapon> _weapons;

    public Weapon CurrentWeapon { get; private set; }
    public  bool IsEquepud { get; private set; } = false;


    private void Start()
    {
        // 1. При старте игры у персонажа ничего нет и он не может стрелять
        //2. После присвоения текущему оружию статус IsEquepud
         //CurrentWeapon =_weapons[0];
        _health.CurrentValue = _health.StartValue;
        _hunger.CurrentValue = _hunger.StartValue;
        _thristy.CurrentValue = _thristy.StartValue;
        _radiation.CurrentValue = _radiation.StartValue;
    }

    private void Update()
    {
        _hunger.RemoveValue(_hunger.DecayRate*Time.deltaTime);
        _thristy.RemoveValue(_thristy.DecayRate*Time.deltaTime);
        _radiation.AddValue(_radiation.Regenerate * Time.deltaTime);

        if (_hunger.CurrentValue == 0.0f)
        {
            _health.RemoveValue(_hungerHealthDecay * Time.deltaTime);
        } 

        if (_thristy.CurrentValue == 0.0f)
        {
            _health.RemoveValue(_thirstHealthDecay * Time.deltaTime);
        }

        if (_radiation.CurrentValue == _radiation.MaxValue)
        {
            _health.RemoveValue(_radiationHealthDecay * Time.deltaTime);
        }

        _health.Uibar.fillAmount = _health.GetPercentage();
        _hunger.Uibar.fillAmount = _hunger.GetPercentage();
        _thristy.Uibar.fillAmount = _thristy.GetPercentage();
        _radiation.Uibar.fillAmount = _radiation.GetPercentage();
    }

    public void Heal(float amount)
    {

    } 

    public void Eat(float amount)
    {

    }

    public void Drink(float amount)
    {

    }

    public void Radiation(float amount)
    {

    } 

    public void TakeDamage(int damage)
    {

    }

    public void Die()
    {

    }

}

[System.Serializable]
public class Needs
{ 
    public float CurrentValue;
    public float MaxValue;
    public float StartValue;
    public float Regenerate;
    public float DecayRate;
    public Image Uibar;


    public void AddValue(float amount)
    {
        CurrentValue = Mathf.Min(CurrentValue+amount,MaxValue);// возвращает одно  минимальное значение из  двух 
    }

    public void RemoveValue(float amount)
    {
        CurrentValue = Mathf.Max(CurrentValue - amount, 0.0f);// возвращает одно  иаксимальное  значение из  двух 
    }

    public float GetPercentage()
    {
        return CurrentValue/MaxValue;
    }
}


