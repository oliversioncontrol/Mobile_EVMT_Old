using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnLocationEVMT.Views
{   
    public partial class ProjectImage : ContentView
    {
        public ProjectImage(Grid grid)
        {
            InitializeComponent();
            sname.Children.Add(grid);

        }
    }
}