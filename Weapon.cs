using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage = 1;

    public int GetDamage()
    {
        return _damage;
    }
}