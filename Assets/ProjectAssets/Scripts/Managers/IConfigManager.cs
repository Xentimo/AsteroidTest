using System;
public interface IConfigManager
{
    public Config config { get; }
}

[Serializable]
public class Config
{
    [Serializable]
    public class AsteroidInfo
    {
        public int start_asteriod_count;
        public int min_verts_count;
        public int max_verts_count;

        public float min_distance;
        public float max_distance;

        public float min_speed;
        public float max_speed;
        
        public float radius_min;
        public float radius_max;
        public int min_asteriod_count;
        public int fragments_count;
    }

    [Serializable]
    public class PlayerInfo
    {
        public float collider_radius;
        public int max_lazers_count;
        public float lazer_recharge_speed;
    }
    public AsteroidInfo asteroid;
    public PlayerInfo player;
    public EnemiesInfo enemies;
   
}

[Serializable]
public class EnemiesInfo
{
    public int max_enemies;
    
    public float min_speed;
    public float max_speed;
    
    public float min_distance;
    public float max_distance;
    public float cooldown;
    public float collider_radius;
    public float shoot_cooldown;
    public float shoot_angle;
    public float shoot_distance;
}

