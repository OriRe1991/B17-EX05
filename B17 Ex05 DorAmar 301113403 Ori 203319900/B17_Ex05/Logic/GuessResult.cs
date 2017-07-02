namespace B17_Ex05
{
    public class GuessResult
    {
        // a symbol that appears in the same sequence location
        private int m_BulHits = 0;

        // a symbol that appears in the sequence but not in the same location
        private int m_PgiyaHits = 0;

        public int BulHits { get => m_BulHits; set => m_BulHits = value; }

        public int PgiyaHits { get => m_PgiyaHits; set => m_PgiyaHits = value; }
    }
}
