using Components;
using ECS_demo.UniqueComponents;
using ForgeECS;
using UnityEngine;

namespace Systems
{
  public class SpawnBulletSystem : IUpdateSystem
  {
    Entities.With<CPosition, CRotation>.Where<CIsCreateBullet> _createBullet;
    
    public void Update()
    {
      foreach (var createBullet in _createBullet)
      {
        var prefab = World.First.Get<BulletPrefabHolder>().BulletPrefab;
        var bullet = Object.Instantiate(prefab, createBullet.C1.Position, createBullet.C2.Rotation);
        var bulletEntity = World.First.CreateEntity();

        if (createBullet.Entity.Has<CIsEnemy>())
          bulletEntity.Tag<CIsEnemy>();
        else
          bulletEntity.Tag<CIsPlayer>();
        
        bullet.GetComponent<BulletController>().Entity = bulletEntity.Seal();
        bullet.GetComponent<EntityHolder>().Entity = bulletEntity.Seal(); 
        
        createBullet.Entity.Destroy();
      }
    }
  }
}