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
          var lookRotation = Quaternion.LookRotation(unit.C1.MoveInput);
          unit.C2.Transform.rotation = Quaternion.Slerp(unit.C2.Transform.rotation, lookRotation, Time.deltaTime * 3.5f);
        }
      }  
    }
  }
}