using Components;
using ForgeECS;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private SealedEntity _sealedEntity;

  private void Start()
  {
    Initialize();
  }

  public void Initialize()
  {
    var entity = World.First.CreateEntity();
    entity.Tag<CIsPlayer>();
    entity.Tag<CIsShootable>();
    entity.Add<CMoveInput>();
    entity.Add<CRigidbody>().Rigidbody = GetComponent<Rigidbody>();
    entity.Add<CTransform>().Transform = transform;
    _sealedEntity = entity.Seal();
    GetComponent<EntityHolder>().Entity = _sealedEntity;
  }

  void Update()
  {
    var horizontal = Input.GetAxis("Horizontal");
    var vertical = Input.GetAxis("Vertical");

    if (_sealedEntity.GetIfAlive(out var entity))
    {
      if (entity.Has<CMoveInput>())
        entity.Get<CMoveInput>().MoveInput = new Vector3(horizontal, 0, vertical);
    }
    else
    {
      return;
    }
    
    if (Input.GetButtonDown("Fire1"))
    {
      var createBulletEntity = World.First.CreateEntity();
      createBulletEntity.Add<CPosition>().Position = transform.position + transform.forward * 2;
      createBulletEntity.Add<CRotation>().Rotation = Quaternion.LookRotation(transform.forward);
      createBulletEntity.Tag<CIsCreateBullet>();
      createBulletEntity.Tag<CIsPlayer>();
    }
  }
}