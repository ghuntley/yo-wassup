using System;

namespace ReactiveSearch.Features.AppShell
{
    public class AppShellMenuItem
    {
        public AppShellMenuItem()
        {
            TargetType = typeof(AppShellDetail);
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}