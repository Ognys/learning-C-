using ElevatorSim;

var elevator = new Elevator(minFloor: 1, maxFloor: 10, initialFloor: 1);

elevator.Call(1, 5);
elevator.Call(3, 8);

for (int i = 0; i < 30; i++)
{
    Console.WriteLine(
        $"Step {i:00} | Floor: {elevator.CurrentFloor} | State: {elevator.State} | Door: {(elevator.IsDoorOpen ? "Open" : "Closed")} | HasPassengers: {elevator.HasPassengers}");
    
    elevator.Step();
}

Console.WriteLine("Done");
