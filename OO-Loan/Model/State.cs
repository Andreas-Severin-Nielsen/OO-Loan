namespace OO_Loan
{
    public enum State
    {
        /// <summary>
        /// Available for loans
        /// </summary>
        Free,
        /// <summary>
        /// Unit is being loaned by a user
        /// </summary>
        Lended,
        /// <summary>
        /// Unit is reserved for maintenance
        /// </summary>
        Reserved
    }
}
