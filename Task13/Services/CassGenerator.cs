namespace Task13
{
    internal class CassGenerator : ICassGenerator
    {
        private List<Cassa> casses;
        private int coordinate_Y = default;

        public CassGenerator()
        {
            casses = new();
        }

        public List<Cassa> GenerateCasses(int count)
        {
            if (count <= 0) throw new ArgumentException("cass count most be upper than 0");

            for (int i = 0; i < count; i++)
            {
                casses.Add(new Cassa(GenerateCoordinate(), ++Constants.cassNumber));
            }

            return casses;
        }

        private double GenerateCoordinate()
        {
            return double.Parse($"{Constants.defaultCassaCordinate_X},{++coordinate_Y}");
        }
    }
}
