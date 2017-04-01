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
        Restart,
        LeftCamera,
        RightCamera
    }

    private void Start()
    {
        iusables = FindObjectsOfType(typeof(IUsable)) as IUsable[];
        pauseAllActions();
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
            case BUTTONTYPE.LeftCamera:
                break;
            case BUTTONTYPE.RightCamera:
                break;

        }
    }


    public void pauseAllActions()
    {
        foreach(IUsable usable in iusables)
        {
            usable.Restart();
            usable.enabled = false;
        }
        
    }

    public void startAllActions()
    {
     // foreach
    }

    public void restart()
    {
        pauseAllActions();
    }
}