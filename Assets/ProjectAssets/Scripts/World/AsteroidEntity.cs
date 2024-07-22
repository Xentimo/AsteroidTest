using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.World
{
    public class AsteroidEntity : Entity
    {
        public Vector3[] points;
        public double MinDistance(Vector3 playerPosition)
        {
            float min = float.MaxValue;
            Vector3 local = playerPosition - position;
            foreach (var pt in points)
            {
                float dist = Vector3.Distance(pt, local);
                if (dist < min)
                    min = dist;
            }
            return min;
        }

        public List<AsteroidEntity> GenerateFragments(int fragmentsCount)
        {
            List<AsteroidEntity> fragments = new ();
            int fragmentLen = points.Length / fragmentsCount ;
            int ostLen = points.Length % fragmentsCount;
            int index = 0;
            for (int i = 0; i < fragmentsCount; i++)
            {
                AsteroidEntity fragment = new AsteroidEntity();
                var ps = new List<Vector3>();
                ps.Add(Vector3.zero);
                Vector3 dir = Vector3.zero;
                int len = i < fragmentsCount - 1 ? fragmentLen : fragmentLen + ostLen + 1;
                for (int k = 0; k < len ; k++)
                {
                    int i1 = index % points.Length;
                    ps.Add(points[i1]);
                    dir += points[i1];
                    if (k < len - 1)
                        index++;
                }
                var center = 1f/ps.Count * dir;
                for (int h = 0; h < ps.Count; h++)
                    ps[h] -= center;

                fragment.points = ps.ToArray();
                fragment.velocity = 1.0f;
                fragment.damage = 10f;
                fragment.health = 100;
                fragment.isBig = false;
                fragment.position = position + center;
                fragment.direction = dir.normalized;
                fragments.Add(fragment);
            }
            
            return fragments;
        }
        
        public bool Intersect(Vector3 startPoint, Vector3 endPoint)
        {
            var local = endPoint - position;
            return Extentions.IsPointInPolygon(points, local, false);
        }

    }
}

