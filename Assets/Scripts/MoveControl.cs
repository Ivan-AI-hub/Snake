using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    public Transform PlayerBrain;
    public Transform PlayerSkin;
    public GameObject Camera;

    public float Speed;

    private float _speedCamera;
    private float _acceleration = 1;

    private void Start()
    {
        _speedCamera = Speed / 100;
    }

    private void Update()
    {
        Camera.transform.position = Vector3.Lerp(Camera.transform.position, PlayerSkin.position - Vector3.forward , _speedCamera);

        PlayerSkin.transform.position = Vector3.Lerp(PlayerSkin.position, PlayerBrain.position, _speedCamera);

        if (Input.GetKey(KeyCode.W))
        {
            Move(Vector3.up);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Move(Vector3.down);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
        }

        if (Input.anyKey && _acceleration<2)
        {
            _acceleration += 0.1f * Time.deltaTime ;
        }
        else if (_acceleration > 1f)
        {
            _acceleration -= 0.5f ;
        }
    }

    private void Move(Vector3 direction)
    {
        PlayerBrain.position += direction * Speed * _acceleration * Time.deltaTime;
    }
}
