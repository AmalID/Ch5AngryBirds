﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShooter : MonoBehaviour
{
    public CircleCollider2D Collider;
    private Vector2 _startPos;
    private Bird _bird;

    [SerializeField] private float _radius = 0.75f;
    [SerializeField] private float _throwSpeed = 30;

    void Start()
    {
        _startPos = transform.position;
    }

    void OnMouseUp()
    {
        Collider.enabled = false;
        Vector2 velocity = _startPos - (Vector2)transform.position;
        float distance = Vector2.Distance(_startPos, transform.position);

        _bird.Shoot(velocity, distance, _throwSpeed);

        gameObject.transform.position = _startPos;    }

    void OnMouseDrag()
    {
        Vector2 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = p - _startPos;

        if (dir.sqrMagnitude > _radius)
        {
            dir = dir.normalized * _radius;
            transform.position = _startPos + dir;
        }
    }
    public void InitiateBird(Bird bird)
    {
        _bird = bird;
        _bird.MoveTo(gameObject.transform.position, gameObject);
        Collider.enabled = true;
    }
}
