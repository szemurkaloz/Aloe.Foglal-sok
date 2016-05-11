namespace Aloe.Foglalások.ViewModels
{
    using Catel.Data;
    using Catel.IoC;
    using Catel.MVVM;
    using Models;
    using Models.Repository;
    using MongoDB.Driver;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Catel.Logging;
    using System.Diagnostics;
    public class DolgozóiListaViewModel : ViewModelBase
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        public DolgozóiListaViewModel()
        {
            
        }

        #region Properties

        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return "Dolgozók listája"; } }

        /// <summary>
        /// Gets the collection of Persons.
        /// </summary>
        public ObservableCollection<Dolgozo> DolgozoCollection
        {
            get { return GetValue<ObservableCollection<Dolgozo>>(DolgozoCollectionProperty); }
            set { SetValue(DolgozoCollectionProperty, value); }
        }

        /// <summary>
        /// Register the PersonCollection property so it is known in the class.
        /// </summary>
        public static readonly PropertyData DolgozoCollectionProperty = RegisterProperty("DolgozoCollection", typeof(ObservableCollection<Dolgozo>));

        /// <summary>
        /// Gets or sets the selected person.
        /// </summary>
        public Dolgozo SelectedPerson
        {
            get { return GetValue<Dolgozo>(SelectedDolgozoProperty); }
            set { SetValue(SelectedDolgozoProperty, value); }
        }

        /// <summary>
        /// Register the SelectedPerson property so it is known in the class.
        /// </summary>
        public static readonly PropertyData SelectedDolgozoProperty = RegisterProperty("SelectedDolgozoProperty", typeof(Dolgozo), null);

        #endregion Properties
        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            var url = ServiceLocator.Default.ResolveType<MongoUrl>();
            DolgozoRepository dolgozoRepo = new DolgozoRepository(url);
            DolgozoCollection = new ObservableCollection<Dolgozo>(dolgozoRepo.All());

            Log.Info(string.Format("Dolgozók száma: {0}", DolgozoCollection.Count));

            Add = new TaskCommand(OnAddExecuteAsync);
            // TODO: subscribe to events here
        }

        protected override async Task CloseAsync()
        {
            // TODO: unsubscribe from events here

            await base.CloseAsync();
        }

        #region Commands
        /// <summary>
        /// Gets the Add command.
        /// </summary>
        public TaskCommand Add { get; private set; }

        /// <summary>
        /// Method to invoke when the Add command is executed.
        /// </summary>
        private async Task OnAddExecuteAsync()
        {
           /* var viewModel = new PersonViewModel(new Person());
            if (await _uiVisualizerService.ShowDialogAsync(viewModel) ?? false)
            {
                PersonCollection.Add(viewModel.Person);
            }*/
        }

        #endregion Commands
    }
}
