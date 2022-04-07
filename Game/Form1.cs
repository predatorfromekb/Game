using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            var model = new Model.Model();
            var label = new Label()
            {
                Width = 400,
                Text = "Clicks Count: " + model.Counter
            };
            var button = new Button();
            button.Width = 400;
            button.Height = 100;
            button.Top = label.Bottom;
            button.Text = "Increment";
            button.Click += (sender, args) =>
            {
                model.Increment();
                Invalidate();
            };
            Controls.Add(button);
            Controls.Add(label);
            Paint += (sender, args) =>
            {
                label.Text = "Clicks Count: " + model.Counter;
            };
            InitializeComponent();
        }
    }
}