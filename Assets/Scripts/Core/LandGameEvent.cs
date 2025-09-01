using System;

public class LandGameEvent : GameEvent {}

public class LandSelectedGameEvent : LandGameEvent
{
    public Land Land { get; set; }
    public Action<Land> OnLandSelected { get; set; }

    public LandSelectedGameEvent(Land land, Action<Land> onLandSelected)
    {
        Land = land;
        OnLandSelected = onLandSelected;
    }
}
