using System;

namespace Tests
{
    internal class SqlCommand
    {
        public string CommandText { get; internal set; }

        internal void ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }
    }
}