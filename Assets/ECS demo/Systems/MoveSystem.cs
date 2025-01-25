using Components;
using ForgeECS;
using UnityEngine;

namespace Systems
{
  public class MoveSystem : IUpdateSystem
  {
    Entities.With<CMoveInput, CRigidbody, CTransform> _units;
    
    public void Update()
    {
      foreach (var unit in _units)
      {
        if (unit.C1.MoveInput != Vector3.zero)
          unit.C2.Rigidbody.AddForce(unit.C3.Transform.forward * 300 * Time.deltaTime);
      }
    }
  }
}