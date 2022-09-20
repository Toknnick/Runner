using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _speed = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x - 1, transform.position.y), _speed * Time.deltaTime);
    }
}
