namespace MyRepositories.UnitOfWork
{
    public class UnitOfWorkOptions
    {
        /// <summary>
        /// Default: true.
        /// </summary>
        public bool IsAutoTransactions { get; set; } = true;
        public bool IsAutoCommit { get; set; } = true;

        //public IsolationLevel? IsolationLevel { get; set; }
    }
}
