using ForgeECS;
using UnityEngine.UI;

namespace ECS_demo.UniqueComponents
{
  public struct WinButton : IUniqueComponent
  {
    public Button Button;

    public WinButton(Button button)
    {
      Button = button;
    }
  }
}