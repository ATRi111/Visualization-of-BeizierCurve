using Services;

public class Button_LaunchOrReset : ButtonBase
{
    private bool isRunning;
    public bool IsRunning
    {
        get => isRunning;
        set
        {
            if (isRunning != value)
            {
                isRunning = value;
                if(value)
                {
                    eventSystem.Invoke(EEvent.AfterLaunch);
                    tmp.text = "÷ÿ÷√";
                }
                else
                {
                    eventSystem.Invoke(EEvent.AfterReset);
                    tmp.text = "∆Ù∂Ø";
                }
            }
        }
    }

    protected override void Awake()
    {
        base.Awake();
        isRunning = true;
        IsRunning = false;
    }

    protected override void OnClick()
    {
        IsRunning = !IsRunning;
    }
}
