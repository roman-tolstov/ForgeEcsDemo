using ECS_demo.UniqueComponents;
using ForgeECS;
using Systems;
using UnityEngine;
using UnityEngine.UI;

public class Setup : MonoBehaviour
{
  public GameObject BulletPrefab;
  public Button WonButton;
  public Button LostButton;
  public PlayerController Player;
  public EnemyController Enemy;
  public Transform PlayerSpawn;
  public Transform EnemySpawn;
  private SystemRunner _systemRunner;

  private void Awake()
  {
    World.First.Set(new BulletPrefabHolder(BulletPrefab));
    World.First.Set(new WinButton(WonButton));
    World.First.Set(new LoseButton(LostButton));
    
    _systemRunner = SystemRunner.For(World.First)
      .Add<SpawnBulletSystem>()
      .Add<DealDamageSystem>()
      .Add<ClearDamagesSystem>()
      .Add<RotateSystem>()
      .Add<MoveSystem>()
      .Add<EndRoundSystem>()
      .Init();
  }

  private void Update()
  {
    _systemRunner.Update();
  }

  public void OnEndRoundClick()
  {
    Player.transform.position = PlayerSpawn.position;
    Enemy.transform.position = EnemySpawn.position;
    Player.Initialize();
    Enemy.Initialize();
    
    WonButton.gameObject.SetActive(false);
    LostButton.gameObject.SetActive(false);
  }
}