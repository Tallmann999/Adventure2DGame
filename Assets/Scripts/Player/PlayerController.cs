using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{

    //[SerializeField] private int PlayerId;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _movementBaseSpeed = 1.0f;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GameObject _crosshair;
    [SerializeField] private float _crosshairDistance = 1.0f;
    //[SerializeField] private GameObject _bulletPrefabs;
    //[SerializeField] private float _bulletBaseSpeed = 1.0f;
    [SerializeField] private GameObject _dialogImage;
    [SerializeField] private Transform _shootPoint;

    private Weapon _weapon;
    private Player _player;
    private Animator _animator;
    private Vector2 _movingDirection;
    private bool EndAiming = true;

    private  bool canLook = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
        Animate();
        Aim();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {   // 1.сделать смену анимации когда у персонажа есть в руках оружие и только тогда производить 
            // 
                //Shoot();
        }
    }

    private void Move()
    {
        _movingDirection.x = Input.GetAxis("Horizontal");
        _movingDirection.y = Input.GetAxis("Vertical");
        //MovingDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        _rigidbody.velocity = _movingDirection * _movementSpeed * _movementBaseSpeed;

        _movementSpeed = Mathf.Clamp(_movingDirection.magnitude, 0.0f, 1.0f);
        _movingDirection.Normalize();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _movementBaseSpeed = 4f;
            _animator.SetFloat("Speed", 2);
        }
        else
        {
            _movementBaseSpeed = 2f;
            _animator.SetFloat("Speed", _movementSpeed);
        }



        //EndAiming = Input.GetButtonDown("Fire1");
    }

    private void Animate()
    {
        if (_movingDirection != Vector2.zero)
        {
            _animator.SetFloat("Horizontal", _movingDirection.x);
            _animator.SetFloat("Vertical", _movingDirection.y);
        }

        _animator.SetFloat("Speed",_movementSpeed);

    }

    private void Aim()
    {
        if (_movingDirection != Vector2.zero)
        {
            _crosshair.transform.localPosition = _movingDirection * _crosshairDistance;
           
            //RaycastHit2D hit = Physics2D.Raycast(_rigidbody.position + _movingDirection * 0.2f, _movingDirection, 1f, LayerMask.GetMask("Workbench"));

            //if (hit.collider != null)
            //{
            //    Debug.DrawRay(transform.position, _movingDirection, Color.red);
            //    _dialogImage.SetActive(true);
            //}
            //else
            //{
            //    _dialogImage.SetActive(false);

            //}
        }
    }

    //private void Shoot()
    //{
    //    //Vector2 shotingDirection = _crosshair.transform.localPosition; // стреляет куда направлена цель, а цель поворачивается вместе с анимацией
    //    Vector2 shotingDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; // стреляет в направление курсора мыши
    //    shotingDirection.Normalize();
    //    _crosshair.transform.localPosition = shotingDirection;  // поворот аима за центром камеры без поворота анимации
    //    GameObject bullet = Instantiate(_bulletPrefabs, _shootPoint.position, Quaternion.identity);
    //    bullet.GetComponent<Rigidbody2D>().velocity = shotingDirection * _bulletBaseSpeed;
    //    bullet.transform.Rotate(0, 0, Mathf.Atan2(shotingDirection.y, shotingDirection.x) * Mathf.Rad2Deg);
    //    Destroy(bullet, 2.0f);
    //}

    public void ToogleCursor(bool toggle)
    {
        Cursor.lockState = toggle? CursorLockMode.None : CursorLockMode.Locked;
        canLook = !toggle;
    }
}

