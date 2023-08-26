using System;
using System.Windows.Forms;

namespace UIAssignment
{
    public class ChildForm : Form
    {
        public virtual bool UnsavedChangesDetected() { throw new NotImplementedException();}
    }
}
