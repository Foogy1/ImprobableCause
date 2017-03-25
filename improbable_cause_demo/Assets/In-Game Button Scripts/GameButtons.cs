using UnityEngine;
using UnityEngine.UI;

public class GameButtons : MonoBehaviour
{
    private IUsable[] iusables;
    private Button button;
    public BUTTONTYPE buttonType;

    public enum BUTTONTYPE
    {
        Start,
        Pause,
        Restart
    }

    private void Start()
    {
        iusables = FindObjectsOfType(typeof(IUsable)) as IUsable[];
        button = GetComponent<Button>();
        switch (buttonType)
        {
            case BUTTONTYPE.Start:
                button.onClick.AddListener(() => startAllActions());
                break;

            case BUTTONTYPE.Pause:
                button.onClick.AddListener(() => pauseAllActions());
                break;

            case BUTTONTYPE.Restart:
                button.onClick.AddListener(() => restart());
                break;
        }
    }

    public void pauseAllActions()
    {
        
    }

    public void startAllActions()
    {
      
    }

    public void restart()
    {
        
    }
}