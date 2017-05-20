namespace ReactiveSearch.Services.State
{
    public static class StateKeys
    {
        public static string GetKeyForSearchQuery(string query) => string.Format("searchQuery-{0}", query);
    }
}