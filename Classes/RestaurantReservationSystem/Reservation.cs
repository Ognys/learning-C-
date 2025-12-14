namespace RestaurantReservationSystem;

public class Reservation
{
    public Guid Id { get;  } = Guid.NewGuid();
    public Table Table { get;  }

    public string CustomerName { get;  }
    public DateTime Start {get; }
    public TimeSpan Duration { get; }
    public int GuestsCount { get; }

    public ReservationStatus Status { get; private set; }

    public Reservation(Table table, string customerName, DateTime start, TimeSpan duration, int guestsCount)
    {

        Table = table ?? throw new ArgumentNullException(nameof(table),"Значение table не может быть пустым");
        CustomerName = string.IsNullOrEmpty(customerName) ? throw new ArgumentException("Имя клиента не может быть пустым", nameof(customerName)) : customerName;
        GuestsCount = guestsCount <= 0 ? throw new ArgumentException("Значение не может быть меньше или равно нулю", nameof(guestsCount)) : guestsCount;

        Start = start;
        Duration = duration;
        Status = ReservationStatus.Pending;
    }

    public void Confirm()
    {
        if(Status != ReservationStatus.Pending)
            throw new InvalidOperationException("Бронирование можно подтвердить только из статуса Pending");

        Status = ReservationStatus.Confirmed;
    }

    public void Cancel()
    {
        if(Status == ReservationStatus.Cancelled)
            throw new InvalidOperationException("Бронирование можно отменить только из статуса Pending или Confirmed");
        
        Status = ReservationStatus.Cancelled;
    }
}


public enum ReservationStatus
{
    Pending,
    Confirmed,
    Cancelled
}