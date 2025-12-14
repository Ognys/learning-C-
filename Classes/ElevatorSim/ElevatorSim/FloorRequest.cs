namespace ElevatorSim;

public class FloorRequest
{
    public int FromFloor { get; set; }
    public int ToFloor { get; set; }
    public DateTime RequesteDate { get; set; }

    public FloorRequest(int fromFloor, int toFloor)
    {
        FromFloor = fromFloor;
        ToFloor = toFloor;
        RequesteDate = DateTime.Now;
    }
}