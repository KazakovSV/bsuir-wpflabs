namespace Lab01
{
    public abstract class CalculatorState
    {
        public virtual void Read(Calculator calculator, string character)
        {
            ChangeState(calculator, character);
        }

        protected abstract void ChangeState(Calculator calculator, string character);
    }
}