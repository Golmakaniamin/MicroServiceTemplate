namespace Mabna.MicroService.Domain.Instrument;

public class Instrument
{
    public Instrument(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }

}
