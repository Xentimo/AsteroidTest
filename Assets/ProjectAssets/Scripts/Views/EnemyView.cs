using UnityEngine;
using Game.World;

public class EnemyView : UpdatedView
{
    EnemyEntity _enemyEntity;
   [SerializeField] SpriteRenderer _spriteRenderer;
   [SerializeField] SpriteRenderer _aura;
   public void Init(EnemyEntity model)
    {
        _enemyEntity = model;
        UpdateView();
        _spriteRenderer.color = Color.white;
        _aura.gameObject.SetActiveWithCheck(false);
    }
    
    public override void UpdateView()
    {
        transform.position = _enemyEntity.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, _enemyEntity.direction);
        var val =     _enemyEntity.health / 100f;
        _spriteRenderer.color = new Color(1, val, val);
        _aura.gameObject.SetActiveWithCheck(!(_enemyEntity.acceleration.x == 0 && _enemyEntity.acceleration.y == 0));
    }
}
