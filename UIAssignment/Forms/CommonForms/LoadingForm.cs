using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIAssignment.Forms.CommonForms
{
    public partial class LoadingForm : ChildForm
    {
        public LoadingForm()
        {
            InitializeComponent();
            // Create a new thread to perform a task
            Thread taskThread = new Thread(setUpImage);

            // Start the thread
            taskThread.Start();
        }

        private void setUpImage()
        {
            pictureBox2.Image = Image.FromFile("../../Resources/hourglassLoadingScreen.gif");
        }

        public override bool UnsavedChangesDetected()
        {
            return false;
        }
    }
}
