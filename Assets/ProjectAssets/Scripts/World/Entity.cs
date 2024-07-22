using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.World
{
    public class Entity
    {
        public Vector3 position;
        public Vector3 direction;
        public float moment;
        public float health;
        public float damage;
        public float velocity;
        public Vector3 acceleration;
        public float cashedDistanceToPlayer;
        public float colliderRadius;
        
        public bool isBig;
        
     
        public bool Intersect(Vector3 shotEndPoint)
        {
            return (position - shotEndPoint).magnitude < colliderRadius;
        }
        
    }
}