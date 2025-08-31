public class LandGameEvent : GameEvent {}

public class LandSelectedGameEvent : LandGameEvent
{
    public Land Land { get; set; }
    public LandSelectedGameEvent(Land land)
    {
        Land = land;
    }
}
