namespace RestaurantReservationSystem;

public class Restaurant
{
    private readonly List<Table> _tables = new();
    private readonly List<Reservation> _reservations = new();

    public IReadOnlyList<Table> Tables => _tables;
    public IReadOnlyList<Reservation> Reservations => _reservations;


    public void AddTable(int number, int seats) => _tables.Add(new Table(number, seats));
    public void RemoveTable(int number) => _tables.RemoveAll(t => t.Number == number);

    public Reservation BookTable(string customerName, int guestsCount, DateTime start, TimeSpan duration, bool vipOnly)
    {
        if (start < DateTime.Now.AddHours(1))
            throw new ArgumentOutOfRangeException(nameof(start), "Недоступное время для бронирования");

        for (int i = 0; i < _tables.Count; i++)
        {
            bool availFlag = true;
            bool tableInRes = false;

            if (_tables[i].Seats >= guestsCount && (!vipOnly || _tables[i].IsVip))
            {
                for (int j = 0; j < _reservations.Count; j++)
                {
                    if (_reservations[j].Status == ReservationStatus.Cancelled)
                        continue;

                    if (_reservations[j].Table.Number == _tables[i].Number)
                    {
                        tableInRes = true;
                        if (!(_reservations[j].Start + _reservations[j].Duration < start || start + duration < _reservations[j].Start))
                        {
                            availFlag = false;
                            break;
                        }
                            
                    }
                }

                if (availFlag || !tableInRes)
                {
                    _reservations.Add(new Reservation(_tables[i], customerName, start, duration, guestsCount));
                    return _reservations[^1];
                }
            }

        }

        throw new ArgumentException("Недоступные значения");

    }
}