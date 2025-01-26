using Components;
using ForgeECS;

namespace Systems
{
  public class DealDamageSystem : IUpdateSystem
  {
    private Entities.With<CTargetEntity>.Where<CIsDamage> _damages;

    public void Update()
    {
      foreach (var damage in _damages)
      {
        var targetEntity = damage.C1.TargetEntity.Unseal;
        
        if (targetEntity.Has<CIsPlayer>())
        {
          if (damage.Entity.Has<CIsPlayer>())
            continue;

          var roundLostEntity = World.First.CreateEntity();
          roundLostEntity.Tag<CIsRoundLost>();
          break;
        }

        if (targetEntity.Has<CIsEnemy>())
        {
          if (damage.Entity.Has<CIsEnemy>())
            continue;

          var enemyKilledEntity = World.First.CreateEntity();
          enemyKilledEntity.Tag<CIsEnemyKilled>();
          break;
        }

        targetEntity.Untag<CIsShootable>();
        targetEntity.Remove<CMoveInput>();
      }
    }
  }
}