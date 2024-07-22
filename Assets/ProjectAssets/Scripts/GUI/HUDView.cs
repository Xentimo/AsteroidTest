using Game.World;
using TMPro;
using UnityEngine;

public class HUDView : MonoBehaviour
{
    [SerializeField] TMP_Text _coords;
    [SerializeField] TMP_Text _angle;
    [SerializeField] TMP_Text _velocity;
    [SerializeField] TMP_Text _lazers;
    [SerializeField] TMP_Text _lazersCooldown;
    [SerializeField] TMP_Text _health;
    [SerializeField] TMP_Text _score;

    public void UpdateHUD(PlayerEntity playerEntity)
    {
        _coords.text = string.Format("Player X = {0:N1}, Y = {1:N1}", playerEntity.position.x, playerEntity.position.y);
        float angle = Vector3.Angle(Vector3.up, playerEntity.direction);
        _angle.text = string.Format("Angle = {0:N0}", angle);
        _velocity.text = string.Format("Velocity = {0:N1}", playerEntity.velocity);
        _lazers.text = string.Format("Lazers : {0:N0}", (int)playerEntity.lazers);
        _lazersCooldown.text = string.Format("LazersCooldown : {0:N1}", playerEntity.lazersCooldown);
        _health.text = string.Format("Health : {0:N0}", playerEntity.health);
        _score.text = string.Format("Score : {0:N0}", playerEntity.score);
    }
}
