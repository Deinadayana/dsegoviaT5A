using dsegoviaS5A.Utils;

namespace dsegoviaS5A
{
    public partial class App : Application
    {
        public static PersonRepository PersonRepo { get; private set; }

        public App(PersonRepository personRepository)
        {
            InitializeComponent();
            PersonRepo = personRepository;
            MainPage = new Views.Principal();
        }
    }
}

