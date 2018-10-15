using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 1;
    [SerializeField] private GameObject _goldPrefab;

    private float _xSpeed;
    private float _ySpeed;

    private ParticleSystem _bulletSystem;

    private void Awake()
    {
        _bulletSystem = GetComponentInChildren<ParticleSystem>();
        _xSpeed = Random.Range(-1f, 1f);
        _ySpeed = Random.Range(-2f, -.25f);
    }

    private void Update()
    {
        if (_xSpeed < 0 && transform.position.x < GameManager.Instance.GetLowerLeftBound().x)
            _xSpeed *= -1;
        else if (_xSpeed > 0 && transform.position.x > GameManager.Instance.GetUpperRightBound().x)
            _xSpeed *= -1;

        if (transform.position.y < GameManager.Instance.GetLowerLeftBound().y)
            Destroy(gameObject);

        transform.position += new Vector3(_xSpeed * Time.deltaTime, _ySpeed * Time.deltaTime, 0);
    }


    private void OnParticleCollision(GameObject other)
    {
        _health -= other.GetComponent<Weapon>().GetDamage();
        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        _bulletSystem.transform.SetParent(null);
        _bulletSystem.Stop(false, ParticleSystemStopBehavior.StopEmitting);
        Destroy(Instantiate(_goldPrefab, transform.position, Quaternion.identity), 20f);
        Destroy(gameObject);
    }
}