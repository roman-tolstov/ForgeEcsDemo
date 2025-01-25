using Components;
using ForgeECS;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
  private Vector3 _movement;
  private float _timeElapsed;
  private SealedEntity _entity;

  private void Start()
  {
    Initialize();
    
    var createBulletEntity = World.First.CreateEntity();
    createBulletEntity.Add<CPosition>().Position = transform.position + transform.forward * 2;
    createBulletEntity.Add<CRotation>().Rotation = Quaternion.LookRotation(transform.forward);
    createBulletEntity.Tag<CIsCreateBullet>();
    createBulletEntity.Tag<CIsEnemy>();
  }

  public void Initialize()
  {
    var entity = World.First.CreateEntity();
    entity.Tag<CIsEnemy>();
    entity.Tag<CIsShootable>();
    entity.Add<CMoveInput>();
    entity.Add<CRigidbody>().Rigidbody = GetComponent<Rigidbody>();
    entity.Add<CTransform>().Transform = transform;
    _entity = entity.Seal();
    GetComponent<EntityHolder>().Entity = _entity;
  }

  private void Update()
  {
    if (_entity.GetIfAlive(out var entity))
    {
      if (!entity.Has<CMoveInput>())
        return;
        
      entity.Get<CMoveInput>().MoveInput = _movement;
    }
    else
    {
      return;
    }
    
    _timeElapsed += Time.deltaTime;
    
    if (_timeElapsed > 0.3f)
    {
      var createBulletEntity = World.First.CreateEntity();
      createBulletEntity.Add<CPosition>().Position = transform.position + transform.forward * 2;
      createBulletEntity.Add<CRotation>().Rotation = Quaternion.LookRotation(transform.forward);
      createBulletEntity.Tag<CIsCreateBullet>();
      createBulletEntity.Tag<CIsEnemy>();
      
      _movement = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
      _timeElapsed = 0;
    }
  }
}