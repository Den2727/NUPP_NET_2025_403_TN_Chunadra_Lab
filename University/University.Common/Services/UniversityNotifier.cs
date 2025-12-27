using System;

namespace University.Common.Services
{
    public delegate void UniversityEventHandler(string message);

    public static class UniversityNotifier
    {
        public static event UniversityEventHandler OnEvent;

        public static void Notify(string message)
        {
            OnEvent?.Invoke(message);
        }
    }
}
