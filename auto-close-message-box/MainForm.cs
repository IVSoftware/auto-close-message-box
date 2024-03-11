namespace auto_close_message_box
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            buttonShow.Click += (sender, e) =>
            {
                var result = MessageBox.Show(
                    owner: new EphemeralParent(TimeSpan.FromSeconds(2.5)),
                    "Hello",
                    "Auto Close",
                    MessageBoxButtons.YesNoCancel);
                Text = result.ToString();
            };
        }
    }
    public class EphemeralParent : Form
    {
        public EphemeralParent(TimeSpan timeout)
        {
            _ = Handle;
            Task
                .Delay(timeout)
                .GetAwaiter()
                .OnCompleted(()=>Dispose());
        }
    }
}
