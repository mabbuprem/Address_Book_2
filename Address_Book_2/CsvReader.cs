using System.Globalization;

namespace Address_Book_2
{
    internal class CsvReader
    {
        private StreamReader streamreader;
        private CultureInfo invariantCulture;

        public CsvReader(StreamReader streamreader, CultureInfo invariantCulture)
        {
            this.streamreader = streamreader;
            this.invariantCulture = invariantCulture;
        }

        internal object GetRecords<T>()
        {
            throw new NotImplementedException();
        }
    }
}