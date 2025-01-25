using Components;
using ForgeECS;

namespace Systems
{
  public class ClearDamagesSystem : IUpdateSystem
  {
    private Entities.Where<CIsDamage> _damages;

    public void Update()
    {
      foreach (var damage in _damages)
      {
        damage.Entity.Destroy();
      }
    }
  }
}