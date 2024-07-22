using System;
using System.Collections;
using System.Collections.Generic;
using Game.World;
using UnityEngine;

public class LazerView : UpdatedView
{
    [SerializeField] AudioClip sound;
    PlayerEntity _playerEntity;
    public void Init(ShotEvent shotEvent, PlayerEntity playerEntity)
    {
        _playerEntity = playerEntity;
        transform.position = _playerEntity.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up,  _playerEntity.direction);
        AudioSource.PlayClipAtPoint(sound, shotEvent.startPoint);
    }

    public override void UpdateView()
    {
        transform.position =_playerEntity.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up,  _playerEntity.direction);
    }
}
