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
        var target = damage.C1.TargetEntity.Unseal;
        
        if (target.Has<CIsPlayer>())
        {
          var roundLostEntity = World.First.CreateEntity();
          roundLostEntity.Tag<CIsRoundLost>();
          break;
        }

        if (target.Has<CIsEnemy>())
        {
          var enemyKilledEntity = World.First.CreateEntity();
          enemyKilledEntity.Tag<CIsEnemyKilled>();
          break;
        }
      }
    }
  }
}