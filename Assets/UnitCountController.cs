using TMPro;
using UnityEngine;
using Zenject;

public class UnitCountController : MonoBehaviour
{
    [Inject(Id = "RedPlayer")]
    private Player player;
    [SerializeField]
    private EUnitClass unitClass;
    [SerializeField]
    private EResource resource;
    [SerializeField]
    private TextMeshProUGUI text;

    public void NeedMore()
    {
        (int, bool) result = player.NeedUnit(+1, unitClass, resource);
        ChangeText(result);
    }

    public void NeedLess()
    {
        (int, bool) result = player.NeedUnit(-1, unitClass, resource);
        ChangeText(result);
    }
    public void NeedMax()
    {
        (int, bool) result = player.NeedUnit(int.MaxValue, unitClass, resource);
        ChangeText(result);
    }
    public void NeedZero()
    {
        (int, bool) result = player.NeedUnit(int.MinValue, unitClass, resource);
        ChangeText(result);
    }

    private void ChangeText((int, bool) result)
    {
        text.text = result.Item1.ToString();
        text.color = result.Item2 ? Color.black : Color.red;
    }
}
