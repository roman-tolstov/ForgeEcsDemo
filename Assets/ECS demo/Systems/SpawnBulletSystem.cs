using Components;
using ECS_demo.UniqueComponents;
using ForgeECS;
using UnityEngine;

namespace Systems
{
  public class SpawnBulletSystem : IUpdateSystem
  {
    private Entities.With<CPosition, CRotation>.Where<CIsCreateBullet> _createBullet;
    
    public void Update()
    {
      foreach (var createBullet in _createBullet)
      {
        var prefab = World.First.Get<BulletPrefabHolder>().BulletPrefab;
        var bulletPrefab = Object.Instantiate(prefab, createBullet.C1.Position, createBullet.C2.Rotation);
        var bullet = World.First.CreateEntity();

        if (createBullet.Entity.Has<CIsEnemyBullet>())
          bullet.Tag<CIsEnemyBullet>();
        else if (createBullet.Entity.Has<CIsPlayerBullet>())
          bullet.Tag<CIsPlayerBullet>();
        else
          Debug.LogError("Bullet belonging is not specified");
        
        bulletPrefab.GetComponent<BulletController>().Entity = bullet.Seal();
        bulletPrefab.GetComponent<EntityHolder>().Entity = bullet.Seal(); 
        
        createBullet.Entity.Destroy();
      }
    }
  }
}