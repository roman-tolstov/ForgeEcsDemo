﻿using ForgeECS;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Components
{
  [Il2CppSetOption(Option.NullChecks, false)]
  [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
  [Il2CppSetOption(Option.DivideByZeroChecks, false)]
  public struct CPosition : IValueComponent
  {
    public Vector3 Position;
  }
}