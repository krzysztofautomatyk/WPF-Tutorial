using _03___View_Model_MVVM_Basic.Directory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03___View_Model_MVVM_Basic
{
    /// <summary>
    /// The view model for the applications main Directory view
    /// </summary>
    public class DirectoryStructureViewModel 
    {
        #region Public Properties
        /// <summary>
        /// A list of all directories on the machine
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }
        #endregion

        #region Constructor 
        /// <summary>
        /// Default constructor
        /// </summary>
        public DirectoryStructureViewModel()
        {
            // Get the logical drivers
            var children = DirectoryStructure.GetLogicalDrives();

            // Create the view models form the data
            this.Items = new ObservableCollection<DirectoryItemViewModel>(
                children.Select(drive => new DirectoryItemViewModel(drive.FullPath, DirectoryItemType.Drive)));

        }
        #endregion
    }
}
