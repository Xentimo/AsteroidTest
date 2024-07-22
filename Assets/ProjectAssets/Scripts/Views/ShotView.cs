using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotView : UpdatedView
{
    ShotEvent _shotEvent;
    [SerializeField] AudioClip sound;
    [SerializeField] SpriteRenderer _spriteRenderer;
    public void Init(ShotEvent model)
    {
        _shotEvent = model;
        transform.position = _shotEvent.startPoint;
        transform.rotation = Quaternion.FromToRotation(Vector3.up,  _shotEvent.direction);
        AudioSource.PlayClipAtPoint(sound, _shotEvent.startPoint);
        _spriteRenderer.color = _shotEvent.isEnemy ? Color.cyan : Color.yellow;

    }

    public override void UpdateView()
    {
        transform.position = _shotEvent.endPoint;
        transform.rotation = Quaternion.FromToRotation(Vector3.up,  _shotEvent.direction);
    }
}
