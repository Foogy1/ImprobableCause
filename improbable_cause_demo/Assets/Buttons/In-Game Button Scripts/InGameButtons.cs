using UnityEngine;
using UnityEngine.UI;

public class InGameButtons : MonoBehaviour
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
        Time.timeScale = 0;
    }

    public void startAllActions()
    {
        Time.timeScale = 1;
    }

    public void restart()
    {
        foreach (IUsable usable in iusables)
        {
            usable.restart();
        }
    }
}