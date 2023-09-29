namespace $ext_safeprojectname$.Business.Common.Util
{
    public static class Helper
    {
        /// <summary>
        /// Creats Chunks based on the batch size and total records
        /// </summary>
        /// <param name="chunkCount">starting chunk value</param>
        /// <param name="batchSize">size of chunks to create</param>
        /// <param name="totalRecords">total records to process</param>
        /// <returns>Dictionary of start/stop for each chunk </returns>
        public static IDictionary<int, int> ProcessChunks(int chunkCount, int batchSize, int totalRecords)
        {
            var dict = new Dictionary<int, int>();
            while ((chunkCount + batchSize) < totalRecords)
            {
                dict.TryAdd(chunkCount, batchSize);
                chunkCount += batchSize;
            }
            dict.TryAdd(chunkCount, batchSize);

            return dict;
        }

        public static string FormatEasternTime(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz");
        }
    }
}
