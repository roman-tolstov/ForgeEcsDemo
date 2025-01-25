using ForgeECS;
using UnityEngine;

namespace ECS_demo.UniqueComponents
{
  public struct BulletPrefabHolder : IUniqueComponent
  {
    public GameObject BulletPrefab;

    public BulletPrefabHolder(GameObject bulletPrefab)
    {
      BulletPrefab = bulletPrefab;
    }
  }
}