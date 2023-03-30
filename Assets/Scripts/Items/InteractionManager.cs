using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public interface IInteractable
{
   public  string GetInteractPromt();
   public void OnInteract();
   
}

public class InteractionManager : MonoBehaviour
{

    [SerializeField] private  float checkrate = 0.05f;
    [SerializeField] private float lastCheckTime;
    [SerializeField] private float maxCheckDistance;
    [SerializeField] private  LayerMask layerMask;
    [SerializeField] private  TextMeshProUGUI promptText;

    private GameObject currentInteractGameObject;
    private  IInteractable currentInteractable;
    private Camera cam;
    public Transform pointInteractable;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Time.time - lastCheckTime > checkrate)// Проверка каждую секунду checkrate
        {
            lastCheckTime = Time.time;
        }

        // Не корректно работает луч РЭЙ  лучь должен исследовать всегад, а он бьёт только вверх 
        //Vector2 vectorMouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        //pointInteractable.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
         //Ray2D ray = new Ray2D(_player.transform.position, vectorMouse);

         RaycastHit2D hit = Physics2D.Raycast( transform.position,transform.position, 1.5f, LayerMask.GetMask("Interactable"));
         Debug.DrawLine(transform.position,transform.position, Color.red);

        if (hit)
        {
            currentInteractGameObject = hit.collider.gameObject;
            currentInteractable = hit.collider.GetComponent<IInteractable>();
            SetPrompText();
        }
        else
        {
            currentInteractGameObject = null;
            currentInteractable = null;
            promptText.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
           //здесь сделать что если это обьект Item.Type == WorkBench рогда мы в него заходим и взаимодействуем 
           // Ещё вариант это сделать отдельный скрипт Workbench который будет интерактивно гореть при нахождении рядом с 
           // верстаком
            currentInteractable.OnInteract();
            currentInteractGameObject = null;
            currentInteractable = null;
            promptText.gameObject.SetActive(false);


        }
    }

    public void SetPrompText()
    {
        promptText.gameObject.SetActive(true);
        promptText.text = string.Format("<b>[E]</b> {0}", currentInteractable.GetInteractPromt());
    }

}

