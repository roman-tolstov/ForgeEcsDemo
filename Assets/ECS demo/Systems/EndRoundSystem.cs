using Components;
using ECS_demo.UniqueComponents;
using ForgeECS;

namespace Systems
{
  public class EndRoundSystem : IUpdateSystem
  {
    private Entities.Where<CIsEnemyKilled> _roundWon;
    private Entities.Where<CIsRoundLost> _roundLost;
    
    public void Update()
    {
      foreach (var roundLost in _roundLost)
      {
        World.First.Get<LoseButton>().Button.gameObject.SetActive(true);
        World.First.Clear();
      }

      foreach (var roundWon in _roundWon)
      {
        World.First.Get<WinButton>().Button.gameObject.SetActive(true);
        World.First.Clear();
      }
    }
  }
}