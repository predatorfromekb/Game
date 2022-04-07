namespace Game.Model
{
    public class Model
    {
        public int Counter { get; private set; }

        public void Increment()
        {
            Counter += 2;
        }
    }
}