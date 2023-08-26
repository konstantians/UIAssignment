namespace UIAssignment.Forms.CommonForms
{
    public partial class MainForm : ChildForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public override bool UnsavedChangesDetected()
        {
            return false;
        }
            
    }
}
