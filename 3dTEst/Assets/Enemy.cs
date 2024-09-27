using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public Transform _player;
    [SerializeField] private float _speed;

    private void Start()
    {
    }
 
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position , _player.position , _speed);
    }
}
