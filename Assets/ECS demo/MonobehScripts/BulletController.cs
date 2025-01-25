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
    if (other.gameObject.TryGetComponent<BulletController>(out var _))
      return;
    
    Entity.GetIfAlive(out var entity);

    if (other.gameObject.TryGetComponent<EntityHolder>(out var holder)
        && holder.Entity.GetIfAlive(out var target))
    {
      if (target.Has<CIsShootable>())
      {
        var shotEntity = World.First.CreateEntity();
        shotEntity.Tag<CIsDamage>();
        
        if (entity.Has<CIsEnemy>())
          shotEntity.Tag<CIsEnemy>();
        else if (entity.Has<CIsPlayer>())
          shotEntity.Tag<CIsPlayer>();

        shotEntity.Add<CTargetEntity>().TargetEntity = target.Seal();
      }
    }
    
    if (entity.IsAlive) // as collision might delay the GO destruction
      entity.Destroy();
    
    Destroy(gameObject);
  }
}