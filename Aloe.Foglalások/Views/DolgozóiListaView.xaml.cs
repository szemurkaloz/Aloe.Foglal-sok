namespace Aloe.Foglalások.Views
{
    using Catel.Windows;
    using ViewModels;

    /// <summary>
    /// Interaction logic for DolgozóiListaView.xaml.
    /// </summary>
    public partial class DolgozóiListaView : DataWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DolgozóiListaView"/> class.
        /// </summary>
        public DolgozóiListaView()
            : this(null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DolgozóiListaView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model to inject.</param>
        /// <remarks>
        /// This constructor can be used to use view-model injection.
        /// </remarks>
        public DolgozóiListaView(DolgozóiListaViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }
    }
}
