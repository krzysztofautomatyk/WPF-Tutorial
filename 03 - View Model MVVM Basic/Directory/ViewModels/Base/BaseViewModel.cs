using PropertyChanged;
using System.ComponentModel;

namespace _03___View_Model_MVVM_Basic
{

    /// <summary>
    /// A base view model that fires Property Changed event as needed
    /// </summary>
    //[ImplementPropertyChanged]
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = ( sender, e ) => {};
    }
}