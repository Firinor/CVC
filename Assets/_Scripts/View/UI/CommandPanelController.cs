using UnityEngine;

public class CommandPanelController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] panels;

    public void OpenPanel(int index)
    {
        for(int i = 0; i < panels.Length; i++)
        {
            if(i == index)
            {
                panels[i].SetActive(!panels[i].activeSelf);
                continue;
            }
            panels[i].SetActive(false);
        }
    }
}
