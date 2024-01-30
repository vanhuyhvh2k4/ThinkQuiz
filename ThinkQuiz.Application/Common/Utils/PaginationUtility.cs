namespace ThinkQuiz.Application.Common.Utils
{
    public static class PaginationUtility
	{
		public static List<T> PaginateList<T>(List<T> items, int page, int perPage)
		{
            int startIndex = (page - 1) * perPage;
            int endIndex = startIndex + perPage;

            if (startIndex < 0 || startIndex >= items.Count || page <= 0)
                return new List<T>();

            if (endIndex > items.Count)
                endIndex = items.Count;

            return items.GetRange(startIndex, endIndex - startIndex);
        }
	}
}

