using System;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")] [SerializeField]
    private float _verticalMoveSpeed = 1f;

    [SerializeField] private float _horizontalMoveSpeed = 1f;
    [SerializeField] private float _focusMultiplier = .5f;


    [Header("Scene Settings")] [SerializeField]
    private Transform _lowerLeftBound;

    [SerializeField] private Transform _upperRightBound;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float focus = Input.GetButton("Focus") ? _focusMultiplier : 1f;
        var horizontalSpeed = Input.GetAxis("Horizontal") * _horizontalMoveSpeed * focus * Time.deltaTime;
        var verticalSpeed = Input.GetAxis("Vertical") * _verticalMoveSpeed * focus * Time.deltaTime;
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + horizontalSpeed, _lowerLeftBound.position.x, _upperRightBound.position.x),
            Mathf.Clamp(transform.position.y + verticalSpeed, _lowerLeftBound.position.y, _upperRightBound.position.y), 0);
    }
    
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Gold"))
        {
            GameManager.Instance.AddScore(10);
        }

        if (other.CompareTag("Bullet"))
        {
            GameManager.Instance.Die();
        }
    }

}