using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zabawki
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            toyTypeCombo.Items.Add(Toys.BOAT);
            toyTypeCombo.Items.Add(Toys.CAR);
            toyTypeCombo.Items.Add(Toys.PLANE);
            toyTypeCombo.Items.Add(Toys.STONE);
            toyTypeCombo.Items.Add(Toys.AMFIBIA);
            toyTypeCombo.SelectedIndex = 0;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Toys toy = (Toys)toyTypeCombo.SelectedItem;
            switch (toy)
            {
                case Toys.BOAT:
                    toyInstanceCombo.Items.Add(new Boat());
                    break;

                case Toys.CAR:
                    toyInstanceCombo.Items.Add(new Car());
                    break;

                case Toys.PLANE:
                    toyInstanceCombo.Items.Add(new Plane());
                    break;

                case Toys.STONE:
                    toyInstanceCombo.Items.Add(new Stone());
                    break;

                case Toys.AMFIBIA:
                    toyInstanceCombo.Items.Add(new Amfibia());
                    break;

                default:

                    break;
            }
        }

        private void toyInstanceCombo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            controlsPanel.Controls.Clear();
            object toy = toyInstanceCombo.SelectedItem;
            //to wbrew mojej godności   
            if (toy is IAccelerate)
            {
                IAccelerate accelerator = toy as IAccelerate;
                Label propertyLabel = new Label();
                propertyLabel.Text = "przyśpieszenie";
                NumericUpDown propertySpinner = new NumericUpDown();
                propertySpinner.Value = accelerator.speed;
                propertySpinner.ValueChanged += new EventHandler(delegate (Object o, EventArgs a)
                {
                    accelerator.Accelerate(Convert.ToInt32(propertySpinner.Value));
                });
                controlsPanel.Controls.Add(propertyLabel);
                controlsPanel.Controls.Add(propertySpinner);
                
            }

            if (toy is IDive)
            {
               
                IDive diver = toy as IDive;
                Label propertyLabel = new Label();
                propertyLabel.Text = "zanurzenie";
                NumericUpDown propertySpinner = new NumericUpDown();
                propertySpinner.Value = diver.submersion;
                propertySpinner.ValueChanged += new EventHandler(delegate (Object o, EventArgs a)
                {
                    diver.Dive(Convert.ToInt32(propertySpinner.Value));
                });
                controlsPanel.Controls.Add(propertyLabel);
                controlsPanel.Controls.Add(propertySpinner);

            }

            if (toy is IRise) 
            {
                IRise riser = toy as IRise;
                NumericUpDown propertySpinner = new NumericUpDown();
                Label propertyLabel = new Label();
                propertyLabel.Text = "wzniesienie";
                propertySpinner.Value = riser.altitude;
                propertySpinner.ValueChanged += new EventHandler(delegate (Object o, EventArgs a)
                {
                    riser.Rise(Convert.ToInt32(propertySpinner.Value));
                });
                controlsPanel.Controls.Add(propertyLabel);
                controlsPanel.Controls.Add(propertySpinner);
            }
          
        }

    }

}
