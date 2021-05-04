using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
public enum BirdState { idle,Thrown}
    public GameObject Parent;
    public Rigidbody2D Rigidbody;
    public CircleCollider2D Collider;

    private BirdState _state;
    private float _minVelocity = 0.0f;
    private bool _flagDestroy = false;

    void Start()
    {
        Rigidbody.bodyType = RigidbodyType2D.Kinematic;
        Collider.enabled = false;
        _state = BirdState.idle;
    }

    void FixedUpdate()
    {
        if (_state == BirdState.idle && Rigidbody.velocity.sqrMagnitude < _minVelocity && !_flagDestroy)
        {
            _flagDestroy = true;
            StartCoroutine(DestroyAfter(2));
        }
    }

    private IEnumerator DestroyAfter(float second)
    {
        yield return new WaitForSeconds(second);
        Destroy(gameObject);
    }

    public void MoveTo(Vector2 target, GameObject parent)
    {
        gameObject.transform.SetParent(parent.transform);
        gameObject.transform.position = target;
    }

    public void Shoot(Vector2 velocity, float distance, float speed)
    {
        Collider.enabled = true;
        Rigidbody.bodyType = RigidbodyType2D.Dynamic;
        Rigidbody.velocity = velocity * speed * distance;
    }
}
