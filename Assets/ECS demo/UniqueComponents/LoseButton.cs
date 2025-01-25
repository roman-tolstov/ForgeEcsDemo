using ForgeECS;
using UnityEngine.UI;

namespace ECS_demo.UniqueComponents
{
  public struct LoseButton : IUniqueComponent
  {
    public Button Button;

    public LoseButton(Button button)
    {
      Button = button;
    }
  }
}