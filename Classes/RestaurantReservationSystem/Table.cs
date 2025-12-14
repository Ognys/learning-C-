namespace RestaurantReservationSystem;

public class Table
{
    public int Number { get; }
    public int Seats { get; }
    public bool IsVip { get; private set;}
    public Location Location { get; private set;}
    public bool IsActive { get; private set;} = true;

    public Table(int number, int seats)
    {
        Number = number <= 0 ? throw new ArgumentOutOfRangeException("Значение не может быть меньше или равно 0", nameof(number)) : number;
        Seats = seats <= 0 ? throw new ArgumentOutOfRangeException("Значение не может быть меньше или равно 0", nameof(seats)) : seats;
    }

    public void UpdateVipStatus(bool status) => IsVip = status;

    public void SetLocation(Location location) => Location = location;

    public void SetActive(bool active) => IsActive = active;

}

public enum Location
{
    Hall,
    Terrace
}