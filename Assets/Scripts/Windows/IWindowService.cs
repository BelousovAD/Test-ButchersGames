namespace Windows
{
    public interface IWindowService
    {
        public void CloseCurrent();

        public void Open(string id, int countToClose);
    }
}