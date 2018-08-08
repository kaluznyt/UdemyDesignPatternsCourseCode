namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Observer
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using UdemyDesignPatternsCourse.Annotations;

    public class Market : INotifyPropertyChanged
    {
        private float volatility;

        public float Volatility
        {
            get => this.volatility;
            set
            {
                if (value.Equals(this.volatility)) return;
                this.volatility = value;
                this.OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}