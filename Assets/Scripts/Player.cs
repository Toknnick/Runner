using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    public UnityEvent Died;

    [SerializeField] private Sprite[] _sprites;

    private SpriteRenderer _spriteRenderer;

    private int _numberOfSprite = 0;
    private int _health = 3;

    public void ChangeHealth()
    {
        _numberOfSprite = 0;
        _spriteRenderer.sprite = _sprites[_numberOfSprite];
        _health = 3;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (_health > 0)
        {
            _numberOfSprite++;
            _spriteRenderer.sprite = _sprites[_numberOfSprite];
            _health--;
        }
        else
        {
            Died?.Invoke();
        }
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
