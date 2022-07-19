namespace WpfApplication.Models
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Base class for models.
    /// </summary>
    public abstract class ModelBase : INotifyPropertyChanged
    {
        /// <inheritdoc/>
        public virtual event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises PropertyChangedEvent.
        /// </summary>
        /// <param name="propertyName">Property which changed.</param>
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}