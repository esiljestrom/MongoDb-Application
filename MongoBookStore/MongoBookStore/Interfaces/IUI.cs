namespace MongoBookStore.Interfaces
{
    internal interface IUI
    {
        public void Print(string text);
        public void PrintLine(string text);
        public string GetInput();
        public void PressToContinue();
        public void Delay(int seconds);
        public void Clear();
        public void Exit();
    }
}
