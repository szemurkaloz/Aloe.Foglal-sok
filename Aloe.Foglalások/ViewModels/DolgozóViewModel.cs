namespace Aloe.Foglalások.ViewModels
{
    using Catel.MVVM;
    using Models;
    using System.Threading.Tasks;
    using Catel.Data;

    public class DolgozóViewModel : ViewModelBase
    {
        public DolgozóViewModel(DolgozóDto dolgozó)
        {
            Dolgozó = dolgozó ?? new DolgozóDto();
            
            ToggleCustomError = new Command<object>(OnToggleCustomErrorExecute);
        }

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title
        {
            get { return "Dolgózói adatok"; }
        }

        #region Models
        /// <summary>
        /// Gets or sets the person model.
        /// </summary>
        [Model]
        [Catel.Fody.Expose("Név")]
        [Catel.Fody.Expose("Jelszó")]
        public DolgozóDto Dolgozó
        {
            get { return GetValue<DolgozóDto>(DolgozóProperty); }
            private set { SetValue(DolgozóProperty, value); }
        }

        /// <summary>
        /// Register the Person property so it is known in the class.
        /// </summary>
        public static readonly PropertyData DolgozóProperty = RegisterProperty("Dolgozó", typeof(DolgozóDto));
        #endregion

        #region View model
        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
       /* [ViewModelToModel("Person")]
        public Gender Gender
        {
            get { return GetValue<Gender>(GenderProperty); }
            set { SetValue(GenderProperty, value); }
        }

        /// <summary>
        /// Register the Gender property so it is known in the class.
        /// </summary>
        public static readonly PropertyData GenderProperty = RegisterProperty("Gender", typeof(Gender));*/

        ///// <summary>
        ///// Gets or sets the first name.
        ///// </summary>
        //[ViewModelToModel("Person")]
        //public string FirstName
        //{
        //    get { return GetValue<string>(FirstNameProperty); }
        //    set { SetValue(FirstNameProperty, value); }
        //}

        ///// <summary>
        ///// Register the FirstName property so it is known in the class.
        ///// </summary>
        //public static readonly PropertyData FirstNameProperty = RegisterProperty("FirstName", typeof(string));

        ///// <summary>
        ///// Gets or sets the middle name.
        ///// </summary>
        //[ViewModelToModel("Person")]
        //public string MiddleName
        //{
        //    get { return GetValue<string>(MiddleNameProperty); }
        //    set { SetValue(MiddleNameProperty, value); }
        //}

        ///// <summary>
        ///// Register the MiddleName property so it is known in the class.
        ///// </summary>
        //public static readonly PropertyData MiddleNameProperty = RegisterProperty("MiddleName", typeof(string));

        ///// <summary>
        ///// Gets or sets the last name.
        ///// </summary>
        //[ViewModelToModel("Person")]
        //public string LastName
        //{
        //    get { return GetValue<string>(LastNameProperty); }
        //    set { SetValue(LastNameProperty, value); }
        //}

        ///// <summary>
        ///// Register the LastName property so it is known in the class.
        ///// </summary>
        //public static readonly PropertyData LastNameProperty = RegisterProperty("LastName", typeof(string));

        /// <summary>
        /// Gets or sets the custom error.
        /// </summary>
        public string CustomError
        {
            get { return GetValue<string>(CustomErrorProperty); }
            set { SetValue(CustomErrorProperty, value); }
        }

        /// <summary>
        /// Register the CustomError property so it is known in the class.
        /// </summary>
        public static readonly PropertyData CustomErrorProperty = RegisterProperty("CustomError", typeof(string));

        /// <summary>
        /// Gets the custom defined property to test whether the ICustomTypeDescriptor for WPF works.
        /// </summary>
        public string CustomDefinedProperty { get { return "My Custom Defined Property"; } }
        #endregion

        #region Commands

        /// <summary>
        /// Gets the GenerateData command.
        /// </summary>
        public Command<object, object> GenerateData { get; private set; }

        /// <summary>
        /// Method to check whether the GenerateData command can be executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private bool OnGenerateDataCanExecute(object parameter)
        {
            // Note: normally you wouldn't use the ExposeAttribute if you need to access
            // the properties, but this is to show that all existing features (such as
            // INotifyPropertyChanged, IDataErrorInfo, etc also work with the ExposeAttribute).

            if (!string.IsNullOrEmpty(GetValue<string>("Név")))
            {
                return false;
            }

            if (!string.IsNullOrEmpty(GetValue<string>("Jelszó")))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the ToggleCustomError command.
        /// </summary>
        public Command<object> ToggleCustomError { get; private set; }

        /// <summary>
        /// Method to invoke when the ToggleCustomError command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnToggleCustomErrorExecute(object parameter)
        {
            if (string.IsNullOrEmpty(CustomError))
            {
                CustomError = "Error message 1";
            }
            else if (CustomError == "Error message 1")
            {
                CustomError = "Replaced error message, does tooltip update?";
            }
            else
            {
                CustomError = string.Empty;
            }
        }
        #endregion
        #endregion

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            // TODO: subscribe to events here
        }

        protected override async Task CloseAsync()
        {
            // TODO: unsubscribe from events here

            await base.CloseAsync();
        }
    }
    /// <summary>
    /// Design time version of the <see cref="DolgozóViewModel"/>.
    /// </summary>
    public class DesignPersonViewModel : DolgozóViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DesignPersonViewModel"/> class.
        /// </summary>
        public DesignPersonViewModel()
            : base(new DolgozóDto { Név = "Geert", Jelszó = "van" })
        {
        }
    }
}
