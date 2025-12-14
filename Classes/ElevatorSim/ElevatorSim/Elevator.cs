namespace ElevatorSim;

public class Elevator
{
    public int CurrentFloor { get; private set; }
    public int MinFloor { get; }
    public int MaxFloor { get; }
    public bool IsDoorOpen { get; private set; } = false;
    public ElevatorState State { get; private set; } = ElevatorState.Idle;
    public bool HasPassengers { get; private set; }
    private readonly Queue<FloorRequest> _requests = new();

    public Elevator(int minFloor, int maxFloor, int initialFloor)
    {
        if (minFloor >= maxFloor)
            throw new ArgumentOutOfRangeException(nameof(minFloor), "Минимальный этаж должен быть меньше максимального");

        MaxFloor = maxFloor;
        MinFloor = minFloor;

        CurrentFloor = initialFloor >= MinFloor && initialFloor <= MaxFloor ? initialFloor : throw new ArgumentOutOfRangeException(nameof(initialFloor), "Недопустимое значение");

    }


    public void Call(int fromFloor, int toFloor)
    {
        if (!(fromFloor >= MinFloor && fromFloor <= MaxFloor))
            throw new ArgumentOutOfRangeException(nameof(fromFloor), "Этаж с которого происходит вызов должен находится в диапазоне [min,max]");

        if (!(toFloor >= MinFloor && toFloor <= MaxFloor))
            throw new ArgumentOutOfRangeException(nameof(toFloor), "Этаж на который происходит вызов должен находится в диапазоне [min,max]");

        if (fromFloor == toFloor)
            throw new ArgumentOutOfRangeException(nameof(fromFloor), "Недопустимый вызов");

        _requests.Enqueue(new FloorRequest(fromFloor, toFloor));

    }

    public void Step()
    {
        if (_requests.Count == 0)
        {
            State = ElevatorState.Idle;
            return;
        }

        var request = _requests.Peek();

        if (HasPassengers)
        {
            if (request.ToFloor < CurrentFloor)
            {
                State = ElevatorState.MovingDown;
                CurrentFloor--;
            }
            else if (request.ToFloor > CurrentFloor)
            {
                State = ElevatorState.MovingUp;
                CurrentFloor++;
            }
            else
            {
                State = ElevatorState.Idle;
                IsDoorOpen = true;
                HasPassengers = false;
                _requests.Dequeue();

            }
        }
        else
        {
            if (request.FromFloor < CurrentFloor)
            {
                State = ElevatorState.MovingDown;
                CurrentFloor--;
            }
            else if (request.FromFloor > CurrentFloor)
            {
                State = ElevatorState.MovingUp;
                CurrentFloor++;
            }
            else
            {
                State = ElevatorState.Idle;
                IsDoorOpen = true;
                HasPassengers = true;
            }
        }

        if(State == ElevatorState.MovingUp || State == ElevatorState.MovingDown)
            IsDoorOpen = false;
    }
}