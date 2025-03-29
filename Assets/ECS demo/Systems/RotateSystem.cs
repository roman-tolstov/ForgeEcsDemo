using Components;
using ForgeECS;
using UnityEngine;

namespace Systems
{
  public class RotateSystem : IUpdateSystem
  {
    private Entities.With<CMoveInput, CTransform> _units;
    
    public void Update()
    {
      foreach (var unit in _units)
      {
        if (unit.C1.MoveInput != Vector3.zero)
        {
          var targetRotation = Quaternion.LookRotation(unit.C1.MoveInput);
          var rotationSpeed = Time.deltaTime * 3.5f;
          unit.C2.Transform.rotation = Quaternion.Slerp(unit.C2.Transform.rotation, targetRotation, rotationSpeed);
        }
      }  
    }
  }
}