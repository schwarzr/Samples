namespace GlobalAzure.RestContract.Database
{
    public class DoToEntry
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime? Completed { get; set; }
    }
}