using Components;
using ForgeECS;
using UnityEngine;

public class BulletController : MonoBehaviour
{
  public SealedEntity Entity;

  private void Update()
  {
    transform.Translate(Vector3.forward * Time.deltaTime * 15f);
  }

  private void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.TryGetComponent<BulletController>(out _))
      return;

    var entity = Entity.Unseal;

    if (other.gameObject.TryGetComponent<EntityHolder>(out var holder)
        && holder.Entity.GetIfAlive(out var target))
    {
      if (target.Has<CIsShootable>())
      {
        var damageEntity = World.First.CreateEntity();
        damageEntity.Tag<CIsDamage>();
        
        if (entity.Has<CIsEnemyBullet>())
          damageEntity.Tag<CIsEnemyBullet>();
        else if (entity.Has<CIsPlayerBullet>())
          damageEntity.Tag<CIsPlayerBullet>();

        damageEntity.Add<CTargetEntity>().TargetEntity = target.Seal();
      }
    }
    
    if (entity.IsAlive) // as collision might delay the GO destruction
      entity.Destroy();
    
    Destroy(gameObject);
  }
}