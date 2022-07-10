namespace Task13;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            Simulator simulator = new(new CassGenerator(), new PersonGenerator());

            simulator.QueueOverflowEvent += Interviewer.ReprofilToSpecificStatus;
            simulator.CloseQueueEvent += Interviewer.IsCloseCase;

            simulator.Cordinate(default, default, new WriterTinnedPersons());
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ups exception" + ex.Message);
        }

        Console.ReadLine();
    }
}
